using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Data;

public partial class APSInventory_BranchStockDashboardaspx : BasePage
{
    static int dtflag;
    static string ItemNameGlobal;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            FillddlBranch();
        }
    }

    private void FillddlBranch()
    {
        var objAssetManagement = new BL.AssetManagement();
        ddlBranch.DataSource = objAssetManagement.GetBranchName();
        ddlBranch.DataTextField = "BranchCodeName";
        ddlBranch.DataValueField = "BranchCode";
        ddlBranch.DataBind();

    }
    protected void btnView_Click(object sender, EventArgs e)
    {
        gvOrderGrid.Visible = true;
        FillgvOrderGrid();  
    }
    protected void gvOrderGrid_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        GridViewRow objGridViewRow = e.Row;
        Label lblSerialNo = (Label)objGridViewRow.FindControl("lblSerialNo");
        if (lblSerialNo != null)
        {
            int serialNo = gvOrderGrid.PageIndex * gvOrderGrid.PageSize + int.Parse(objGridViewRow.RowIndex.ToString());
            lblSerialNo.Text = Convert.ToString((serialNo + 1));
        }
    }
    protected void gvOrderGrid_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvOrderGrid.PageIndex = e.NewPageIndex;
        gvOrderGrid.EditIndex = -1;
        FillgvOrderGrid();
    }
    private void FillgvOrderGrid()
    {
        try
        {
            var objAssetMgmt = new BL.AssetManagement();
            var dsAssetMaster = new DataSet();
            var dtAssetMaster = new DataTable();
            dtflag = 1;
            dsAssetMaster = objAssetMgmt.GetBranchItemStock(ddlBranch.SelectedItem.Value, Convert.ToInt32(BaseLocationAutoID));
            dtAssetMaster = dsAssetMaster.Tables[0];
            if (dtAssetMaster.Rows.Count == 0)
            {
                dtflag = 0;
                dtAssetMaster.Rows.Add(dtAssetMaster.NewRow());
            }
            gvOrderGrid.DataSource = dtAssetMaster;
            gvOrderGrid.DataBind();
            if (dtflag == 0)
            {
                gvOrderGrid.Rows[0].Visible = false;
                dtflag = 0;
                lblmsg.Visible = true;
                lblmsg.Text = "No Stock Available !!";
            }
            else
            {
                dtflag = 1;
                lblmsg.Visible = false;
                lblmsg.Text = "No Stock Available !!";
            }
            // lblavailble.Text = dsAssetMaster.Tables[0].Rows[0]["TotalStock"].ToString();
        }
        catch (Exception ex)
        {
        }
    }
  
}