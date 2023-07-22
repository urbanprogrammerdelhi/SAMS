﻿// ***********************************************************************
// Assembly         :
// Author           : 
// Created          : 09-13-2013
//
// Last Modified By : 
// Last Modified On : 02-17-2014
// ***********************************************************************
// <copyright file="CreatePortalUser.aspx.cs" company="Magnon">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Data;
using System.Web.UI.WebControls;

/// <summary>
/// Class UserManagement_CreatePortalUser
/// </summary>
public partial class UserManagement_CreatePortalUser : BasePage
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
                int virtualDirNameLenght = 0;
                virtualDirNameLenght = int.Parse(System.Web.HttpContext.Current.Request.Url.AbsolutePath.IndexOf(@"/", 1).ToString());
                return IsReadAllowed(System.Web.HttpContext.Current.Request.Url.AbsolutePath.Remove(0, virtualDirNameLenght));
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
                int virtualDirNameLenght = 0;
                virtualDirNameLenght = int.Parse(System.Web.HttpContext.Current.Request.Url.AbsolutePath.IndexOf(@"/", 1).ToString());
                return IsWriteAllowed(System.Web.HttpContext.Current.Request.Url.AbsolutePath.Remove(0, virtualDirNameLenght));
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
                int virtualDirNameLenght = 0;
                virtualDirNameLenght = int.Parse(System.Web.HttpContext.Current.Request.Url.AbsolutePath.IndexOf(@"/", 1).ToString());
                return IsModifyAllowed(System.Web.HttpContext.Current.Request.Url.AbsolutePath.Remove(0, virtualDirNameLenght));
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
                int virtualDirNameLenght = 0;
                virtualDirNameLenght = int.Parse(System.Web.HttpContext.Current.Request.Url.AbsolutePath.IndexOf(@"/", 1).ToString());
                return IsDeleteAllowed(System.Web.HttpContext.Current.Request.Url.AbsolutePath.Remove(0, virtualDirNameLenght));
            }
            catch (Exception ex)
            { throw new Exception("Have not Rights", ex); }
        }
    }

    #endregion

    /// <summary>
    /// Handles the Load event of the Page control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="System.EventArgs" /> instance containing the event data.</param>
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (IsReadAccess)
            {
                var javaScript = new System.Text.StringBuilder();
                javaScript.Append("<script type='text/javascript'>");
                javaScript.Append("window.document.body.onload = function ()");
                javaScript.Append("{\n");
                javaScript.Append("PageTitle('" + Resources.Resource.CreateUser + "');");
                javaScript.Append("};\n");
                javaScript.Append("// -->\n");
                javaScript.Append("</script>");
                Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "BodyLoadUnloadScript", javaScript.ToString());
                //Code Modified By   on 21-May-2012 
                //Purpose: To Select the Fill Methord on the Basis of Selected Value in ddlUserType"
                if (ddlUserType.SelectedValue.Equals("Customer"))
                {
                    FillCustomerCode();
                    Label3.Text = Resources.Resource.CustomerCode;
                }
                else
                {
                    FillEmployeeCode();
                    Label3.Text = Resources.Resource.Employee;
                }
                btnSave.Attributes["onclick"] = "javascript:Timerf('" + lblErrorMsg.ClientID + "');";

                txtloginID.Attributes["onKeyUp"] = "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionCode + ");";
                txtloginID.Attributes["onblur"] = "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionCode + ");";

                txtAccountID.Attributes["onKeyUp"] = "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionCode + ");";
                txtAccountID.Attributes["onblur"] = "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionCode + ");";


                if (Request.QueryString["PortalLoginGuid"] != null)
                {
                    GetPortalUserDetails();
                }
            }
            else
            {
                Response.Redirect("../UserManagement/Home.aspx");
            }
        }
    }

    /// <summary>
    /// Gets portal user details.
    /// </summary>
    private void GetPortalUserDetails()
    {
        var objPortal = new BL.Portal();
        var dt = new DataTable();
        int dtflag = 1;
        dt = objPortal.PortalUserDetailGet(BaseCompanyCode, Request.QueryString["PortalLoginGuid"]).Tables[0];
        if (dt != null)
        {
            //txtPassword.Text = "";
            //txtConfirmPassword.Attributes.Add("value","");
            ddlUserType.SelectedValue = dt.Rows[0]["PortalType"].ToString();
            if (dt.Rows[0]["PortalType"].ToString().Equals("Customer"))
            {
                FillCustomerCode();
                Label3.Text = Resources.Resource.CustomerCode;
            }
            else
            {
                FillEmployeeCode();
                Label3.Text = Resources.Resource.Employee;
            }
            ddlCustomer.SelectedValue = dt.Rows[0]["CustomerCode"].ToString();
            txtAccountID.Text = dt.Rows[0]["AccountID"].ToString();
            txtEmail.Text = dt.Rows[0]["Email"].ToString();
            txtloginID.Text = dt.Rows[0]["LoginID"].ToString();

            txtPassword.Attributes.Add("value", "ChangePasswordPortal");
            txtConfirmPassword.Attributes.Add("value", "ChangePasswordPortal");


            hfPassword.Value = dt.Rows[0]["Password"].ToString();
            txtUserName.Text = dt.Rows[0]["UserName"].ToString();
            CBActive.Checked = bool.Parse(dt.Rows[0]["Active"].ToString());
            ddlUserType.Enabled = false;
            ddlCustomer.Enabled = false;
            txtAccountID.Enabled = false;
            btnSave.Visible = false;
            btnUpdate.Visible = true;
            btnBack.Visible = true;
            HFPortalLoginGuid.Value = Request.QueryString["PortalLoginGuid"];
            FillgvInchargeDetails();
        }
    }

    /// <summary>
    /// Fills the customer code.
    /// </summary>
    private void FillCustomerCode()
    {
        var objSale = new BL.Sales();
        var dsClient = new DataSet();
        dsClient = objSale.ClientsMappedToLocationGet(BaseLocationAutoID, "ALL", "", BaseUserEmployeeNumber, BaseUserIsAreaIncharge, DateTime.Now.ToString("dd-MMM-yyyy"), DateTime.Now.ToString("dd-MMM-yyyy"));
        if (dsClient != null && dsClient.Tables.Count > 0 && dsClient.Tables[0].Rows.Count > 0)
        {
            ddlCustomer.DataSource = dsClient.Tables[0];
            ddlCustomer.DataTextField = "ClientCodeName";
            ddlCustomer.DataValueField = "ClientCode";
            ddlCustomer.DataBind();
        }

    }

    /// <summary>
    /// Fills the Employee list on the basis of LocationAutoID
    /// </summary>
    private void FillEmployeeCode()
    {
        var objHr = new BL.HRManagement();
        var dsEmployee = new DataSet();
        dsEmployee = objHr.EmployeesOfLocationGetAll(BaseLocationCode, BaseHrLocationCode, DateTime.Now.ToString("dd-MMM-yyyy"), DateTime.Now.ToString("dd-MMM-yyyy"));
        if (dsEmployee != null && dsEmployee.Tables.Count > 0 && dsEmployee.Tables[0].Rows.Count > 0)
        {
            ddlCustomer.DataSource = dsEmployee.Tables[0];
            ddlCustomer.DataTextField = "Name";
            ddlCustomer.DataValueField = "EmployeeNumber";
            ddlCustomer.DataBind();
        }

    }

    /// <summary>
    /// Fillgvs the incharge details.
    /// </summary>
    private void FillgvInchargeDetails()
    {
        var objPortal = new BL.Portal();
        var dt = new DataTable();
        int dtflag = 1;
        dt = objPortal.CustomerInchargeDetailGet(HFPortalLoginGuid.Value).Tables[0];
        if (dt != null)
        {
            //to fix empety gridview
            if (dt.Rows.Count == 0)
            {
                dtflag = 0;
                dt.Rows.Add(dt.NewRow());
            }
            gvInchargeDetails.DataSource = dt;
            gvInchargeDetails.DataBind();

            if (dtflag == 0) //to fix empety gridview
            {
                gvInchargeDetails.Rows[0].Visible = false;
            }
        }

    }

    /// <summary>
    /// Fills the incharge drop down.
    /// </summary>
    /// <param name="ddlInchargeId">The DDL incharge id.</param>
    //private void FillIncharge(DropDownList ddlInchargeId)
    //{
    //    //var objHrManagement = new BL.HRManagement();
    //    //var ds = new DataSet();

    //    //ds = objHrManagement.EmployeeNameGetAll(BaseLocationAutoID);

    //     BL.UserManagement objblUserManagement = new BL.UserManagement();
    //    DataSet ds = new DataSet();
    //    ds = objblUserManagement.ChildUserGetAll(BaseUserID, BaseIsAdmin, Resources.Resource.User, Resources.Resource.SuperUser, Resources.Resource.Administrator);
    //    if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
    //    {
    //        ddlInchargeId.DataSource = ds.Tables[0];
    //        ddlInchargeId.DataTextField = "UserName";
    //        ddlInchargeId.DataValueField = "UserID";
    //        ddlInchargeId.DataBind();
    //    }
    //    else
    //    {
    //        var li = new ListItem { Text = Resources.Resource.NoDataToShow, Value = "" };
    //        ddlInchargeId.Items.Add(li);
    //    }

    //}

    /// <summary>
    /// Handles the RowDataBound event of the gvInchargeDetails control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="System.Web.UI.WebControls.GridViewRowEventArgs" /> instance containing the event data.</param>
    protected void gvInchargeDetails_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            var ddlInchargeId = (DropDownList)e.Row.FindControl("ddlInchargeId");
            if (ddlInchargeId != null)
            {
               // FillIncharge(ddlInchargeId);
                var hFInchargeId = (HiddenField)e.Row.FindControl("HFInchargeId");
                if (hFInchargeId != null)
                {
                    ddlInchargeId.SelectedValue = hFInchargeId.Value;
                }
            }


            //IBDeleteTran.Attributes["onclick"] = "javascript:Timerf('" + lblErrorMsg.ClientID.ToString() + "');javascript:return confirm('" + Resources.Resource.MsgConfirmDelete + "');";
        }
        if (e.Row.RowType == DataControlRowType.Footer)
        {
            var ddlInchargeId = (DropDownList)e.Row.FindControl("ddlInchargeId");
            if (ddlInchargeId != null)
            {
              //  FillIncharge(ddlInchargeId);
            }
        }
    }

    /// <summary>
    /// Handles the RowCommand event of the gvInchargeDetails control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="System.Web.UI.WebControls.GridViewCommandEventArgs" /> instance containing the event data.</param>
    protected void gvInchargeDetails_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "Add")
        {
            var ddlInchargeId = (DropDownList)gvInchargeDetails.FooterRow.FindControl("ddlInchargeId");
            var txtEmailId = (TextBox)gvInchargeDetails.FooterRow.FindControl("txtEmailId");
            var txtPhoneNumber = (TextBox)gvInchargeDetails.FooterRow.FindControl("txtPhoneNumber");

            var objPortal = new BL.Portal();
            var dsInsert = new DataSet();
            if (HFPortalLoginGuid != null)
            {
                dsInsert = objPortal.CustomerInchargeDetailInsert(ddlInchargeId.SelectedValue, txtEmailId.Text, txtPhoneNumber.Text, HFPortalLoginGuid.Value, BaseCompanyCode, BaseUserID);

                if (dsInsert != null && dsInsert.Tables.Count > 0 && dsInsert.Tables[0].Rows.Count > 0)
                {
                    DisplayMessage(lblErrorMsg, dsInsert.Tables[0].Rows[0]["MessageID"].ToString());
                }
                FillgvInchargeDetails();
            }
        }

    }

    /// <summary>
    /// Handles the RowUpdating event of the gvInchargeDetails control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="System.Web.UI.WebControls.GridViewUpdateEventArgs" /> instance containing the event data.</param>
    protected void gvInchargeDetails_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        var hFCustomerInchargeGuid = (HiddenField)gvInchargeDetails.Rows[e.RowIndex].FindControl("HFCustomerInchargeGuid");
        var ddlInchargeId = (DropDownList)gvInchargeDetails.Rows[e.RowIndex].FindControl("ddlInchargeId");
        var txtEmailId = (TextBox)gvInchargeDetails.Rows[e.RowIndex].FindControl("txtEmailId");
        var txtPhoneNumber = (TextBox)gvInchargeDetails.Rows[e.RowIndex].FindControl("txtPhoneNumber");
        var objPortal = new BL.Portal();
        var dsUpdate = new DataSet();
        if (hFCustomerInchargeGuid != null)
        {
            dsUpdate = objPortal.CustomerInchargeDetailUpdate(ddlInchargeId.SelectedValue, txtEmailId.Text, txtPhoneNumber.Text, hFCustomerInchargeGuid.Value, BaseUserID);
            if (dsUpdate != null && dsUpdate.Tables.Count > 0 && dsUpdate.Tables[0].Rows.Count > 0)
            {
                DisplayMessage(lblErrorMsg, dsUpdate.Tables[0].Rows[0]["MessageID"].ToString());
            }
            gvInchargeDetails.EditIndex = -1;
            FillgvInchargeDetails();
        }
    }

    /// <summary>
    /// Handles the RowEditing event of the gvInchargeDetails control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="System.Web.UI.WebControls.GridViewEditEventArgs" /> instance containing the event data.</param>
    protected void gvInchargeDetails_RowEditing(object sender, GridViewEditEventArgs e)
    {
        gvInchargeDetails.EditIndex = e.NewEditIndex;
        FillgvInchargeDetails();
    }

    /// <summary>
    /// Handles the RowCancelingEdit event of the gvInchargeDetails control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="System.Web.UI.WebControls.GridViewCancelEditEventArgs" /> instance containing the event data.</param>
    protected void gvInchargeDetails_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        gvInchargeDetails.EditIndex = -1;
        FillgvInchargeDetails();
    }

    /// <summary>
    /// Handles the RowDeleting event of the gvInchargeDetails control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="System.Web.UI.WebControls.GridViewDeleteEventArgs" /> instance containing the event data.</param>
    protected void gvInchargeDetails_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        var hFCustomerInchargeGuid = (HiddenField)gvInchargeDetails.Rows[e.RowIndex].FindControl("HFCustomerInchargeGuid");
        var objPortal = new BL.Portal();
        var dsDelete = new DataSet();
        if (hFCustomerInchargeGuid != null)
        {
            dsDelete = objPortal.CustomerInchargeDetailDelete(hFCustomerInchargeGuid.Value);
            if (dsDelete != null && dsDelete.Tables.Count > 0 && dsDelete.Tables[0].Rows.Count > 0)
            {
                DisplayMessage(lblErrorMsg, dsDelete.Tables[0].Rows[0]["MessageID"].ToString());
            }
            FillgvInchargeDetails();
        }
    }

    /// <summary>
    /// Handles the PageIndexChanging event of the gvInchargeDetails control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="System.Web.UI.WebControls.GridViewPageEventArgs" /> instance containing the event data.</param>
    protected void gvInchargeDetails_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvInchargeDetails.PageIndex = e.NewPageIndex;
        FillgvInchargeDetails();
    }

    /// <summary>
    /// Handles the Click event of the btnSave control to create new Portal Login.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="System.EventArgs" /> instance containing the event data.</param>
    protected void btnSave_Click(object sender, EventArgs e)
    {
        var objPortal = new BL.Portal();
        var dsInsert = new DataSet();
        string keyForEncryption = GetDecryptkey(BaseCountryCode);
        dsInsert = objPortal.PortalUserInsert(ddlUserType.SelectedValue, ddlCustomer.SelectedValue, txtAccountID.Text, txtloginID.Text, txtEmail.Text, txtUserName.Text, txtPassword.Text, CBActive.Checked, BaseCompanyCode, BaseUserID, keyForEncryption);
        if (dsInsert != null && dsInsert.Tables[0].Rows.Count > 0)
        {
            DisplayMessage(lblErrorMsg, dsInsert.Tables[0].Rows[0]["MessageID"].ToString());

            if (dsInsert.Tables[0].Rows[0]["PortalLoginGuid"].ToString() != "")
            {
                HFPortalLoginGuid.Value = dsInsert.Tables[0].Rows[0]["PortalLoginGuid"].ToString();
                FillgvInchargeDetails();
                DisableFields();
                btnSave.Visible = false;
            }
            else
            {
                HFPortalLoginGuid.Value = "";
            }
        }

    }

    /// <summary>
    /// Handles the Click event of the btnBack control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="System.EventArgs" /> instance containing the event data.</param>
    protected void btnBack_Click(object sender, EventArgs e)
    {
        Response.Redirect("../UserManagement/CustomerPortalDetail.aspx");
    }

    /// <summary>
    /// Handles the Click event of the btnUpdate control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="System.EventArgs" /> instance containing the event data.</param>
    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        var objPortal = new BL.Portal();
        var dsUpdate = new DataSet();
        string keyForEncryption = GetDecryptkey(BaseCountryCode);
        dsUpdate = objPortal.PortalUserUpdate(txtAccountID.Text, hfPassword.Value, Request.QueryString["PortalLoginGuid"], txtloginID.Text, txtEmail.Text, txtUserName.Text, txtPassword.Text, CBActive.Checked, BaseCompanyCode, BaseUserID, keyForEncryption);
        if (dsUpdate != null && dsUpdate.Tables[0].Rows.Count > 0)
        {
            DisplayMessage(lblErrorMsg, dsUpdate.Tables[0].Rows[0]["MessageID"].ToString());
            GetPortalUserDetails();
        }
    }

    /// <summary>
    /// Get the  key vlaue from Encrypted file.
    /// </summary>
    /// <param name="strCountry">The STR country.</param>
    /// <returns>Key that we are using to Decrypt the string</returns>
    string GetDecryptkey(string strCountry)
    {
        var objConString = new DL.ConnectionString();
        return objConString.DecryptKeyGet(strCountry);

    }

    /// <summary>
    /// Disables the fields.
    /// </summary>
    private void DisableFields()
    {
        ddlCustomer.Enabled = false;
        ddlUserType.Enabled = false;
        txtAccountID.Enabled = false;
        txtConfirmPassword.Enabled = false;
        txtEmail.Enabled = false;
        txtloginID.Enabled = false;
        txtPassword.Enabled = false;
        txtUserName.Enabled = false;
    }

    /// <summary>
    /// Handles the SelectedIndexChanged event of the ddlUserType control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="System.EventArgs" /> instance containing the event data.</param>
    protected void ddlUserType_SelectedIndexChanged(object sender, EventArgs e)
    {
        if(ddlUserType.SelectedValue.Equals("Customer"))
        {
            FillCustomerCode();
            Label3.Text = Resources.Resource.CustomerCode;
        }
        else
        {
            FillEmployeeCode();
            Label3.Text = Resources.Resource.Employee;
        }
    }
}