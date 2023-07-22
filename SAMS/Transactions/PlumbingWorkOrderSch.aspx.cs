﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Transactions_PlumbingWorkOrderSch : BasePage
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

    #endregion
    protected void Page_Load(object sender, EventArgs e)
    {
        //GoogleMapForASPNet1.PushpinDrag += new UserControls_GoogleMapForASPNet.PushpinDragHandler(OnPushpinDrag);

        if(!IsPostBack)
        {
            //GoogleMapForASPNet1.GoogleMapObject.APIKey = System.Configuration.ConfigurationManager.AppSettings["GoogleAPIKey"];
            //GoogleMapForASPNet1.GoogleMapObject.Width = "1050px";
            //GoogleMapForASPNet1.GoogleMapObject.Height = "500px";
            //GoogleMapForASPNet1.GoogleMapObject.ZoomLevel = 14;

            if (IsReadAccess)
            {
                if (Request.QueryString["WorkOrderAutoId"] != null)
                {
                    hfWorkOrderAutoId.Value = Request.QueryString["WorkOrderAutoId"];
                }
                if (Request.QueryString["OrderStatus"] != null)
                {
                    lblStatus.Text = Request.QueryString["OrderStatus"];
                }
                if (Request.QueryString["WorkOrderNo"] != null)
                {
                    lblWorkOrderNo.Text = Request.QueryString["WorkOrderNo"];
                    FillWorkOrderDetails();
                }
                
            }
            else
            {
                Response.Redirect("../UserManagement/Home.aspx");
            }
        }
    }

    protected void FillWorkOrderDetails()
    {
        DataSet ds = new DataSet();
        BL.Sales objSales = new BL.Sales();
        ds = objSales.WorkOrderDetailGetByWoNo(lblWorkOrderNo.Text);
        if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
        {
            lblPreferredDate.Text = DateFormat(ds.Tables[0].Rows[0]["PreferredFromDate"].ToString());
            lblOrderDate.Text = DateFormat(ds.Tables[0].Rows[0]["WorkOrderDate"].ToString());
            lblStatus.Text = ds.Tables[0].Rows[0]["Status"].ToString();
            lblTimeSlot.Text = ds.Tables[0].Rows[0]["PreferredFromTime"].ToString();
            lblService.Text = ds.Tables[0].Rows[0]["ServiceCategoryName"].ToString();
            hfServiceAutoId.Value = ds.Tables[0].Rows[0]["ServiceAutoId"].ToString();
            lblPrice.Text = ds.Tables[0].Rows[0]["Price"].ToString();
            lblClientCode.Text = ds.Tables[0].Rows[0]["UserId"].ToString();
            lblClientName.Text = ds.Tables[0].Rows[0]["UserName"].ToString();
            lblAddress.Text = ds.Tables[0].Rows[0]["UserAddress"].ToString();
            hfAddress.Value = ds.Tables[0].Rows[0]["Locality"].ToString() + ", " + ds.Tables[0].Rows[0]["CityName"].ToString(); ;

            if(ds.Tables[0].Rows[0]["Status"].ToString().ToUpper() == "NEW".ToUpper()
                || ds.Tables[0].Rows[0]["Status"].ToString().ToUpper() == "BREAKDOWN".ToUpper()
                || ds.Tables[0].Rows[0]["Status"].ToString().ToUpper() == "ONHOLD".ToUpper())
            {
                btnSaveSchedule.Visible = true;
                gvSelectEmployee.Visible = true;
                FillgvSelectEmployee();
            }
            else
            {
                btnSaveSchedule.Visible = false;
                gvSelectEmployee.Visible = false;
            }
        }

        ds = new DataSet();
        ds = objSales.PlumbingScheduleGetByWoNo(lblWorkOrderNo.Text);
        if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
        {
            lblSchEmployeeNumber.Text = ds.Tables[0].Rows[0]["EmployeeNumber"].ToString(); ;
            lblSchEmployeeName.Text = ds.Tables[0].Rows[0]["EmployeeName"].ToString(); ;
        }
        //DataSet dsTS = new DataSet();
        //Plumbing objP = new Plumbing();
        //dsTS = objP.GetTimeSlotDetailDs(BaseCountryCode);
        //if (dsTS != null && dsTS.Tables.Count > 0 && dsTS.Tables[0].Rows.Count > 0)
        //{
        //    cbTimeSlot1.Text = dsTS.Tables[0].Rows[0]["TimeSlot"].ToString();
        //    cbTimeSlot2.Text = dsTS.Tables[0].Rows[1]["TimeSlot"].ToString();
        //    cbTimeSlot3.Text = dsTS.Tables[0].Rows[2]["TimeSlot"].ToString();
        //    cbTimeSlot4.Text = dsTS.Tables[0].Rows[3]["TimeSlot"].ToString();
        //}
    }
    protected void btnSaveSchedule_Click(object sender, EventArgs e)
    {
        DataSet ds = new DataSet();
        BL.Sales objSales = new BL.Sales();
        //workOrderAutoId, workOrderNo, employeeNumber, schDate, schTimeSlot, modifiedBy
        if (hfWorkOrderAutoId.Value != string.Empty && lblWorkOrderNo.Text != string.Empty && lblSchEmployeeNumber.Text != string.Empty && lblPreferredDate.Text != string.Empty && lblTimeSlot.Text != string.Empty)
        {
            ds = objSales.PlumbingScheduleInsert(hfWorkOrderAutoId.Value, lblWorkOrderNo.Text, lblSchEmployeeNumber.Text, lblPreferredDate.Text, lblTimeSlot.Text, BaseUserID);
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                lblError.Text = ds.Tables[0].Rows[0][0].ToString();
            }
         
        }
        else
        {
            lblError.Text = "Can't Schedule without required Information";
        }
        FillWorkOrderDetails();
    }

    protected void FillgvSelectEmployee()
    {
        DataSet ds = new DataSet();
        BL.Sales objSales = new BL.Sales();
        ds = objSales.SutableEmployeeForWorkOrderGet(lblWorkOrderNo.Text);
        if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
        {
            gvSelectEmployee.Visible = true;
            gvSelectEmployee.DataSource = ds;
            gvSelectEmployee.DataBind();
        }
        else
        {
            lblError.Text = Resources.Resource.NoRecordFound;
            gvSelectEmployee.Visible = false;
        }
    }
    protected void gvSelectEmployee_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvSelectEmployee.PageIndex = e.NewPageIndex;
        gvSelectEmployee.EditIndex = -1;
        FillgvSelectEmployee();
    }

    #region Scheduling Ver1
    protected void txtEmployeeNumber_TextChanged(object sender, EventArgs e)
    {
    }
    protected void txtEmployeeName_TextChanged(object sender, EventArgs e)
    {
       
    }

    #region Ajax AutoCompleteExtender
    [System.Web.Script.Services.ScriptMethod()]
    [System.Web.Services.WebMethod]
    public static List<string> SearchEmployeeNumber(string prefixText)
    {
        Transactions_PlumbingWorkOrderSch EmpNoobj = new Transactions_PlumbingWorkOrderSch();
        List<string> list = EmpNoobj.SearchEmployeeNumberGet(prefixText);
        return list;
    }

    public List<string> SearchEmployeeNumberGet(string prefixText)
    {
        PlumbingEngineerApp PeAppobj = new PlumbingEngineerApp();
        List<string> list = PeAppobj.SearchEmployeeNumber(BaseCountryCode, prefixText);
        return list;
    }

    [System.Web.Script.Services.ScriptMethod()]
    [System.Web.Services.WebMethod]
    public static List<string> SearchEmployeeName(string prefixText)
    {
       Transactions_PlumbingWorkOrderSch EmpNoobj = new Transactions_PlumbingWorkOrderSch();
        List<string> list = EmpNoobj.SearchEmployeeNameGet(prefixText);
        return list;
    }

    public List<string> SearchEmployeeNameGet(string prefixText)
    {
        PlumbingEngineerApp PeAppobj = new PlumbingEngineerApp();
        List<string> list = PeAppobj.SearchEmployeeName(BaseCountryCode, prefixText);
        return list;
    }
    #endregion

    #endregion Scheduling Ver1
    protected void rbSelectEmployee_CheckedChanged(object sender, EventArgs e)
    {
        CheckBox objCheckBox = (CheckBox)sender;
        GridViewRow row = (GridViewRow)objCheckBox.NamingContainer;
        var lblEmployeeNumber = (Label)gvSelectEmployee.Rows[row.RowIndex].FindControl("lblEmployeeNumber");
        var lblEmployeeName = (Label)gvSelectEmployee.Rows[row.RowIndex].FindControl("lblEmployeeName");

        lblSchEmployeeNumber.Text = lblEmployeeNumber.Text;
        lblSchEmployeeName.Text = lblEmployeeName.Text;
    }
}