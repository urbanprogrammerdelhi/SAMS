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
using System.Data.SqlClient;
using System.IO;
using System.Configuration;


public partial class GeoFenceSetup_MapEmp : BasePage
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
            lblmsg.Visible = false;
            FillgvAttendence();
            FillddlClientcode();

        }
    }
    protected void btnmap_Click(object sender, EventArgs e)
    {
        lblmsg.Visible = true;
        var ds = new DataSet();
        var objAssetMgmt = new BL.AssetManagement();

        ds = objAssetMgmt.insertempmapping(BaseLocationAutoID,  txtempcode.Text, ddlclientcode.SelectedItem.Value);
        lblmsg.Text = "Employee Mapped Sucessfully";
        txtempcode.Text = "";
     
        FillgvAttendence();

    }
    protected void FillddlClientcode()
    {
        DataSet ds = new DataSet();
        BL.Sales objsales = new BL.Sales();

        ds = objsales.ClientsLocationWiseGet(BaseLocationAutoID);

        if (ds != null)
        {
            if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                ddlclientcode.DataSource = ds.Tables[0];
                ddlclientcode.DataTextField = "ClientNameCode";
                ddlclientcode.DataValueField = "ClientCode";
                ddlclientcode.DataBind();
             


            }
            else
            {
                ListItem li = new ListItem();
                li.Text = Resources.Resource.NoData;
                li.Value = "0";
                ddlclientcode.Items.Add(li);
            }
        }
        else
        {
            ListItem li = new ListItem();
            li.Text = Resources.Resource.NoData;
            li.Value = "0";
            ddlclientcode.Items.Add(li);
        }
    }
    protected void FillgvAttendence()
    {
      
        var objAssetMgmt = new BL.Sales();
        var ds = new DataSet();
        var dt = new DataTable();
  
        ds = objAssetMgmt.getmappedempdetails(BaseLocationAutoID);
        dt = ds.Tables[0];

        if (dt.Rows.Count == 0)
        {         
            dt.Rows.Add(dt.NewRow());
        }

        

        gvAttendence.DataSource = dt;
        gvAttendence.DataBind();

      

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
    }

    protected void gvAttendence_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvAttendence.PageIndex = e.NewPageIndex;
        gvAttendence.EditIndex = -1;
        FillgvAttendence();
    }

    protected void gvAttendence_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        DataSet ds = new DataSet();
        BL.Sales objsales = new BL.Sales();
        HiddenField hfShiftCodevalue = (HiddenField)gvAttendence.Rows[e.RowIndex].FindControl("hfShiftCodevalue");
        ds = objsales.deleteempmapping(BaseLocationAutoID,  hfShiftCodevalue.Value);
        lblmsg.Text = "Mapping Deleted Sucessfully !!";
        FillgvAttendence();
    }

    protected void gvAttendence_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        gvAttendence.EditIndex = -1;
        FillgvAttendence();
    }

    protected void gvAttendence_RowEditing(object sender, GridViewEditEventArgs e)
    {
        gvAttendence.EditIndex = e.NewEditIndex;
        FillgvAttendence();
    }

    protected void gvAttendence_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
     
        DataSet ds = new DataSet();
        BL.Sales objsales = new BL.Sales();
        TextBox txtEmployeeNumber = (TextBox)gvAttendence.Rows[e.RowIndex].FindControl("txtEmployeeNumber");
        Label txtEmployeeName = (Label)gvAttendence.Rows[e.RowIndex].FindControl("txtEmployeeName");
        HiddenField hfShiftCodevalue = (HiddenField)gvAttendence.Rows[e.RowIndex].FindControl("hfShiftCodevalue");
        ds = objsales.updateempmapping(BaseLocationAutoID,txtEmployeeNumber.Text,txtEmployeeName.Text,hfShiftCodevalue.Value);
        lblmsg.Text = "Mapping Updated Sucessfully !!";
        gvAttendence.EditIndex = -1;
        FillgvAttendence();

    }
}