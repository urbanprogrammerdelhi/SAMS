﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using AjaxControlToolkit;


public partial class SMCL_BreakFixRequests : BasePage
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
                if (!IsWriteAccess)
                {

                }
                FillgvAssetMaster();
            }
            else
            {
                Response.Redirect("../UserManagement/Home.aspx");
            }


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
            dsAssetMaster = objAssetMgmt.GetbreakFixSMCL(Convert.ToInt32(BaseLocationAutoID));
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
    protected void gvAssetMaster_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        DataSet ds = new DataSet();
        GridViewRow objGridViewRow = e.Row;
        Label lblSerialNo = (Label)objGridViewRow.FindControl("lblSerialNo");
        if (lblSerialNo != null)
        {
            int serialNo = gvAssetMaster.PageIndex * gvAssetMaster.PageSize + int.Parse(objGridViewRow.RowIndex.ToString());
            lblSerialNo.Text = Convert.ToString((serialNo + 1));
        }

        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            HiddenField hfScheduleStatus = (HiddenField)e.Row.FindControl("hfScheduleStatus");
            LinkButton btnschedule = (LinkButton)e.Row.FindControl("btnschedule");

            Label Status = (Label)e.Row.FindControl("LbAssestName1131");
            Status.Font.Bold = true;
            if (Status.Text == "Open")
            {
                Status.ForeColor = System.Drawing.Color.Red;
              
            }
            else
                Status.ForeColor = System.Drawing.Color.Green;


            if (hfScheduleStatus.Value == "0")
            {
                btnschedule.Visible = true;
            }
            else
            {
                btnschedule.Visible = false;
            }

        }
    }

    protected void gvAssetMaster_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvAssetMaster.PageIndex = e.NewPageIndex;
        gvAssetMaster.EditIndex = -1;
        FillgvAssetMaster();
    }


    protected void btnschedule_Click(object sender, EventArgs e)
    {
        divSchedule.Visible = true;
        gvAssetMaster.Visible = false;
        ddlEmp.Enabled = true;
        lblerror.Text = "";
        LinkButton objLinkButton = (LinkButton)sender;
        GridViewRow row = (GridViewRow)objLinkButton.NamingContainer;
        HiddenField hfAutoID = (HiddenField)gvAssetMaster.Rows[row.RowIndex].FindControl("hfAutoID");
        var objAssetMgmt = new BL.AssetManagement();
        var ds = objAssetMgmt.GetBreakfixDetailsSMCL(Convert.ToInt32(hfAutoID.Value),Convert.ToInt32(BaseLocationAutoID));
        lblid.Text = ds.Tables[0].Rows[0]["AutoID"].ToString();
        txtfloor.Text = ds.Tables[0].Rows[0]["Floor"].ToString();
            txtCategory.Text = ds.Tables[0].Rows[0]["RequestType"].ToString();
            txtAssetCode.Text = ds.Tables[0].Rows[0]["Asset"].ToString();
            txtAssetName.Text = ds.Tables[0].Rows[0]["AssetName"].ToString();
            txtProblem.Text = ds.Tables[0].Rows[0]["Problem"].ToString();
            FillddlEmp();

    }

    protected void btnScheduleemp_Click(object sender, EventArgs e)
    {
        var ds = new DataSet();
        var objAssetMgmt = new BL.AssetManagement();
        ds = objAssetMgmt.ScheduleEmpSMCL(Convert.ToInt32(lblid.Text), Convert.ToInt32(BaseLocationAutoID),ddlEmp.SelectedItem.Value);
        ddlEmp.Enabled = false;
        lblerror.Text = "Employee Schedule Sucessfully !!";
        }

    protected void btnBack_Click(object sender, EventArgs e)
    {
        divSchedule.Visible = false;
        gvAssetMaster.Visible = true;
        FillgvAssetMaster();
    }

    private void FillddlEmp()
    {
        try
        {
            var objAssetMgmt = new BL.AssetManagement();
            var dsAssetMaster = new DataSet();
            var dtAssetMaster = new DataTable();
            dtflag = 1;
            dsAssetMaster = objAssetMgmt.GetEmpSMCL(Convert.ToInt32(BaseLocationAutoID));
            dtAssetMaster = dsAssetMaster.Tables[0];
            ddlEmp.DataSource = dtAssetMaster;
            ddlEmp.DataTextField = "EmpDetails";
            ddlEmp.DataValueField = "EmployeeCode";
            ddlEmp.DataBind();
        }
        catch (Exception ex)
        {
        }
    }
}