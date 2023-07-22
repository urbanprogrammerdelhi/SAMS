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

public partial class APS_MonthlyChecklistReport : BasePage
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
            for (int Loop = 2022; Loop <= 2023; Loop++)
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
            ddlYear.SelectedValue = year.ToString();
            ddlmonth.SelectedValue = month1;
           
        }
     
     
    }
    private void FillData(int Year, int Month)
    {
        try
        {
            var obj = new BL.AssetManagement();
            var dt = new DataTable();
            int flag = 0;
            ds = obj.ConsolidateChecklistReport(Convert.ToInt32(BaseLocationAutoID), Year, Month);
            dt = ds.Tables[0];
            if (dt.Rows.Count == 0)
            {
                dt.Rows.Add(dt.NewRow());
                flag = 1;
            }
         
            gdvData.DataSource = dt;
            gdvData.DataBind();
            if (flag == 1)
            {
                lblNodata.Visible = true;
                gdvData.Visible = false;
                bntExport.Visible = false;
            }
            else
            {
                lblNodata.Visible = false;
                gdvData.Visible = true;
                bntExport.Visible = true;
            }
        }
        catch (Exception ex)
        {
        }
    }
    //protected void ddlmonth_SelectedIndexChanged(object sender, EventArgs e)
    //{
    //    year = Convert.ToInt32(ddlYear.SelectedValue);
    //    month = Convert.ToInt32(ddlmonth.SelectedValue);
    //    FillData(year, month);
    //}
    //protected void ddlYear_SelectedIndexChanged(object sender, EventArgs e)
    //{
    //    year = Convert.ToInt32(ddlYear.SelectedValue);
    //    month = Convert.ToInt32(ddlmonth.SelectedValue);
    //    FillData(year, month);
    //}
    protected void gdvData_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        year = Convert.ToInt32(ddlYear.SelectedValue);
        month = Convert.ToInt32(ddlmonth.SelectedValue);
        gdvData.PageIndex = e.NewPageIndex;
        gdvData.EditIndex = -1;
        FillData(year, month);
    }
    protected void gdvData_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        string B = "Color:#2e6293;Font-weight:Bold";
        string T = "Color:black;Font-weight:Bold";
        string N = "Color:#cc0052;Font-weight:Bold";
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            Label lblEmpCode = (Label)e.Row.FindControl("lblEmpCode");
            lblEmpCode.Attributes.Add("style", N);
            Label lblEmpName = (Label)e.Row.FindControl("lblEmpName");
            lblEmpName.Attributes.Add("style", B);
         
            Label lblSNo = (Label)e.Row.FindControl("lblSNo");
            lblSNo.Attributes.Add("style", T);
            Label lblDesignation = (Label)e.Row.FindControl("lblDesignation");
            lblDesignation.Attributes.Add("style", T);

            //lblOverTime.Attributes.Add("style", T);    
            Label lblDate1 = (Label)e.Row.FindControl("lblDate1");
            lblDate1.Attributes.Add("style", T);
            Label lblDate2 = (Label)e.Row.FindControl("lblDate2");
            lblDate2.Attributes.Add("style", T);
            Label lblDate3 = (Label)e.Row.FindControl("lblDate3");
            lblDate3.Attributes.Add("style", T);
            Label lblDate4 = (Label)e.Row.FindControl("lblDate4");
            lblDate4.Attributes.Add("style", T);
            Label lblDate5 = (Label)e.Row.FindControl("lblDate5");
            lblDate5.Attributes.Add("style", T);
            Label lblDate6 = (Label)e.Row.FindControl("lblDate6");
            lblDate6.Attributes.Add("style", T);
            Label lblDate7 = (Label)e.Row.FindControl("lblDate7");
            lblDate7.Attributes.Add("style", T);
            Label lblDate8 = (Label)e.Row.FindControl("lblDate8");
            lblDate8.Attributes.Add("style", T);
            Label lblDate9 = (Label)e.Row.FindControl("lblDate9");
            lblDate9.Attributes.Add("style", T);
            Label lblDate10 = (Label)e.Row.FindControl("lblDate10");
            lblDate10.Attributes.Add("style", T);
            Label lblDate11 = (Label)e.Row.FindControl("lblDate11");
            lblDate11.Attributes.Add("style", T);
            Label lblDate12 = (Label)e.Row.FindControl("lblDate12");
            lblDate12.Attributes.Add("style", T);
            Label lblDate13 = (Label)e.Row.FindControl("lblDate13");
            lblDate13.Attributes.Add("style", T);
            Label lblDate14 = (Label)e.Row.FindControl("lblDate14");
            lblDate14.Attributes.Add("style", T);
            Label lblDate15 = (Label)e.Row.FindControl("lblDate15");
            lblDate15.Attributes.Add("style", T);
            Label lblDate16 = (Label)e.Row.FindControl("lblDate16");
            lblDate16.Attributes.Add("style", T);
            Label lblDate17 = (Label)e.Row.FindControl("lblDate17");
            lblDate17.Attributes.Add("style", T);
            Label lblDate18 = (Label)e.Row.FindControl("lblDate18");
            lblDate18.Attributes.Add("style", T);
            Label lblDate19 = (Label)e.Row.FindControl("lblDate19");
            lblDate19.Attributes.Add("style", T);
            Label lblDate20 = (Label)e.Row.FindControl("lblDate20");
            lblDate20.Attributes.Add("style", T);
            Label lblDate21 = (Label)e.Row.FindControl("lblDate21");
            lblDate21.Attributes.Add("style", T);
            Label lblDate22 = (Label)e.Row.FindControl("lblDate22");
            lblDate22.Attributes.Add("style", T);
            Label lblDate23 = (Label)e.Row.FindControl("lblDate23");
            lblDate23.Attributes.Add("style", T);
            Label lblDate24 = (Label)e.Row.FindControl("lblDate24");
            lblDate24.Attributes.Add("style", T);
            Label lblDate25 = (Label)e.Row.FindControl("lblDate25");
            lblDate25.Attributes.Add("style", T);
            Label lblDate26 = (Label)e.Row.FindControl("lblDate26");
            lblDate26.Attributes.Add("style", T);
            Label lblDate27 = (Label)e.Row.FindControl("lblDate27");
            lblDate27.Attributes.Add("style", T);
             Label lblDate28 = (Label)e.Row.FindControl("lblDate28");
            lblDate28.Attributes.Add("style", T);
             Label lblDate29 = (Label)e.Row.FindControl("lblDate29");
            lblDate29.Attributes.Add("style", T);
            Label lblDate30 = (Label)e.Row.FindControl("lblDate30");
            lblDate30.Attributes.Add("style", T);
            Label lblDate31 = (Label)e.Row.FindControl("lblDate31");
            lblDate31.Attributes.Add("style", T);
            Label lblDutyday = (Label)e.Row.FindControl("lblDutyday");
            lblDutyday.Attributes.Add("style", T);
            Label lblDutyHrs = (Label)e.Row.FindControl("lblDutyHrs");
            lblDutyHrs.Attributes.Add("style", T);
        }
    }
   
   
    protected void bntExport_Click(object sender, EventArgs e)
    {
        Response.Clear();
        Response.Buffer = true;
        if(BaseLocationAutoID=="31")
        Response.AddHeader("content-disposition", "attachment;filename=TATA-AIA-North-MonthlyMaterialReport-"+ddlmonth.SelectedItem.Text+".xls");
        else
        {
            Response.AddHeader("content-disposition", "attachment;filename=TATA-AIA-South-MonthlyMaterialReport-" + ddlmonth.SelectedItem.Text + ".xls");
        }
        Response.Charset = "";
        Response.ContentType = "application/vnd.ms-excel";
        using (StringWriter sw = new StringWriter())
        {
            HtmlTextWriter hw = new HtmlTextWriter(sw);

            //To Export all pages
            gdvData.AllowPaging = false;
            year = Convert.ToInt32(ddlYear.SelectedValue);
            month = Convert.ToInt32(ddlmonth.SelectedValue);
            FillData(year, month);


            gdvData.HeaderRow.BackColor = Color.White;
            foreach (TableCell cell in gdvData.HeaderRow.Cells)
            {
                cell.BackColor = gdvData.HeaderStyle.BackColor;
            }
            foreach (GridViewRow row in gdvData.Rows)
            {
                row.BackColor = Color.White;
                foreach (TableCell cell in row.Cells)
                {
                    if (row.RowIndex % 2 == 0)
                    {
                        cell.BackColor = gdvData.AlternatingRowStyle.BackColor;
                    }
                    else
                    {
                        cell.BackColor = gdvData.RowStyle.BackColor;
                    }
                    cell.CssClass = "textmode";
                }
            }
            gdvData.RenderControl(hw);
            //style to format numbers to string
            string style = @"<style> .textmode { } </style>";
            Response.Write(style);
            Response.Output.Write(sw.ToString());
            Response.Flush();
            Response.End();
        }
    }
    public override void VerifyRenderingInServerForm(Control control)
    {
        // controller   
    }

    protected void btnfetchreport_Click(object sender, EventArgs e)
    {
        year = Convert.ToInt32(ddlYear.SelectedValue);
           month = Convert.ToInt32(ddlmonth.SelectedValue);
           FillData(year, month);
    }
}