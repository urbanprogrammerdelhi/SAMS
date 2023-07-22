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

public partial class APS_MaxMonthlyReport : BasePage
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
         //   FillData(Convert.ToInt32(year), Convert.ToInt32(month));
        }
      //  divDetails.Visible = false;
      //  lblEmpName0.Text = "";
    }
    private void FillData(int Year, int Month)
    {
        try
        {
            var obj = new BL.AssetManagement();
            var dt = new DataTable();
            var dt2 = new DataTable();
            int flag = 0;
            ds = obj.MaxMonthlyData(Convert.ToInt32(BaseLocationAutoID), Year, Month);
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
                // lnkBack.Visible = false;
                bntExport.Visible = false;
             //   imagebtn.Visible = true;
            }
            else
            {
                lblNodata.Visible = false;
                //  lnkBack.Visible = false;
                bntExport.Visible = true;
              // imagebtn.Visible = false;

            }
        }
        catch (Exception ex)
        {
        }
    }
    protected void ddlmonth_SelectedIndexChanged(object sender, EventArgs e)
    {
        //year = Convert.ToInt32(ddlYear.SelectedValue);
        //month = Convert.ToInt32(ddlmonth.SelectedValue);
        //FillData(year, month);
    }
    protected void ddlYear_SelectedIndexChanged(object sender, EventArgs e)
    {
        //year = Convert.ToInt32(ddlYear.SelectedValue);
        //month = Convert.ToInt32(ddlmonth.SelectedValue);
        //FillData(year, month);
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
           
            if (lblDate29.Text == "A")
            {
                lblDate29.Attributes.Add("style", A);
            }
            else
            {
                lblDate29.Attributes.Add("style", P);
            }

            if (lblDate31.Text == "A")
            {
                lblDate31.Attributes.Add("style", A);
            }
            else
            {
                lblDate31.Attributes.Add("style", P);
            }

            if (lblDate30.Text == "A")
            {
                lblDate30.Attributes.Add("style", A);
            }
            else
            {
                lblDate30.Attributes.Add("style", P);
            }
            Label lblSNo = (Label)e.Row.FindControl("lblSNo");
            if (lblSNo.Text == "A")
            {
                lblSNo.Attributes.Add("style", A);
            }
            else
            {
                lblSNo.Attributes.Add("style", P);
            }
            Label lblDate26FOREMARKS = (Label)e.Row.FindControl("lblDate26FOREMARKS");
            if (lblDate26FOREMARKS.Text == "A")
            {
                lblDate26FOREMARKS.Attributes.Add("style", A);
            }
            else
            {
                lblDate26FOREMARKS.Attributes.Add("style", P);
            }
            Label lblDateAudote = (Label)e.Row.FindControl("lblDateAudote");
            if (lblDateAudote.Text == "A")
            {
                lblDateAudote.Attributes.Add("style", A);
            }
            else
            {
                lblDateAudote.Attributes.Add("style", P);
            }
            Label lblDate26SPOCMLI = (Label)e.Row.FindControl("lblDate26SPOCMLI");
            if (lblDate26SPOCMLI.Text == "A")
            {
                lblDate26SPOCMLI.Attributes.Add("style", A);
            }
            else
            {
                lblDate26SPOCMLI.Attributes.Add("style", P);
            }
            Label lblDate26idcard = (Label)e.Row.FindControl("lblDate26idcard");
            if (lblDate26idcard.Text == "A")
            {
                lblDate26idcard.Attributes.Add("style", A);
            }
            else
            {
                lblDate26idcard.Attributes.Add("style", P);
            }
            Label lblDate26thermo = (Label)e.Row.FindControl("lblDate26thermo");
            if (lblDate26thermo.Text == "A")
            {
                lblDate26thermo.Attributes.Add("style", A);
            }
            else
            {
                lblDate26thermo.Attributes.Add("style", P);
            }
            Label lblDate26stock7 = (Label)e.Row.FindControl("lblDate26stock7");
            if (lblDate26stock7.Text == "A")
            {
                lblDate26stock7.Attributes.Add("style", A);
            }
            else
            {
                lblDate26stock7.Attributes.Add("style", P);
            }
            Label lblDate30surroun22d1 = (Label)e.Row.FindControl("lblDate30surroun22d1");
            if (lblDate30surroun22d1.Text == "A")
            {
                lblDate30surroun22d1.Attributes.Add("style", A);
            }
            else
            {
                lblDate30surroun22d1.Attributes.Add("style", P);
            }
            Label lblDate31surround2 = (Label)e.Row.FindControl("lblDate31surround2");
            if (lblDate31surround2.Text == "A")
            {
                lblDate31surround2.Attributes.Add("style", A);
            }
            else
            {
                lblDate31surround2.Attributes.Add("style", P);
            }
          
        }
    }
    protected void bntExport_Click(object sender, EventArgs e)
    {
        //try
        //{
        //    var obj = new BL.AssetManagement();
        //    var dt = new DataTable();
        //    var dtdetail = new DataTable();
        //    var dtCount = new DataTable();
        //    var dtSum = new DataTable();
        //    var dtCompnyDetails = new DataTable();
        //    string cmpnydetail = null;
        //    ds = obj.MaxMonthlyData(Convert.ToInt32(BaseLocationAutoID), Convert.ToInt32(ddlYear.SelectedValue), Convert.ToInt32(ddlmonth.SelectedValue));
        //    dt = ds.Tables[0];
        //    //if (dt.Rows.Count > 0)
        //    //{
        //    //    //dt.Columns[34].Visible= false;
        //    //    //dt.Columns["31"].Visible = false;
        //    // //   dt.Columns["31"].ColumnMapping = MappingType.Hidden;
        //    //}
        ////    dtdetail = ds.Tables[1];
        // //   dtCompnyDetails = ds.Tables[2];
        //    //if (dtdetail.Rows.Count != 0)
        //    //{
        //    //    cmpnydetail = ds.Tables[1].Rows[0]["CompnayDetails"].ToString();
        //    //}
        //    //Create a dummy GridView
        //    GridView GridView1 = new GridView();
        //  //  GridView GridView2 = new GridView();
        //    GridView1.AllowPaging = false;

        //    GridView1.DataSource = dt;
        //    GridView1.DataBind();
        //    Response.Clear();
        //    Response.Buffer = true;
        //    string FileName = "MonthlyReport -" + cmpnydetail + '-' + ddlmonth.SelectedItem.Text + '(' + ddlYear.SelectedValue + ')' + ".xls";
        //    Response.AddHeader("content-disposition", "attachment;filename=" + FileName);
        //    Response.Charset = "";
        //    Response.ContentType = "application/vnd.ms-excel";
        //    StringWriter sw = new StringWriter();
        //    HtmlTextWriter hw = new HtmlTextWriter(sw);
        //    //Applying stlye to gridview header cells
        //    for (int i = 0; i < GridView1.HeaderRow.Cells.Count; i++)
        //    {
        //        GridView1.HeaderRow.Cells[i].Style.Add("background-color", "#538DD5");
        //    }
        //    for (int i = 0; i < GridView2.HeaderRow.Cells.Count; i++)
        //    {
        //        GridView2.HeaderRow.Cells[i].Style.Add("background-color", "#538DD5");
        //    }
        //    //Applying Color Style
        //    for (int i = 0; i < GridView1.Rows.Count; i++)
        //    {
        //        for (int j = 0; j < GridView1.HeaderRow.Cells.Count; j++)
        //        {
        //            String value = GridView1.Rows[i].Cells[j].Text;
        //            if (value == "A")
        //            {
        //                GridView1.Rows[i].Cells[j].BackColor = System.Drawing.Color.OrangeRed;
        //                GridView1.Rows[i].Cells[j].ForeColor = System.Drawing.Color.White;
        //            }
        //            else if (value == "P")
        //            {
        //                GridView1.Rows[i].Cells[j].BackColor = System.Drawing.Color.Green;
        //                GridView1.Rows[i].Cells[j].ForeColor = System.Drawing.Color.White;
        //            }
        //            else if (j == 0)
        //            {
        //                GridView1.Rows[i].Cells[j].BackColor = System.Drawing.Color.FromArgb(166, 166, 166);
        //                GridView1.Rows[i].Cells[j].ForeColor = System.Drawing.Color.Black;
        //            }
        //            else if (i >= 0 && j == GridView1.HeaderRow.Cells.Count - 1)
        //            {
        //                GridView1.Rows[i].Cells[j].BackColor = System.Drawing.Color.YellowGreen;
        //                GridView1.Rows[i].Cells[j].ForeColor = System.Drawing.Color.Black;
        //            }
        //            else if (i >= 0 && j == GridView1.HeaderRow.Cells.Count - 2)
        //            {
        //                GridView1.Rows[i].Cells[j].BackColor = System.Drawing.Color.FromArgb(146, 205, 220);
        //                GridView1.Rows[i].Cells[j].ForeColor = System.Drawing.Color.Black;
        //            }
        //            else
        //            {
        //                GridView1.Rows[i].Cells[j].BackColor = System.Drawing.Color.Wheat;
        //            }
        //        }
        //    }
        //    GridView2.RenderControl(hw);
        //    GridView1.RenderControl(hw);
        //    //style to format numbers to string
        //    string style = @"<style> .textmode { mso-number-format:\@; } </style>";
        //    Response.Write(style);
        //    Response.Output.Write(sw.ToString());
        //    Response.Flush();
        //    Response.End();
        //}
        //catch (Exception ex)
        //{
        //}
        // }
        Response.Clear();
        Response.Buffer = true;

        Response.AddHeader("content-disposition", "attachment;filename=MaxMonthlyReport-" + ddlmonth.SelectedItem.Text + ".xls");

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
    protected void btnview_Click(object sender, EventArgs e)
    {
        //imagebtn.Visible = true;
           year = Convert.ToInt32(ddlYear.SelectedValue);
        month = Convert.ToInt32(ddlmonth.SelectedValue);
        FillData(year, month);
    }
}