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

public partial class AssetManagement_TicketMaster : BasePage
{   
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
                var VirtualDirNameLenght = 0;
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
                var VirtualDirNameLenght = 0;
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
                var VirtualDirNameLenght = 0;
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
                var VirtualDirNameLenght = 0;
                VirtualDirNameLenght = int.Parse(System.Web.HttpContext.Current.Request.Url.AbsolutePath.IndexOf(@"/", 1).ToString());
                return IsDeleteAllowed(System.Web.HttpContext.Current.Request.Url.AbsolutePath.Remove(0, VirtualDirNameLenght));
            }
            catch (Exception ex)
            { throw new Exception("Have not Rights", ex); }
        }
    }
    /// <summary>
    /// Gets a value indicating whether the item is enabled. Returns User Authorization Rights.
    /// </summary>
    /// <value><c>true</c> if this instance is authorization access; otherwise, <c>false</c>.</value>
    /// <exception cref="System.Exception"></exception>
    protected bool IsAuthorizationAccess
    {
        get
        {
            try
            {
                var bp = new BasePage();
                int virtualDirNameLenght = int.Parse(System.Web.HttpContext.Current.Request.Url.AbsolutePath.IndexOf(@"/", 1).ToString());
                return bp.IsAuthorizationAllowed(System.Web.HttpContext.Current.Request.Url.AbsolutePath.Remove(0, virtualDirNameLenght));
            }
            catch (Exception ex)
            {
                throw new Exception(Resources.Resource.NOAccessRights, ex);
            }
        }
    }

    #endregion

    static int dtflag;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (IsReadAccess)
            {
                txtDate.Text = DateTime.Today.ToString("dd-MMM-yyyy");
               txtToDate.Text = DateTime.Today.ToString("dd-MMM-yyyy");
                if (txtUserId != null)
                {
                    txtUserId.Attributes.Add("onkeyup", "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionString + ");");
                    txtUserId.Attributes.Add("onblur", "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionString + ");");
                }
                if (txtTicketNo != null)
                {
                    txtTicketNo.Attributes.Add("onkeyup", "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionString + ");");
                    txtTicketNo.Attributes.Add("onblur", "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionString + ");");
                }
                ReadOnly();
                FillgvTicketMaster();
            }
        }
        txtDate.Attributes.Add("readonly", "readonly");
        txtToDate.Attributes.Add("readonly", "readonly");
    }
    protected void gvTicketMaster_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvTicketMaster.PageIndex = e.NewPageIndex;
        gvTicketMaster.EditIndex = -1;
        FillgvTicketMaster();
    }
    protected void gvTicketMaster_RowDataBound(object sender, GridViewRowEventArgs e)
    {
    }
    private void FillgvTicketMaster()
    {
        try
        {
            var objAssetMgmt = new BL.AssetManagement();
            var dsTicketMaster = new DataSet();
            var dtTicketMaster = new DataTable();
            dtflag = 1;
            dsTicketMaster = objAssetMgmt.GetAllTickets(BaseLocationAutoID,ddlStatusMain.SelectedItem.Value,txtTicketNo.Text.Trim(),txtUserId.Text.Trim(),txtDate.Text,txtToDate.Text);
            dtTicketMaster = dsTicketMaster.Tables[0];
            if (dtTicketMaster.Rows.Count == 0)
            {
                dtflag = 0;
                dtTicketMaster.Rows.Add(dtTicketMaster.NewRow());
            }
            gvTicketMaster.DataSource = dtTicketMaster;
            gvTicketMaster.DataBind();

            if (dtflag == 0)
            {
                gvTicketMaster.Rows[0].Visible = false;
                dtflag = 0;
            }
            else
            {
                dtflag = 1;
            }

        }
        catch (Exception ex)
        {
        }
    }
  
    protected void lblTicketNo_Click(object sender, EventArgs e)
    {
        LinkButton objLinkButton = (LinkButton)sender;
        GridViewRow row = (GridViewRow)objLinkButton.NamingContainer;
        LinkButton lblTicketNo = (LinkButton)gvTicketMaster.Rows[row.RowIndex].FindControl("lblTicketNo");
        Label lblTicketStatus = (Label)gvTicketMaster.Rows[row.RowIndex].FindControl("lblTicketStatus");
        FillTicketDetail(lblTicketNo.Text);
        pnlTicetMaster.Visible = false;
        btnExport.Visible = false;
       
        pnlTicketDetail.Visible = true;
        if ((lblTicketStatus.Text == "Approved") || (lblTicketStatus.Text == "Reject"))
        {
            btnUpdate.Visible = false;
            ddlStatus.Enabled = false;
            hfstatus.Value = lblTicketStatus.Text;
            ddlStatus.SelectedValue = lblTicketStatus.Text;
        }
        else if(lblTicketStatus.Text == "Closed")
        {
            btnUpdate.Visible = false;
            ddlStatus.Enabled = false;
            hfstatus.Value = lblTicketStatus.Text;

        }
        else
        {
            btnUpdate.Visible = true;
            ddlStatus.Enabled = true;
        }
    }
    private void FillTicketDetail(string TicketNo)
    {
        var objAssetMgmt = new BL.AssetManagement();
        var ds = objAssetMgmt.TicketDetail(TicketNo,BaseLocationAutoID);
        try
        {
            btnExport.Visible = false;
       
            lblTicketNo.Text = TicketNo;
            if (ds.Tables.Count > 0)
            {
                txtClientName.Text = ds.Tables[0].Rows[0]["ClientName"].ToString();
                txtSiteName.Text = ds.Tables[0].Rows[0]["AsmtName"].ToString();
                txtDOC.Text =DateFormat( ds.Tables[0].Rows[0]["DateOfCreation"].ToString());
                txtSummary.Text = ds.Tables[0].Rows[0]["SummaryOfIssues"].ToString();
                txtDesc.Text = ds.Tables[0].Rows[0]["DescOfIssues"].ToString();
                txtSeverity.Text = ds.Tables[0].Rows[0]["Severity"].ToString();
                txtCommercialValue.Text = ds.Tables[0].Rows[0]["CommercialValue"].ToString();
                var dt = new DataTable();
                dt = ds.Tables[0];

                DataColumn dc = new DataColumn("ImageBase64String", typeof(System.String));
                ds.Tables[0].Columns.Add(dc);

                if (ds.Tables[0].Rows[0]["WOImage"].ToString() != "")
                    {
                        ds.Tables[0].Rows[0]["ImageBase64String"] = "data:image/jpeg;base64," + Convert.ToBase64String(((byte[])((object)ds.Tables[0].Rows[0]["WOImage"])), 0, ((byte[])((object)ds.Tables[0].Rows[0]["WOImage"])).Length);
                    }
                    else
                    {
                        ds.Tables[0].Rows[0]["ImageBase64String"] = string.Empty;
                    }
                ImageBox.ImageUrl = ds.Tables[0].Rows[0]["ImageBase64String"].ToString();

             }
        }
        catch (Exception ex)
        { }
    }
    public void ReadOnly()
    {
        txtClientName.Attributes.Add("readonly", "readonly");
        txtSiteName.Attributes.Add("readonly", "readonly");
        txtDOC.Attributes.Add("readonly", "readonly");
        txtSummary.Attributes.Add("readonly", "readonly");
        txtDesc.Attributes.Add("readonly", "readonly");
        txtSeverity.Attributes.Add("readonly", "readonly");
        txtCommercialValue.Attributes.Add("readonly", "readonly");
    }
    protected string DateFormat(string strdate)
    {
        var dt = new DateTime();
        string formatedDate;
        if (strdate != string.Empty)
        {
            dt = DateTime.Parse(strdate);
            formatedDate = dt.ToString("dd-MMM-yyyy");
        }
        else
        {
            formatedDate = string.Empty;
        }
        return formatedDate;
    }
    protected void btnBack_Click(object sender, EventArgs e)
    {
        pnlTicetMaster.Visible = true;
        btnExport.Visible = true;
        pnlTicketDetail.Visible = false;
    }
    protected void btnUpdate_Click1(object sender, EventArgs e)
    {
        var ds = new DataSet();
        var objAssetMgmt = new BL.AssetManagement();
        try
        {
            ds = objAssetMgmt.UpdateTicketStatus(lblTicketNo.Text,ddlStatus.SelectedItem.Value,BaseLocationAutoID,BaseUserID);
            lblErrorMsg.Text = ds.Tables[0].Rows[0]["MessageString"].ToString();
            FillTicketDetail(lblTicketNo.Text);
            btnUpdate.Visible = false;
            ddlStatus.Enabled = false;
        }
        catch (Exception ex)
        { }
    }
    
    protected void txtUserId_TextChanged(object sender, EventArgs e)
    {
        FillgvTicketMaster();
    }
    protected void txtTicketNo_TextChanged(object sender, EventArgs e)
    {
        FillgvTicketMaster();
    }
    protected void ddlStatusMain_SelectedIndexChanged(object sender, EventArgs e)
    {
        FillgvTicketMaster();
    }
    protected void txtDate_TextChanged(object sender, EventArgs e)
    {
        FillgvTicketMaster();
    }
    protected void txtFromDate_TextChanged(object sender, EventArgs e)
    {

    }
    protected void txtToDate_TextChanged(object sender, EventArgs e)
    {
        FillgvTicketMaster();

    }

    public override void VerifyRenderingInServerForm(Control control)
    {
        // controller   
    }  
    protected void btnExport_Click(object sender, EventArgs e)
    {
       
        Response.Clear();
        Response.Buffer = true;
        Response.AddHeader("content-disposition", "attachment;filename=TicketReport-" + txtDate.Text + " to " + txtToDate.Text + ".xls");
        Response.Charset = "";
        Response.ContentType = "application/vnd.ms-excel";
        using (StringWriter sw = new StringWriter())
        {
            HtmlTextWriter hw = new HtmlTextWriter(sw);

            //To Export all pages
            gvTicketMaster.AllowPaging = false;
            FillgvTicketMaster();

            gvTicketMaster.HeaderRow.BackColor = Color.White;
            foreach (TableCell cell in gvTicketMaster.HeaderRow.Cells)
            {
                cell.BackColor = gvTicketMaster.HeaderStyle.BackColor;
            }
            foreach (GridViewRow row in gvTicketMaster.Rows)
            {
                row.BackColor = Color.White;
                foreach (TableCell cell in row.Cells)
                {
                    if (row.RowIndex % 2 == 0)
                    {
                        cell.BackColor = gvTicketMaster.AlternatingRowStyle.BackColor;
                    }
                    else
                    {
                        cell.BackColor = gvTicketMaster.RowStyle.BackColor;
                    }
                    cell.CssClass = "textmode";
                }
            }

            gvTicketMaster.RenderControl(hw);

            //style to format numbers to string
            string style = @"<style> .textmode { } </style>";
            Response.Write(style);
            Response.Output.Write(sw.ToString());
            Response.Flush();
            Response.End();
        }
    }
}