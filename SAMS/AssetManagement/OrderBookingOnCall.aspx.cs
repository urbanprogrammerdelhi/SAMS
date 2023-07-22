using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class AssetManagement_OrderBookingOnCall : BasePage
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        //if (txtSearchMobile.Text != "")
        //{
        //    var objSale = new BL.AssetManagement();
        //    DataSet ds = objSale.SearchCustomer(txtSearchMobile.Text, BaseLocationAutoID);
        //    if (ds.Tables[0].Rows[0]["MessgaeId"].ToString() == "1")
        //    {
        //        Readonly();
        //        txtName.Text = ds.Tables[0].Rows[0]["ClientName"].ToString();
        //        txtAddress.Text = ds.Tables[0].Rows[0]["ClientAddress"].ToString();
        //        txtMobile.Text = ds.Tables[0].Rows[0]["Phone"].ToString();
        //        ddlQuerytype.SelectedItem.Value = ds.Tables[0].Rows[0]["City"].ToString();
        //        lblCustMsg.Text = "Customer Exists";
        //        hfMobile.Value = "1";
        //    }
        //    else
        //    {
        //        hfMobile.Value = "0";
        //        Readonlytrue();
        //        Reset();
        //        EnableDisableTimeSlots();
        //        txtMobile.Text = txtSearchMobile.Text;
        //        lblCustMsg.Text = "Customer Not Exists";
        //        txtAddress.Text = "";
        //        txtName.Text = "";
        //        txtMobile.Text = "";

        //    }
        //}
        //else
        //{
        //    lblCustMsg.Text = "Please Enter Customer Id";
        //}

    }
    protected void btnsubmit_Click(object sender, EventArgs e)
    {

    }
}