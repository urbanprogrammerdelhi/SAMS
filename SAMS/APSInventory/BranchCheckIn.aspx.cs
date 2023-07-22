using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AjaxControlToolkit;


public partial class APSInventory_BranchCheckIn : BasePage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            FillddlHUB();
            FillddlDistrict(ddlHub.SelectedItem.Value);
            FillddlCity(ddlHub.SelectedItem.Value, ddlDistrict.SelectedItem.Value);
            Fillddllocation(ddlHub.SelectedItem.Value, ddlDistrict.SelectedItem.Value, ddlCity.SelectedItem.Value);
        }


        if (txtqty1 != null)
        {
            txtqty1.Attributes.Add("onkeyup", "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionNum + ");");
            txtqty1.Attributes.Add("onblur", "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionNum + ");");
        }
        if (txtqty2 != null)
        {
            txtqty2.Attributes.Add("onkeyup", "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionNum + ");");
            txtqty2.Attributes.Add("onblur", "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionNum + ");");
        }
        if (txtqty3 != null)
        {
            txtqty3.Attributes.Add("onkeyup", "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionNum + ");");
            txtqty3.Attributes.Add("onblur", "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionNum + ");");
        }
        if (txtqty4 != null)
        {
            txtqty4.Attributes.Add("onkeyup", "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionNum + ");");
            txtqty4.Attributes.Add("onblur", "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionNum + ");");
        }
        if (txtqty5 != null)
        {
            txtqty5.Attributes.Add("onkeyup", "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionNum + ");");
            txtqty5.Attributes.Add("onblur", "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionNum + ");");
        }
        if (txtqty6 != null)
        {
            txtqty6.Attributes.Add("onkeyup", "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionNum + ");");
            txtqty6.Attributes.Add("onblur", "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionNum + ");");
        }
        if (txtqty7 != null)
        {
            txtqty7.Attributes.Add("onkeyup", "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionNum + ");");
            txtqty7.Attributes.Add("onblur", "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionNum + ");");
        }
        if (txtqty8 != null)
        {
            txtqty8.Attributes.Add("onkeyup", "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionNum + ");");
            txtqty8.Attributes.Add("onblur", "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionNum + ");");
        }
        if (txtqty9 != null)
        {
            txtqty9.Attributes.Add("onkeyup", "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionNum + ");");
            txtqty9.Attributes.Add("onblur", "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionNum + ");");
        }
        if (txtqty10 != null)
        {
            txtqty10.Attributes.Add("onkeyup", "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionNum + ");");
            txtqty10.Attributes.Add("onblur", "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionNum + ");");
        }
        if (txtqty11 != null)
        {
            txtqty11.Attributes.Add("onkeyup", "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionNum + ");");
            txtqty11.Attributes.Add("onblur", "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionNum + ");");
        }
        if (txtqty12 != null)
        {
            txtqty12.Attributes.Add("onkeyup", "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionNum + ");");
            txtqty12.Attributes.Add("onblur", "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionNum + ");");
        }
        if (txtqty13 != null)
        {
            txtqty13.Attributes.Add("onkeyup", "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionNum + ");");
            txtqty13.Attributes.Add("onblur", "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionNum + ");");
        }
        if (txtqty14 != null)
        {
            txtqty14.Attributes.Add("onkeyup", "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionNum + ");");
            txtqty14.Attributes.Add("onblur", "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionNum + ");");
        }
        if (txtqty15 != null)
        {
            txtqty15.Attributes.Add("onkeyup", "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionNum + ");");
            txtqty15.Attributes.Add("onblur", "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionNum + ");");
        }
        if (txtqty16 != null)
        {
            txtqty16.Attributes.Add("onkeyup", "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionNum + ");");
            txtqty16.Attributes.Add("onblur", "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionNum + ");");
        }
        if (txtqty17 != null)
        {
            txtqty17.Attributes.Add("onkeyup", "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionNum + ");");
            txtqty17.Attributes.Add("onblur", "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionNum + ");");
        }
        if (txtqty18 != null)
        {
            txtqty18.Attributes.Add("onkeyup", "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionNum + ");");
            txtqty18.Attributes.Add("onblur", "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionNum + ");");
        }
        if (txtqty19 != null)
        {
            txtqty19.Attributes.Add("onkeyup", "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionNum + ");");
            txtqty19.Attributes.Add("onblur", "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionNum + ");");
        }
        if (txtqty20 != null)
        {
            txtqty20.Attributes.Add("onkeyup", "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionNum + ");");
            txtqty20.Attributes.Add("onblur", "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionNum + ");");
        }
        if (txtqty21 != null)
        {
            txtqty21.Attributes.Add("onkeyup", "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionNum + ");");
            txtqty21.Attributes.Add("onblur", "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionNum + ");");
        }
        if (txtqty22 != null)
        {
            txtqty22.Attributes.Add("onkeyup", "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionNum + ");");
            txtqty22.Attributes.Add("onblur", "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionNum + ");");
        }
        if (txtqty23 != null)
        {
            txtqty23.Attributes.Add("onkeyup", "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionNum + ");");
            txtqty23.Attributes.Add("onblur", "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionNum + ");");
        }
        if (txtqty24 != null)
        {
            txtqty24.Attributes.Add("onkeyup", "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionNum + ");");
            txtqty24.Attributes.Add("onblur", "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionNum + ");");
        }
        if (txtqty25 != null)
        {
            txtqty25.Attributes.Add("onkeyup", "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionNum + ");");
            txtqty25.Attributes.Add("onblur", "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionNum + ");");
        }
        if (txtqty26 != null)
        {
            txtqty26.Attributes.Add("onkeyup", "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionNum + ");");
            txtqty26.Attributes.Add("onblur", "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionNum + ");");
        }
        if (txtqty27 != null)
        {
            txtqty27.Attributes.Add("onkeyup", "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionNum + ");");
            txtqty27.Attributes.Add("onblur", "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionNum + ");");
        }
        if (txtqty28 != null)
        {
            txtqty28.Attributes.Add("onkeyup", "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionNum + ");");
            txtqty28.Attributes.Add("onblur", "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionNum + ");");
        }
        if (txtqty29 != null)
        {
            txtqty29.Attributes.Add("onkeyup", "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionNum + ");");
            txtqty29.Attributes.Add("onblur", "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionNum + ");");
        }
        if (txtqty30 != null)
        {
            txtqty30.Attributes.Add("onkeyup", "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionNum + ");");
            txtqty30.Attributes.Add("onblur", "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionNum + ");");
        }
        if (txtqty31 != null)
        {
            txtqty31.Attributes.Add("onkeyup", "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionNum + ");");
            txtqty31.Attributes.Add("onblur", "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionNum + ");");
        }

        if (txtqty32 != null)
        {
            txtqty32.Attributes.Add("onkeyup", "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionNum + ");");
            txtqty32.Attributes.Add("onblur", "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionNum + ");");
        }

        if (txtqty33 != null)
        {
            txtqty33.Attributes.Add("onkeyup", "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionNum + ");");
            txtqty33.Attributes.Add("onblur", "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionNum + ");");
        }

        if (txtqty34 != null)
        {
            txtqty34.Attributes.Add("onkeyup", "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionNum + ");");
            txtqty34.Attributes.Add("onblur", "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionNum + ");");
        }

        txtdate1.Text = System.DateTime.Now.ToString("dd-MMM-yyyy");
        txtdate1.Enabled = false;
        txtdate1.Font.Bold = true;

        txtdate2.Text = System.DateTime.Now.ToString("dd-MMM-yyyy");
        txtdate2.Enabled = false;
        txtdate2.Font.Bold = true;

        txtdate3.Text = System.DateTime.Now.ToString("dd-MMM-yyyy");
        txtdate3.Enabled = false;
        txtdate3.Font.Bold = true;

        txtdate4.Text = System.DateTime.Now.ToString("dd-MMM-yyyy");
        txtdate4.Enabled = false;
        txtdate4.Font.Bold = true;

        txtdate5.Text = System.DateTime.Now.ToString("dd-MMM-yyyy");
        txtdate5.Enabled = false;
        txtdate5.Font.Bold = true;

        txtdate6.Text = System.DateTime.Now.ToString("dd-MMM-yyyy");
        txtdate6.Enabled = false;
        txtdate6.Font.Bold = true;

        txtdate7.Text = System.DateTime.Now.ToString("dd-MMM-yyyy");
        txtdate7.Enabled = false;
        txtdate7.Font.Bold = true;

        txtdate8.Text = System.DateTime.Now.ToString("dd-MMM-yyyy");
        txtdate8.Enabled = false;
        txtdate8.Font.Bold = true;

        txtdate9.Text = System.DateTime.Now.ToString("dd-MMM-yyyy");
        txtdate9.Enabled = false;
        txtdate9.Font.Bold = true;

        txtdate10.Text = System.DateTime.Now.ToString("dd-MMM-yyyy");
        txtdate10.Enabled = false;
        txtdate10.Font.Bold = true;

        txtdate11.Text = System.DateTime.Now.ToString("dd-MMM-yyyy");
        txtdate11.Enabled = false;
        txtdate11.Font.Bold = true;

        txtdate12.Text = System.DateTime.Now.ToString("dd-MMM-yyyy");
        txtdate12.Enabled = false;
        txtdate12.Font.Bold = true;

        txtdate13.Text = System.DateTime.Now.ToString("dd-MMM-yyyy");
        txtdate13.Enabled = false;
        txtdate13.Font.Bold = true;

        txtdate14.Text = System.DateTime.Now.ToString("dd-MMM-yyyy");
        txtdate14.Enabled = false;
        txtdate14.Font.Bold = true;

        txtdate15.Text = System.DateTime.Now.ToString("dd-MMM-yyyy");
        txtdate15.Enabled = false;
        txtdate15.Font.Bold = true;

        txtdate16.Text = System.DateTime.Now.ToString("dd-MMM-yyyy");
        txtdate16.Enabled = false;
        txtdate16.Font.Bold = true;

        txtdate17.Text = System.DateTime.Now.ToString("dd-MMM-yyyy");
        txtdate17.Enabled = false;
        txtdate17.Font.Bold = true;

        txtdate18.Text = System.DateTime.Now.ToString("dd-MMM-yyyy");
        txtdate18.Enabled = false;
        txtdate18.Font.Bold = true;

        txtdate19.Text = System.DateTime.Now.ToString("dd-MMM-yyyy");
        txtdate19.Enabled = false;
        txtdate19.Font.Bold = true;

        txtdate20.Text = System.DateTime.Now.ToString("dd-MMM-yyyy");
        txtdate20.Enabled = false;
        txtdate20.Font.Bold = true;

        txtdate21.Text = System.DateTime.Now.ToString("dd-MMM-yyyy");
        txtdate21.Enabled = false;
        txtdate21.Font.Bold = true;

        txtdate22.Text = System.DateTime.Now.ToString("dd-MMM-yyyy");
        txtdate22.Enabled = false;
        txtdate22.Font.Bold = true;

        txtdate23.Text = System.DateTime.Now.ToString("dd-MMM-yyyy");
        txtdate23.Enabled = false;
        txtdate23.Font.Bold = true;

        txtdate24.Text = System.DateTime.Now.ToString("dd-MMM-yyyy");
        txtdate24.Enabled = false;
        txtdate24.Font.Bold = true;

        txtdate25.Text = System.DateTime.Now.ToString("dd-MMM-yyyy");
        txtdate25.Enabled = false;
        txtdate25.Font.Bold = true;

        txtdate26.Text = System.DateTime.Now.ToString("dd-MMM-yyyy");
        txtdate26.Enabled = false;
        txtdate26.Font.Bold = true;

        txtdate27.Text = System.DateTime.Now.ToString("dd-MMM-yyyy");
        txtdate27.Enabled = false;
        txtdate27.Font.Bold = true;

        txtdate28.Text = System.DateTime.Now.ToString("dd-MMM-yyyy");
        txtdate28.Enabled = false;
        txtdate28.Font.Bold = true;

        txtdate29.Text = System.DateTime.Now.ToString("dd-MMM-yyyy");
        txtdate29.Enabled = false;
        txtdate29.Font.Bold = true;

        txtdate30.Text = System.DateTime.Now.ToString("dd-MMM-yyyy");
        txtdate30.Enabled = false;
        txtdate30.Font.Bold = true;

        txtdate31.Text = System.DateTime.Now.ToString("dd-MMM-yyyy");
        txtdate31.Enabled = false;
        txtdate31.Font.Bold = true;


        txtdate32.Text = System.DateTime.Now.ToString("dd-MMM-yyyy");
        txtdate32.Enabled = false;
        txtdate32.Font.Bold = true;

        txtdate33.Text = System.DateTime.Now.ToString("dd-MMM-yyyy");
        txtdate33.Enabled = false;
        txtdate33.Font.Bold = true;

        txtdate34.Text = System.DateTime.Now.ToString("dd-MMM-yyyy");
        txtdate34.Enabled = false;
        txtdate34.Font.Bold = true;
    }
    private void Fillddllocation(string HubId, string District, string City)
    {
        var objAssetManagement = new BL.AssetManagement();
        ddlBranch.DataSource = objAssetManagement.GetBranchDetails(HubId, District, City);
        ddlBranch.DataTextField = "BranchCodeName";
        ddlBranch.DataValueField = "BranchCode";
        ddlBranch.DataBind();
    }
    private void FillddlBranch()
    {
        var objAssetManagement = new BL.AssetManagement();
        ddlBranch.DataSource = objAssetManagement.GetBranchName();
        ddlBranch.DataTextField = "BranchCodeName";
        ddlBranch.DataValueField = "BranchCode";
        ddlBranch.DataBind();
    

      
    }
    protected void btn1_Click(object sender, EventArgs e)
    {
        var ds = new DataSet();
        var objAssetMgmt = new BL.AssetManagement();
        try
        {
           
                ds = objAssetMgmt.BranchMaterialIN(Label1.Text, txtdate1.Text, txtqty1.Text, txtVendor1.Text, "IN", BaseLocationAutoID, BaseUserID, ddlHub.SelectedItem.Value,ddlBranch.SelectedItem.Value);
                txtVendor1.Text = "";
             //   txtqty1.Text = "";

                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Material IN Successfully!!')", true);
            
        }
        catch (Exception ex)
        {

        }
    }

    protected void btn2_Click(object sender, EventArgs e)
    {
        var ds = new DataSet();
        var objAssetMgmt = new BL.AssetManagement();
        try
        {
          
                ds = objAssetMgmt.BranchMaterialIN( Label2.Text, txtdate2.Text, txtqty2.Text, txtVendor2.Text, "IN", BaseLocationAutoID, BaseUserID, ddlHub.SelectedItem.Value, ddlBranch.SelectedItem.Value);
                txtVendor2.Text = "";
             //   txtqty2.Text = "";

                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Material IN Successfully!!')", true);
          
        }
        catch (Exception ex)
        {

        }
    }

    protected void btn3_Click(object sender, EventArgs e)
    {
        var ds = new DataSet();
        var objAssetMgmt = new BL.AssetManagement();
        try
        {
           
                ds = objAssetMgmt.BranchMaterialIN( Label3.Text, txtdate3.Text, txtqty3.Text, txtVendor3.Text, "IN", BaseLocationAutoID, BaseUserID, ddlHub.SelectedItem.Value, ddlBranch.SelectedItem.Value);
                txtVendor3.Text = "";
               // txtqty3.Text = "";

                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Material In Successfully!!')", true);
           
        }
        catch (Exception ex)
        {

        }
    }

    protected void btn4_Click(object sender, EventArgs e)
    {
        var ds = new DataSet();
        var objAssetMgmt = new BL.AssetManagement();
        try
        {
           
                ds = objAssetMgmt.BranchMaterialIN( Label4.Text, txtdate4.Text, txtqty4.Text, txtVendor4.Text, "IN", BaseLocationAutoID, BaseUserID, ddlHub.SelectedItem.Value, ddlBranch.SelectedItem.Value);
                txtVendor4.Text = "";
              //  txtqty4.Text = "";

                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Material In Successfully!!')", true);
           
        }
        catch (Exception ex)
        {

        }
    }

    protected void btn5_Click(object sender, EventArgs e)
    {
        var ds = new DataSet();
        var objAssetMgmt = new BL.AssetManagement();
        try
        {
           
                ds = objAssetMgmt.BranchMaterialIN(Label5.Text, txtdate5.Text, txtqty5.Text, txtVendor5.Text, "IN", BaseLocationAutoID, BaseUserID, ddlHub.SelectedItem.Value, ddlBranch.SelectedItem.Value);
                txtVendor5.Text = "";
               // txtqty5.Text = "";

                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Material In Successfully!!')", true);
            
        }
        catch (Exception ex)
        {

        }

    }

    protected void btn6_Click(object sender, EventArgs e)
    {
        var ds = new DataSet();
        var objAssetMgmt = new BL.AssetManagement();
        try
        {
           
                ds = objAssetMgmt.BranchMaterialIN( Label6.Text, txtdate6.Text, txtqty6.Text, txtVendor6.Text, "IN", BaseLocationAutoID, BaseUserID, ddlHub.SelectedItem.Value, ddlBranch.SelectedItem.Value);
                txtVendor6.Text = "";
               // txtqty6.Text = "";

                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Material In Successfully!!')", true);
            
        }
        catch (Exception ex)
        {

        }
    }

    protected void btn7_Click(object sender, EventArgs e)
    {
        var ds = new DataSet();
        var objAssetMgmt = new BL.AssetManagement();
        try
        {
                ds = objAssetMgmt.BranchMaterialIN( Label7.Text, txtdate7.Text, txtqty7.Text, txtVendor7.Text, "IN", BaseLocationAutoID, BaseUserID, ddlHub.SelectedItem.Value, ddlBranch.SelectedItem.Value);
                txtVendor7.Text = "";
              // txtqty7.Text = "";

                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Material In Successfully!!')", true);
           
        }
        catch (Exception ex)
        {

        }
    }

    protected void btn8_Click(object sender, EventArgs e)
    {
        var ds = new DataSet();
        var objAssetMgmt = new BL.AssetManagement();
        try
        {
           
                ds = objAssetMgmt.BranchMaterialIN( Label8.Text, txtdate8.Text, txtqty8.Text, txtVendor8.Text, "IN", BaseLocationAutoID, BaseUserID, ddlHub.SelectedItem.Value, ddlBranch.SelectedItem.Value);
                txtVendor8.Text = "";
            //    txtqty8.Text = "";

                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Material In Successfully!!')", true);
          
        }
        catch (Exception ex)
        {

        }
    }

    protected void btn9_Click(object sender, EventArgs e)
    {
        var ds = new DataSet();
        var objAssetMgmt = new BL.AssetManagement();
        try
        {
           
                ds = objAssetMgmt.BranchMaterialIN( Label9.Text, txtdate9.Text, txtqty9.Text, txtVendor9.Text, "IN", BaseLocationAutoID, BaseUserID, ddlHub.SelectedItem.Value, ddlBranch.SelectedItem.Value);
                txtVendor9.Text = "";
              //  txtqty9.Text = "";

                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Material In Successfully!!')", true);
           
        }
        catch (Exception ex)
        {

        }
    }

    protected void btn10_Click(object sender, EventArgs e)
    {
        var ds = new DataSet();
        var objAssetMgmt = new BL.AssetManagement();
        try
        {
                ds = objAssetMgmt.BranchMaterialIN( Label10.Text, txtdate10.Text, txtqty10.Text, txtVendor10.Text, "IN", BaseLocationAutoID, BaseUserID, ddlHub.SelectedItem.Value, ddlBranch.SelectedItem.Value);
                txtVendor10.Text = "";
               // txtqty10.Text = "";

                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Material In Successfully!!')", true);
          
        }
        catch (Exception ex)
        {

        }
    }

    protected void btn11_Click(object sender, EventArgs e)
    {
        var ds = new DataSet();
        var objAssetMgmt = new BL.AssetManagement();
        try
        {
           
                ds = objAssetMgmt.BranchMaterialIN( Label11.Text, txtdate11.Text, txtqty11.Text, txtVendor11.Text, "IN", BaseLocationAutoID, BaseUserID, ddlHub.SelectedItem.Value, ddlBranch.SelectedItem.Value);
                txtVendor11.Text = "";
             //   txtqty11.Text = "";

                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Material In Successfully!!')", true);
           
        }
        catch (Exception ex)
        {

        }
    }

    protected void btn12_Click(object sender, EventArgs e)
    {
        var ds = new DataSet();
        var objAssetMgmt = new BL.AssetManagement();
        try
        {
           
                ds = objAssetMgmt.BranchMaterialIN( Label12.Text, txtdate12.Text, txtqty12.Text, txtVendor12.Text, "IN", BaseLocationAutoID, BaseUserID, ddlHub.SelectedItem.Value, ddlBranch.SelectedItem.Value);
                txtVendor12.Text = "";
               // txtqty12.Text = "";

                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Material In Successfully!!')", true);
           
        }
        catch (Exception ex)
        {

        }

    }

    protected void btn13_Click(object sender, EventArgs e)
    {
        var ds = new DataSet();
        var objAssetMgmt = new BL.AssetManagement();
        try
        {
           
                ds = objAssetMgmt.BranchMaterialIN( Label13.Text, txtdate13.Text, txtqty13.Text, txtVendor13.Text, "IN", BaseLocationAutoID, BaseUserID, ddlHub.SelectedItem.Value, ddlBranch.SelectedItem.Value);
                txtVendor13.Text = "";
              //  txtqty13.Text = "";

                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Material In Successfully!!')", true);
           
        }
        catch (Exception ex)
        {

        }

    }

    protected void btn14_Click(object sender, EventArgs e)
    {
        var ds = new DataSet();
        var objAssetMgmt = new BL.AssetManagement();
        try
        {
           
                ds = objAssetMgmt.BranchMaterialIN( Label14.Text, txtdate14.Text, txtqty14.Text, txtVendor14.Text, "IN", BaseLocationAutoID, BaseUserID, ddlHub.SelectedItem.Value, ddlBranch.SelectedItem.Value);
                txtVendor14.Text = "";
              //  txtqty14.Text = "";

                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Material In Successfully!!')", true);
           
        }
        catch (Exception ex)
        {

        }
    }

    protected void btn15_Click(object sender, EventArgs e)
    {
        var ds = new DataSet();
        var objAssetMgmt = new BL.AssetManagement();
        try
        {
           
                ds = objAssetMgmt.BranchMaterialIN( Label15.Text, txtdate15.Text, txtqty15.Text, txtVendor15.Text, "IN", BaseLocationAutoID, BaseUserID, ddlHub.SelectedItem.Value, ddlBranch.SelectedItem.Value);
                txtVendor15.Text = "";
               // txtqty15.Text = "";

                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Material In Successfully!!')", true);
           
        }
        catch (Exception ex)
        {

        }
    }

    protected void btn16_Click(object sender, EventArgs e)
    {
        var ds = new DataSet();
        var objAssetMgmt = new BL.AssetManagement();
        try
        {
                ds = objAssetMgmt.BranchMaterialIN( Label16.Text, txtdate16.Text, txtqty16.Text, txtVendor16.Text, "IN", BaseLocationAutoID, BaseUserID, ddlHub.SelectedItem.Value, ddlBranch.SelectedItem.Value);
                txtVendor16.Text = "";
              //  txtqty16.Text = "";

                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Material In Successfully!!')", true);
            
        }
        catch (Exception ex)
        {

        }

    }

    protected void btn17_Click(object sender, EventArgs e)
    {
        var ds = new DataSet();
        var objAssetMgmt = new BL.AssetManagement();
        try
        {
           
                ds = objAssetMgmt.BranchMaterialIN( Label17.Text, txtdate17.Text, txtqty17.Text, txtVendor17.Text, "IN", BaseLocationAutoID, BaseUserID, ddlHub.SelectedItem.Value, ddlBranch.SelectedItem.Value);
                txtVendor17.Text = "";
               // txtqty17.Text = "";

                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Material In Successfully!!')", true);
            
        }
        catch (Exception ex)
        {

        }
    }

    protected void btn18_Click(object sender, EventArgs e)
    {
        var ds = new DataSet();
        var objAssetMgmt = new BL.AssetManagement();
        try
        {
           
                ds = objAssetMgmt.BranchMaterialIN( Label18.Text, txtdate18.Text, txtqty18.Text, txtVendor18.Text, "IN", BaseLocationAutoID, BaseUserID, ddlHub.SelectedItem.Value, ddlBranch.SelectedItem.Value);
                txtVendor18.Text = "";
             //   txtqty18.Text = "";

                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Material In Successfully!!')", true);
           
        }
        catch (Exception ex)
        {

        }
    }

    protected void btn19_Click(object sender, EventArgs e)
    {
        var ds = new DataSet();
        var objAssetMgmt = new BL.AssetManagement();
        try
        {
            
                ds = objAssetMgmt.BranchMaterialIN( Label19.Text, txtdate19.Text, txtqty19.Text, txtVendor19.Text, "IN", BaseLocationAutoID, BaseUserID, ddlHub.SelectedItem.Value, ddlBranch.SelectedItem.Value);
                txtVendor19.Text = "";
              //  txtqty19.Text = "";

                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Material In Successfully!!')", true);
          
        }
        catch (Exception ex)
        {

        }
    }

    protected void btn20_Click(object sender, EventArgs e)
    {
        var ds = new DataSet();
        var objAssetMgmt = new BL.AssetManagement();
        try
        {
           
                ds = objAssetMgmt.BranchMaterialIN( Label20.Text, txtdate20.Text, txtqty20.Text, txtVendor20.Text, "IN", BaseLocationAutoID, BaseUserID, ddlHub.SelectedItem.Value, ddlBranch.SelectedItem.Value);
                txtVendor20.Text = "";
               // txtqty20.Text = "";

                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Material In Successfully!!')", true);
            
        }
        catch (Exception ex)
        {

        }
    }

    protected void btn21_Click(object sender, EventArgs e)
    {
        var ds = new DataSet();
        var objAssetMgmt = new BL.AssetManagement();
        try
        {
          
                ds = objAssetMgmt.BranchMaterialIN( Label21.Text, txtdate21.Text, txtqty21.Text, txtVendor21.Text, "IN", BaseLocationAutoID, BaseUserID, ddlHub.SelectedItem.Value, ddlBranch.SelectedItem.Value);
                txtVendor21.Text = "";
               // txtqty21.Text = "";

                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Material In Successfully!!')", true);
            
        }
        catch (Exception ex)
        {

        }
    }

    protected void btn22_Click(object sender, EventArgs e)
    {
        var ds = new DataSet();
        var objAssetMgmt = new BL.AssetManagement();
        try
        {
            
                ds = objAssetMgmt.BranchMaterialIN( Label22.Text, txtdate22.Text, txtqty22.Text, txtVendor22.Text, "IN", BaseLocationAutoID, BaseUserID, ddlHub.SelectedItem.Value, ddlBranch.SelectedItem.Value);
                txtVendor22.Text = "";
              //  txtqty22.Text = "";

                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Material In Successfully!!')", true);
            
        }
        catch (Exception ex)
        {

        }

    }

    protected void btn23_Click(object sender, EventArgs e)
    {
        var ds = new DataSet();
        var objAssetMgmt = new BL.AssetManagement();
        try
        {
          
                ds = objAssetMgmt.BranchMaterialIN( Label23.Text, txtdate23.Text, txtqty23.Text, txtVendor23.Text, "IN", BaseLocationAutoID, BaseUserID, ddlHub.SelectedItem.Value, ddlBranch.SelectedItem.Value);
                txtVendor23.Text = "";
             //   txtqty23.Text = "";

                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Material In Successfully!!')", true);
            
        }
        catch (Exception ex)
        {

        }
    }

    protected void btn24_Click(object sender, EventArgs e)
    {
        var ds = new DataSet();
        var objAssetMgmt = new BL.AssetManagement();
        try
        {
           
                ds = objAssetMgmt.BranchMaterialIN( Label24.Text, txtdate24.Text, txtqty24.Text, txtVendor24.Text, "IN", BaseLocationAutoID, BaseUserID, ddlHub.SelectedItem.Value, ddlBranch.SelectedItem.Value);
                txtVendor24.Text = "";
              //  txtqty24.Text = "";

                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Material In Successfully!!')", true);
            
        }
        catch (Exception ex)
        {

        }
    }

    protected void btn25_Click(object sender, EventArgs e)
    {
        var ds = new DataSet();
        var objAssetMgmt = new BL.AssetManagement();
        try
        {
            
                ds = objAssetMgmt.BranchMaterialIN( Label25.Text, txtdate25.Text, txtqty25.Text, txtVendor25.Text, "IN", BaseLocationAutoID, BaseUserID, ddlHub.SelectedItem.Value, ddlBranch.SelectedItem.Value);
                txtVendor25.Text = "";
               // txtqty25.Text = "";

                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Material In Successfully!!')", true);
           
        }
        catch (Exception ex)
        {

        }
    }

    protected void btn26_Click(object sender, EventArgs e)
    {
        var ds = new DataSet();
        var objAssetMgmt = new BL.AssetManagement();
        try
        {
         
                ds = objAssetMgmt.BranchMaterialIN( Label26.Text, txtdate26.Text, txtqty26.Text, txtVendor26.Text, "IN", BaseLocationAutoID, BaseUserID, ddlHub.SelectedItem.Value, ddlBranch.SelectedItem.Value);
                txtVendor26.Text = "";
               // txtqty26.Text = "";

                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Material In Successfully!!')", true);
           
        }
        catch (Exception ex)
        {

        }
    }

    protected void btn27_Click(object sender, EventArgs e)
    {
        var ds = new DataSet();
        var objAssetMgmt = new BL.AssetManagement();
        try
        {
           
                ds = objAssetMgmt.BranchMaterialIN( Label27.Text, txtdate27.Text, txtqty27.Text, txtVendor27.Text, "IN", BaseLocationAutoID, BaseUserID, ddlHub.SelectedItem.Value, ddlBranch.SelectedItem.Value);
                txtVendor27.Text = "";
               // txtqty27.Text = "";

                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Material In Successfully!!')", true);
            
        }
        catch (Exception ex)
        {

        }
    }

    protected void btn28_Click(object sender, EventArgs e)
    {
        var ds = new DataSet();
        var objAssetMgmt = new BL.AssetManagement();
        try
        {
           
                ds = objAssetMgmt.BranchMaterialIN( Label28.Text, txtdate28.Text, txtqty28.Text, txtVendor28.Text, "IN", BaseLocationAutoID, BaseUserID, ddlHub.SelectedItem.Value, ddlBranch.SelectedItem.Value);
                txtVendor28.Text = "";
               // txtqty28.Text = "";

                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Material In Successfully!!')", true);
           
        }
        catch (Exception ex)
        {

        }
    }

    protected void btn29_Click(object sender, EventArgs e)
    {
        var ds = new DataSet();
        var objAssetMgmt = new BL.AssetManagement();
        try
        {
            
                ds = objAssetMgmt.BranchMaterialIN( Label29.Text, txtdate29.Text, txtqty29.Text, txtVendor29.Text, "IN", BaseLocationAutoID, BaseUserID, ddlHub.SelectedItem.Value, ddlBranch.SelectedItem.Value);
                txtVendor29.Text = "";
              //  txtqty29.Text = "";

                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Material In Successfully!!')", true);
           
        }
        catch (Exception ex)
        {

        }
    }

    protected void btn30_Click(object sender, EventArgs e)
    {
        var ds = new DataSet();
        var objAssetMgmt = new BL.AssetManagement();
        try
        {
           
                ds = objAssetMgmt.BranchMaterialIN(Label30.Text, txtdate30.Text, txtqty30.Text, txtVendor30.Text, "IN", BaseLocationAutoID, BaseUserID, ddlHub.SelectedItem.Value, ddlBranch.SelectedItem.Value);
                txtVendor30.Text = "";
               // txtqty30.Text = "";

                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Material In Successfully!!')", true);
            
        }
        catch (Exception ex)
        {

        }
    }

    protected void btn31_Click(object sender, EventArgs e)
    {
        var ds = new DataSet();
        var objAssetMgmt = new BL.AssetManagement();
        try
        {
          
                ds = objAssetMgmt.BranchMaterialIN(Label31.Text, txtdate31.Text, txtqty31.Text, txtVendor31.Text, "IN", BaseLocationAutoID, BaseUserID, ddlHub.SelectedItem.Value, ddlBranch.SelectedItem.Value);
                txtVendor31.Text = "";
               // txtqty31.Text = "";

                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Material In Successfully!!')", true);
           
        }
        catch (Exception ex)
        {

        }
    }

    protected void btn32_Click(object sender, EventArgs e)
    {
        var ds = new DataSet();
        var objAssetMgmt = new BL.AssetManagement();
        try
        {
           
                ds = objAssetMgmt.BranchMaterialIN( Label32.Text, txtdate32.Text, txtqty32.Text, txtVendor32.Text, "IN", BaseLocationAutoID, BaseUserID, ddlHub.SelectedItem.Value, ddlBranch.SelectedItem.Value);
                txtVendor32.Text = "";
                //txtqty32.Text = "";

                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Material In Successfully!!')", true);
           
        }
        catch (Exception ex)
        {

        }
    }

    protected void btn33_Click(object sender, EventArgs e)
    {
        var ds = new DataSet();
        var objAssetMgmt = new BL.AssetManagement();
        try
        {
            
                ds = objAssetMgmt.BranchMaterialIN( Label33.Text, txtdate33.Text, txtqty33.Text, txtVendor33.Text, "IN", BaseLocationAutoID, BaseUserID, ddlHub.SelectedItem.Value, ddlBranch.SelectedItem.Value);
                txtVendor33.Text = "";
              //  txtqty33.Text = "";

                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Material In Successfully!!')", true);
           
        }
        catch (Exception ex)
        {

        }
    }

    protected void btn34_Click(object sender, EventArgs e)
    {
        var ds = new DataSet();
        var objAssetMgmt = new BL.AssetManagement();
        try
        {
           
                ds = objAssetMgmt.BranchMaterialIN( Label34.Text, txtdate34.Text, txtqty34.Text, txtVendor34.Text, "IN", BaseLocationAutoID, BaseUserID, ddlHub.SelectedItem.Value, ddlBranch.SelectedItem.Value);
                txtVendor34.Text = "";
              //  txtqty34.Text = "";

                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Material In Successfully!!')", true);
            
        }
        catch (Exception ex)
        {

        }
    }

    protected void ddlBranch_SelectedIndexChanged(object sender, EventArgs e)
    {
        Fillddllocation(ddlHub.SelectedItem.Value, ddlDistrict.SelectedItem.Value, ddlCity.SelectedItem.Value);
    }

    protected void ddlHUB_SelectedIndexChanged(object sender, EventArgs e)
    {
        FillddlDistrict(ddlHub.SelectedItem.Value);
        FillddlCity(ddlHub.SelectedItem.Value, ddlDistrict.SelectedItem.Value);
        Fillddllocation(ddlHub.SelectedItem.Value, ddlDistrict.SelectedItem.Value, ddlCity.SelectedItem.Value);
    }

    protected void ddlDistrict_SelectedIndexChanged(object sender, EventArgs e)
    {
        FillddlCity(ddlHub.SelectedItem.Value, ddlDistrict.SelectedItem.Value);
        Fillddllocation(ddlHub.SelectedItem.Value, ddlDistrict.SelectedItem.Value, ddlCity.SelectedItem.Value);
    }

    protected void ddlCity_SelectedIndexChanged(object sender, EventArgs e)
    {
        Fillddllocation(ddlHub.SelectedItem.Value, ddlDistrict.SelectedItem.Value, ddlCity.SelectedItem.Value);
    }

    private void FillddlHUB()
    {
        var objAssetManagement = new BL.AssetManagement();
        ddlHub.DataSource = objAssetManagement.GetHubNameWithID();
        ddlHub.DataTextField = "HubName";
        ddlHub.DataValueField = "AutoId";
        ddlHub.DataBind();

    }
    private void FillddlDistrict(string HubId)
    {
        var objAssetManagement = new BL.AssetManagement();
        ddlDistrict.DataSource = objAssetManagement.GetDistrictDetails(HubId);
        ddlDistrict.DataTextField = "District";
        ddlDistrict.DataValueField = "District";
        ddlDistrict.DataBind();

    }
    private void FillddlCity(string HubId, string District)
    {
        var objAssetManagement = new BL.AssetManagement();
        ddlCity.DataSource = objAssetManagement.GetCityDetails(HubId, District);
        ddlCity.DataTextField = "City";
        ddlCity.DataValueField = "City";
        ddlCity.DataBind();
    }
    protected void BtnOneShot_Click(object sender, EventArgs e)
    {
        var ds = new DataSet();
        var objAssetMgmt = new BL.AssetManagement();
        try
        {

            ds = objAssetMgmt.BranchMaterialINOneShot( txtdate27.Text,  "", "IN", BaseLocationAutoID, BaseUserID, ddlHub.SelectedItem.Value, ddlBranch.SelectedItem.Value);
         
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Material In Successfully!!')", true);

        }
        catch (Exception ex)
        {

        }

    }
}