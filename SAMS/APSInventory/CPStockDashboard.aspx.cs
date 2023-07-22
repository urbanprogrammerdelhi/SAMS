using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Data;


public partial class APSInventory_CPStockDashboard : BasePage
{
    static int dtflag;
    static string ItemNameGlobal;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            FillItem();
           
        }
    }
   
    protected void btnView_Click(object sender, EventArgs e)
    {
        //if (ddlItemDescription.SelectedItem.Value != "0")
        //{
        gvOrderGrid.Visible = true;

        FillgvOrderGrid();
        pnlItemLedger.Visible = false;
        pnlorderstatus.Visible = true;
        //}
        //else
        //{
        //    pnlorderstatus.Visible = false;
        //  //  gvOrderGrid.Visible = false;
        //    lblmsg.Text = "No Record Found !!";
        //}

    }
    protected void FillItem()
    {
        BL.AssetManagement objAssetMgmt = new BL.AssetManagement();
        ddlItemDescription.DataSource = objAssetMgmt.GetCPItemDetails();
        ddlItemDescription.DataTextField = "MaterialName";
        ddlItemDescription.DataValueField = "MaterialID";
        ddlItemDescription.DataBind();
        ddlItemDescription.Items.Insert(0, new ListItem("All Equipment", "All"));
        if (ddlItemDescription.Text == "")
        {
            ListItem li = new ListItem();
            li.Text = Resources.Resource.NoData;
            li.Value = "0";
            ddlItemDescription.Items.Add(li);
        }
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
            dsAssetMaster = objAssetMgmt.GetItemStock(ddlItemDescription.SelectedItem.Value, ddloffice.SelectedItem.Value, Convert.ToInt32(BaseLocationAutoID));
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
    protected void btnViewStock_Click(object sender, EventArgs e)
    {
        Button objLinkButton = (Button)sender;
        GridViewRow row = (GridViewRow)objLinkButton.NamingContainer;
        Label ItemName = (Label)gvOrderGrid.Rows[row.RowIndex].FindControl("lblItemname");
        HiddenField ItemID = (HiddenField)gvOrderGrid.Rows[row.RowIndex].FindControl("hfmaterialid");
        ItemNameGlobal = ItemID.Value;
        FillgvGridItemLedger(ItemNameGlobal);
        pnlItemLedger.Visible = true;
        pnlorderstatus.Visible = false;
    }
    private void FillgvGridItemLedger(string ItemName)
    {
        try
        {
            var objAssetMgmt = new BL.AssetManagement();
            var dsAssetMaster = new DataSet();
            var dtAssetMaster = new DataTable();
            dtflag = 1;
            dsAssetMaster = objAssetMgmt.GetItemStockLedger(ItemName.ToString(), ddloffice.SelectedItem.Value, Convert.ToInt32(BaseLocationAutoID));
            dtAssetMaster = dsAssetMaster.Tables[1];
            gvItemLedger.DataSource = dtAssetMaster;
            gvItemLedger.DataBind();
            lblavailble.Text = dsAssetMaster.Tables[0].Rows[0]["TotalStock"].ToString();
        }
        catch (Exception ex)
        {
        }
    }
    protected void btnback_Click(object sender, EventArgs e)
    {
        pnlItemLedger.Visible = false;
        pnlorderstatus.Visible = true;
    }
    protected void gvItemLedger_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvItemLedger.PageIndex = e.NewPageIndex;
        gvItemLedger.EditIndex = -1;
        FillgvGridItemLedger(ItemNameGlobal);
    }
    protected void gvItemLedger_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        GridViewRow objGridViewRow = e.Row;
        Label lblSerialNo = (Label)objGridViewRow.FindControl("lblSerialNo");
        if (lblSerialNo != null)
        {
            int serialNo = gvItemLedger.PageIndex * gvItemLedger.PageSize + int.Parse(objGridViewRow.RowIndex.ToString());
            lblSerialNo.Text = Convert.ToString((serialNo + 1));
        }

        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            Label lblStockType = (Label)objGridViewRow.FindControl("lblStockType");
            if (lblStockType.Text == "OUT")
            {
                lblStockType.ForeColor = System.Drawing.Color.Red;

            }
            else
            {
                lblStockType.ForeColor = System.Drawing.Color.Green;

            }
        }
    }
}