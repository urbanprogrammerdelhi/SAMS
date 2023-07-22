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


public partial class GeoFenceSetup_InsertLatLong : BasePage
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
        if(!IsPostBack)
        {
            lblmsg.Visible = false;
            FillddlClientcode();

        }
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
                FilltxtLatlong();



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

    protected void FilltxtLatlong()
    {
        DataSet ds = new DataSet();
        BL.Sales objsales = new BL.Sales();

        ds = objsales.GetLatlong(BaseLocationAutoID,ddlclientcode.SelectedItem.Value);
        if (ds.Tables[0].Rows.Count !=0)
        {
            txtLatitude.Text = ds.Tables[0].Rows[0]["Latitude"].ToString();
        
        txtLong.Text = ds.Tables[0].Rows[0]["Longitude"].ToString();
        }

    }

    protected void ddlclientcode_SelectedIndexChanged(object sender, EventArgs e)
    {
        FilltxtLatlong();
    }

    protected void btnupdate_Click(object sender, EventArgs e)
    {
        lblmsg.Visible = true;
        var ds = new DataSet();
        var objAssetMgmt = new BL.AssetManagement();

        ds = objAssetMgmt.UpdateLatLong(BaseLocationAutoID, ddlclientcode.SelectedItem.Value, txtLatitude.Text, txtLong.Text);
        lblmsg.Text = "Geo Location Updated Sucessfully";

    }
}