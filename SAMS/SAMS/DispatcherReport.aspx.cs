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

public partial class SAMS_DispatcherReport : BasePage
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

        FillgvAttendence();

    }
    protected void FillgvAttendence()
    {
        var objAssetMgmt = new BL.Sales();
        var ds = new DataSet();
        var dt = new DataTable();
        var dtflag = 1;
        ds = objAssetMgmt.GetDispatcherReport(BaseLocationAutoID, txtDutyDate.Text.Trim());
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
            if (ds.Tables[0].Rows[i]["INImage"].ToString() != "")
            {
                ds.Tables[0].Rows[i]["ImageBase64String"] = "data:image/jpeg;base64," + Convert.ToBase64String(((byte[])((object)ds.Tables[0].Rows[i]["INImage"])), 0, ((byte[])((object)ds.Tables[0].Rows[i]["INImage"])).Length);
            }
            else
            {
                ds.Tables[0].Rows[i]["ImageBase64String"] = string.Empty;
            }
        }

        DataColumn dc1 = new DataColumn("ImageBase64String1", typeof(System.String));
        ds.Tables[0].Columns.Add(dc1);
        for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
        {
            if (ds.Tables[0].Rows[i]["OutImage"].ToString() != "")
            {
                ds.Tables[0].Rows[i]["ImageBase64String1"] = "data:image/jpeg;base64," + Convert.ToBase64String(((byte[])((object)ds.Tables[0].Rows[i]["OutImage"])), 0, ((byte[])((object)ds.Tables[0].Rows[i]["OutImage"])).Length);
            }
            else
            {
                ds.Tables[0].Rows[i]["ImageBase64String1"] = string.Empty;
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
        Response.AddHeader("content-disposition", "attachment;filename=DispatcherReport-" + txtDutyDate.Text + ".xls");
        Response.Charset = "";
        Response.ContentType = "application/vnd.ms-excel";
        using (StringWriter sw = new StringWriter())
        {
            HtmlTextWriter hw = new HtmlTextWriter(sw);

            //To Export all pages
            gvAttendence.AllowPaging = false;
            FillgvAttendence();
            gvAttendence.Columns[9].Visible = false;
            gvAttendence.Columns[12].Visible = false;

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
            Label lblSerialNo1 = (Label)e.Row.FindControl("lblSerialNo");
            lblSerialNo1.ForeColor = System.Drawing.Color.Black;
            lblSerialNo1.Font.Bold = true;
            Label lblLoginID = (Label)e.Row.FindControl("lblLoginID");
            lblLoginID.ForeColor = System.Drawing.Color.Black;
            lblLoginID.Font.Bold = true;
            Label lblRoute = (Label)e.Row.FindControl("lblRoute");
            lblRoute.ForeColor = System.Drawing.Color.Black;
            lblRoute.Font.Bold = true;
            Label lblVType = (Label)e.Row.FindControl("lblVType");
            lblVType.ForeColor = System.Drawing.Color.Black;
            lblVType.Font.Bold = true;
            Label lblVendorName = (Label)e.Row.FindControl("lblVendorName");
            lblVendorName.ForeColor = System.Drawing.Color.Black;
            lblVendorName.Font.Bold = true;
            Label lblVehicleNo = (Label)e.Row.FindControl("lblVehicleNo");
            lblVehicleNo.ForeColor = System.Drawing.Color.Black;
            lblVehicleNo.Font.Bold = true;
            Label lblDate = (Label)e.Row.FindControl("lblDate");
            lblDate.ForeColor = System.Drawing.Color.Black;
            lblDate.Font.Bold = true;

            Label lblINKM = (Label)e.Row.FindControl("lblINKM");
            lblINKM.ForeColor = System.Drawing.Color.Red;
            lblINKM.Font.Bold = true;
            Label lblINKM2 = (Label)e.Row.FindControl("lblINKM2");
            lblINKM2.ForeColor = System.Drawing.Color.Red;
            lblINKM2.Font.Bold = true;
            Label lblINKM3 = (Label)e.Row.FindControl("lblINKM3");
            lblINKM3.ForeColor = System.Drawing.Color.Red;
            lblINKM3.Font.Bold = true;


            Label lblINTime = (Label)e.Row.FindControl("lblINTime");
            lblINTime.ForeColor = System.Drawing.Color.Red;
            lblINTime.Font.Bold = true;
            Label lblINKM4 = (Label)e.Row.FindControl("lblINKM4");
            lblINKM4.ForeColor = System.Drawing.Color.Green;
            lblINKM4.Font.Bold = true;
            Label lblINKM5 = (Label)e.Row.FindControl("lblINKM5");
            lblINKM5.ForeColor = System.Drawing.Color.Green;
            lblINKM5.Font.Bold = true;
            Label lblINKM6 = (Label)e.Row.FindControl("lblINKM6");
            lblINKM6.ForeColor = System.Drawing.Color.Green;
            lblINKM6.Font.Bold = true;

            Label lblOUTTime = (Label)e.Row.FindControl("lblOUTTime");
            lblOUTTime.ForeColor = System.Drawing.Color.Green;
            lblOUTTime.Font.Bold = true;

            Label lblLatitude = (Label)e.Row.FindControl("lblLatitude");
            lblLatitude.ForeColor = System.Drawing.Color.Black;
            lblLatitude.Font.Bold = true;
            Label lblLongitude = (Label)e.Row.FindControl("lblLongitude");
            lblLongitude.ForeColor = System.Drawing.Color.Black;
            lblLongitude.Font.Bold = true;


            Label lblLocationName = (Label)e.Row.FindControl("lblLocationName");
            lblLocationName.ForeColor = System.Drawing.Color.Black;
            lblLocationName.Font.Bold = true;
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