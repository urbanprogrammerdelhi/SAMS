using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using AjaxControlToolkit;
using System.IO;

public partial class AssetManagement_AssetCheckList : BasePage
{
    static int dtflag;
    static int dtflag1;
  
    static int Checklistid;
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
    protected void Page_Load(object sender, EventArgs e)
    {
         Page.Form.Attributes.Add("enctype", "multipart/form-data");
         if (!IsPostBack)
         {
             if (IsReadAccess)
             {
                 hfAssetId.Value = (Request.QueryString["AssetId"]);
                 FillServiceType(Convert.ToInt32(hfAssetId.Value));
                 FillDetailsForUpdate(hfAssetId.Value);
                 FillChecklistName(Convert.ToInt32(hfAssetId.Value), ddlServicetype);
                 FillAssetCategory();
                 FillAssetManufacturer();
                 FillAssetSubCategory(Convert.ToInt32(ddlAssetCategory.SelectedValue));

                 if (txtCheccklistname != null)
                 {
                     txtCheccklistname.Attributes.Add("onkeyup", "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionString + ");");
                     txtCheccklistname.Attributes.Add("onblur", "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionString + ");");
                 }
                 if (!IsWriteAccess)
                 {
                    // btnSubmit.Enabled = false;
                     btnSubmit.Visible = false;
                 }
             }
             else
             {
                 Response.Redirect("../UserManagement/Home.aspx");
             }

         }
    }
    private void FillChecklistName(int AssetId, DropDownList ddlServicetype)
    {
        try
        {
            var objAssetMgmt = new BL.AssetManagement();
            var dsChecklistName = new DataSet();
            var dtChecklistName = new DataTable();
            dtflag = 1;
            dsChecklistName = objAssetMgmt.GetChecklistName(AssetId,ddlServicetype.SelectedValue,BaseCompanyCode);
            dtChecklistName = dsChecklistName.Tables[0];
            if (dtChecklistName.Rows.Count == 0)
            {
                dtflag = 0;
                dtChecklistName.Rows.Add(dtChecklistName.NewRow());
            }
            gvAssetChecklistName.DataSource = dtChecklistName;
            gvAssetChecklistName.DataBind();

            if (dtflag == 0)
            {
                gvAssetChecklistName.Rows[0].Visible = false;
                gvAssetChecklistName.HeaderRow.Visible = false;
                dtflag = 0;
            }
            else
            {
                dtflag = 1;
            }
            if (dsChecklistName.Tables[0].Rows[0]["AssetCheckListAutoId"].ToString() != string.Empty)
            {
                if (Checklistid != null)
                {
                    Checklistid = Convert.ToInt32( dsChecklistName.Tables[0].Rows[0]["AssetCheckListAutoId"].ToString());
                }
                FillgvAssetChecklistNameDetail(Checklistid);
                PanelAssetChecklistNameDetail.Visible = true;
            }

        }
        catch (Exception ex)
        {
        }

    }
    //private void FillChecklistName(int AssetId)
    //{
    //    var objAssetManagement = new BL.AssetManagement();
    //    CBLCheckListName.DataSource = objAssetManagement.GetChecklistName(AssetId);
    //    CBLCheckListName.DataTextField = "CheckListName";
    //    CBLCheckListName.DataValueField = "CheckListName";
    //    CBLCheckListName.DataBind();
    //    //if (CBLCheckListName.SelectedValue == "")
    //    //{
    //    //    var li = new ListItem { Text = Resources.Resource.NoData, Value = @"0" };
    //    //    CBLCheckListName.Items.Add(li);

    //    //}
      

    //}
    private void  FillAssetSubCategory(int AssetId)
    {
        var objAssetManagement = new BL.AssetManagement();
        ddlAssetSubCategory.DataSource = objAssetManagement.AssetSubCategoryDetailGet(AssetId,BaseCompanyCode);
        ddlAssetSubCategory.DataTextField = "AssetSubCategoryName";
        ddlAssetSubCategory.DataValueField = "AssetSubCategoryAutoId";
        ddlAssetSubCategory.DataBind();
        if (ddlAssetSubCategory.SelectedValue == "")
        {
            var li = new ListItem { Text = Resources.Resource.NoData, Value = @"0" };
            ddlAssetSubCategory.Items.Add(li);

        }


    }
    private void FillServiceType(int AssetId)
    {
        var objAssetManagement = new BL.AssetManagement();
        ddlServicetype.DataSource = objAssetManagement.AssetServiceTypeGet(AssetId,BaseCompanyCode);
        ddlServicetype.DataTextField = "AssetServiceTypename";
        ddlServicetype.DataValueField = "AssetServiceTypeAutoId";
        ddlServicetype.DataBind();
        if (ddlServicetype.SelectedValue == "")
        {
            var li = new ListItem { Text = Resources.Resource.NoData, Value = @"0" };
            ddlServicetype.Items.Add(li);

        }

    
    }
    private void FillAssetManufacturer()
    {
        var objAssetManagement = new BL.AssetManagement();
        ddlAssetManufacture.DataSource = objAssetManagement.AssetManufactureDetailGet(BaseCompanyCode);
        ddlAssetManufacture.DataTextField = "ManufacturerName";
        ddlAssetManufacture.DataValueField = "ManufacturerAutoID";
        ddlAssetManufacture.DataBind();
        if (ddlAssetManufacture.SelectedValue == "")
        {
            var li = new ListItem { Text = Resources.Resource.NoData, Value = @"0" };
            ddlAssetManufacture.Items.Add(li);
            //  btnSave.Enabled = false;
        }


    }
    private void FillDetailsForUpdate(string AssetId)
    {
        var objAssetMgmt = new BL.AssetManagement();


        var ds = objAssetMgmt.AssetMasterDetailForUpdate(AssetId,BaseCompanyCode);
        try
        {
            txtAssetCode.Text = ds.Tables[0].Rows[0]["AssetCode"].ToString();
            txtAssetName.Text = ds.Tables[0].Rows[0]["AssetName"].ToString();
            ddlAssetCategory.SelectedValue = ds.Tables[0].Rows[0]["AssetCategoryAutoId"].ToString();
            ddlAssetSubCategory.SelectedValue = ds.Tables[0].Rows[0]["AssetSubCategoryAutoId"].ToString();
            ddlAssetManufacture.SelectedValue = ds.Tables[0].Rows[0]["ManufacturerAutoID"].ToString();
            txtModelNo.Text = ds.Tables[0].Rows[0]["ModelNo"].ToString();
            txtModelName.Text = ds.Tables[0].Rows[0]["ModelName"].ToString();
            txtSerialNo.Text = ds.Tables[0].Rows[0]["SerialNo"].ToString();
            txtDescription.Text = ds.Tables[0].Rows[0]["Description"].ToString();
           

        }
        catch (Exception ex)
        { }
    }
    private void FillAssetCategory()
    {
        var objAssetManagement = new BL.AssetManagement();
        ddlAssetCategory.DataSource = objAssetManagement.AssetCategoryDetailGet(BaseCompanyCode);
        ddlAssetCategory.DataTextField = "AssetCategoryName";
        ddlAssetCategory.DataValueField = "AssetCategoryAutoId";
        ddlAssetCategory.DataBind();
        if (ddlAssetCategory.SelectedValue == "")
        {
            var li = new ListItem { Text = Resources.Resource.NoData, Value = @"0" };
            ddlAssetCategory.Items.Add(li);

        }


    }
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        var toolkitScriptManager1 = (System.Web.UI.ScriptManager)Master.FindControl("ToolkitScriptManager1");
        var ds = new DataSet();
        var objAssetMgmt = new BL.AssetManagement();
        try
        {if(ddlServicetype.SelectedValue=="0")
        {
            lblChecklistNameError.Text = Resources.Resource.SelectServiceType;
        }
        else
        { 
            ds = objAssetMgmt.AssetChecklistNameInsert(Convert.ToInt32( hfAssetId.Value),Convert.ToInt32( ddlServicetype.SelectedValue),txtCheccklistname.Text, BaseUserID,BaseCompanyCode);
            DisplayMessage(lblChecklistNameError, ds.Tables[0].Rows[0]["MessageId"].ToString());
            txtCheccklistname.Text = "";
        }
        }
        catch(Exception ex)
        { }
        FillChecklistName(Convert.ToInt32(hfAssetId.Value),ddlServicetype);
    }
    protected void btnack_Click(object sender, EventArgs e)
    {
        Response.Redirect("AssetMaster.aspx");
    }
    protected void lbChecklistName_Click(object sender, EventArgs e)
    {
        LinkButton lbChecklistName = sender as LinkButton;
        GridViewRow row = (GridViewRow)lbChecklistName.NamingContainer;
        HiddenField hfAssetCheckListAutoId = (HiddenField)row.FindControl("hfAssetCheckListAutoId");
        Checklistid = Convert.ToInt32(hfAssetCheckListAutoId.Value);
        FillgvAssetChecklistNameDetail(Convert.ToInt32(hfAssetCheckListAutoId.Value));
        PanelAssetChecklistNameDetail.Visible = true;
        
    }
    private void FillgvAssetChecklistNameDetail(int ChecklistId)
    {
        try
        {
            var objAssetMgmt = new BL.AssetManagement();
            var dsChecklistNameItems = new DataSet();
            var dtChecklistNameItems = new DataTable();
            dtflag1 = 1;
            dsChecklistNameItems = objAssetMgmt.GetChecklistNameItems(ChecklistId,BaseCompanyCode);
            dtChecklistNameItems = dsChecklistNameItems.Tables[0];
            if (dtChecklistNameItems.Rows.Count == 0)
            {
                dtflag1 = 0;
                dtChecklistNameItems.Rows.Add(dtChecklistNameItems.NewRow());
            }
            gvAssetChecklistNameDetail.DataSource = dtChecklistNameItems;
            gvAssetChecklistNameDetail.DataBind();

            if (dtflag1 == 0)
            {
                gvAssetChecklistNameDetail.Rows[0].Visible = false;
               // gvAssetChecklistName.HeaderRow.Visible = false;
                dtflag1 = 0;
            }
            else
            {
                dtflag1 = 1;
            }

        }
        catch (Exception ex)
        {
        }

    }
    protected void gvAssetChecklistNameDetail_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        gvAssetChecklistNameDetail.EditIndex = -1;
        FillgvAssetChecklistNameDetail(Checklistid);
    }
    protected void gvAssetChecklistNameDetail_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        var toolkitScriptManager1 = (System.Web.UI.ScriptManager)Master.FindControl("ToolkitScriptManager1");
        var ds = new DataSet();
        var objAssetMgmt = new BL.AssetManagement();
        var hfAssetCheckListDetailAutoId = (HiddenField)gvAssetChecklistNameDetail.Rows[e.RowIndex].FindControl("hfAssetCheckListDetailAutoId");
        var txtChecklistNameDetail = (TextBox)gvAssetChecklistNameDetail.Rows[e.RowIndex].FindControl("txtChecklistNameDetail");
          try
            {
                ds = objAssetMgmt.ChecklistItemNameUpdate(Convert.ToInt32(hfAssetCheckListDetailAutoId.Value), txtChecklistNameDetail.Text, BaseUserID,BaseCompanyCode);
                DisplayMessage(lblChecklistDetail, ds.Tables[0].Rows[0]["MessageId"].ToString());
                gvAssetChecklistNameDetail.EditIndex = -1;
                FillgvAssetChecklistNameDetail(Checklistid);
            }
            catch (Exception ex)
            { }

    }
    protected void gvAssetChecklistNameDetail_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        var ds = new DataSet();
      
        var objAssetMgmt = new BL.AssetManagement();
        var hfAssetCheckListDetailAutoId = (HiddenField)gvAssetChecklistNameDetail.Rows[e.RowIndex].FindControl("hfAssetCheckListDetailAutoId");
        ds = objAssetMgmt.ChecklistItemNameDelete(Convert.ToInt32(hfAssetCheckListDetailAutoId.Value),BaseCompanyCode);
        DisplayMessage(lblChecklistDetail, ds.Tables[0].Rows[0]["MessageId"].ToString());
        gvAssetChecklistNameDetail.EditIndex = -1;
        FillgvAssetChecklistNameDetail(Checklistid);
    }
    protected void gvAssetChecklistNameDetail_RowEditing(object sender, GridViewEditEventArgs e)
    {
        gvAssetChecklistNameDetail.EditIndex = e.NewEditIndex;
        FillgvAssetChecklistNameDetail(Checklistid);
    }
    protected void gvAssetChecklistNameDetail_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvAssetChecklistNameDetail.PageIndex = e.NewPageIndex;
        gvAssetChecklistNameDetail.EditIndex = -1;
        FillgvAssetChecklistNameDetail(Checklistid);
    }
    protected void gvAssetChecklistNameDetail_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        var toolkitScriptManager1 = (System.Web.UI.ScriptManager)Master.FindControl("ToolkitScriptManager1");
        var ds = new DataSet();
        var objAssetMgmt = new BL.AssetManagement();
      //  var hfAssetCheckListNameAutoId = (HiddenField)gvAssetChecklistNameDetail.FooterRow.FindControl("hfAssetCheckListNameAutoId");

        var txtChecklistNameDetail = (TextBox)gvAssetChecklistNameDetail.FooterRow.FindControl("txtChecklistNameDetail");

        if (e.CommandName == "AddNew")
        {
            try
            {
                ds = objAssetMgmt.ChecklistItemNameInsert(Checklistid, txtChecklistNameDetail.Text, BaseUserID,BaseCompanyCode);
                DisplayMessage(lblChecklistDetail, ds.Tables[0].Rows[0]["MessageId"].ToString());
                txtChecklistNameDetail.Text = "";

                FillgvAssetChecklistNameDetail(Checklistid);
            }
            catch (Exception ex)
            { }

        }
        if (e.CommandName == "Reset")
        {
            txtChecklistNameDetail.Text = "";
        }

    }
    protected void gvAssetChecklistNameDetail_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            if (!IsDeleteAccess)
            {
                var IBDeleteTran = (ImageButton)e.Row.FindControl("IBDeleteTran");
                if (IBDeleteTran != null)
                {
                    IBDeleteTran.Visible = false;
                }

            }
            if (!IsModifyAccess)
            {
                var IBEditTran = (ImageButton)e.Row.FindControl("IBEditTran");
                if (IBEditTran != null)
                    IBEditTran.Visible = false;

            }
            //var txtChecklistNameDetail = (TextBox)e.Row.FindControl("txtChecklistNameDetail");
            //if (txtChecklistNameDetail != null)
            //{
            //    txtChecklistNameDetail.Attributes.Add("onkeyup", "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionString + ");");
            //    txtChecklistNameDetail.Attributes.Add("onblur", "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionString + ");");
            //}
        }
        if (e.Row.RowType == DataControlRowType.Footer)
        {
            if (IsWriteAccess)
            {
                //var txtChecklistNameDetail = (TextBox)e.Row.FindControl("txtChecklistNameDetail");
                //if (txtChecklistNameDetail != null)
                //{
                //    txtChecklistNameDetail.Attributes.Add("onkeyup", "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionString + ");");
                //    txtChecklistNameDetail.Attributes.Add("onblur", "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionString + ");");
                //}
            } 
             else
             {
                 var lbADD = (ImageButton)e.Row.FindControl("lbADD");
                 if (lbADD != null)
                 {
                     lbADD.Visible = false;
                     gvAssetChecklistNameDetail.ShowFooter = false;
                 }
             }
        }

    }
    protected void ddlServicetype_SelectedIndexChanged(object sender, EventArgs e)
    {
        FillChecklistName(Convert.ToInt32(hfAssetId.Value), ddlServicetype);
        PanelAssetChecklistNameDetail.Visible = true;
      
    }
    protected void gvAssetChecklistName_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvAssetChecklistName.PageIndex = e.NewPageIndex;
        gvAssetChecklistName.EditIndex = -1;
        FillChecklistName(Convert.ToInt32(hfAssetId.Value), ddlServicetype);
    }
}