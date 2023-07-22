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


public partial class APSInventory_UpdateCPData : BasePage
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
            FillgvAttendence();
        }  
    }
    protected void FillgvAttendence()
    {
     
        var objAssetMgmt = new BL.AssetManagement();
        var ds = new DataSet();
        var dt = new DataTable();
        var dtflag = 1;
        ds = objAssetMgmt.GetCPData(BaseLocationAutoID);
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
          
        }    
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
            Label lblDesignation = (Label)e.Row.FindControl("lblDesignation");
            lblDesignation.ForeColor = System.Drawing.Color.Black;
            lblDesignation.Font.Bold = true;
        
            Label lblShift = (Label)e.Row.FindControl("lblShift");
            lblShift.ForeColor = System.Drawing.Color.Black;
            lblShift.Font.Bold = true;
            Label lblTime = (Label)e.Row.FindControl("lblTime");
            lblTime.ForeColor = System.Drawing.Color.Black;
            lblTime.Font.Bold = true;
           
        }

    }
    protected void gvAttendence_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvAttendence.PageIndex = e.NewPageIndex;
        gvAttendence.EditIndex = -1;
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
        //FillgvAttendence();
        //lblerrormsg.Text = "";
    }
    protected void gvAttendence_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {      
        DataSet ds = new DataSet();
        BL.AssetManagement objsales = new BL.AssetManagement();
        TextBox txtQuantity = (TextBox)gvAttendence.Rows[e.RowIndex].FindControl("txtQuantity");
        TextBox txtDate = (TextBox)gvAttendence.Rows[e.RowIndex].FindControl("txtDate");
        HiddenField HF1 = (HiddenField)gvAttendence.Rows[e.RowIndex].FindControl("HF1");
        HiddenField HF2 = (HiddenField)gvAttendence.Rows[e.RowIndex].FindControl("HF2");
        ds = objsales.UpdateCPData(BaseLocationAutoID,txtQuantity.Text, txtDate.Text,HF1.Value,HF2.Value);
        ClientScript.RegisterStartupScript(this.GetType(), "PopupScript", "alert('Record Updated Sucessfully !! ')", true);
        gvAttendence.EditIndex = -1;
        FillgvAttendence();

         }
    protected void gvAttendence_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        DataSet ds = new DataSet();
        BL.AssetManagement objsales = new BL.AssetManagement();
       HiddenField HF1 = (HiddenField)gvAttendence.Rows[e.RowIndex].FindControl("HF1");
        HiddenField HF2 = (HiddenField)gvAttendence.Rows[e.RowIndex].FindControl("HF2");
        ds = objsales.DeleteCPData(BaseLocationAutoID,  HF1.Value, HF2.Value);
        ClientScript.RegisterStartupScript(this.GetType(), "PopupScript", "alert('Record Deleted Sucessfully !! ')", true);
        gvAttendence.EditIndex = -1;
        FillgvAttendence();
    }
  
}