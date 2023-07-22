using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AjaxControlToolkit;
using QRCoder;
using System.Drawing;
using System.Configuration;
public partial class AssetManagement_AssetTagging : BasePage
{
    static int dtflag;
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

    #endregion
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (IsReadAccess)
            {
                FillgvAssetMaster();
                FillddlClient();
                FillAsmtId();
                FillddlPost();
            }
            else
            {
                Response.Redirect("../UserManagement/Home.aspx");
            }
        }
    }
    protected void gvAssetMaster_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvAssetMaster.PageIndex = e.NewPageIndex;
        gvAssetMaster.EditIndex = -1;
        FillgvAssetMaster();
    }
    protected void btnTaging_Click(object sender, EventArgs e)
    {
        divTaging.Visible = true;
        divMaster.Visible = false;
        lblMapping.Text = "";
        LinkButton objLinkButton = (LinkButton)sender;
        GridViewRow row = (GridViewRow)objLinkButton.NamingContainer;
        HiddenField hfAssetMaster = (HiddenField)gvAssetMaster.Rows[row.RowIndex].FindControl("hfAssetMaster");
        Label lblAssetCode = (Label)gvAssetMaster.Rows[row.RowIndex].FindControl("lblAssetCode");
        LinkButton btnTaging = (LinkButton)gvAssetMaster.Rows[row.RowIndex].FindControl("btnTaging");
        Label LbAssestName = (Label)gvAssetMaster.Rows[row.RowIndex].FindControl("LbAssestName");
        lblAssetCode1.Text = lblAssetCode.Text;
        lblAssetName1.Text = LbAssestName.Text;
        hfId.Value = hfAssetMaster.Value;
        divAllocate.Visible = false;
        FillAssetClientMapping(hfId.Value);       
        if (btnTaging.Text == "Click Here")
        {
            ddlClientCode.Enabled = true;
            ddlAsmtId.Enabled = true;
            ddlPost.Enabled = true;
            btnSubmitMapping.Visible = true;
            btnupdate.Visible = false;
            QRCode.Visible = false;
        }
        else
        {
            ddlClientCode.Enabled = false;
            ddlAsmtId.Enabled = false;
            ddlPost.Enabled = false;
            btnSubmitMapping.Visible = false;
            btnupdate.Visible = true;
            QRCode.Visible = true;
        }
    }
    private void FillgvAssetMaster()
    {
        try
        {
            var objAssetMgmt = new BL.AssetManagement();
            var dsAssetMaster = new DataSet();
            var dtAssetMaster = new DataTable();
            dtflag = 1;
            dsAssetMaster = objAssetMgmt.AssetMasterDetailGet(BaseCompanyCode);
            dtAssetMaster = dsAssetMaster.Tables[0];
            if (dtAssetMaster.Rows.Count == 0)
            {
                dtflag = 0;
                dtAssetMaster.Rows.Add(dtAssetMaster.NewRow());
            }
            gvAssetMaster.DataSource = dtAssetMaster;
            gvAssetMaster.DataBind();

            if (dtflag == 0)
            {
                gvAssetMaster.Rows[0].Visible = false;
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
    protected void QRCode_Click(object sender, EventArgs e)
    {
        lblMapping.Text = "";
        string code = lblAssetCode1.Text + "Q" + ddlPost.SelectedItem.Value;
        QRCodeGenerator qrGenerator = new QRCodeGenerator();
        QRCodeGenerator.QRCode qrCode = qrGenerator.CreateQrCode(code, QRCodeGenerator.ECCLevel.Q);
        System.Web.UI.WebControls.Image imgBarCode = new System.Web.UI.WebControls.Image();
        imgBarCode.Height = 250;
        imgBarCode.Width = 250;
        using (Bitmap bitMap = qrCode.GetGraphic(20))
        {
            using (MemoryStream ms = new MemoryStream())
            {
                bitMap.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
                byte[] byteImage = ms.ToArray();
                imgBarCode.ImageUrl = "data:image/png;base64," + Convert.ToBase64String(byteImage);
            }
            plBarCode.Controls.Add(imgBarCode);
        }
    }
    protected void btnSubmitMapping_Click(object sender, EventArgs e)
    {
        var ds = new DataSet();
        var objAssetMgmt = new BL.AssetManagement();
        try
        {
            string code = lblAssetCode1.Text + "Q" + ddlPost.SelectedItem.Value;
            ds = objAssetMgmt.AssetClientMappingInsert(Convert.ToInt32(hfId.Value), Convert.ToInt32(BaseLocationAutoID), ddlClientCode.SelectedItem.Value, ddlAsmtId.SelectedItem.Value, Convert.ToInt32(ddlPost.SelectedItem.Value), "", "", BaseUserID, code.ToString());
            DisplayMessage(lblMapping, ds.Tables[0].Rows[0]["MessageId"].ToString());
            btnupdate.Visible = true;
            btnSubmitMapping.Visible = false;
            ddlClientCode.Enabled = false;
            ddlAsmtId.Enabled = false;
            ddlPost.Enabled = false;
            QRCode.Visible = true;
        }
        catch (Exception ex)
        { }
    }
    protected void btnUpdateMapping_Click(object sender, EventArgs e)
    {
        var ds = new DataSet();
        var objAssetMgmt = new BL.AssetManagement();
        try
        {
            string code = lblAssetCode1.Text + "Q" + ddlPost.SelectedItem.Value;
            ds = objAssetMgmt.AssetClientMappingUpdate(Convert.ToInt32(hfId.Value), Convert.ToInt32(BaseLocationAutoID), ddlClientCode.SelectedItem.Value, ddlAsmtId.SelectedItem.Value, Convert.ToInt32(ddlPost.SelectedItem.Value), "", "", BaseUserID, code.ToString());
            DisplayMessage(lblMapping, ds.Tables[0].Rows[0]["MessageId"].ToString());
            QRCode.Visible = true;
            btnupdate.Visible = true;
            btnUpdateMapping.Visible = false;
            btncancel.Visible = false;
            ddlClientCode.Enabled = false;
            ddlAsmtId.Enabled = false;
            ddlPost.Enabled = false;
            btnBack.Visible = true;
        }
        catch (Exception ex)
        { }
    }
    private void FillAssetClientMapping(string AssetId)
    {
        var objAssetMgmt = new BL.AssetManagement();
        var ds = objAssetMgmt.AssetClientMappingGetRecords(AssetId);
        try
        {
            if (ds.Tables.Count > 0)
            {

                if (ds.Tables[0].Rows.Count > 0)
                {
                    ddlClientCode.SelectedValue = ds.Tables[0].Rows[0]["ClientCode"].ToString();
                    ddlAsmtId.SelectedValue = ds.Tables[0].Rows[0]["AsmtId"].ToString();
                    ddlPost.SelectedValue = ds.Tables[0].Rows[0]["PostAutoId"].ToString();
                    //txtRemark.Text = ds.Tables[0].Rows[0]["Remark"].ToString();
                    //txtUsage.Text = ds.Tables[0].Rows[0]["Usage"].ToString();
                    btnupdate.Visible = true;
                    btnSubmitMapping.Visible = false;
                }
                else
                {
                    btnupdate.Visible = false;
                    btnSubmitMapping.Visible = true;
                }
            }
            else
            {
                btnupdate.Visible = false;
                btnSubmitMapping.Visible = true;

            }

        }
        catch (Exception ex)
        { }
    }
    protected void ddlClientCode_SelectedIndexChanged(object sender, EventArgs e)
    {
        FillAsmtId();
    }
    protected void ddlAsmtId_SelectedIndexChanged(object sender, EventArgs e)
    {
        FillddlPost();
    }
    protected void FillddlClient()
    {
        DataSet ds = new DataSet();
        BL.Sales objsales = new BL.Sales();
        if (BaseIsAdmin.Trim().ToLower() == "C".Trim().ToLower())
        {
            ds = objsales.ClientGet(BaseLocationAutoID, BaseUserID);
        }
        else
        {          
            ds = objsales.ClientsMappedToLocationGet(BaseLocationAutoID, "ALL", "".ToString(), BaseUserEmployeeNumber, BaseUserIsAreaIncharge, DateFormat(DateTime.Now), DateFormat(DateTime.Now));
        }
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
                FillAsmtId();
            }
            else
            {
                ListItem li = new ListItem();
                li.Text = Resources.Resource.NoData;
                li.Value = "0";
                ddlClientCode.Items.Add(li);
            }
        }
        else
        {
            ListItem li = new ListItem();
            li.Text = Resources.Resource.NoData;
            li.Value = "0";
            ddlClientCode.Items.Add(li);
        }
    }
    protected void FillAsmtId()
    {
        BL.Sales objSales = new BL.Sales();
        ddlAsmtId.DataSource = objSales.ClientAsmtIdsGetAll(BaseLocationAutoID, ddlClientCode.SelectedValue.ToString(), BaseUserEmployeeNumber, "");
        ddlAsmtId.DataTextField = "AsmtIDAddress";
        ddlAsmtId.DataValueField = "AsmtID";
        ddlAsmtId.DataBind();
        if (ddlAsmtId.Text == "")
        {
            ListItem li = new ListItem();
            li.Text = Resources.Resource.NoData;
            li.Value = "0";
            ddlAsmtId.Items.Add(li);
        }
        FillddlPost();
    }
    protected void FillddlPost()
    {
        if (ddlClientCode.Items.Count > 0 && ddlAsmtId.Items.Count > 0)
        {
            var objSales = new BL.Sales();
            DataSet ds = objSales.PostGetAll(ddlClientCode.SelectedItem.Value, ddlAsmtId.SelectedItem.Value);
            ddlPost.DataSource = ds;

            ddlPost.DataTextField = "Post";
            ddlPost.DataValueField = "PostAutoId";
            ddlPost.DataBind();
            if (ddlPost.Text == "")
            {
                ListItem li = new ListItem();
                li.Text = Resources.Resource.NoData;
                li.Value = "0";
                ddlPost.Items.Add(li);
            }
        }
    }
    protected void btnBack_Click(object sender, EventArgs e)
    {
        divTaging.Visible = false;
        divMaster.Visible = true;
        FillgvAssetMaster();
    }

    protected void lblAssetCode_Click(object sender, EventArgs e)
    {
        
    }
    public void FillgvOwnerAllocate(string strAssetId)
    {
        var objAssetMgmt = new BL.AssetManagement();
        DataSet ds = new DataSet();
        DataTable dt = new DataTable();
        int dtflag;
        dtflag = 1;
        ds = objAssetMgmt.GetAssetOwnerMappingNew(Convert.ToInt32(BaseLocationAutoID), Convert.ToInt32(strAssetId));
        dt = ds.Tables[0];
        if (dt.Rows.Count == 0)
        {
            dtflag = 0;
            dt.Rows.Add(dt.NewRow());
        }
        gvOwnerAllocate.DataSource = dt;
        gvOwnerAllocate.DataBind();
        gvOwnerAllocate.Columns[0].Visible = true;
        ViewState["AreaDates"] = dt;
        if (dtflag == 0)
        {
            gvOwnerAllocate.Rows[0].Visible = false;
        }
    }
    protected void gvOwnerAllocate_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvOwnerAllocate.PageIndex = e.NewPageIndex;
        gvOwnerAllocate.EditIndex = -1;
        FillgvOwnerAllocate(hfAssetCode.Value);
    }
    protected void gvOwnerAllocate_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        DataSet ds = new DataSet();
        BL.AssetManagement objAsmt = new BL.AssetManagement();
        Label lblAssetID = (Label)gvOwnerAllocate.FooterRow.FindControl("lblNewAssetID");
        Label lblNewAssetName = (Label)gvOwnerAllocate.FooterRow.FindControl("lblNewAssetName");
        Label lblNewEmployeeName = (Label)gvOwnerAllocate.FooterRow.FindControl("lblNewEmployeeName");

        TextBox txtNewEmployeeNumber = (TextBox)gvOwnerAllocate.FooterRow.FindControl("txtNewEmployeeNumber");
        TextBox txtEffectiveFrom = (TextBox)gvOwnerAllocate.FooterRow.FindControl("txtEffectiveFrom");
        HiddenField hdEmpDOJ = (HiddenField)gvOwnerAllocate.FooterRow.FindControl("hdEmpDOJ");
       if (e.CommandName.Equals("AddNewAreaInch"))
        {
            if (lblAssetID.Text != "" && lblNewAssetName.Text != "" && lblNewEmployeeName.Text != "" && txtNewEmployeeNumber.Text != "")
            {
                if (Convert.ToDateTime(hdEmpDOJ.Value) < Convert.ToDateTime(txtEffectiveFrom.Text))        
                {
                    ds = objAsmt.OwnerAssetMappingInsert(Convert.ToInt32(hfAssetCode.Value), txtNewEmployeeNumber.Text, BaseLocationAutoID, BaseUserID, txtEffectiveFrom.Text, lblNewEmployeeName.Text, lblAssetID.Text);
                    DisplayMessage(lblErrorMsg, ds.Tables[0].Rows[0]["MessageID"].ToString());
                    if (gvOwnerAllocate.Rows.Count.Equals(gvOwnerAllocate.PageSize))
                    {
                        gvOwnerAllocate.PageIndex = gvOwnerAllocate.PageCount + 1;
                    }
                    gvOwnerAllocate.EditIndex = -1;
                    FillgvOwnerAllocate(hfAssetCode.Value);
                }
                else           
                {
                    lblErrorMsg.Text = Resources.Resource.EffectiveDateGreaterDOJ;
                    txtEffectiveFrom.Text = "";
                    txtEffectiveFrom.Focus();
                }
            }
        }
        if (e.CommandName.Equals("Reset"))
        {
            txtNewEmployeeNumber.Text = "";
            txtEffectiveFrom.Text = "";
        }
    }
    protected void gvOwnerAllocate_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        GridViewRow objGridViewRow = e.Row;
        Label lblSerialNo = (Label)objGridViewRow.FindControl("lblSerialNo");
        if (lblSerialNo != null)
        {
            int serialNo = gvOwnerAllocate.PageIndex * gvOwnerAllocate.PageSize + int.Parse(objGridViewRow.RowIndex.ToString());
            lblSerialNo.Text = Convert.ToString((serialNo + 1));
        }
        if (IsWriteAccess == false && IsModifyAccess == false && IsDeleteAccess == false)
        {
            gvOwnerAllocate.Columns[0].Visible = false;
        }
        if (DataControlRowState.Edit == e.Row.RowState)
        {
            TextBox txtEffectiveTo = (TextBox)e.Row.FindControl("txtEffectiveTo");
            txtEffectiveTo.Focus();
        }
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            e.Row.Attributes["onmouseover"] = "javascript:setMouseOverColor(this);";
            e.Row.Attributes["onmouseout"] = "javascript:setMouseOutColor(this);";
            HiddenField hfAreaInchargeAutoID = (HiddenField)e.Row.FindControl("AssetOwnerMappingAutoId");
            Label lblEmployeeNumber = (Label)e.Row.FindControl("lblEmployeeNumber");
            if (hfAreaInchargeAutoID != null)
            {
                try
                {
                    if (IsMinValue(int.Parse(hfAreaInchargeAutoID.Value), lblEmployeeNumber.Text))
                    {
                        ImageButton IBEditAreaIncharge = (ImageButton)e.Row.FindControl("IBEditAreaIncharge");
                        if (IBEditAreaIncharge != null)
                        {
                            IBEditAreaIncharge.Visible = false;
                        }
                    }
                }
                catch (Exception) { }
            }           
        }

        if (e.Row.RowType == DataControlRowType.Footer)
        {
            DataSet ds = new DataSet();
            BL.OperationManagement objOperationManagement = new BL.OperationManagement();
            if (IsWriteAccess == false)
            {
                gvOwnerAllocate.ShowFooter = false;
            }
            else
            {
                ImageButton lbADD = (ImageButton)e.Row.FindControl("lbADD");
                if (lbADD != null)
                {
                    lbADD.Attributes["onclick"] = "javascript:Timerf('" + lblErrorMsg.ClientID.ToString() + "');";
                }
                Label lblAssetID = (Label)e.Row.FindControl("lblNewAssetID");
                Label lblAssetName = (Label)e.Row.FindControl("lblNewAssetName");
                ImageButton imgSearch = (ImageButton)e.Row.FindControl("imgSearch");
                TextBox txtNewEmployeeNumber = (TextBox)e.Row.FindControl("txtNewEmployeeNumber");
                // imgSearch.Attributes.Add("OnClick", "javascript:OpenSearch('" + txtNewEmployeeNumber.ClientID.ToString() + "')");
                imgSearch.Attributes.Add("onClick", "window.open('../search/commonSearch.aspx?SearchId=CCH01&ControlId=" + txtNewEmployeeNumber.ClientID.ToString() + "&Company=" + BaseCompanyCode.ToString() + "&HrLocation=" + BaseHrLocationCode.ToString() + "&Location=',null,'status=off,center=yes,scrollbars=1,resizeable=1,Width=850,Height=450,help=no')");
                string handler = ClientScript.GetPostBackEventReference(this.btnPostBack, "");
                txtNewEmployeeNumber.Attributes.Add("onblur", handler);
                lblAssetID.Text = hfAssetCode1.Value;
                lblAssetName.Text = hfAssetName1.Value;
                if (txtNewEmployeeNumber != null)
                {
                    txtNewEmployeeNumber.Attributes["onKeyUp"] = "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionString + ");";
                }
            }
        }
    }
    private bool IsMinValue(int val, string areaIncharge)
    {
        bool result = false;
        DataTable dt = (DataTable)gvOwnerAllocate.DataSource;
        if (dt != null && dt.Rows.Count > 1)
        {
            int maxVal = Convert.ToInt32(dt.Compute("max(AreaInchargeAutoId)", "AreaIncharge='" + areaIncharge.Trim() + "'"));
            if (maxVal > val)
                result = true;
        }
        return result;
    }
    protected void gvOwnerAllocate_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        Label lblAssetID = (Label)gvOwnerAllocate.Rows[e.RowIndex].FindControl("lblAssetID");
        Label lblEmployeeNumber = (Label)gvOwnerAllocate.Rows[e.RowIndex].FindControl("lblEmployeeNumber");
        DataSet ds = new DataSet();
        BL.AssetManagement objAsmt = new BL.AssetManagement();
        ds = objAsmt.OwnerAssetMappingDelete(lblAssetID.Text, lblEmployeeNumber.Text, BaseLocationAutoID);
        DisplayMessage(lblErrorMsg, ds.Tables[0].Rows[0]["MessageID"].ToString());
        FillgvOwnerAllocate(hfAssetCode.Value);
    }
    protected void gvOwnerAllocate_RowEditing(object sender, GridViewEditEventArgs e)
    {
        gvOwnerAllocate.EditIndex = e.NewEditIndex;
        FillgvOwnerAllocate(hfAssetCode.Value);
    }
    protected void gvOwnerAllocate_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        gvOwnerAllocate.EditIndex = -1;
        FillgvOwnerAllocate(hfAssetCode.Value);
    }
    protected void gvOwnerAllocate_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        ImageButton IBEditAreaIncharge = (ImageButton)gvOwnerAllocate.Rows[e.RowIndex].FindControl("IBEditAreaIncharge");
        TextBox txtEffectiveTo = (TextBox)gvOwnerAllocate.Rows[e.RowIndex].FindControl("txtEffectiveTo");
        TextBox txtEffectiveFrom = (TextBox)gvOwnerAllocate.Rows[e.RowIndex].FindControl("txtEffectiveFrom");
        Label lblAssetID = (Label)gvOwnerAllocate.Rows[e.RowIndex].FindControl("lblAssetID");
        Label lblEmployeeNumber = (Label)gvOwnerAllocate.Rows[e.RowIndex].FindControl("lblEmployeeNumber");
        HiddenField hfAssetAutoId = (HiddenField)gvOwnerAllocate.Rows[e.RowIndex].FindControl("hfAssetAutoId");
      
        if (!ConvertStringToDateFormat(txtEffectiveFrom, lblErrorMsg))
        {
            lblErrorMsg.Text = Resources.Resource.InvalidateFromDate;
            txtEffectiveFrom.Text = "";
            txtEffectiveFrom.Focus();
            return;
        }

        DateTime EffectiveToDate = DateTime.Now.Date;
        if (string.IsNullOrEmpty(txtEffectiveTo.Text))
            EffectiveToDate = DateTime.Parse("31-Dec-90");
        else
        {
            if (!ConvertStringToDateFormat(txtEffectiveTo, lblErrorMsg))
            {
                lblErrorMsg.Text = Resources.Resource.InvalidToDate;
                txtEffectiveTo.Text = "";
                txtEffectiveTo.Focus();
                return;
            }
            else
                EffectiveToDate = DateTime.Parse((txtEffectiveTo.Text));
        }
        if (CheckDate(DateTime.Parse(txtEffectiveFrom.Text), hfAssetAutoId.Value, lblEmployeeNumber.Text))
        {
            lblErrorMsg.Text = Resources.Resource.InvalidateFromDate;
            txtEffectiveFrom.Text = "";
            txtEffectiveFrom.Focus();
            return;
        }

        if (!string.IsNullOrEmpty(txtEffectiveTo.Text) && EffectiveToDate < (DateTime.Parse(txtEffectiveFrom.Text)))
        {
            lblErrorMsg.Text = Resources.Resource.InvalidToDate;
            txtEffectiveTo.Text = "";
            txtEffectiveTo.Focus();
            return;
        }
        else
        {
            BL.AssetManagement objAsmt = new BL.AssetManagement();
            DataSet dsUpdateAI = new DataSet();
            dsUpdateAI = objAsmt.OwnerAssetMappingUpdate(hfAssetCode.Value, lblEmployeeNumber.Text, BaseLocationAutoID, hfAssetAutoId.Value, txtEffectiveFrom.Text, EffectiveToDate.ToString(), BaseUserID);
            if (dsUpdateAI != null && dsUpdateAI.Tables.Count > 0 && dsUpdateAI.Tables[0].Rows.Count > 0)
            {
                if (dsUpdateAI.Tables[0].Rows[0]["MessageID"].ToString() == "2")
                {
                    DisplayMessage(lblErrorMsg, dsUpdateAI.Tables[0].Rows[0]["MessageID"].ToString());
                    gvOwnerAllocate.EditIndex = -1;
                    FillgvOwnerAllocate(hfAssetCode.Value);                 
                }
            }
        }
    }
    private bool CheckDate(DateTime dateValue, string id, string areaIncharge)
    {
        bool result = false;
        DataTable dt = (DataTable)ViewState["AreaDates"];

        for (int i = 0; i < dt.Rows.Count; i++)
        {
            if (dt.Rows[i]["AssetOwnerMappingAutoId"].ToString() == id)
            {
                dt.Rows[i].Delete();
                dt.AcceptChanges();
                break;
            }
        }

        if (dt != null && dt.Rows.Count > 0)
        {
            foreach (DataRow dr in dt.Rows)
            {
                if (!string.IsNullOrEmpty(dr["EffectiveTo"].ToString()))
                {
                    if (dateValue <= DateTime.Parse(dr["EffectiveTo"].ToString()) && dr["EmployeeNumber"].ToString() == areaIncharge)
                    {
                        result = true;
                        break;
                    }
                }
            }
        }
        return result;
    }
    protected void txtNewEmployeeNumber_TextChanged(object sender, EventArgs e)
    {
        TextBox objTextBox = (TextBox)sender;
        GridViewRow row = (GridViewRow)objTextBox.NamingContainer;

        TextBox txtNewEmployeeNumber = (TextBox)gvOwnerAllocate.FooterRow.FindControl("txtNewEmployeeNumber");
        string handler = ClientScript.GetPostBackEventReference(this.btnPostBack, "");
        txtNewEmployeeNumber.Attributes.Add("onblur", handler);

    }
    protected void btnPostBack_Click(object sender, EventArgs e)
    {
        DataSet ds = new DataSet();
        BL.OperationManagement objOperationManagement = new BL.OperationManagement();
        Label lblNewEmployeeName = (Label)gvOwnerAllocate.FooterRow.FindControl("lblNewEmployeeName");
        TextBox txtNewEmployeeNumber = (TextBox)gvOwnerAllocate.FooterRow.FindControl("txtNewEmployeeNumber");
        ImageButton lbADD = (ImageButton)gvOwnerAllocate.FooterRow.FindControl("lbADD");
        HiddenField hdEmpDOJ = (HiddenField)gvOwnerAllocate.FooterRow.FindControl("hdEmpDOJ");
        ds = objOperationManagement.EmployeeNameByIdGet(txtNewEmployeeNumber.Text);
        if (txtNewEmployeeNumber.Text != "")
        {
            try
            {
                lblNewEmployeeName.Text = ds.Tables[0].Rows[0]["Name"].ToString();
                hdEmpDOJ.Value = ds.Tables[0].Rows[0]["DOJ"].ToString();
                lbADD.Enabled = true;
            }
            catch (Exception)
            {
                lblNewEmployeeName.Text = Resources.Resource.InvalidEmployee;
                lbADD.Enabled = false;
            }
        }
        else
        {
            lblNewEmployeeName.Text = "";
        }

    }
    protected void btnEmployeeMApping_Click(object sender, EventArgs e)
    {
        LinkButton objLinkButton = (LinkButton)sender;
        GridViewRow row = (GridViewRow)objLinkButton.NamingContainer;
        HiddenField hfAssetMaster = (HiddenField)gvAssetMaster.Rows[row.RowIndex].FindControl("hfAssetMaster");
        LinkButton btnEmployeeMApping = (LinkButton)gvAssetMaster.Rows[row.RowIndex].FindControl("btnEmployeeMApping");
        Label lblAssetCode = (Label)gvAssetMaster.Rows[row.RowIndex].FindControl("lblAssetCode");
        Label LbAssestName = (Label)gvAssetMaster.Rows[row.RowIndex].FindControl("LbAssestName");
        hfAssetCode1.Value = lblAssetCode.Text;
        lblAssetCode2.Text = lblAssetCode.Text;
        lblAssetName2.Text = LbAssestName.Text;
        hfAssetName1.Value = LbAssestName.Text;
        divAllocate.Visible = true;
        divMaster.Visible = false;
        hfAssetCode.Value = hfAssetMaster.Value;
        lblErrorMsg.Text = "";
        FillgvOwnerAllocate(hfAssetCode.Value);
        if (btnEmployeeMApping.Text != "Click Here")
        {
            gvOwnerAllocate.Visible = true;
        }
        else
        {
            gvOwnerAllocate.Visible = false;
        }
    }
    protected void btnupdate_Click(object sender, EventArgs e)
    {
        btnUpdateMapping.Visible = true;
        ddlPost.Enabled = true;
        ddlClientCode.Enabled = true;
        ddlAsmtId.Enabled = true;
        QRCode.Visible = false;
        btnupdate.Visible = false;
        btncancel.Visible = true;
        btnBack.Visible = false;


    }
    protected void btncancel_Click(object sender, EventArgs e)
    {
        ddlClientCode.Enabled = false;
        ddlAsmtId.Enabled = false;
        ddlPost.Enabled = false;
        QRCode.Visible = true;
        btnupdate.Visible = true;
        btnBack.Visible = true;
        btnUpdateMapping.Visible = false;
        btncancel.Visible = false;
        FillAssetClientMapping(hfId.Value);
    }
    protected void btnSearchEmp_Click(object sender, EventArgs e)
    {
        FillgvEmployee();
    }
    protected void btnBackSearchEmp_Click(object sender, EventArgs e)
    {
        divAllocate.Visible = false;
        divMaster.Visible = true;
        gvEmployeeList.Visible = false;
        gvOwnerAllocate.Visible = false;
        FillgvAssetMaster();
    }
    protected void gvEmployeeList_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvEmployeeList.PageIndex = e.NewPageIndex;
        gvEmployeeList.EditIndex = -1;
        FillgvEmployee();
    }
    private void FillgvEmployee()
    {
        var objAssetMgmt = new BL.AssetManagement();
        var dsAssetMaster = new DataSet();
        var dtAssetMaster = new DataTable();
        dtflag = 1;
        try
        {
            dsAssetMaster = objAssetMgmt.GetAllEmployeeByLocation(txtByNo.Text.Trim(), txtByName.Text.Trim(), Convert.ToInt32(BaseLocationAutoID));
            gvEmployeeList.Visible = true;
            gvOwnerAllocate.Visible = true;
            dtAssetMaster = dsAssetMaster.Tables[0];
            if (dtAssetMaster.Rows.Count == 0)
            {
                dtflag = 0;
                dtAssetMaster.Rows.Add(dtAssetMaster.NewRow());
            }
            gvEmployeeList.DataSource = dtAssetMaster;
            gvEmployeeList.DataBind();
            if (dtflag == 0)
            {
                gvEmployeeList.Rows[0].Visible = false;
                dtflag = 0;
            }
            else
            {
                dtflag = 1;
            }
        }
        catch (Exception ex)
        { }
    }
}