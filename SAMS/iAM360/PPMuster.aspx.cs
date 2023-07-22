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



public partial class iAM360_PPMuster :BasePage
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
            ddlYear.SelectedValue = year.ToString();
            ddlmonth.SelectedValue = month1;
            FillData(Convert.ToInt32(year), Convert.ToInt32(month));
        }
        divDetails.Visible = false;
        lblEmpName0.Text = "";
    }
    private void FillData(int Year, int Month)
    {
        try
        {
            var obj = new BL.AssetManagement();
            var dt = new DataTable();
            var dt2 = new DataTable();
            int flag = 0;
            ds = obj.AttendanceMusterDataWithShiftPP(Convert.ToInt32(BaseLocationAutoID), Year, Month);
            dt = ds.Tables[0];
            if (dt.Rows.Count == 0)
            {
                dt.Rows.Add(dt.NewRow());
                flag = 1;
            }
            dt2 = ds.Tables[1];
            if (dt2.Rows.Count != 0)
            {
                lblMainHead.Text = ds.Tables[1].Rows[0]["CompnayDetails"].ToString();
            }
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
        FillData(year, month);
    }
    protected void ddlYear_SelectedIndexChanged(object sender, EventArgs e)
    {
        year = Convert.ToInt32(ddlYear.SelectedValue);
        month = Convert.ToInt32(ddlmonth.SelectedValue);
        FillData(year, month);
    }
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
            Label lblDesignation = (Label)e.Row.FindControl("lblDesignation");
            lblDesignation.Attributes.Add("style", B);
            //Label lblDutyday = (Label)e.Row.FindControl("lblDutyday");
            //lblDutyday.Attributes.Add("style", T);
            //Label lblDutyHrs = (Label)e.Row.FindControl("lblDutyHrs");
            //lblDutyHrs.Attributes.Add("style", T);
            //Label lblOverTime = (Label)e.Row.FindControl("lblOverTime");
            //lblOverTime.Attributes.Add("style", T);

            Label lblDate1 = (Label)e.Row.FindControl("lblDate1");
            if (lblDate1.Text == "A")
            {
                lblDate1.Attributes.Add("style", A);
            }
            else
            {
                lblDate1.Attributes.Add("style", P);
            }
            Label lblDate2 = (Label)e.Row.FindControl("lblDate2");
            if (lblDate2.Text == "A")
            {
                lblDate2.Attributes.Add("style", A);
            }
            else
            {
                lblDate2.Attributes.Add("style", P);
            }
            Label lblDate3 = (Label)e.Row.FindControl("lblDate3");
            if (lblDate3.Text == "A")
            {
                lblDate3.Attributes.Add("style", A);
            }
            else
            {
                lblDate3.Attributes.Add("style", P);
            }
            Label lblDate4 = (Label)e.Row.FindControl("lblDate4");
            if (lblDate4.Text == "A")
            {
                lblDate4.Attributes.Add("style", A);
            }
            else
            {
                lblDate4.Attributes.Add("style", P);
            }
            Label lblDate5 = (Label)e.Row.FindControl("lblDate5");
            if (lblDate5.Text == "A")
            {
                lblDate5.Attributes.Add("style", A);
            }
            else
            {
                lblDate5.Attributes.Add("style", P);
            }
            Label lblDate6 = (Label)e.Row.FindControl("lblDate6");
            if (lblDate6.Text == "A")
            {
                lblDate6.Attributes.Add("style", A);
            }
            else
            {
                lblDate6.Attributes.Add("style", P);
            }
            Label lblDate7 = (Label)e.Row.FindControl("lblDate7");
            if (lblDate7.Text == "A")
            {
                lblDate7.Attributes.Add("style", A);
            }
            else
            {
                lblDate7.Attributes.Add("style", P);
            }
            Label lblDate8 = (Label)e.Row.FindControl("lblDate8");
            if (lblDate8.Text == "A")
            {
                lblDate8.Attributes.Add("style", A);
            }
            else
            {
                lblDate8.Attributes.Add("style", P);
            }
            Label lblDate9 = (Label)e.Row.FindControl("lblDate9");
            if (lblDate9.Text == "A")
            {
                lblDate9.Attributes.Add("style", A);
            }
            else
            {
                lblDate9.Attributes.Add("style", P);
            }
            Label lblDate10 = (Label)e.Row.FindControl("lblDate10");
            if (lblDate10.Text == "A")
            {
                lblDate10.Attributes.Add("style", A);
            }
            else
            {
                lblDate10.Attributes.Add("style", P);
            }
            Label lblDate11 = (Label)e.Row.FindControl("lblDate11");
            if (lblDate11.Text == "A")
            {
                lblDate11.Attributes.Add("style", A);
            }
            else
            {
                lblDate11.Attributes.Add("style", P);
            }
            Label lblDate12 = (Label)e.Row.FindControl("lblDate12");
            if (lblDate12.Text == "A")
            {
                lblDate12.Attributes.Add("style", A);
            }
            else
            {
                lblDate12.Attributes.Add("style", P);
            }
            Label lblDate13 = (Label)e.Row.FindControl("lblDate13");
            if (lblDate13.Text == "A")
            {
                lblDate13.Attributes.Add("style", A);
            }
            else
            {
                lblDate13.Attributes.Add("style", P);
            }
            Label lblDate14 = (Label)e.Row.FindControl("lblDate14");
            if (lblDate14.Text == "A")
            {
                lblDate14.Attributes.Add("style", A);
            }
            else
            {
                lblDate14.Attributes.Add("style", P);
            }
            Label lblDate15 = (Label)e.Row.FindControl("lblDate15");
            if (lblDate15.Text == "A")
            {
                lblDate15.Attributes.Add("style", A);
            }
            else
            {
                lblDate15.Attributes.Add("style", P);
            }
            Label lblDate16 = (Label)e.Row.FindControl("lblDate16");
            if (lblDate16.Text == "A")
            {
                lblDate16.Attributes.Add("style", A);
            }
            else
            {
                lblDate16.Attributes.Add("style", P);
            }
            Label lblDate17 = (Label)e.Row.FindControl("lblDate17");
            if (lblDate17.Text == "A")
            {
                lblDate17.Attributes.Add("style", A);
            }
            else
            {
                lblDate17.Attributes.Add("style", P);
            }
            Label lblDate18 = (Label)e.Row.FindControl("lblDate18");
            if (lblDate18.Text == "A")
            {
                lblDate18.Attributes.Add("style", A);
            }
            else
            {
                lblDate18.Attributes.Add("style", P);
            }
            Label lblDate19 = (Label)e.Row.FindControl("lblDate19");
            if (lblDate19.Text == "A")
            {
                lblDate19.Attributes.Add("style", A);
            }
            else
            {
                lblDate19.Attributes.Add("style", P);
            }
            Label lblDate20 = (Label)e.Row.FindControl("lblDate20");
            if (lblDate20.Text == "A")
            {
                lblDate20.Attributes.Add("style", A);
            }
            else
            {
                lblDate20.Attributes.Add("style", P);
            }
            Label lblDate21 = (Label)e.Row.FindControl("lblDate21");
            if (lblDate21.Text == "A")
            {
                lblDate21.Attributes.Add("style", A);
            }
            else
            {
                lblDate21.Attributes.Add("style", P);
            }
            Label lblDate22 = (Label)e.Row.FindControl("lblDate22");
            if (lblDate22.Text == "A")
            {
                lblDate22.Attributes.Add("style", A);
            }
            else
            {
                lblDate22.Attributes.Add("style", P);
            }
            Label lblDate23 = (Label)e.Row.FindControl("lblDate23");
            if (lblDate23.Text == "A")
            {
                lblDate23.Attributes.Add("style", A);
            }
            else
            {
                lblDate23.Attributes.Add("style", P);
            }
            Label lblDate24 = (Label)e.Row.FindControl("lblDate24");
            if (lblDate24.Text == "A")
            {
                lblDate24.Attributes.Add("style", A);
            }
            else
            {
                lblDate24.Attributes.Add("style", P);
            }
            Label lblDate25 = (Label)e.Row.FindControl("lblDate25");
            if (lblDate25.Text == "A")
            {
                lblDate25.Attributes.Add("style", A);
            }
            else
            {
                lblDate25.Attributes.Add("style", P);
            }
            Label lblDate26 = (Label)e.Row.FindControl("lblDate26");
            if (lblDate26.Text == "A")
            {
                lblDate26.Attributes.Add("style", A);
            }
            else
            {
                lblDate26.Attributes.Add("style", P);
            }
            Label lblDate27 = (Label)e.Row.FindControl("lblDate27");
            if (lblDate27.Text == "A")
            {
                lblDate27.Attributes.Add("style", A);
            }
            else
            {
                lblDate27.Attributes.Add("style", P);
            }
            Label lblDate28 = (Label)e.Row.FindControl("lblDate28");
            if (lblDate28.Text == "A")
            {
                lblDate28.Attributes.Add("style", A);
            }
            else
            {
                lblDate28.Attributes.Add("style", P);
            }
            Label lblDate29 = (Label)e.Row.FindControl("lblDate29");
            Label lblDate30 = (Label)e.Row.FindControl("lblDate30");
            Label lblDate31 = (Label)e.Row.FindControl("lblDate31");
            if (ddlmonth.SelectedValue == "02")
            {
                lblDate29.Visible = false;
                lblDate30.Visible = false;
                lblDate31.Visible = false;
                gdvData.Columns[32].Visible = false;
                gdvData.Columns[33].Visible = false;
                gdvData.Columns[34].Visible = false;
            }
            else if (ddlmonth.SelectedValue == "04" || ddlmonth.SelectedValue == "06" || ddlmonth.SelectedValue == "09" || ddlmonth.SelectedValue == "11")
            {
                lblDate29.Visible = true;
                lblDate30.Visible = true;
                lblDate31.Visible = false;
                gdvData.Columns[32].Visible = true;
                gdvData.Columns[33].Visible = true;
                gdvData.Columns[34].Visible = false;
            }
            else
            {
                lblDate29.Visible = true;
                lblDate30.Visible = true;
                lblDate31.Visible = true;
                gdvData.Columns[32].Visible = true;
                gdvData.Columns[33].Visible = true;
                gdvData.Columns[34].Visible = true;
            }
            if (lblDate29.Text == "A")
            {
                lblDate29.Attributes.Add("style", A);
            }
            else
            {
                lblDate29.Attributes.Add("style", P);
            }

            if (lblDate30.Text == "A")
            {
                lblDate30.Attributes.Add("style", A);
            }
            else
            {
                lblDate30.Attributes.Add("style", P);
            }

            if (lblDate31.Text == "A")
            {
                lblDate31.Attributes.Add("style", A);
            }
            else
            {
                lblDate31.Attributes.Add("style", P);
            }
        }
    }
    protected void lblEmpCode_Click(object sender, EventArgs e)
    {
        years = ddlYear.SelectedValue;
        months = ddlmonth.SelectedValue;
        LinkButton objLinkButton = (LinkButton)sender;
        GridViewRow row = (GridViewRow)objLinkButton.NamingContainer;
        LinkButton lblEmpCode = (LinkButton)gdvData.Rows[row.RowIndex].FindControl("lblEmpCodeLink");
        lblEmpCode0.Text = lblEmpCode.Text;
        GetDetails(lblEmpCode.Text, years, months);
        attDetail.Visible = false;
        divDetails.Visible = true;
        lnkBack.Visible = true;
        bntExport.Visible = false;
    }
    private void GetDetails(string EmpCode, string years, string months)
    {
        try
        {
            var obj = new BL.AssetManagement();
            var dtEmpDetail = new DataTable();
            var dtAttendanceDetails = new DataTable();
            var dtOtherDetails = new DataTable();
            int flag = 0;
            ds = obj.MusterDetails(BaseLocationAutoID, years, months, EmpCode);

            dtEmpDetail = ds.Tables[0];
            if (dtEmpDetail.Rows.Count != 0)
            {
                lblEmpName0.Text = ds.Tables[0].Rows[0]["EmployeeName"].ToString();
            }

            dtOtherDetails = ds.Tables[1];
            if (dtOtherDetails.Rows.Count != 0)
            {
                lblTAttdPresent0.Text = ds.Tables[1].Rows[0]["P"].ToString();
                lblTAttdAbsent0.Text = ds.Tables[1].Rows[0]["A"].ToString();
                lblTAttd0.Text = (Convert.ToInt32(ds.Tables[1].Rows[0]["T"].ToString()) - (Convert.ToInt32(ds.Tables[1].Rows[0]["WO"].ToString()) + Convert.ToInt32(ds.Tables[1].Rows[0]["H"].ToString()) + Convert.ToInt32(ds.Tables[1].Rows[0]["NH"].ToString()))).ToString();
                lblExtraDuty.Text = "Extra Day's (W/O + H) : " + (Convert.ToInt32(ds.Tables[1].Rows[0]["WWO"].ToString()) + Convert.ToInt32(ds.Tables[1].Rows[0]["WHNH"].ToString())).ToString();
                lblDutyHrs.Text = ds.Tables[1].Rows[0]["DutyHrs"].ToString();
                lblTDetai2.Text = ds.Tables[1].Rows[0]["WO"].ToString();
                lblTDetail4.Text = (Convert.ToInt32(ds.Tables[1].Rows[0]["H"].ToString()) + Convert.ToInt32(ds.Tables[1].Rows[0]["NH"].ToString())).ToString();
                lblMonths0.Text = ddlmonth.SelectedItem.Text + " " + ddlYear.SelectedItem.Text;
            }

            dtAttendanceDetails = ds.Tables[2];
            if (dtAttendanceDetails.Rows.Count == 0)
            {
                dtAttendanceDetails.Rows.Add(dtAttendanceDetails.NewRow());
                flag = 1;
            }
            GridView1.DataSource = dtAttendanceDetails;
            GridView1.DataBind();
            if (flag == 1)
            {
                lnkBack.Visible = false;
            }
            else
            {
                divDetails.Visible = true;
            }
        }
        catch (Exception ex)
        {
        }
    }
    protected void lnkBack_Click(object sender, EventArgs e)
    {
        lblNodata.Visible = false;
        attDetail.Visible = true;
        divDetails.Visible = false;
        lnkBack.Visible = false;
        bntExport.Visible = true;
    }
    protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridView1.PageIndex = e.NewPageIndex;
        GridView1.EditIndex = -1;
        GetDetails(lblEmpCode0.Text, ddlYear.SelectedValue, ddlmonth.SelectedValue);
    }
    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        try
        {
            Label lblSNo = (Label)e.Row.FindControl("lblSNo");
            Label lblDate = (Label)e.Row.FindControl("lblDate");
            Label lblTimeFrom = (Label)e.Row.FindControl("lblTimeFrom");
            Label lblTimeTo = (Label)e.Row.FindControl("lblTimeTo");
            Label lblHrs = (Label)e.Row.FindControl("lblHrs");
            Label lblStatus = (Label)e.Row.FindControl("lblStatus");
            Label lblShiftDetail = (Label)e.Row.FindControl("lblShiftDetail");
            Label lblOverTime = (Label)e.Row.FindControl("lblOverTime");
            if (lblStatus.Text == "A")
            {
                lblSNo.Attributes.Add("style", A);
                lblDate.Attributes.Add("style", A);
                lblTimeFrom.Attributes.Add("style", A);
                lblTimeTo.Attributes.Add("style", A);
                lblHrs.Attributes.Add("style", A);
                lblStatus.Attributes.Add("style", A);
                lblShiftDetail.Attributes.Add("style", A);
            }
            else if (lblStatus.Text == "W/O")
            {
                lblSNo.Attributes.Add("style", WO);
                lblDate.Attributes.Add("style", WO);
                lblTimeFrom.Attributes.Add("style", WO);
                lblTimeTo.Attributes.Add("style", WO);
                lblHrs.Attributes.Add("style", WO);
                lblStatus.Attributes.Add("style", WO);
                lblShiftDetail.Attributes.Add("style", WO);
            }
            else if (lblStatus.Text == "P")
            {
                lblSNo.Attributes.Add("style", P);
                lblDate.Attributes.Add("style", P);
                lblTimeFrom.Attributes.Add("style", P);
                lblTimeTo.Attributes.Add("style", P);
                lblHrs.Attributes.Add("style", P);
                lblStatus.Attributes.Add("style", P);
                lblShiftDetail.Attributes.Add("style", P);
            }
            else
            {
                lblSNo.Attributes.Add("style", H);
                lblDate.Attributes.Add("style", H);
                lblTimeFrom.Attributes.Add("style", H);
                lblTimeTo.Attributes.Add("style", H);
                lblHrs.Attributes.Add("style", H);
                lblStatus.Attributes.Add("style", H);
                lblShiftDetail.Attributes.Add("style", H);
            }
            if (lblOverTime.Text == "0:00:00")
            {
                lblOverTime.Attributes.Add("style", WO);
            }
            else
            {
                lblOverTime.Attributes.Add("style", H);
            }
        }
        catch (Exception ex)
        { }
    }
    protected void bntExport_Click(object sender, EventArgs e)
    {
        try
        {
            var obj = new BL.AssetManagement();
            var dt = new DataTable();
            var dtdetail = new DataTable();
            var dtCount = new DataTable();
            var dtSum = new DataTable();
            var dtCompnyDetails = new DataTable();
            string cmpnydetail = null;
            ds = obj.AttendanceMusterDataWithShiftPP(Convert.ToInt32(BaseLocationAutoID), Convert.ToInt32(ddlYear.SelectedValue), Convert.ToInt32(ddlmonth.SelectedValue));
            dt = ds.Tables[0];
            if (dt.Rows.Count > 0)
            {
                //dt.Columns[34].Visible= false;
                //dt.Columns["31"].Visible = false;
                dt.Columns["31"].ColumnMapping = MappingType.Hidden;
            }
            dtdetail = ds.Tables[1];
            dtCompnyDetails = ds.Tables[2];
            if (dtdetail.Rows.Count != 0)
            {
                cmpnydetail = ds.Tables[1].Rows[0]["CompnayDetails"].ToString();
            }
            //Create a dummy GridView
            GridView GridView1 = new GridView();
            GridView GridView2 = new GridView();
            GridView1.AllowPaging = false;
            GridView2.DataSource = dtCompnyDetails;
            GridView2.DataBind();
            GridView1.DataSource = dt;
            GridView1.DataBind();
            Response.Clear();
            Response.Buffer = true;
            string FileName = "AdvancePPMuster -" + cmpnydetail + '-' + ddlmonth.SelectedItem.Text + '(' + ddlYear.SelectedValue + ')' + ".xls";
            Response.AddHeader("content-disposition", "attachment;filename=" + FileName);
            Response.Charset = "";
            Response.ContentType = "application/vnd.ms-excel";
            StringWriter sw = new StringWriter();
            HtmlTextWriter hw = new HtmlTextWriter(sw);
            //Applying stlye to gridview header cells
            for (int i = 0; i < GridView1.HeaderRow.Cells.Count; i++)
            {
                GridView1.HeaderRow.Cells[i].Style.Add("background-color", "#538DD5");
            }
            for (int i = 0; i < GridView2.HeaderRow.Cells.Count; i++)
            {
                GridView2.HeaderRow.Cells[i].Style.Add("background-color", "#538DD5");
            }
            //Applying Color Style
            for (int i = 0; i < GridView1.Rows.Count; i++)
            {
                for (int j = 0; j < GridView1.HeaderRow.Cells.Count; j++)
                {
                    String value = GridView1.Rows[i].Cells[j].Text;
                    if (value == "A")
                    {
                        GridView1.Rows[i].Cells[j].BackColor = System.Drawing.Color.OrangeRed;
                        GridView1.Rows[i].Cells[j].ForeColor = System.Drawing.Color.White;
                    }
                    else if (value == "P")
                    {
                        GridView1.Rows[i].Cells[j].BackColor = System.Drawing.Color.Green;
                        GridView1.Rows[i].Cells[j].ForeColor = System.Drawing.Color.White;
                    }
                    else if (value == "PP")
                    {
                        GridView1.Rows[i].Cells[j].BackColor = System.Drawing.Color.MediumSpringGreen;
                        GridView1.Rows[i].Cells[j].ForeColor = System.Drawing.Color.Black;
                    }
                    else if (j == 0)
                    {
                        GridView1.Rows[i].Cells[j].BackColor = System.Drawing.Color.FromArgb(166, 166, 166);
                        GridView1.Rows[i].Cells[j].ForeColor = System.Drawing.Color.Black;
                    }
                    else if (i >= 0 && j == GridView1.HeaderRow.Cells.Count - 1)
                    {
                        GridView1.Rows[i].Cells[j].BackColor = System.Drawing.Color.YellowGreen;
                        GridView1.Rows[i].Cells[j].ForeColor = System.Drawing.Color.Black;
                    }
                    else if (i >= 0 && j == GridView1.HeaderRow.Cells.Count - 2)
                    {
                        GridView1.Rows[i].Cells[j].BackColor = System.Drawing.Color.FromArgb(146, 205, 220);
                        GridView1.Rows[i].Cells[j].ForeColor = System.Drawing.Color.Black;
                    }
                    else
                    {
                        GridView1.Rows[i].Cells[j].BackColor = System.Drawing.Color.Wheat;
                    }
                }
            }
            GridView2.RenderControl(hw);
            GridView1.RenderControl(hw);
            //style to format numbers to string
            string style = @"<style> .textmode { mso-number-format:\@; } </style>";
            Response.Write(style);
            Response.Output.Write(sw.ToString());
            Response.Flush();
            Response.End();
        }
        catch (Exception ex)
        {
        }
    }
    protected void btnExport2_Click(object sender, EventArgs e)
    {
        try
        {
            var obj = new BL.AssetManagement();
            var dtEmpDetail = new DataTable();
            var dtAttendanceDetails = new DataTable();
            var dtOtherDetails = new DataTable();
            var dtCompanyDetails = new DataTable();
            string empdeatils = null;
            ds = obj.MusterDetails(BaseLocationAutoID, ddlYear.SelectedValue, ddlmonth.SelectedValue, lblEmpCode0.Text);

            dtEmpDetail = ds.Tables[0];
            dtOtherDetails = ds.Tables[3];
            dtAttendanceDetails = ds.Tables[2];
            dtCompanyDetails = ds.Tables[4];
            if (dtEmpDetail.Rows.Count != 0)
            {
                empdeatils = ds.Tables[0].Rows[0]["EmployeeName"].ToString();
            }
            //Create a dummy GridView

            //GridView GridView1 = new GridView();                                                
            //GridView1.DataSource = dtEmpDetail;
            //GridView1.DataBind();

            GridView GridView2 = new GridView();
            GridView2.DataSource = dtOtherDetails;
            GridView2.DataBind();

            GridView GridView3 = new GridView();
            GridView3.AllowPaging = false;
            GridView3.DataSource = dtAttendanceDetails;
            GridView3.DataBind();

            GridView GridView4 = new GridView();
            GridView4.DataSource = dtCompanyDetails;
            GridView4.DataBind();

            Response.Clear();
            Response.Buffer = true;
            string FileName = "AttendanceMuster -" + ddlmonth.SelectedItem.Text + '(' + ddlYear.SelectedValue + ')' + '[' + empdeatils + ']' + ".xls";
            Response.AddHeader("content-disposition", "attachment;filename=" + FileName);
            Response.Charset = "";
            Response.ContentType = "application/vnd.ms-excel";
            StringWriter sw = new StringWriter();
            HtmlTextWriter hw = new HtmlTextWriter(sw);

            //Applying stlye to Excel Header

            //if (dtEmpDetail.Rows.Count != 0)
            //{
            //    for (int i = 0; i < GridView1.HeaderRow.Cells.Count; i++)
            //    {
            //        GridView1.HeaderRow.Cells[i].Style.Add("background-color", "#538DD5");
            //    }
            //}

            for (int i = 0; i < GridView2.HeaderRow.Cells.Count; i++)
            {
                GridView2.HeaderRow.Cells[i].Style.Add("background-color", "#538DD5");
            }

            for (int i = 0; i < GridView3.HeaderRow.Cells.Count; i++)
            {
                GridView3.HeaderRow.Cells[i].Style.Add("background-color", "#403151");
                GridView3.HeaderRow.Cells[i].Style.Add("color", "white");
            }

            for (int i = 0; i < GridView4.HeaderRow.Cells.Count; i++)
            {
                GridView4.HeaderRow.Cells[i].Style.Add("background-color", "#538DD5");
            }

            //Applying stlye to Excel Data

            //for (int i = 0; i < GridView1.Rows.Count; i++)
            //{
            //    for (int j = 0; j < GridView1.HeaderRow.Cells.Count; j++)
            //    {
            //        GridView1.Rows[i].Cells[j].BackColor = System.Drawing.Color.FromArgb(217, 217, 217);
            //    }
            //}

            for (int i = 0; i < GridView2.Rows.Count; i++)
            {
                for (int j = 0; j < GridView2.HeaderRow.Cells.Count; j++)
                {
                    GridView2.Rows[i].Cells[j].BackColor = System.Drawing.Color.FromArgb(217, 217, 217);
                }
            }

            for (int i = 0; i < GridView4.Rows.Count; i++)
            {
                for (int j = 0; j < GridView4.HeaderRow.Cells.Count; j++)
                {
                    GridView4.Rows[i].Cells[j].BackColor = System.Drawing.Color.FromArgb(217, 217, 217);
                    if (i == 0 && j > 3)
                    {
                        GridView4.Rows[i].Cells[j].BackColor = System.Drawing.Color.FromArgb(255, 255, 0);
                    }
                }
            }

            for (int i = 0; i < GridView3.Rows.Count; i++)
            {
                String value = GridView3.Rows[i].Cells[6].Text;
                if (value == "A")
                {
                    GridView3.Rows[i].ForeColor = System.Drawing.Color.White;
                    GridView3.Rows[i].BackColor = System.Drawing.ColorTranslator.FromHtml("#ED1D22");
                }
                else if (value == "P")
                {
                    GridView3.Rows[i].ForeColor = System.Drawing.Color.Black;
                    GridView3.Rows[i].BackColor = System.Drawing.Color.FromArgb(0, 192, 64);
                }
                else if (value == "W/O")
                {
                    GridView3.Rows[i].ForeColor = System.Drawing.Color.White;
                    GridView3.Rows[i].BackColor = System.Drawing.ColorTranslator.FromHtml("#B36F05");
                }
                else
                {
                    GridView3.Rows[i].ForeColor = System.Drawing.Color.White;
                    GridView3.Rows[i].BackColor = System.Drawing.Color.FromArgb(18, 7, 243);
                }
            }

            StringBuilder sb = new StringBuilder(sw.ToString());
            sb = sb.Replace("</table>", "<tr><td>Column1</td><td>Column2</td></tr></table>");
            GridView4.RenderControl(hw);
            //GridView1.RenderControl(hw);
            GridView2.RenderControl(hw);
            GridView3.RenderControl(hw);

            //style to format numbers to string
            string style = @"<style> .textmode { mso-number-format:\@; } </style>";
            Response.Write(style);
            Response.Output.Write(sw.ToString());
            Response.Flush();
            Response.End();
        }
        catch (Exception ex)
        { }
    }
}