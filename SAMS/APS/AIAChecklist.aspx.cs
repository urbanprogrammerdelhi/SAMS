using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using AjaxControlToolkit;
using System.Drawing;
using System.Text;
using System.Web.UI.HtmlControls;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Configuration;
using System.Data.SqlClient;

public partial class SAMS_AIAChecklist : BasePage
{
    static int flag;
    static int dtflag;
    static int dtflag1;
    static string HF1 = "";
    static string HF2 = "";
    static string Client = "";
    #region Properties

    /// <summary>
    /// Returns User Read Rights.
    /// </summary>
    /// <value><c>true</c> if this instance is read access; otherwise, <c>false</c>.</value>
    /// <exception cref="System.Exception">Have not Rights</exception>

    private bool IsReadAccess
    {
        get
        {
            try
            {
                int VirtualDirNameLenght = 0;
                VirtualDirNameLenght = int.Parse(System.Web.HttpContext.Current.Request.Url.AbsolutePath.IndexOf(@"/", 1).ToString());
                return IsReadAllowed(System.Web.HttpContext.Current.Request.Url.AbsolutePath.Remove(0, VirtualDirNameLenght));
            }
            catch (Exception ex)
            { throw new Exception("Have not Rights", ex); }
        }
    }

    /// <summary>
    /// Returns User Write Rights.
    /// </summary>
    /// <value><c>true</c> if this instance is write access; otherwise, <c>false</c>.</value>
    /// <exception cref="System.Exception">Have not Rights</exception>
    private bool IsWriteAccess
    {
        get
        {
            try
            {
                int VirtualDirNameLenght = 0;
                VirtualDirNameLenght = int.Parse(System.Web.HttpContext.Current.Request.Url.AbsolutePath.IndexOf(@"/", 1).ToString());
                return IsWriteAllowed(System.Web.HttpContext.Current.Request.Url.AbsolutePath.Remove(0, VirtualDirNameLenght));
            }
            catch (Exception ex)
            { throw new Exception("Have not Rights", ex); }
        }
    }

    /// <summary>
    /// Returns User Modify Rights.
    /// </summary>
    /// <value><c>true</c> if this instance is modify access; otherwise, <c>false</c>.</value>
    /// <exception cref="System.Exception">Have not Rights</exception>
    private bool IsModifyAccess
    {
        get
        {
            try
            {
                int VirtualDirNameLenght = 0;
                VirtualDirNameLenght = int.Parse(System.Web.HttpContext.Current.Request.Url.AbsolutePath.IndexOf(@"/", 1).ToString());
                return IsModifyAllowed(System.Web.HttpContext.Current.Request.Url.AbsolutePath.Remove(0, VirtualDirNameLenght));
            }
            catch (Exception ex)
            { throw new Exception("Have not Rights", ex); }
        }
    }

    /// <summary>
    /// Returns User Delete Rights.
    /// </summary>
    /// <value><c>true</c> if this instance is delete access; otherwise, <c>false</c>.</value>
    /// <exception cref="System.Exception">Have not Rights</exception>
    private bool IsDeleteAccess
    {
        get
        {
            try
            {
                int VirtualDirNameLenght = 0;
                VirtualDirNameLenght = int.Parse(System.Web.HttpContext.Current.Request.Url.AbsolutePath.IndexOf(@"/", 1).ToString());
                return IsDeleteAllowed(System.Web.HttpContext.Current.Request.Url.AbsolutePath.Remove(0, VirtualDirNameLenght));
            }
            catch (Exception ex)
            { throw new Exception("Have not Rights", ex); }
        }
    }

    #endregion
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            txtDutyDate.Attributes.Add("readonly", "readonly");
            txtDutyDate.Text = DateTime.Now.ToString("dd-MMM-yyyy");
            gvAttendence.Visible = true;
            if (IsReadAccess == true)
            {
                //  FillddlAreaID();
                FillddlClientCode();
                //FillAsmtId();
                System.Web.UI.ScriptManager ToolkitScriptManager1 = (System.Web.UI.ScriptManager)Master.FindControl("ToolkitScriptManager1");
                ToolkitScriptManager1.SetFocus(ddlClientCode);
            }
            else
            {
                Response.Redirect("../UserManagement/Home.aspx");
            }
            FillgvAttendence();
        }
    }
    protected void FillddlClientCode()
    {
        DataSet ds = new DataSet();
        BL.Sales objsales = new BL.Sales();

        ds = objsales.GetClientDetailsTATAChecklist(BaseLocationAutoID,txtDutyDate.Text);

        if (ds != null)
        {
            if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                ddlClientCode.DataSource = ds.Tables[0];
                ddlClientCode.DataTextField = "ClientCodeName";
                ddlClientCode.DataValueField = "ClientCode";
                ddlClientCode.DataBind();
                if (Request.QueryString["ClientCode"] != null)
                {
                    ddlClientCode.SelectedIndex = ddlClientCode.Items.IndexOf(ddlClientCode.Items.FindByValue(Request.QueryString["ClientCode"].ToString()));
                }
              //  ddlClientCode.Items.Insert(0, new ListItem("All", "All"));

            }
            else
            {
                ddlClientCode.Items.Clear();
                ListItem li = new ListItem();
                li.Text = "No Branch Available !!";
                li.Value = "0";
                ddlClientCode.Items.Add(li);
            }
        }
        else
        {
            ddlClientCode.Items.Clear();
            ListItem li = new ListItem();
            li.Text = "No Branch Available !!";
            li.Value = "0";
            ddlClientCode.Items.Add(li);
        }
    }
    protected void FillgvAttendence()
    {
        divGV.Visible = true; ;
        var objAssetMgmt = new BL.Sales();
        var ds = new DataSet();
        var dt = new DataTable();
        var dtflag = 1;
        ds = objAssetMgmt.GetChecklistReport(BaseLocationAutoID, ddlClientCode.SelectedItem.Value, txtDutyDate.Text.Trim(),ddlChecklistHeader.SelectedItem.Value);
        dt = ds.Tables[0];

        if (dt.Rows.Count == 0)
        {
            dtflag = 0;
            dt.Rows.Add(dt.NewRow());
        }
      
        gvAttendence.DataSource = dt;
        gvAttendence.DataBind();

        
        if (dtflag == 0)
        {
            gvAttendence.Rows[0].Visible = false;
          
            lblmsg.Visible = true;
        }
        else
        {
         //   btnExport.Visible = true;
            lblmsg.Visible = false;
        }
    }
    public override void VerifyRenderingInServerForm(Control control)
    {
        // controller   
    }
    protected void btnView_Click(object sender, EventArgs e)
    {
        FillgvAttendence();
    }
    protected void gvAttendence_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        GridViewRow objGridViewRow = e.Row;
        Label lblSerialNo = (Label)objGridViewRow.FindControl("lblSerialNo");
        if (lblSerialNo != null)
        {
            int serialNo = gvAttendence.PageIndex * gvAttendence.PageSize + int.Parse(objGridViewRow.RowIndex.ToString());
            lblSerialNo.Text = Convert.ToString((serialNo + 1));
        }
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            Label lblEmployeeNumber = (Label)e.Row.FindControl("lblEmployeeNumber");
            lblEmployeeNumber.ForeColor = System.Drawing.Color.Black;
            lblEmployeeNumber.Font.Bold = true;
            Label lblSerialNo1 = (Label)e.Row.FindControl("lblSerialNo");
            lblSerialNo1.ForeColor = System.Drawing.Color.Black;
            lblSerialNo1.Font.Bold = true;
           
          
            Label lblbranchname = (Label)e.Row.FindControl("lblbranchname");
            lblbranchname.ForeColor = System.Drawing.Color.Black;
            lblbranchname.Font.Bold = true;
            Label lblEmployeeRemarks = (Label)e.Row.FindControl("lblEmployeeRemarks");
            lblEmployeeRemarks.ForeColor = System.Drawing.Color.Black;
            lblEmployeeRemarks.Font.Bold = true;
            Label lblEmployeeNameHeader = (Label)e.Row.FindControl("lblEmployeeNameHeader");
            lblEmployeeNameHeader.ForeColor = System.Drawing.Color.Black;
            lblEmployeeNameHeader.Font.Bold = true;
            Label lblDate = (Label)e.Row.FindControl("lblDate");
            lblDate.ForeColor = System.Drawing.Color.Black;
            lblDate.Font.Bold = true;
            Label lblTime = (Label)e.Row.FindControl("lblTime");
            lblTime.ForeColor = System.Drawing.Color.Black;
            lblTime.Font.Bold = true;

            Label lblEmployeeName = (Label)e.Row.FindControl("lblEmployeeName");
            if (lblEmployeeName.Text == "No")
            {
                lblEmployeeName.ForeColor = System.Drawing.Color.Red;
                lblEmployeeName.Font.Bold = true;
            }
            else
            {
                lblEmployeeName.ForeColor = System.Drawing.Color.Green;
                lblEmployeeName.Font.Bold = true;
            }

        }
    }
    protected void gvAttendence_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvAttendence.PageIndex = e.NewPageIndex;
        gvAttendence.EditIndex = -1;
        FillgvAttendence();
    }
    protected void btnExport_Click(object sender, EventArgs e)
    {
        Response.Clear();
        Response.Buffer = true;
        Response.AddHeader("content-disposition", "attachment;filename=ChecklistReport-" + ddlClientCode.SelectedItem.Value +"-" + txtDutyDate.Text + ".xls");
        Response.Charset = "";
        Response.ContentType = "application/vnd.ms-excel";
        using (StringWriter sw = new StringWriter())
        {
            HtmlTextWriter hw = new HtmlTextWriter(sw);

            //To Export all pages
            gvAttendence.AllowPaging = false;
            FillgvAttendence();
            gvAttendence.Columns[0].Visible = false;

            gvAttendence.HeaderRow.BackColor = Color.White;
            foreach (TableCell cell in gvAttendence.HeaderRow.Cells)
            {
                cell.BackColor = gvAttendence.HeaderStyle.BackColor;
            }
            foreach (GridViewRow row in gvAttendence.Rows)
            {
                row.BackColor = Color.White;
                foreach (TableCell cell in row.Cells)
                {
                    if (row.RowIndex % 2 == 0)
                    {
                        cell.BackColor = gvAttendence.AlternatingRowStyle.BackColor;
                    }
                    else
                    {
                        cell.BackColor = gvAttendence.RowStyle.BackColor;
                    }
                    cell.CssClass = "textmode";
                }
            }
            gvAttendence.RenderControl(hw);
            //style to format numbers to string
            string style = @"<style> .textmode { } </style>";
            Response.Write(style);
            Response.Output.Write(sw.ToString());
            Response.Flush();
            Response.End();
        }
    }
    protected void txtDutyDate_TextChanged(object sender, EventArgs e)
    {
        divGV.Visible = false;
        FillddlClientCode();
    }
    protected void ddlClientCode_SelectedIndexChanged(object sender, EventArgs e)
    {
        FillgvAttendence();
    }
    protected void lblimage_Click(object sender, EventArgs e)
    {
        pnlTaskImage.Visible = true;
        divGV.Visible = false;
        LinkButton objLinkButton = (LinkButton)sender;
        GridViewRow row = (GridViewRow)objLinkButton.NamingContainer;
        HiddenField hfid1 = (HiddenField)gvAttendence.Rows[row.RowIndex].FindControl("hfid1");
        HiddenField hfid2 = (HiddenField)gvAttendence.Rows[row.RowIndex].FindControl("hfid2");
        Label lblbranchname = (Label)gvAttendence.Rows[row.RowIndex].FindControl("lblbranchname");
        HF1 = hfid1.Value;
        HF2 = hfid2.Value;
        Client = lblbranchname.Text;     
        FillgvImage(HF1,HF2,Client);
    }
    protected void FillgvImage(string HF1, string HF2, string Client)
    {
        var objsales = new BL.Sales();
        var ds = new DataSet();
        var dt = new DataTable();
        dtflag = 1;
        ds = objsales.GetChecklistImage(BaseLocationAutoID, HF1.ToString(), HF2.ToString(), Client.ToString(),txtDutyDate.Text);
        dt = ds.Tables[0];

        if (dt.Rows.Count == 0)
        {
            dtflag = 0;
            dt.Rows.Add(dt.NewRow());
        }

        DataColumn dc = new DataColumn("ImageBase64String", typeof(System.String));
        ds.Tables[0].Columns.Add(dc);
        for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
        {
            if (ds.Tables[0].Rows[i]["ItemImage"].ToString() != "")
            {
                ds.Tables[0].Rows[i]["ImageBase64String"] = "data:image/jpeg;base64," + Convert.ToBase64String(((byte[])((object)ds.Tables[0].Rows[i]["ItemImage"])), 0, ((byte[])((object)ds.Tables[0].Rows[i]["ItemImage"])).Length);
            }
            else
            {
                ds.Tables[0].Rows[i]["ImageBase64String"] = string.Empty;
            }
        }

        gvImage.DataSource = dt;
        gvImage.DataBind();

        if (dtflag == 0)//to fix empety gridview
        {
            gvImage.Rows[0].Visible = false;
        }
    }
    protected void gvImage_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvImage.PageIndex = e.NewPageIndex;
        gvImage.EditIndex = -1;
        FillgvImage(HF1, HF2, Client);
    }
    protected void btnbacktaskList_Click(object sender, EventArgs e)
    {
        pnlTaskImage.Visible = false;
        divGV.Visible = true;
    }
    protected void ddlChecklistHeader_SelectedIndexChanged(object sender, EventArgs e)
    {
        FillgvAttendence();
    }
}