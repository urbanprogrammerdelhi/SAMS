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


public partial class APS_MacquarieMuster : BasePage
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
            for (int Loop = 2022; Loop <= DateTime.Now.Year; Loop++)
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
     
    }
    private void FillData(int Year, int Month)
    {
        try
        {
            var obj = new BL.AssetManagement();
            var dt = new DataTable();
            var dt2 = new DataTable();
            int flag = 0;
            ds = obj.AttendanceMusterDataMacquarie(Convert.ToInt32(BaseLocationAutoID), Year, Month);
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
            
                bntExport.Visible = false;
            }
            else
            {
                lblNodata.Visible = false;
            
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
        GridViewRow objGridViewRow = e.Row;

        Label lblSNo = (Label)objGridViewRow.FindControl("lblSNo");
        if (lblSNo != null)
        {
            int serialNo = gdvData.PageIndex * gdvData.PageSize + int.Parse(objGridViewRow.RowIndex.ToString());
            lblSNo.Text = Convert.ToString((serialNo + 1));
        }

        string B = "Color:#2e6293;Font-weight:Bold";
        string T = "Color:black;Font-weight:Bold";
        string N = "Color:#cc0052;Font-weight:Bold";
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            Label lblDate31total = (Label)e.Row.FindControl("lblDate31total");
            lblDate31total.ForeColor = System.Drawing.Color.Black;
            lblDate31total.Font.Bold = true;

            lblSNo.ForeColor = System.Drawing.Color.Black;
            lblSNo.Font.Bold = true;


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
            else if (lblDate1.Text == "P")
            {
                lblDate1.Attributes.Add("style", P);
            }
            else
            {
                lblDate1.Attributes.Add("style", T);
            }
            Label lblDate2 = (Label)e.Row.FindControl("lblDate2");
            if (lblDate2.Text == "A")
            {
                lblDate2.Attributes.Add("style", A);
            }
            else if (lblDate2.Text == "P")
            {
                lblDate2.Attributes.Add("style", P);
            }
            else
            {
                lblDate2.Attributes.Add("style", T);
            }
            Label lblDate3 = (Label)e.Row.FindControl("lblDate3");
            if (lblDate3.Text == "A")
            {
                lblDate3.Attributes.Add("style", A);
            }
            else if (lblDate3.Text == "P")
            {
                lblDate3.Attributes.Add("style", P);
            }
            else
            {
                lblDate3.Attributes.Add("style", T);
            }
            Label lblDate4 = (Label)e.Row.FindControl("lblDate4");
            if (lblDate4.Text == "A")
            {
                lblDate4.Attributes.Add("style", A);
            }
            else if (lblDate4.Text == "P")
            {
                lblDate4.Attributes.Add("style", P);
            }
            else
            {
                lblDate4.Attributes.Add("style", T);
            }
            Label lblDate5 = (Label)e.Row.FindControl("lblDate5");
            if (lblDate5.Text == "A")
            {
                lblDate5.Attributes.Add("style", A);
            }
            else if (lblDate5.Text == "P")
            {
                lblDate5.Attributes.Add("style", P);
            }
            else
            {
                lblDate5.Attributes.Add("style", T);
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
   
 
   
   
    protected void bntExport_Click(object sender, EventArgs e)
    {
        try
        {
            var obj = new BL.AssetManagement();
            var dt = new DataTable();
            //var dtdetail = new DataTable();
            //var dtCount = new DataTable();
            //var dtSum = new DataTable();
            //var dtCompnyDetails = new DataTable();
       
            ds = obj.AttendanceMusterDataMacquarie(Convert.ToInt32(BaseLocationAutoID), Convert.ToInt32(ddlYear.SelectedValue), Convert.ToInt32(ddlmonth.SelectedValue));
            dt = ds.Tables[0];
            if (dt.Rows.Count > 0)
            {
                //dt.Columns[34].Visible= false;
                //dt.Columns["31"].Visible = false;
               // dt.Columns["31"].ColumnMapping = MappingType.Hidden;
            }
       
            //Create a dummy GridView
            GridView GridView1 = new GridView();
          
            GridView1.AllowPaging = false;
      
           
            GridView1.DataSource = dt;
            GridView1.DataBind();
            Response.Clear();
            Response.Buffer = true;
            string FileName = "AttendanceMuster-Macquarie -"  + ddlmonth.SelectedItem.Text + '(' + ddlYear.SelectedValue + ')' + ".xls";
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
                    else
 if (j == 0)
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
  
}