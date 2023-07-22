using DevExpress.Data.Utils;
using System;
using System.Data;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
using System.Drawing;

public partial class iAM360_MonthlyReport : BasePage
{
    #region Declare
    int year, month;
    string months, years;
    string P = "Color:green;Font-weight:Bold";
    string A = "Color:#FF3434;Font-weight:Bold";
    string H = "Color:#2E6293;Font-weight:Bold";
    string WO = "Color:#B36F05;Font-weight:Bold";
    DataSet ds = new DataSet();
    #endregion
    protected void Page_Load(object sender, EventArgs e)
    {
        int year = Convert.ToInt32(DateTime.Now.Year.ToString());
        var month = Convert.ToInt32(DateTime.Now.Month.ToString());
        if (!IsPostBack)
        {
            string month1 = null;
            for (int Loop = 2016; Loop <= DateTime.Now.Year; Loop++)
            {
                ddlYear.Items.Add(Loop.ToString());
            }
            if (month < 10)
            {
                month1 = month.ToString();
                month1 = "0" + month1;
            }
            else
            {
                month1 = month.ToString();
            }
            FillddlBranch();
            ddlYear.SelectedValue = year.ToString();
            ddlmonth.SelectedValue = month1;
            FillData(Convert.ToInt32(year), Convert.ToInt32(month),ddlbranch.SelectedItem.Value);
        }
      
    }
    private void FillData(int Year, int Month,string Branch)
    {
        try
        {
            var obj = new BL.AssetManagement();
            var dt = new DataTable();
            var dt2 = new DataTable();
            int flag = 0;
            ds = obj.APSReportNew(Convert.ToInt32(BaseLocationAutoID), Year, Month, Branch);
            dt = ds.Tables[0];
            if (dt.Rows.Count == 0)
            {
                dt.Rows.Add(dt.NewRow());
                flag = 1;
            }
          //  dt2 = ds.Tables[1];
            //if (dt2.Rows.Count != 0)
            //{
            //    lblMainHead.Text = ds.Tables[1].Rows[0]["CompnayDetails"].ToString();
            //}
            gdvData.DataSource = dt;
            gdvData.DataBind();
            if (flag == 1)
            {
                lblNodata.Visible = true;
                lnkBack.Visible = false;
                bntExport.Visible = false;
            }
            else
            {
                lblNodata.Visible = false;
                lnkBack.Visible = false;
                bntExport.Visible = true;
            }
        }
        catch (Exception ex)
        {
        }
    }
    protected void ddlmonth_SelectedIndexChanged(object sender, EventArgs e)
    {
        year = Convert.ToInt32(ddlYear.SelectedValue);
        month = Convert.ToInt32(ddlmonth.SelectedValue);
        FillData(year, month,ddlbranch.SelectedItem.Value);
    }
    protected void ddlYear_SelectedIndexChanged(object sender, EventArgs e)
    {
        year = Convert.ToInt32(ddlYear.SelectedValue);
        month = Convert.ToInt32(ddlmonth.SelectedValue);
        FillData(year, month, ddlbranch.SelectedItem.Value);
    }
    protected void gdvData_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        year = Convert.ToInt32(ddlYear.SelectedValue);
        month = Convert.ToInt32(ddlmonth.SelectedValue);
        gdvData.PageIndex = e.NewPageIndex;
        gdvData.EditIndex = -1;
        FillData(year, month,ddlbranch.SelectedItem.Value);
    }
    protected void gdvData_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        GridViewRow objGridViewRow = e.Row;

        Label lblSerialNo = (Label)objGridViewRow.FindControl("lblSNo");
        if (lblSerialNo != null)
        {
            int serialNo = gdvData.PageIndex * gdvData.PageSize + int.Parse(objGridViewRow.RowIndex.ToString());
            lblSerialNo.Text = Convert.ToString((serialNo + 1));
        }

        string B = "Color:#2e6293;Font-weight:Bold";
        string T = "Color:black;Font-weight:Bold";
        string N = "Color:#cc0052;Font-weight:Bold";
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            //Label lblEmpCode = (Label)e.Row.FindControl("lblEmpCode");
            //lblEmpCode.Attributes.Add("style", N);
            Label lblEmpName = (Label)e.Row.FindControl("lblEmpName");
            lblEmpName.Attributes.Add("style", B);
            Label lblSNo = (Label)e.Row.FindControl("lblSNo");
            lblSNo.Attributes.Add("style", B);
            Label lblSNoDistrict = (Label)e.Row.FindControl("lblSNoDistrict");
            lblSNoDistrict.Attributes.Add("style", B);
            Label lblSNoCenter = (Label)e.Row.FindControl("lblSNoCenter");
            lblSNoCenter.Attributes.Add("style", B);
            Label lblSNoLocation = (Label)e.Row.FindControl("lblSNoLocation");
            lblSNoLocation.Attributes.Add("style", B);

            Label lblSNoTAb = (Label)e.Row.FindControl("lblSNoTAb");
            lblSNoTAb.Attributes.Add("style", A);
            Label lblSNoTPre = (Label)e.Row.FindControl("lblSNoTPre");
            lblSNoTPre.Attributes.Add("style", P);
            Label lblSNoTWorking = (Label)e.Row.FindControl("lblSNoTWorking");
            lblSNoTWorking.Attributes.Add("style", N);

            //Label lblDate1 = (Label)e.Row.FindControl("lblDate1");
            //if (lblDate1.Text == "A")
            //{
            //    lblDate1.Attributes.Add("style", A);
            //}
            //else
            //{
            //    lblDate1.Attributes.Add("style", P);
            //}


        }
    }
    
   
    protected void lnkBack_Click(object sender, EventArgs e)
    {
        lblNodata.Visible = false;
        attDetail.Visible = true;
       // divDetails.Visible = false;
        lnkBack.Visible = false;
        bntExport.Visible = true;
    }

    protected void FillddlBranch()
    {
        DataSet ds = new DataSet();
        BL.Sales objsales = new BL.Sales();

        ds = objsales.GetALLBranchesAPS(BaseLocationAutoID);

        if (ds != null)
        {
            if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                ddlbranch.DataSource = ds.Tables[0];
                ddlbranch.DataTextField = "Branch";
                ddlbranch.DataValueField = "Branch";
                ddlbranch.DataBind();

                ddlbranch.Items.Insert(0, new ListItem("All", "All"));

            }
            else
            {
                ListItem li = new ListItem();
                li.Text = Resources.Resource.NoData;
                li.Value = "0";
                ddlbranch.Items.Add(li);
            }
        }
        else
        {
            ListItem li = new ListItem();
            li.Text = Resources.Resource.NoData;
            li.Value = "0";
            ddlbranch.Items.Add(li);
        }
    }
    protected void bntExport_Click(object sender, EventArgs e)
    {        
        try
        {
            Response.Clear();
            Response.Buffer = true;
            gdvData.AllowPaging = false;
           // gdvData.Columns[0].Visible = false;

            var obj = new BL.AssetManagement();
            var dt = new DataTable();
            ds = obj.APSReportNew(Convert.ToInt32(BaseLocationAutoID), Convert.ToInt32(ddlYear.SelectedValue), Convert.ToInt32(ddlmonth.SelectedValue), ddlbranch.SelectedItem.Value);
            dt = ds.Tables[0];
            gdvData.DataSource = dt;
            gdvData.DataBind();
            string FileName = "MonthlyReport -" + ddlmonth.SelectedItem.Text + '(' + ddlYear.SelectedValue + ')' + '-' + ddlbranch.SelectedItem.Value + ".xls";
            Response.AddHeader("content-disposition", "attachment;filename=" + FileName);
            Response.Charset = "";
            Response.ContentType = "application/vnd.ms-excel";
            StringWriter sw = new StringWriter();
            HtmlTextWriter hw = new HtmlTextWriter(sw);

            gdvData.RenderControl(hw);

            //style to format numbers to string
            string style = @"<style> .textmode { } </style>";
            Response.Write(style);
            Response.Output.Write(sw.ToString());
            Response.Flush();
            Response.End();
        }
        catch (Exception ex)
        {
        }
    }

    public override void VerifyRenderingInServerForm(Control control)
    {
        // controller   
    }


    protected void ddlbranch_SelectedIndexChanged(object sender, EventArgs e)
    {
        year = Convert.ToInt32(ddlYear.SelectedValue);
        month = Convert.ToInt32(ddlmonth.SelectedValue);
        FillData(year, month, ddlbranch.SelectedItem.Value);
    }
}