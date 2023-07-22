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
using System.Threading;

public partial class iAM360_AttendanceMusterWithTiming : BasePage
{
    #region Declare
    int year, month;
    string months, years;
    string P = "Color:green;Font-weight:Bold";
    string A = "Color:#FF3434;Font-weight:Bold";
    string H = "Color:#2E6293;Font-weight:Bold";
    string WO = "Color:#B36F05;Font-weight:Bold";
    DataSet ds = new DataSet();
    DataTable dtBackupData = new DataTable();
    DataTable dtBackupOthersDetails = new DataTable();
    DataTable dtBackupCompanyDetails = new DataTable();
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
            FillgvAssetScheduling(Convert.ToInt32(year), Convert.ToInt32(month));
        }
        divDetails.Visible = false;
        lblEmpName0.Text = "";
    }
    private void FillgvAssetScheduling(int Year, int Month)
    {
        try
        {
            var startDate = new DateTime(Year, Month, 1);
            var endDate = startDate.AddMonths(1).AddDays(-1);
            var ts = endDate.Subtract(startDate);
            var t = int.Parse(ts.Days.ToString()) + 1;
            var dttempDate = startDate;

            var obj = new BL.AssetManagement();
            ds = obj.AttendanceMusterDataNew(Convert.ToInt32(BaseLocationAutoID), Year, Month);
            var dtcheck = new DataTable();
            dtcheck = ds.Tables[0];
            dtBackupCompanyDetails = ds.Tables[2];
            dtBackupOthersDetails = ds.Tables[3];
            if (dtBackupCompanyDetails.Rows.Count != 0)
            {
                lblMainHead.Text = ds.Tables[2].Rows[0]["CompnayDetails"].ToString();
            }
            DataTable dsResult = ds.Tables[0].Copy();
            for (int j = 0; j < t; j++)
            {
                string strColName = Convert.ToString(dttempDate.ToString(Resources.Resource.ScheduleDefaultDateFormat));
                var strColNo = new DataColumn(strColName);
                dsResult.Columns.Add(strColNo);
                dttempDate = dttempDate.AddDays(double.Parse("1"));
            }
            for (var j = 0; j < dsResult.Rows.Count; j++)
            {
                var dv1 = new DataView(ds.Tables[1]);
                var filterCondition = "[Employeenumber]='" + (dsResult.Rows[j]["Employeenumber"]) + "'";
                dv1.RowFilter = filterCondition;

                foreach (DataRowView drV1 in dv1)
                {
                    var str = DateTime.Parse(drV1["DutyDate"].ToString()).ToString(Resources.Resource.ScheduleDefaultDateFormat);
                    if (dsResult.Rows[j]["Employeenumber"].ToString() == drV1["Employeenumber"].ToString())
                    {
                        dsResult.Rows[j][DateTime.Parse(str).ToString(Resources.Resource.ScheduleDefaultDateFormat).ToLower()] = drV1["Attendance"].ToString() + "/" + drV1["TimeFrom"].ToString() + "/" + drV1["TimeTo"].ToString();
                    }
                }
            }
            dtBackupData = dsResult.Copy();
            int enc = 1;
            for (var k = 6; k < t + 6; k++)
            {
                dsResult.Columns[k].ColumnName = enc.ToString();
                enc++;
            }
            #region Data
            dsResult.Columns.Add("100");
            dsResult.Columns.Add("101");
            dsResult.Columns.Add("102");

            dsResult.Columns.Add("200");
            dsResult.Columns.Add("201");
            dsResult.Columns.Add("202");

            dsResult.Columns.Add("300");
            dsResult.Columns.Add("301");
            dsResult.Columns.Add("302");

            dsResult.Columns.Add("400");
            dsResult.Columns.Add("401");
            dsResult.Columns.Add("402");

            dsResult.Columns.Add("500");
            dsResult.Columns.Add("501");
            dsResult.Columns.Add("502");

            dsResult.Columns.Add("600");
            dsResult.Columns.Add("601");
            dsResult.Columns.Add("602");

            dsResult.Columns.Add("700");
            dsResult.Columns.Add("701");
            dsResult.Columns.Add("702");

            dsResult.Columns.Add("800");
            dsResult.Columns.Add("801");
            dsResult.Columns.Add("802");

            dsResult.Columns.Add("900");
            dsResult.Columns.Add("901");
            dsResult.Columns.Add("902");

            dsResult.Columns.Add("1000");
            dsResult.Columns.Add("1001");
            dsResult.Columns.Add("1002");

            dsResult.Columns.Add("1100");
            dsResult.Columns.Add("1101");
            dsResult.Columns.Add("1102");

            dsResult.Columns.Add("1200");
            dsResult.Columns.Add("1201");
            dsResult.Columns.Add("1202");

            dsResult.Columns.Add("1300");
            dsResult.Columns.Add("1301");
            dsResult.Columns.Add("1302");

            dsResult.Columns.Add("1400");
            dsResult.Columns.Add("1401");
            dsResult.Columns.Add("1402");

            dsResult.Columns.Add("1500");
            dsResult.Columns.Add("1501");
            dsResult.Columns.Add("1502");

            dsResult.Columns.Add("1600");
            dsResult.Columns.Add("1601");
            dsResult.Columns.Add("1602");

            dsResult.Columns.Add("1700");
            dsResult.Columns.Add("1701");
            dsResult.Columns.Add("1702");

            dsResult.Columns.Add("1800");
            dsResult.Columns.Add("1801");
            dsResult.Columns.Add("1802");

            dsResult.Columns.Add("1900");
            dsResult.Columns.Add("1901");
            dsResult.Columns.Add("1902");

            dsResult.Columns.Add("2000");
            dsResult.Columns.Add("2001");
            dsResult.Columns.Add("2002");

            dsResult.Columns.Add("2100");
            dsResult.Columns.Add("2101");
            dsResult.Columns.Add("2102");

            dsResult.Columns.Add("2200");
            dsResult.Columns.Add("2201");
            dsResult.Columns.Add("2202");

            dsResult.Columns.Add("2300");
            dsResult.Columns.Add("2301");
            dsResult.Columns.Add("2302");

            dsResult.Columns.Add("2400");
            dsResult.Columns.Add("2401");
            dsResult.Columns.Add("2402");

            dsResult.Columns.Add("2500");
            dsResult.Columns.Add("2501");
            dsResult.Columns.Add("2502");

            dsResult.Columns.Add("2600");
            dsResult.Columns.Add("2601");
            dsResult.Columns.Add("2602");

            dsResult.Columns.Add("2700");
            dsResult.Columns.Add("2701");
            dsResult.Columns.Add("2702");

            dsResult.Columns.Add("2800");
            dsResult.Columns.Add("2801");
            dsResult.Columns.Add("2802");

            dsResult.Columns.Add("2900");
            dsResult.Columns.Add("2901");
            dsResult.Columns.Add("2902");

            dsResult.Columns.Add("3000");
            dsResult.Columns.Add("3001");
            dsResult.Columns.Add("3002");

            dsResult.Columns.Add("3100");
            dsResult.Columns.Add("3101");
            dsResult.Columns.Add("3102");
            #endregion
            DataTable dt = dsResult.Copy();
            string value = "";
            var row = dt.Rows.Count;
            #region Data2
            t++;
            for (int i = 0; i < row; i++)
            {
                for (int j = 6; j < t + 5; j++)
                {
                    value = dt.Rows[i][j].ToString();
                    if (value != "")
                    {
                        if (j == 6)
                        {
                            string[] splitPipeValue = value.Split('/');
                            dt.Rows[i][t + 5] = splitPipeValue[0].ToString();//36
                            dt.Rows[i][t + 6] = splitPipeValue[1].ToString();
                            dt.Rows[i][t + 7] = splitPipeValue[2].ToString();
                        }
                        if (j == 7)
                        {
                            string[] splitPipeValue = value.Split('/');
                            dt.Rows[i][t + 8] = splitPipeValue[0].ToString();//39
                            dt.Rows[i][t + 9] = splitPipeValue[1].ToString();
                            dt.Rows[i][t + 10] = splitPipeValue[2].ToString();
                        }
                        if (j == 8)
                        {
                            string[] splitPipeValue = value.Split('/');
                            dt.Rows[i][t + 11] = splitPipeValue[0].ToString();//42
                            dt.Rows[i][t + 12] = splitPipeValue[1].ToString();
                            dt.Rows[i][t + 13] = splitPipeValue[2].ToString();
                        }
                        if (j == 9)
                        {
                            string[] splitPipeValue = value.Split('/');
                            dt.Rows[i][t + 14] = splitPipeValue[0].ToString();//45
                            dt.Rows[i][t + 15] = splitPipeValue[1].ToString();
                            dt.Rows[i][t + 16] = splitPipeValue[2].ToString();
                        }
                        if (j == 10)//5
                        {
                            string[] splitPipeValue = value.Split('/');
                            dt.Rows[i][t + 17] = splitPipeValue[0].ToString();//48
                            dt.Rows[i][t + 18] = splitPipeValue[1].ToString();
                            dt.Rows[i][t + 19] = splitPipeValue[2].ToString();
                        }
                        if (j == 11)
                        {
                            string[] splitPipeValue = value.Split('/');
                            dt.Rows[i][t + 20] = splitPipeValue[0].ToString();//51
                            dt.Rows[i][t + 21] = splitPipeValue[1].ToString();
                            dt.Rows[i][t + 22] = splitPipeValue[2].ToString();
                        }
                        if (j == 12)
                        {
                            string[] splitPipeValue = value.Split('/');
                            dt.Rows[i][t + 23] = splitPipeValue[0].ToString();//54
                            dt.Rows[i][t + 24] = splitPipeValue[1].ToString();
                            dt.Rows[i][t + 25] = splitPipeValue[2].ToString();
                        }
                        if (j == 13)
                        {
                            string[] splitPipeValue = value.Split('/');
                            dt.Rows[i][t + 26] = splitPipeValue[0].ToString();//57
                            dt.Rows[i][t + 27] = splitPipeValue[1].ToString();
                            dt.Rows[i][t + 28] = splitPipeValue[2].ToString();
                        }
                        if (j == 14)
                        {
                            string[] splitPipeValue = value.Split('/');
                            dt.Rows[i][t + 29] = splitPipeValue[0].ToString();//60
                            dt.Rows[i][t + 30] = splitPipeValue[1].ToString();
                            dt.Rows[i][t + 31] = splitPipeValue[2].ToString();
                        }
                        if (j == 15)//10
                        {
                            string[] splitPipeValue = value.Split('/');
                            dt.Rows[i][t + 32] = splitPipeValue[0].ToString();//63
                            dt.Rows[i][t + 33] = splitPipeValue[1].ToString();
                            dt.Rows[i][t + 34] = splitPipeValue[2].ToString();
                        }
                        if (j == 16)
                        {
                            string[] splitPipeValue = value.Split('/');
                            dt.Rows[i][t + 35] = splitPipeValue[0].ToString();
                            dt.Rows[i][t + 36] = splitPipeValue[1].ToString();
                            dt.Rows[i][t + 37] = splitPipeValue[2].ToString();
                        }
                        if (j == 17)
                        {
                            string[] splitPipeValue = value.Split('/');
                            dt.Rows[i][t + 38] = splitPipeValue[0].ToString();
                            dt.Rows[i][t + 39] = splitPipeValue[1].ToString();
                            dt.Rows[i][t + 40] = splitPipeValue[2].ToString();
                        }
                        if (j == 18)
                        {
                            string[] splitPipeValue = value.Split('/');
                            dt.Rows[i][t + 41] = splitPipeValue[0].ToString();
                            dt.Rows[i][t + 42] = splitPipeValue[1].ToString();
                            dt.Rows[i][t + 43] = splitPipeValue[2].ToString();
                        }
                        if (j == 19)
                        {
                            string[] splitPipeValue = value.Split('/');
                            dt.Rows[i][t + 44] = splitPipeValue[0].ToString();
                            dt.Rows[i][t + 45] = splitPipeValue[1].ToString();
                            dt.Rows[i][t + 46] = splitPipeValue[2].ToString();
                        }
                        if (j == 20)//15
                        {
                            string[] splitPipeValue = value.Split('/');
                            dt.Rows[i][t + 47] = splitPipeValue[0].ToString();
                            dt.Rows[i][t + 48] = splitPipeValue[1].ToString();
                            dt.Rows[i][t + 49] = splitPipeValue[2].ToString();
                        }
                        if (j == 21)
                        {
                            string[] splitPipeValue = value.Split('/');
                            dt.Rows[i][t + 50] = splitPipeValue[0].ToString();//81
                            dt.Rows[i][t + 51] = splitPipeValue[1].ToString();
                            dt.Rows[i][t + 52] = splitPipeValue[2].ToString();
                        }
                        if (j == 22)
                        {
                            string[] splitPipeValue = value.Split('/');
                            dt.Rows[i][t + 53] = splitPipeValue[0].ToString();
                            dt.Rows[i][t + 54] = splitPipeValue[1].ToString();
                            dt.Rows[i][t + 55] = splitPipeValue[2].ToString();
                        }
                        if (j == 23)
                        {
                            string[] splitPipeValue = value.Split('/');
                            dt.Rows[i][t + 56] = splitPipeValue[0].ToString();
                            dt.Rows[i][t + 57] = splitPipeValue[1].ToString();
                            dt.Rows[i][t + 58] = splitPipeValue[2].ToString();
                        }
                        if (j == 24)
                        {
                            string[] splitPipeValue = value.Split('/');
                            dt.Rows[i][t + 59] = splitPipeValue[0].ToString();
                            dt.Rows[i][t + 60] = splitPipeValue[1].ToString();
                            dt.Rows[i][t + 61] = splitPipeValue[2].ToString();
                        }
                        if (j == 25)//20
                        {
                            string[] splitPipeValue = value.Split('/');
                            dt.Rows[i][t + 62] = splitPipeValue[0].ToString();
                            dt.Rows[i][t + 63] = splitPipeValue[1].ToString();
                            dt.Rows[i][t + 64] = splitPipeValue[2].ToString();
                        }
                        if (j == 26)
                        {
                            string[] splitPipeValue = value.Split('/');
                            dt.Rows[i][t + 65] = splitPipeValue[0].ToString();
                            dt.Rows[i][t + 66] = splitPipeValue[1].ToString();
                            dt.Rows[i][t + 67] = splitPipeValue[2].ToString();
                        }
                        if (j == 27)
                        {
                            string[] splitPipeValue = value.Split('/');
                            dt.Rows[i][t + 68] = splitPipeValue[0].ToString();
                            dt.Rows[i][t + 69] = splitPipeValue[1].ToString();
                            dt.Rows[i][t + 70] = splitPipeValue[2].ToString();
                        }
                        if (j == 28)
                        {
                            string[] splitPipeValue = value.Split('/');
                            dt.Rows[i][t + 71] = splitPipeValue[0].ToString();
                            dt.Rows[i][t + 72] = splitPipeValue[1].ToString();
                            dt.Rows[i][t + 73] = splitPipeValue[2].ToString();
                        }
                        if (j == 29)
                        {
                            string[] splitPipeValue = value.Split('/');
                            dt.Rows[i][t + 74] = splitPipeValue[0].ToString();
                            dt.Rows[i][t + 75] = splitPipeValue[1].ToString();
                            dt.Rows[i][t + 76] = splitPipeValue[2].ToString();
                        }
                        if (j == 30)//25
                        {
                            string[] splitPipeValue = value.Split('/');
                            dt.Rows[i][t + 77] = splitPipeValue[0].ToString();//108
                            dt.Rows[i][t + 78] = splitPipeValue[1].ToString();
                            dt.Rows[i][t + 79] = splitPipeValue[2].ToString();
                        }
                        if (j == 31)//26
                        {
                            string[] splitPipeValue = value.Split('/');
                            dt.Rows[i][t + 80] = splitPipeValue[0].ToString();
                            dt.Rows[i][t + 81] = splitPipeValue[1].ToString();
                            dt.Rows[i][t + 82] = splitPipeValue[2].ToString();
                        }
                        if (j == 32)//27
                        {
                            string[] splitPipeValue = value.Split('/');
                            dt.Rows[i][t + 83] = splitPipeValue[0].ToString();
                            dt.Rows[i][t + 84] = splitPipeValue[1].ToString();
                            dt.Rows[i][t + 85] = splitPipeValue[2].ToString();
                        }
                        if (j == 33 && t > 28)//28
                        {
                            string[] splitPipeValue = value.Split('/');
                            dt.Rows[i][t + 86] = splitPipeValue[0].ToString();
                            dt.Rows[i][t + 87] = splitPipeValue[1].ToString();
                            dt.Rows[i][t + 88] = splitPipeValue[2].ToString();
                        }
                        if (j == 34 && t - 1 > 28)//29
                        {
                            string[] splitPipeValue = value.Split('/');
                            dt.Rows[i][t + 89] = splitPipeValue[0].ToString();
                            dt.Rows[i][t + 90] = splitPipeValue[1].ToString();
                            dt.Rows[i][t + 91] = splitPipeValue[2].ToString();
                        }
                        if (j == 35 && t - 1 > 28)//30
                        {
                            string[] splitPipeValue = value.Split('/');
                            dt.Rows[i][t + 92] = splitPipeValue[0].ToString();
                            dt.Rows[i][t + 93] = splitPipeValue[1].ToString();
                            dt.Rows[i][t + 94] = splitPipeValue[2].ToString();
                        }
                        if (j == 36 && t - 1 == 31)//31
                        {
                            string[] splitPipeValue = value.Split('/');
                            dt.Rows[i][t + 95] = splitPipeValue[0].ToString();
                            dt.Rows[i][t + 96] = splitPipeValue[1].ToString();
                            dt.Rows[i][t + 97] = splitPipeValue[2].ToString();
                        }
                    }
                }
            }
            #endregion
            if (dt.Rows.Count > 0)
            {
                gvAssetScheduling.Visible = true;
                gvAssetScheduling.DataSource = dt;
                gvAssetScheduling.DataBind();
                lblNodata.Visible = false;
                btnExport.Visible = true;
                lnkBack.Visible = false;
            }
            else
            {
                gvAssetScheduling.Visible = true;
                dt.Rows.Add(dt.NewRow());
                gvAssetScheduling.DataSource = dt;
                gvAssetScheduling.DataBind();
                lblNodata.Visible = true;
                btnExport.Visible = false;
                lnkBack.Visible = false;
            }
            if (t - 1 == 28)
            {
                gvAssetScheduling.Columns[29].Visible = false;//29
                gvAssetScheduling.Columns[30].Visible = false;//30
                gvAssetScheduling.Columns[31].Visible = false;//31
            }
            if (t - 1 == 30)
            {
                gvAssetScheduling.Columns[29].Visible = true;//29
                gvAssetScheduling.Columns[30].Visible = true;//30
                gvAssetScheduling.Columns[31].Visible = false;//31
            }
            if (t - 1 == 31)
            {
                gvAssetScheduling.Columns[29].Visible = true;//29
                gvAssetScheduling.Columns[30].Visible = true;//30
                gvAssetScheduling.Columns[31].Visible = true;//31
            }
        }
        catch (Exception ex) { }
    }
    protected void ddlYear_SelectedIndexChanged(object sender, EventArgs e)
    {
        year = Convert.ToInt32(ddlYear.SelectedValue);
        month = Convert.ToInt32(ddlmonth.SelectedValue);
        FillgvAssetScheduling(Convert.ToInt32(year), Convert.ToInt32(month));
    }
    protected void ddlmonth_SelectedIndexChanged(object sender, EventArgs e)
    {
     //   year = Convert.ToInt32(ddlYear.SelectedValue);
      //  month = Convert.ToInt32(ddlmonth.SelectedValue);
     //   FillgvAssetScheduling(Convert.ToInt32(year), Convert.ToInt32(month));
        Response.Clear();
        Response.Buffer = true;

        Response.AddHeader("content-disposition", "attachment;filename=AttendanceMusterWithTimings - " + lblMainHead.Text +"-" + ddlmonth.SelectedItem.Text + '(' + ddlYear.SelectedValue + ')' + ".xls");
        Response.Charset = "";
        Response.ContentType = "application/vnd.ms-excel";
        using (StringWriter sw = new StringWriter())
        {
            HtmlTextWriter hw = new HtmlTextWriter(sw);         
            gvAssetScheduling.AllowPaging = false;
            FillgvAssetScheduling(Convert.ToInt32(ddlYear.SelectedValue), Convert.ToInt32(ddlmonth.SelectedValue));           
            gvAssetScheduling.RenderControl(hw);
            //style to format numbers to string
            string style = @"<style> .textmode { } </style>";
            Response.Write(style);
            Response.Output.Write(sw.ToString());
            Response.Flush();
            Response.End();
        }        
    }
    protected void gvAssetScheduling_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        string A = "Color:#FF3434;Font-weight:Bold";
        string P = "Color:green;Font-weight:Bold";
        string B = "Color:#2e6293;Font-weight:Bold";
        string T = "Color:black;Font-weight:Bold";
        string N = "Color:#cc0052;Font-weight:Bold";
        string H = "Color:#e29600;Font-weight:Bold";
        var startDate = new DateTime(Convert.ToInt32(ddlYear.SelectedValue), Convert.ToInt32(ddlmonth.SelectedValue), 1);
        #region Information
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            LinkButton lblEmpCode = (LinkButton)e.Row.FindControl("lblEmpCode");
            lblEmpCode.Attributes.Add("style", N);
            Label lblEmpName = (Label)e.Row.FindControl("lblAssetName");
            lblEmpName.Attributes.Add("style", B);
            Label lblDesignation = (Label)e.Row.FindControl("lblAsseqName");
            lblDesignation.Attributes.Add("style", B);
            Label lblDutyday = (Label)e.Row.FindControl("Label10");
            lblDutyday.Attributes.Add("style", T);
            Label lblDutyHrs = (Label)e.Row.FindControl("Label11");
            lblDutyHrs.Attributes.Add("style", T);
        }
        #endregion
        #region Date
        if (e.Row.RowType == DataControlRowType.Header)
        {
            var lbld1 = (Label)e.Row.FindControl("lbld1");
            if (lbld1 != null)
            {
                lbld1.Text = startDate.ToString("dd-MMM-yyyy") + " [" + Convert.ToDateTime(startDate).DayOfWeek.ToString() + " ]";
            }
            var lbld2 = (Label)e.Row.FindControl("lbld2");
            if (lbld2 != null)
            {
                var SDay = Convert.ToDateTime(startDate).AddDays(1).ToString("dd-MMM-yyyy");
                lbld2.Text = Convert.ToDateTime(startDate).AddDays(1).ToString("dd-MMM-yyyy") + " [" + Convert.ToDateTime(SDay).DayOfWeek.ToString() + " ]";
            }
            var lbld3 = (Label)e.Row.FindControl("lbld3");
            if (lbld3 != null)
            {
                var TDay = Convert.ToDateTime(startDate).AddDays(2).ToString("dd-MMM-yyyy");
                lbld3.Text = Convert.ToDateTime(startDate).AddDays(2).ToString("dd-MMM-yyyy") + " [" + Convert.ToDateTime(TDay).DayOfWeek.ToString() + "]";
            }
            var lbld4 = (Label)e.Row.FindControl("lbld4");
            if (lbld4 != null)
            {
                var TDay = Convert.ToDateTime(startDate).AddDays(3).ToString("dd-MMM-yyyy");
                lbld4.Text = Convert.ToDateTime(startDate).AddDays(3).ToString("dd-MMM-yyyy") + " [" + Convert.ToDateTime(TDay).DayOfWeek.ToString() + "]";
            }
            var lbld5 = (Label)e.Row.FindControl("lbld5");
            if (lbld5 != null)
            {
                var TDay = Convert.ToDateTime(startDate).AddDays(4).ToString("dd-MMM-yyyy");
                lbld5.Text = Convert.ToDateTime(startDate).AddDays(4).ToString("dd-MMM-yyyy") + " [" + Convert.ToDateTime(TDay).DayOfWeek.ToString() + "]";
            }
            var lbld6 = (Label)e.Row.FindControl("lbld6");
            if (lbld6 != null)
            {
                var TDay = Convert.ToDateTime(startDate).AddDays(5).ToString("dd-MMM-yyyy");
                lbld6.Text = Convert.ToDateTime(startDate).AddDays(5).ToString("dd-MMM-yyyy") + " [" + Convert.ToDateTime(TDay).DayOfWeek.ToString() + "]";
            }
            var lbld7 = (Label)e.Row.FindControl("lbld7");
            if (lbld7 != null)
            {
                var TDay = Convert.ToDateTime(startDate).AddDays(6).ToString("dd-MMM-yyyy");
                lbld7.Text = Convert.ToDateTime(startDate).AddDays(6).ToString("dd-MMM-yyyy") + " [" + Convert.ToDateTime(TDay).DayOfWeek.ToString() + "]";
            }
            var lbld8 = (Label)e.Row.FindControl("lbld8");
            if (lbld8 != null)
            {
                var TDay = Convert.ToDateTime(startDate).AddDays(7).ToString("dd-MMM-yyyy");
                lbld8.Text = Convert.ToDateTime(startDate).AddDays(7).ToString("dd-MMM-yyyy") + " [" + Convert.ToDateTime(TDay).DayOfWeek.ToString() + "]";
            }
            var lbld9 = (Label)e.Row.FindControl("lbld9");
            if (lbld9 != null)
            {
                var TDay = Convert.ToDateTime(startDate).AddDays(8).ToString("dd-MMM-yyyy");
                lbld9.Text = Convert.ToDateTime(startDate).AddDays(8).ToString("dd-MMM-yyyy") + " [" + Convert.ToDateTime(TDay).DayOfWeek.ToString() + "]";
            }
            var lbld10 = (Label)e.Row.FindControl("lbld10");
            if (lbld10 != null)
            {
                var TDay = Convert.ToDateTime(startDate).AddDays(9).ToString("dd-MMM-yyyy");
                lbld10.Text = Convert.ToDateTime(startDate).AddDays(9).ToString("dd-MMM-yyyy") + " [" + Convert.ToDateTime(TDay).DayOfWeek.ToString() + "]";
            }
            var lbld11 = (Label)e.Row.FindControl("lbld11");
            if (lbld11 != null)
            {
                var TDay = Convert.ToDateTime(startDate).AddDays(10).ToString("dd-MMM-yyyy");
                lbld11.Text = Convert.ToDateTime(startDate).AddDays(10).ToString("dd-MMM-yyyy") + " [" + Convert.ToDateTime(TDay).DayOfWeek.ToString() + "]";
            }
            var lbld12 = (Label)e.Row.FindControl("lbld12");
            if (lbld12 != null)
            {
                var SDay = Convert.ToDateTime(startDate).AddDays(11).ToString("dd-MMM-yyyy");
                lbld12.Text = Convert.ToDateTime(startDate).AddDays(11).ToString("dd-MMM-yyyy") + " [" + Convert.ToDateTime(SDay).DayOfWeek.ToString() + " ]";
            }
            var lbld13 = (Label)e.Row.FindControl("lbld13");
            if (lbld13 != null)
            {
                var TDay = Convert.ToDateTime(startDate).AddDays(12).ToString("dd-MMM-yyyy");
                lbld13.Text = Convert.ToDateTime(startDate).AddDays(12).ToString("dd-MMM-yyyy") + " [" + Convert.ToDateTime(TDay).DayOfWeek.ToString() + "]";
            }
            var lbld14 = (Label)e.Row.FindControl("lbld14");
            if (lbld14 != null)
            {
                var TDay = Convert.ToDateTime(startDate).AddDays(13).ToString("dd-MMM-yyyy");
                lbld14.Text = Convert.ToDateTime(startDate).AddDays(13).ToString("dd-MMM-yyyy") + " [" + Convert.ToDateTime(TDay).DayOfWeek.ToString() + "]";
            }
            var lbld15 = (Label)e.Row.FindControl("lbld15");
            if (lbld15 != null)
            {
                var TDay = Convert.ToDateTime(startDate).AddDays(14).ToString("dd-MMM-yyyy");
                lbld15.Text = Convert.ToDateTime(startDate).AddDays(14).ToString("dd-MMM-yyyy") + " [" + Convert.ToDateTime(TDay).DayOfWeek.ToString() + "]";
            }
            var lbld16 = (Label)e.Row.FindControl("lbld16");
            if (lbld16 != null)
            {
                var TDay = Convert.ToDateTime(startDate).AddDays(15).ToString("dd-MMM-yyyy");
                lbld16.Text = Convert.ToDateTime(startDate).AddDays(15).ToString("dd-MMM-yyyy") + " [" + Convert.ToDateTime(TDay).DayOfWeek.ToString() + "]";
            }
            var lbld17 = (Label)e.Row.FindControl("lbld17");
            if (lbld17 != null)
            {
                var TDay = Convert.ToDateTime(startDate).AddDays(16).ToString("dd-MMM-yyyy");
                lbld17.Text = Convert.ToDateTime(startDate).AddDays(16).ToString("dd-MMM-yyyy") + " [" + Convert.ToDateTime(TDay).DayOfWeek.ToString() + "]";
            }
            var lbld18 = (Label)e.Row.FindControl("lbld18");
            if (lbld18 != null)
            {
                var TDay = Convert.ToDateTime(startDate).AddDays(17).ToString("dd-MMM-yyyy");
                lbld18.Text = Convert.ToDateTime(startDate).AddDays(17).ToString("dd-MMM-yyyy") + " [" + Convert.ToDateTime(TDay).DayOfWeek.ToString() + "]";
            }
            var lbld19 = (Label)e.Row.FindControl("lbld19");
            if (lbld19 != null)
            {
                var TDay = Convert.ToDateTime(startDate).AddDays(18).ToString("dd-MMM-yyyy");
                lbld19.Text = Convert.ToDateTime(startDate).AddDays(18).ToString("dd-MMM-yyyy") + " [" + Convert.ToDateTime(TDay).DayOfWeek.ToString() + "]";
            }
            var lbld20 = (Label)e.Row.FindControl("lbld20");
            if (lbld20 != null)
            {
                var TDay = Convert.ToDateTime(startDate).AddDays(19).ToString("dd-MMM-yyyy");
                lbld20.Text = Convert.ToDateTime(startDate).AddDays(19).ToString("dd-MMM-yyyy") + " [" + Convert.ToDateTime(TDay).DayOfWeek.ToString() + "]";
            }
            var lbld21 = (Label)e.Row.FindControl("lbld21");
            if (lbld21 != null)
            {
                var SDay = Convert.ToDateTime(startDate).AddDays(20).ToString("dd-MMM-yyyy");
                lbld21.Text = Convert.ToDateTime(startDate).AddDays(20).ToString("dd-MMM-yyyy") + " [" + Convert.ToDateTime(SDay).DayOfWeek.ToString() + " ]";
            }
            var lbld22 = (Label)e.Row.FindControl("lbld22");
            if (lbld22 != null)
            {
                var SDay = Convert.ToDateTime(startDate).AddDays(21).ToString("dd-MMM-yyyy");
                lbld22.Text = Convert.ToDateTime(startDate).AddDays(21).ToString("dd-MMM-yyyy") + " [" + Convert.ToDateTime(SDay).DayOfWeek.ToString() + " ]";
            }
            var lbld23 = (Label)e.Row.FindControl("lbld23");
            if (lbld23 != null)
            {
                var TDay = Convert.ToDateTime(startDate).AddDays(22).ToString("dd-MMM-yyyy");
                lbld23.Text = Convert.ToDateTime(startDate).AddDays(22).ToString("dd-MMM-yyyy") + " [" + Convert.ToDateTime(TDay).DayOfWeek.ToString() + "]";
            }
            var lbld24 = (Label)e.Row.FindControl("lbld24");
            if (lbld24 != null)
            {
                var TDay = Convert.ToDateTime(startDate).AddDays(23).ToString("dd-MMM-yyyy");
                lbld24.Text = Convert.ToDateTime(startDate).AddDays(23).ToString("dd-MMM-yyyy") + " [" + Convert.ToDateTime(TDay).DayOfWeek.ToString() + "]";
            }
            var lbld25 = (Label)e.Row.FindControl("lbld25");
            if (lbld25 != null)
            {
                var TDay = Convert.ToDateTime(startDate).AddDays(24).ToString("dd-MMM-yyyy");
                lbld25.Text = Convert.ToDateTime(startDate).AddDays(24).ToString("dd-MMM-yyyy") + " [" + Convert.ToDateTime(TDay).DayOfWeek.ToString() + "]";
            }
            var lbld26 = (Label)e.Row.FindControl("lbld26");
            if (lbld26 != null)
            {
                var TDay = Convert.ToDateTime(startDate).AddDays(25).ToString("dd-MMM-yyyy");
                lbld26.Text = Convert.ToDateTime(startDate).AddDays(25).ToString("dd-MMM-yyyy") + " [" + Convert.ToDateTime(TDay).DayOfWeek.ToString() + "]";
            }
            var lbld27 = (Label)e.Row.FindControl("lbld27");
            if (lbld27 != null)
            {
                var TDay = Convert.ToDateTime(startDate).AddDays(26).ToString("dd-MMM-yyyy");
                lbld27.Text = Convert.ToDateTime(startDate).AddDays(26).ToString("dd-MMM-yyyy") + " [" + Convert.ToDateTime(TDay).DayOfWeek.ToString() + "]";
            }
            var lbld28 = (Label)e.Row.FindControl("lbld28");
            if (lbld28 != null)
            {
                var TDay = Convert.ToDateTime(startDate).AddDays(27).ToString("dd-MMM-yyyy");
                lbld28.Text = Convert.ToDateTime(startDate).AddDays(27).ToString("dd-MMM-yyyy") + " [" + Convert.ToDateTime(TDay).DayOfWeek.ToString() + "]";
            }
            var lbld29 = (Label)e.Row.FindControl("lbld29");
            if (lbld29 != null)
            {
                var TDay = Convert.ToDateTime(startDate).AddDays(28).ToString("dd-MMM-yyyy");
                lbld29.Text = Convert.ToDateTime(startDate).AddDays(28).ToString("dd-MMM-yyyy") + " [" + Convert.ToDateTime(TDay).DayOfWeek.ToString() + "]";
            }
            var lbld30 = (Label)e.Row.FindControl("lbld30");
            if (lbld30 != null)
            {
                var TDay = Convert.ToDateTime(startDate).AddDays(29).ToString("dd-MMM-yyyy");
                lbld30.Text = Convert.ToDateTime(startDate).AddDays(29).ToString("dd-MMM-yyyy") + " [" + Convert.ToDateTime(TDay).DayOfWeek.ToString() + "]";
            }
            var lbld31 = (Label)e.Row.FindControl("lbld31");
            if (lbld31 != null)
            {
                var TDay = Convert.ToDateTime(startDate).AddDays(30).ToString("dd-MMM-yyyy");
                lbld31.Text = Convert.ToDateTime(startDate).AddDays(30).ToString("dd-MMM-yyyy") + " [" + Convert.ToDateTime(TDay).DayOfWeek.ToString() + "]";
            }
        }
        #endregion
        #region A/P
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            Label lbla1 = (Label)e.Row.FindControl("lbla1");
            Label lbln1 = (Label)e.Row.FindControl("lbln1");
            Label lblt1 = (Label)e.Row.FindControl("lblt1");
            if (lbla1.Text == "A")
            {
                lbla1.Attributes.Add("style", A);
                lbln1.Attributes.Add("style", A);
                lblt1.Attributes.Add("style", A);
            }
            else if (lbla1.Text == "P")
            {
                lbla1.Attributes.Add("style", P);
                lbln1.Attributes.Add("style", P);
                lblt1.Attributes.Add("style", P);
            }
            else
            {
                lbla1.Attributes.Add("style", H);
                lbln1.Attributes.Add("style", H);
                lblt1.Attributes.Add("style", H);
            }
            Label lbla2 = (Label)e.Row.FindControl("lbla2");
            Label lbln2 = (Label)e.Row.FindControl("lbln2");
            Label lblt2 = (Label)e.Row.FindControl("lblt2");
            if (lbla2.Text == "A")
            {
                lbla2.Attributes.Add("style", A);
                lbln2.Attributes.Add("style", A);
                lblt2.Attributes.Add("style", A);
            }
            else if (lbla2.Text == "P")
            {
                lbla2.Attributes.Add("style", P);
                lbln2.Attributes.Add("style", P);
                lblt2.Attributes.Add("style", P);
            }
            else
            {
                lbla2.Attributes.Add("style", H);
                lbln2.Attributes.Add("style", H);
                lblt2.Attributes.Add("style", H);
            }
            Label lbla3 = (Label)e.Row.FindControl("lbla3");
            Label lbln3 = (Label)e.Row.FindControl("lbln3");
            Label lblt3 = (Label)e.Row.FindControl("lblt3");
            if (lbla3.Text == "A")
            {
                lbla3.Attributes.Add("style", A);
                lbln3.Attributes.Add("style", A);
                lblt3.Attributes.Add("style", A);
            }
            else if (lbla3.Text == "P")
            {
                lbla3.Attributes.Add("style", P);
                lbln3.Attributes.Add("style", P);
                lblt3.Attributes.Add("style", P);
            }
            else
            {
                lbla3.Attributes.Add("style", H);
                lbln3.Attributes.Add("style", H);
                lblt3.Attributes.Add("style", H);
            }
            Label lbla4 = (Label)e.Row.FindControl("lbla4");
            Label lbln4 = (Label)e.Row.FindControl("lbln4");
            Label lblt4 = (Label)e.Row.FindControl("lblt4");
            if (lbla4.Text == "A")
            {
                lbla4.Attributes.Add("style", A);
                lbln4.Attributes.Add("style", A);
                lblt4.Attributes.Add("style", A);
            }
            else if (lbla4.Text == "P")
            {
                lbla4.Attributes.Add("style", P);
                lbln4.Attributes.Add("style", P);
                lblt4.Attributes.Add("style", P);
            }
            else
            {
                lbla4.Attributes.Add("style", H);
                lbln4.Attributes.Add("style", H);
                lblt4.Attributes.Add("style", H);
            }
            Label lbla5 = (Label)e.Row.FindControl("lbla5");
            Label lbln5 = (Label)e.Row.FindControl("lbln5");
            Label lblt5 = (Label)e.Row.FindControl("lblt5");
            if (lbla5.Text == "A")
            {
                lbla5.Attributes.Add("style", A);
                lbln5.Attributes.Add("style", A);
                lblt5.Attributes.Add("style", A);
            }
            else if (lbla5.Text == "P")
            {
                lbla5.Attributes.Add("style", P);
                lbln5.Attributes.Add("style", P);
                lblt5.Attributes.Add("style", P);
            }
            else
            {
                lbla5.Attributes.Add("style", H);
                lbln5.Attributes.Add("style", H);
                lblt5.Attributes.Add("style", H);
            }
            Label lbla6 = (Label)e.Row.FindControl("lbla6");
            Label lbln6 = (Label)e.Row.FindControl("lbln6");
            Label lblt6 = (Label)e.Row.FindControl("lblt6");
            if (lbla6.Text == "A")
            {
                lbla6.Attributes.Add("style", A);
                lbln6.Attributes.Add("style", A);
                lblt6.Attributes.Add("style", A);
            }
            else if (lbla6.Text == "P")
            {
                lbla6.Attributes.Add("style", P);
                lbln6.Attributes.Add("style", P);
                lblt6.Attributes.Add("style", P);
            }
            else
            {
                lbla6.Attributes.Add("style", H);
                lbln6.Attributes.Add("style", H);
                lblt6.Attributes.Add("style", H);
            }
            Label lbla7 = (Label)e.Row.FindControl("lbla7");
            Label lbln7 = (Label)e.Row.FindControl("lbln7");
            Label lblt7 = (Label)e.Row.FindControl("lblt7");
            if (lbla7.Text == "A")
            {
                lbla7.Attributes.Add("style", A);
                lbln7.Attributes.Add("style", A);
                lblt7.Attributes.Add("style", A);
            }
            else if (lbla7.Text == "P")
            {
                lbla7.Attributes.Add("style", P);
                lbln7.Attributes.Add("style", P);
                lblt7.Attributes.Add("style", P);
            }
            else
            {
                lbla7.Attributes.Add("style", H);
                lbln7.Attributes.Add("style", H);
                lblt7.Attributes.Add("style", H);
            }
            Label lbla8 = (Label)e.Row.FindControl("lbla8");
            Label lbln8 = (Label)e.Row.FindControl("lbln8");
            Label lblt8 = (Label)e.Row.FindControl("lblt8");
            if (lbla8.Text == "A")
            {
                lbla8.Attributes.Add("style", A);
                lbln8.Attributes.Add("style", A);
                lblt8.Attributes.Add("style", A);
            }
            else if (lbla8.Text == "P")
            {
                lbla8.Attributes.Add("style", P);
                lbln8.Attributes.Add("style", P);
                lblt8.Attributes.Add("style", P);
            }
            else
            {
                lbla8.Attributes.Add("style", H);
                lbln8.Attributes.Add("style", H);
                lblt8.Attributes.Add("style", H);
            }
            Label lbla9 = (Label)e.Row.FindControl("lbla9");
            Label lbln9 = (Label)e.Row.FindControl("lbln9");
            Label lblt9 = (Label)e.Row.FindControl("lblt9");
            if (lbla9.Text == "A")
            {
                lbla9.Attributes.Add("style", A);
                lbln9.Attributes.Add("style", A);
                lblt9.Attributes.Add("style", A);
            }
            else if (lbla9.Text == "P")
            {
                lbla9.Attributes.Add("style", P);
                lbln9.Attributes.Add("style", P);
                lblt9.Attributes.Add("style", P);
            }
            else
            {
                lbla9.Attributes.Add("style", H);
                lbln9.Attributes.Add("style", H);
                lblt9.Attributes.Add("style", H);
            }
            Label lbla10 = (Label)e.Row.FindControl("lbla10");
            Label lbln10 = (Label)e.Row.FindControl("lbln10");
            Label lblt10 = (Label)e.Row.FindControl("lblt10");
            if (lbla10.Text == "A")
            {
                lbla10.Attributes.Add("style", A);
                lbln10.Attributes.Add("style", A);
                lblt10.Attributes.Add("style", A);
            }
            else if (lbla10.Text == "P")
            {
                lbla10.Attributes.Add("style", P);
                lbln10.Attributes.Add("style", P);
                lblt10.Attributes.Add("style", P);
            }
            else
            {
                lbla10.Attributes.Add("style", H);
                lbln10.Attributes.Add("style", H);
                lblt10.Attributes.Add("style", H);
            }
            Label lbla11 = (Label)e.Row.FindControl("lbla11");
            Label lbln11 = (Label)e.Row.FindControl("lbln11");
            Label lblt11 = (Label)e.Row.FindControl("lblt11");
            if (lbla11.Text == "A")
            {
                lbla11.Attributes.Add("style", A);
                lbln11.Attributes.Add("style", A);
                lblt11.Attributes.Add("style", A);
            }
            else if (lbla11.Text == "P")
            {
                lbla11.Attributes.Add("style", P);
                lbln11.Attributes.Add("style", P);
                lblt11.Attributes.Add("style", P);
            }
            else
            {
                lbla11.Attributes.Add("style", H);
                lbln11.Attributes.Add("style", H);
                lblt11.Attributes.Add("style", H);
            }
            Label lbla12 = (Label)e.Row.FindControl("lbla12");
            Label lbln12 = (Label)e.Row.FindControl("lbln12");
            Label lblt12 = (Label)e.Row.FindControl("lblt12");
            if (lbla12.Text == "A")
            {
                lbla12.Attributes.Add("style", A);
                lbln12.Attributes.Add("style", A);
                lblt12.Attributes.Add("style", A);
            }
            else if (lbla12.Text == "P")
            {
                lbla12.Attributes.Add("style", P);
                lbln12.Attributes.Add("style", P);
                lblt12.Attributes.Add("style", P);
            }
            else
            {
                lbla12.Attributes.Add("style", H);
                lbln12.Attributes.Add("style", H);
                lblt12.Attributes.Add("style", H);
            }
            Label lbla13 = (Label)e.Row.FindControl("lbla13");
            Label lbln13 = (Label)e.Row.FindControl("lbln13");
            Label lblt13 = (Label)e.Row.FindControl("lblt13");
            if (lbla13.Text == "A")
            {
                lbla13.Attributes.Add("style", A);
                lbln13.Attributes.Add("style", A);
                lblt13.Attributes.Add("style", A);
            }
            else if (lbla13.Text == "P")
            {
                lbla13.Attributes.Add("style", P);
                lbln13.Attributes.Add("style", P);
                lblt13.Attributes.Add("style", P);
            }
            else
            {
                lbla13.Attributes.Add("style", H);
                lbln13.Attributes.Add("style", H);
                lblt13.Attributes.Add("style", H);
            }
            Label lbla14 = (Label)e.Row.FindControl("lbla14");
            Label lbln14 = (Label)e.Row.FindControl("lbln14");
            Label lblt14 = (Label)e.Row.FindControl("lblt14");
            if (lbla14.Text == "A")
            {
                lbla14.Attributes.Add("style", A);
                lbln14.Attributes.Add("style", A);
                lblt14.Attributes.Add("style", A);
            }
            else if (lbla14.Text == "P")
            {
                lbla14.Attributes.Add("style", P);
                lbln14.Attributes.Add("style", P);
                lblt14.Attributes.Add("style", P);
            }
            else
            {
                lbla14.Attributes.Add("style", H);
                lbln14.Attributes.Add("style", H);
                lblt14.Attributes.Add("style", H);
            }
            Label lbla15 = (Label)e.Row.FindControl("lbla15");
            Label lbln15 = (Label)e.Row.FindControl("lbln15");
            Label lblt15 = (Label)e.Row.FindControl("lblt15");
            if (lbla15.Text == "A")
            {
                lbla15.Attributes.Add("style", A);
                lbln15.Attributes.Add("style", A);
                lblt15.Attributes.Add("style", A);
            }
            else if (lbla15.Text == "P")
            {
                lbla15.Attributes.Add("style", P);
                lbln15.Attributes.Add("style", P);
                lblt15.Attributes.Add("style", P);
            }
            else
            {
                lbla15.Attributes.Add("style", H);
                lbln15.Attributes.Add("style", H);
                lblt15.Attributes.Add("style", H);
            }
            Label lbla16 = (Label)e.Row.FindControl("lbla16");
            Label lbln16 = (Label)e.Row.FindControl("lbln16");
            Label lblt16 = (Label)e.Row.FindControl("lblt16");
            if (lbla16.Text == "A")
            {
                lbla16.Attributes.Add("style", A);
                lbln16.Attributes.Add("style", A);
                lblt16.Attributes.Add("style", A);
            }
            else if (lbla16.Text == "P")
            {
                lbla16.Attributes.Add("style", P);
                lbln16.Attributes.Add("style", P);
                lblt16.Attributes.Add("style", P);
            }
            else
            {
                lbla16.Attributes.Add("style", H);
                lbln16.Attributes.Add("style", H);
                lblt16.Attributes.Add("style", H);
            }
            Label lbla17 = (Label)e.Row.FindControl("lbla17");
            Label lbln17 = (Label)e.Row.FindControl("lbln17");
            Label lblt17 = (Label)e.Row.FindControl("lblt17");
            if (lbla17.Text == "A")
            {
                lbla17.Attributes.Add("style", A);
                lbln17.Attributes.Add("style", A);
                lblt17.Attributes.Add("style", A);
            }
            else if (lbla17.Text == "P")
            {
                lbla17.Attributes.Add("style", P);
                lbln17.Attributes.Add("style", P);
                lblt17.Attributes.Add("style", P);
            }
            else
            {
                lbla17.Attributes.Add("style", H);
                lbln17.Attributes.Add("style", H);
                lblt17.Attributes.Add("style", H);
            }
            Label lbla18 = (Label)e.Row.FindControl("lbla18");
            Label lbln18 = (Label)e.Row.FindControl("lbln18");
            Label lblt18 = (Label)e.Row.FindControl("lblt18");
            if (lbla18.Text == "A")
            {
                lbla18.Attributes.Add("style", A);
                lbln18.Attributes.Add("style", A);
                lblt18.Attributes.Add("style", A);
            }
            else if (lbla18.Text == "P")
            {
                lbla18.Attributes.Add("style", P);
                lbln18.Attributes.Add("style", P);
                lblt18.Attributes.Add("style", P);
            }
            else
            {
                lbla18.Attributes.Add("style", H);
                lbln18.Attributes.Add("style", H);
                lblt18.Attributes.Add("style", H);
            }
            Label lbla19 = (Label)e.Row.FindControl("lbla19");
            Label lbln19 = (Label)e.Row.FindControl("lbln19");
            Label lblt19 = (Label)e.Row.FindControl("lblt19");
            if (lbla19.Text == "A")
            {
                lbla19.Attributes.Add("style", A);
                lbln19.Attributes.Add("style", A);
                lblt19.Attributes.Add("style", A);
            }
            else if (lbla19.Text == "P")
            {
                lbla19.Attributes.Add("style", P);
                lbln19.Attributes.Add("style", P);
                lblt19.Attributes.Add("style", P);
            }
            else
            {
                lbla19.Attributes.Add("style", H);
                lbln19.Attributes.Add("style", H);
                lblt19.Attributes.Add("style", H);
            }
            Label lbla20 = (Label)e.Row.FindControl("lbla20");
            Label lbln20 = (Label)e.Row.FindControl("lbln20");
            Label lblt20 = (Label)e.Row.FindControl("lblt20");
            if (lbla20.Text == "A")
            {
                lbla20.Attributes.Add("style", A);
                lbln20.Attributes.Add("style", A);
                lblt20.Attributes.Add("style", A);
            }
            else if (lbla20.Text == "P")
            {
                lbla20.Attributes.Add("style", P);
                lbln20.Attributes.Add("style", P);
                lblt20.Attributes.Add("style", P);
            }
            else
            {
                lbla20.Attributes.Add("style", H);
                lbln20.Attributes.Add("style", H);
                lblt20.Attributes.Add("style", H);
            }
            Label lbla21 = (Label)e.Row.FindControl("lbla21");
            Label lbln21 = (Label)e.Row.FindControl("lbln21");
            Label lblt21 = (Label)e.Row.FindControl("lblt21");
            if (lbla21.Text == "A")
            {
                lbla21.Attributes.Add("style", A);
                lbln21.Attributes.Add("style", A);
                lblt21.Attributes.Add("style", A);
            }
            else if (lbla21.Text == "P")
            {
                lbla21.Attributes.Add("style", P);
                lbln21.Attributes.Add("style", P);
                lblt21.Attributes.Add("style", P);
            }
            else
            {
                lbla21.Attributes.Add("style", H);
                lbln21.Attributes.Add("style", H);
                lblt21.Attributes.Add("style", H);
            }
            Label lbla22 = (Label)e.Row.FindControl("lbla22");
            Label lbln22 = (Label)e.Row.FindControl("lbln22");
            Label lblt22 = (Label)e.Row.FindControl("lblt22");
            if (lbla22.Text == "A")
            {
                lbla22.Attributes.Add("style", A);
                lbln22.Attributes.Add("style", A);
                lblt22.Attributes.Add("style", A);
            }
            else if (lbla22.Text == "P")
            {
                lbla22.Attributes.Add("style", P);
                lbln22.Attributes.Add("style", P);
                lblt22.Attributes.Add("style", P);
            }
            else
            {
                lbla22.Attributes.Add("style", H);
                lbln22.Attributes.Add("style", H);
                lblt22.Attributes.Add("style", H);
            }
            Label lbla23 = (Label)e.Row.FindControl("lbla23");
            Label lbln23 = (Label)e.Row.FindControl("lbln23");
            Label lblt23 = (Label)e.Row.FindControl("lblt23");
            if (lbla23.Text == "A")
            {
                lbla23.Attributes.Add("style", A);
                lbln23.Attributes.Add("style", A);
                lblt23.Attributes.Add("style", A);
            }
            else if (lbla23.Text == "P")
            {
                lbla23.Attributes.Add("style", P);
                lbln23.Attributes.Add("style", P);
                lblt23.Attributes.Add("style", P);
            }
            else
            {
                lbla23.Attributes.Add("style", H);
                lbln23.Attributes.Add("style", H);
                lblt23.Attributes.Add("style", H);
            }
            Label lbla24 = (Label)e.Row.FindControl("lbla24");
            Label lbln24 = (Label)e.Row.FindControl("lbln24");
            Label lblt24 = (Label)e.Row.FindControl("lblt24");
            if (lbla24.Text == "A")
            {
                lbla24.Attributes.Add("style", A);
                lbln24.Attributes.Add("style", A);
                lblt24.Attributes.Add("style", A);
            }
            else if (lbla24.Text == "P")
            {
                lbla24.Attributes.Add("style", P);
                lbln24.Attributes.Add("style", P);
                lblt24.Attributes.Add("style", P);
            }
            else
            {
                lbla24.Attributes.Add("style", H);
                lbln24.Attributes.Add("style", H);
                lblt24.Attributes.Add("style", H);
            }
            Label lbla25 = (Label)e.Row.FindControl("lbla25");
            Label lbln25 = (Label)e.Row.FindControl("lbln25");
            Label lblt25 = (Label)e.Row.FindControl("lblt25");
            if (lbla25.Text == "A")
            {
                lbla25.Attributes.Add("style", A);
                lbln25.Attributes.Add("style", A);
                lblt25.Attributes.Add("style", A);
            }
            else if (lbla25.Text == "P")
            {
                lbla25.Attributes.Add("style", P);
                lbln25.Attributes.Add("style", P);
                lblt25.Attributes.Add("style", P);
            }
            else
            {
                lbla25.Attributes.Add("style", H);
                lbln25.Attributes.Add("style", H);
                lblt25.Attributes.Add("style", H);
            }
            Label lbla26 = (Label)e.Row.FindControl("lbla26");
            Label lbln26 = (Label)e.Row.FindControl("lbln26");
            Label lblt26 = (Label)e.Row.FindControl("lblt26");
            if (lbla26.Text == "A")
            {
                lbla26.Attributes.Add("style", A);
                lbln26.Attributes.Add("style", A);
                lblt26.Attributes.Add("style", A);
            }
            else if (lbla26.Text == "P")
            {
                lbla26.Attributes.Add("style", P);
                lbln26.Attributes.Add("style", P);
                lblt26.Attributes.Add("style", P);
            }
            else
            {
                lbla26.Attributes.Add("style", H);
                lbln26.Attributes.Add("style", H);
                lblt26.Attributes.Add("style", H);
            }
            Label lbla27 = (Label)e.Row.FindControl("lbla27");
            Label lbln27 = (Label)e.Row.FindControl("lbln27");
            Label lblt27 = (Label)e.Row.FindControl("lblt27");
            if (lbla27.Text == "A")
            {
                lbla27.Attributes.Add("style", A);
                lbln27.Attributes.Add("style", A);
                lblt27.Attributes.Add("style", A);
            }
            else if (lbla27.Text == "P")
            {
                lbla27.Attributes.Add("style", P);
                lbln27.Attributes.Add("style", P);
                lblt27.Attributes.Add("style", P);
            }
            else
            {
                lbla27.Attributes.Add("style", H);
                lbln27.Attributes.Add("style", H);
                lblt27.Attributes.Add("style", H);
            }
            Label lbla28 = (Label)e.Row.FindControl("lbla28");
            Label lbln28 = (Label)e.Row.FindControl("lbln28");
            Label lblt28 = (Label)e.Row.FindControl("lblt28");
            if (lbla28.Text == "A")
            {
                lbla28.Attributes.Add("style", A);
                lbln28.Attributes.Add("style", A);
                lblt28.Attributes.Add("style", A);
            }
            else if (lbla28.Text == "P")
            {
                lbla28.Attributes.Add("style", P);
                lbln28.Attributes.Add("style", P);
                lblt28.Attributes.Add("style", P);
            }
            else
            {
                lbla28.Attributes.Add("style", H);
                lbln28.Attributes.Add("style", H);
                lblt28.Attributes.Add("style", H);
            }
            Label lbla29 = (Label)e.Row.FindControl("lbla29");
            Label lbln29 = (Label)e.Row.FindControl("lbln29");
            Label lblt29 = (Label)e.Row.FindControl("lblt29");
            if (lbla29.Text == "A")
            {
                lbla29.Attributes.Add("style", A);
                lbln29.Attributes.Add("style", A);
                lblt29.Attributes.Add("style", A);
            }
            else if (lbla29.Text == "P")
            {
                lbla29.Attributes.Add("style", P);
                lbln29.Attributes.Add("style", P);
                lblt29.Attributes.Add("style", P);
            }
            else
            {
                lbla29.Attributes.Add("style", H);
                lbln29.Attributes.Add("style", H);
                lblt29.Attributes.Add("style", H);
            }
            Label lbla30 = (Label)e.Row.FindControl("lbla30");
            Label lbln30 = (Label)e.Row.FindControl("lbln30");
            Label lblt30 = (Label)e.Row.FindControl("lblt30");
            if (lbla30.Text == "A")
            {
                lbla30.Attributes.Add("style", A);
                lbln30.Attributes.Add("style", A);
                lblt30.Attributes.Add("style", A);
            }
            else if (lbla30.Text == "P")
            {
                lbla30.Attributes.Add("style", P);
                lbln30.Attributes.Add("style", P);
                lblt30.Attributes.Add("style", P);
            }
            else
            {
                lbla30.Attributes.Add("style", H);
                lbln30.Attributes.Add("style", H);
                lblt30.Attributes.Add("style", H);
            }
            Label lbla31 = (Label)e.Row.FindControl("lbla31");
            Label lbln31 = (Label)e.Row.FindControl("lbln31");
            Label lblt31 = (Label)e.Row.FindControl("lblt31");
            if (lbla31.Text == "A")
            {
                lbla31.Attributes.Add("style", A);
                lbln31.Attributes.Add("style", A);
                lblt31.Attributes.Add("style", A);
            }
            else if (lbla31.Text == "P")
            {
                lbla31.Attributes.Add("style", P);
                lbln31.Attributes.Add("style", P);
                lblt31.Attributes.Add("style", P);
            }
            else
            {
                lbla31.Attributes.Add("style", H);
                lbln31.Attributes.Add("style", H);
                lblt31.Attributes.Add("style", H);
            }
        }
        #endregion
    }
    protected void gvAssetScheduling_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        year = Convert.ToInt32(ddlYear.SelectedValue);
        month = Convert.ToInt32(ddlmonth.SelectedValue);
        gvAssetScheduling.PageIndex = e.NewPageIndex;
        gvAssetScheduling.EditIndex = -1;
        FillgvAssetScheduling(year, month);
    }
    protected void bntExport_Click(object sender, EventArgs e)
    {
        Response.Clear();
        Response.Buffer = true;

        Response.AddHeader("content-disposition", "attachment;filename=AttendanceMusterWithTimings - " + lblMainHead.Text + "-" + ddlmonth.SelectedItem.Text + '(' + ddlYear.SelectedValue + ')' + ".xls");
        Response.Charset = "";
        Response.ContentType = "application/vnd.ms-excel";
        using (StringWriter sw = new StringWriter())
        {
            HtmlTextWriter hw = new HtmlTextWriter(sw);

            //To Export all pages
            gvAssetScheduling.AllowPaging = false;
            FillgvAssetScheduling(Convert.ToInt32(ddlYear.SelectedValue), Convert.ToInt32(ddlmonth.SelectedValue));
            //  gvAttendence.Columns[0].Visible = false;

            //gvAttendence.HeaderRow.BackColor = Color.White;
            //foreach (TableCell cell in gvAttendence.HeaderRow.Cells)
            //{
            //    cell.BackColor = gvAttendence.HeaderStyle.BackColor;
            //}
            //foreach (GridViewRow row in gvAttendence.Rows)
            //{
            //    row.BackColor = Color.White;
            //    foreach (TableCell cell in row.Cells)
            //    {
            //        if (row.RowIndex % 2 == 0)
            //        {
            //            cell.BackColor = gvAttendence.AlternatingRowStyle.BackColor;
            //        }
            //        else
            //        {
            //            cell.BackColor = gvAttendence.RowStyle.BackColor;
            //        }
            //        cell.CssClass = "textmode";
            //    }
            //}
            gvAssetScheduling.RenderControl(hw);
            //style to format numbers to string
            string style = @"<style> .textmode { } </style>";
            Response.Write(style);
            Response.Output.Write(sw.ToString());
            Response.Flush();
            Response.End();
        }
  

        //try
        //{
        //    FillgvAssetScheduling(Convert.ToInt32(ddlYear.SelectedValue), Convert.ToInt32(ddlmonth.SelectedValue));
        //    string cmpnydetail = null;
        //    if (dtBackupCompanyDetails.Rows.Count != 0)
        //    {
        //        cmpnydetail = ds.Tables[2].Rows[0]["CompnayDetails"].ToString();
        //    }
        //    //Create a dummy GridView            
        //    //GridView GridView1 = new GridView();
        //    //GridView GridView2 = new GridView();
        //    //GridView2.DataSource = dtBackupOthersDetails;
        //    //GridView2.DataBind();
        //    //GridView1.AllowPaging = false;
        //    //GridView1.DataSource = dtBackupData;
        //    //GridView1.DataBind();
        //    Response.Clear();
        //    Response.Buffer = true;
        //    string FileName = "AttendanceMusterWithTimings -" + cmpnydetail + '-' + ddlmonth.SelectedItem.Text + '(' + ddlYear.SelectedValue + ')' + ".xls";
        //    Response.AddHeader("content-disposition", "attachment;filename=" + FileName);
        //    Response.Charset = "";
        //    Response.ContentType = "application/vnd.ms-excel";
        //    StringWriter sw = new StringWriter();
        //    HtmlTextWriter hw = new HtmlTextWriter(sw);
        //    //Applying stlye to gridview header cells
        //    //for (int i = 0; i < GridView1.HeaderRow.Cells.Count; i++)
        //    //{
        //    //    GridView1.HeaderRow.Cells[i].Style.Add("background-color", "#538DD5");
        //    //}
        //    //for (int i = 0; i < GridView2.HeaderRow.Cells.Count; i++)
        //    //{
        //    //    GridView2.HeaderRow.Cells[i].Style.Add("background-color", "#538DD5");
        //    //}
        //    //Applying Color Style
        //    //for (int i = 0; i < GridView2.Rows.Count; i++)
        //    //{
        //    //    for (int j = 0; j < GridView2.HeaderRow.Cells.Count; j++)
        //    //    {
        //    //        GridView2.Rows[i].Cells[j].BackColor = System.Drawing.Color.Yellow;
        //    //    }
        //    //}
        //    //for (int i = 0; i < GridView1.Rows.Count; i++)
        //    //{
        //    //    for (int j = 6; j < GridView1.HeaderRow.Cells.Count; j++)
        //    //    {
        //    //        String value = GridView1.Rows[i].Cells[j].Text;
        //    //        string[] splitValue = value.Split('/');
        //    //        if (splitValue[0] == "A")
        //    //        {
        //    //            GridView1.Rows[i].Cells[j].BackColor = System.Drawing.Color.OrangeRed;
        //    //            GridView1.Rows[i].Cells[j].ForeColor = System.Drawing.Color.White;
        //    //        }
        //    //        else if (splitValue[0] == "P")
        //    //        {
        //    //            GridView1.Rows[i].Cells[j].BackColor = System.Drawing.Color.Green;
        //    //            GridView1.Rows[i].Cells[j].ForeColor = System.Drawing.Color.White;
        //    //        }
        //    //        else if (j == 0)
        //    //        {
        //    //            GridView1.Rows[i].Cells[j].BackColor = System.Drawing.Color.FromArgb(166, 166, 166);
        //    //            GridView1.Rows[i].Cells[j].ForeColor = System.Drawing.Color.Black;
        //    //        }
        //    //        else if (i >= 0 && j == GridView1.HeaderRow.Cells.Count - 1)
        //    //        {
        //    //            GridView1.Rows[i].Cells[j].BackColor = System.Drawing.Color.YellowGreen;
        //    //            GridView1.Rows[i].Cells[j].ForeColor = System.Drawing.Color.Black;
        //    //        }
        //    //        else if (i >= 0 && j == GridView1.HeaderRow.Cells.Count - 2)
        //    //        {
        //    //            GridView1.Rows[i].Cells[j].BackColor = System.Drawing.Color.FromArgb(146, 205, 220);
        //    //            GridView1.Rows[i].Cells[j].ForeColor = System.Drawing.Color.Black;
        //    //        }
        //    //        else
        //    //        {
        //    //            GridView1.Rows[i].Cells[j].BackColor = System.Drawing.Color.Wheat;
        //    //        }
        //    //    }
        //    //}
        //    //   GridView2.RenderControl(hw);
        //    //  GridView1.RenderControl(hw);
        //    gvAssetScheduling.RenderControl(hw);
        //    //style to format numbers to string
        //    string style = @"<style> .textmode { mso-number-format:\@; } </style>";
        //    Response.Write(style);
        //    Response.Output.Write(sw.ToString());
        //    Thread.Sleep(500);
        //    Response.Flush();

        //}

        //catch (Exception ex)
        //{
        //}

    }
    protected void lnkBack_Click(object sender, EventArgs e)
    {
        lblNodata.Visible = false;
        attDetail.Visible = true;
        gvAssetScheduling.Visible = true;
        divDetails.Visible = false;
        lnkBack.Visible = false;
        btnExport.Visible = true;
    }
    protected void lblEmpCode_Click(object sender, EventArgs e)
    {
        years = ddlYear.SelectedValue;
        months = ddlmonth.SelectedValue;
        LinkButton objLinkButton = (LinkButton)sender;
        GridViewRow row = (GridViewRow)objLinkButton.NamingContainer;
        LinkButton lblEmpCode = (LinkButton)gvAssetScheduling.Rows[row.RowIndex].FindControl("lblEmpCode");
        lblEmpCode0.Text = lblEmpCode.Text;
        GetDetails(lblEmpCode.Text, years, months);
        attDetail.Visible = false;
        gvAssetScheduling.Visible = false;
        divDetails.Visible = true;
        lnkBack.Visible = true;
        btnExport.Visible = false;
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
            string FileName = "AttendanceMusterWithTimings -" + ddlmonth.SelectedItem.Text + '(' + ddlYear.SelectedValue + ')' + '[' + empdeatils + ']' + ".xls";
            Response.AddHeader("content-disposition", "attachment;filename=" + FileName);
            Response.Charset = "";
            Response.ContentType = "application/vnd.ms-excel";
            StringWriter sw = new StringWriter();
            HtmlTextWriter hw = new HtmlTextWriter(sw);

            //Applying stlye to Excel Header            
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
            GridView2.RenderControl(hw);
            GridView3.RenderControl(hw);

            //style to format numbers to string
            string style = @"<style> .textmode { mso-number-format:\@; } <style>";
            Response.Write(style);
            Response.Output.Write(sw.ToString());
          //  Response.Flush();
         //   HttpContext.Current.ApplicationInstance.CompleteRequest();
              Response.End();
        }
        catch (Exception ex)
        { }
    }
    protected void GVDeatils_RowDataBound(object sender, GridViewRowEventArgs e)
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
        }
        catch (Exception ex)
        { }
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
            GVDeatils.DataSource = dtAttendanceDetails;
            GVDeatils.DataBind();
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
    public override void VerifyRenderingInServerForm(Control control)
    {
        /* Verifies that the control is rendered */
    }
}