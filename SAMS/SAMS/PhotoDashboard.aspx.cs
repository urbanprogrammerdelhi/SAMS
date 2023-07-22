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
public partial class SAMS_PhotoDashboard : BasePage
{
    static int flag;
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

    #region Page Functions
    /// <summary>
    /// Handles the Load event of the Page control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            //Page Title from resource file
            //System.Text.StringBuilder javaScript = new System.Text.StringBuilder();
            //javaScript.Append("<script type='text/javascript'>");
            //javaScript.Append("window.document.body.onload = function ()");
            //javaScript.Append("{\n");
            //javaScript.Append("PageTitle('" + Resources.Resource.SaleOrder + "');");
            //javaScript.Append("};\n");
            //javaScript.Append("// -->\n");
            //javaScript.Append("</script>");
            //this.Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "BodyLoadUnloadScript", javaScript.ToString());

            //ScriptManager scriptManager = ScriptManager.GetCurrent(this.Page);
            //scriptManager.RegisterPostBackControl(UpdatePanel.FindControl("btnExport")); 

            txtDutyDate.Attributes.Add("readonly", "readonly");
            txtDutyDate.Text = DateTime.Now.ToString("dd-MMM-yyyy");
            //txtTodate.Attributes.Add("readonly", "readonly");
            //txtTodate.Text = DateTime.Now.ToString("dd-MMM-yyyy");
            gvAttendence.Visible = true;
            if (IsReadAccess == true)
            {
                //  FillddlAreaID();
              
                //FillAsmtId();
                System.Web.UI.ScriptManager ToolkitScriptManager1 = (System.Web.UI.ScriptManager)Master.FindControl("ToolkitScriptManager1");
               // ToolkitScriptManager1.SetFocus(ddlClientCode);
            }
            else
            {
                Response.Redirect("../UserManagement/Home.aspx");
            }
            FillgvAttendence();
        }
    }
    #endregion

  
    protected void gvAttendence_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvAttendence.PageIndex = e.NewPageIndex;
        gvAttendence.EditIndex = -1;
        FillgvAttendence();
    }
    protected void btnView_Click(object sender, EventArgs e)
    {
        if (flag == 1)
        {
            if (txtEmployeeNo.Text == "")
            {
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "xyz", "alert('Insert Employee Number'); ", true);
            }
            else
            {
                FillgvAttendence();
            }
        }
        else
        {
            FillgvAttendence();
        }
    }
    protected void FillgvAttendence()
    {
        var objAssetMgmt = new BL.Sales();
        var ds = new DataSet();
        var dt = new DataTable();
        var dtflag = 1;
        ds = objAssetMgmt.GetEmployeeAttendenceNewMilkBasket(BaseLocationAutoID, txtDutyDate.Text.Trim(), txtDutyDate.Text.Trim(), txtEmployeeNo.Text.Trim());
        dt = ds.Tables[0];

        if (dt.Rows.Count == 0)
        {
            dtflag = 0;
            dt.Rows.Add(dt.NewRow());
        }
        // lblcount.Text=ds.Tables[1].Rows[0]["Totalcount"].ToString();
        DataColumn dc = new DataColumn("ImageBase64String", typeof(System.String));
        ds.Tables[0].Columns.Add(dc);
        for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
        {
            if (ds.Tables[0].Rows[i]["EmployeeImage"].ToString() != "")
            {
                ds.Tables[0].Rows[i]["ImageBase64String"] = "data:image/jpeg;base64," + Convert.ToBase64String(((byte[])((object)ds.Tables[0].Rows[i]["EmployeeImage"])), 0, ((byte[])((object)ds.Tables[0].Rows[i]["EmployeeImage"])).Length);
            }
            else
            {
                ds.Tables[0].Rows[i]["ImageBase64String"] = string.Empty;
            }
        }

        gvAttendence.DataSource = dt;
        gvAttendence.DataBind();

        //to fix empty gridview
        if (dtflag == 0)
        {
            gvAttendence.Rows[0].Visible = false;
            btnExport.Visible = false;
            lblmsg.Visible = true;
        }
        else
        {
            btnExport.Visible = true;
            lblmsg.Visible = false;
        }
    }
    protected void btnExport_Click(object sender, EventArgs e)
    {
        Response.Clear();
        Response.Buffer = true;
        Response.AddHeader("content-disposition", "attachment;filename=PhotoAttendenceReport-" + txtDutyDate.Text + ".xls");
        Response.Charset = "";
        Response.ContentType = "application/vnd.ms-excel";
        using (StringWriter sw = new StringWriter())
        {
            HtmlTextWriter hw = new HtmlTextWriter(sw);

            //To Export all pages
            gvAttendence.AllowPaging = false;
            FillgvAttendence();
            gvAttendence.Columns[9].Visible = false;

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
    public override void VerifyRenderingInServerForm(Control control)
    {
        // controller   
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
            Label lblEmployeeName = (Label)e.Row.FindControl("lblEmployeeName");
            lblEmployeeName.ForeColor = System.Drawing.Color.Black;
            lblEmployeeName.Font.Bold = true;
            //Label lblBranchcode = (Label)e.Row.FindControl("lblBranchcode");
            //lblBranchcode.ForeColor = System.Drawing.Color.Black;
            //lblBranchcode.Font.Bold = true;
            //Label lblbranchname = (Label)e.Row.FindControl("lblbranchname");
            //lblbranchname.ForeColor = System.Drawing.Color.Black;
            //lblbranchname.Font.Bold = true;
            Label lblDate = (Label)e.Row.FindControl("lblDate");
            lblDate.ForeColor = System.Drawing.Color.Black;
            lblDate.Font.Bold = true;
            Label lblTime = (Label)e.Row.FindControl("lblTime");
            lblTime.ForeColor = System.Drawing.Color.Black;
            lblTime.Font.Bold = true;
            Label lblLatitude = (Label)e.Row.FindControl("lblLatitude");
            lblLatitude.ForeColor = System.Drawing.Color.Black;
            lblLatitude.Font.Bold = true;
            Label lblLongitude = (Label)e.Row.FindControl("lblLongitude");
            lblLongitude.ForeColor = System.Drawing.Color.Black;
            lblLongitude.Font.Bold = true;
            Label lblCluster = (Label)e.Row.FindControl("lblCluster");
            lblCluster.ForeColor = System.Drawing.Color.Black;
            lblCluster.Font.Bold = true;

            Label lblStatus = (Label)e.Row.FindControl("lblStatus");
            if (lblStatus.Text == "OUT")
            {
                lblStatus.ForeColor = System.Drawing.Color.Red;
                lblStatus.Font.Bold = true;
            }
            else
            {
                lblStatus.ForeColor = System.Drawing.Color.Green;
                lblStatus.Font.Bold = true;
            }
        }
    }

    protected void txtDutyDate_TextChanged(object sender, EventArgs e)
    {
        //DateTime dt1 = Convert.ToDateTime(txtDutyDate.Text);
        //DateTime dt2 = Convert.ToDateTime(txtTodate.Text);
        //TimeSpan ts = dt2 - dt1;
        //int days = ts.Days;
        //if (days > 8)
        //{
        //    flag = 1;
        //    txtEmployeeNo.Focus();
        //    txtEmployeeNo.ForeColor = Color.Red;
        //    btnView.BackColor = Color.Red;
        //}
        //else
        //{
        //    flag = 0;
        //    btnView.BackColor = Color.Green;
        //}
        FillgvAttendence();
    }
    protected void txtTodate_TextChanged(object sender, EventArgs e)
    {
        FillgvAttendence();
    }
}