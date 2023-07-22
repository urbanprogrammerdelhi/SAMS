﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using AjaxControlToolkit;
using System.Drawing;
using System.Text;
using System.Web.UI.HtmlControls;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Configuration;
using System.Data.SqlClient;

public partial class SAMS_AIAReport : BasePage
{
    static int flag;
    static int flagData;
    #region Properties

    /// <summary>
    /// Returns User Read Rights.
    /// </summary>
    /// <value><c>true</c> if this instance is read access; otherwise, <c>false</c>.</value>
    /// <exception cref="System.Exception">Have not Rights</exception>

    private bool IsReadAccess
    {
        get
        {
            try
            {
                int VirtualDirNameLenght = 0;
                VirtualDirNameLenght = int.Parse(System.Web.HttpContext.Current.Request.Url.AbsolutePath.IndexOf(@"/", 1).ToString());
                return IsReadAllowed(System.Web.HttpContext.Current.Request.Url.AbsolutePath.Remove(0, VirtualDirNameLenght));
            }
            catch (Exception ex)
            { throw new Exception("Have not Rights", ex); }
        }
    }

    /// <summary>
    /// Returns User Write Rights.
    /// </summary>
    /// <value><c>true</c> if this instance is write access; otherwise, <c>false</c>.</value>
    /// <exception cref="System.Exception">Have not Rights</exception>
    private bool IsWriteAccess
    {
        get
        {
            try
            {
                int VirtualDirNameLenght = 0;
                VirtualDirNameLenght = int.Parse(System.Web.HttpContext.Current.Request.Url.AbsolutePath.IndexOf(@"/", 1).ToString());
                return IsWriteAllowed(System.Web.HttpContext.Current.Request.Url.AbsolutePath.Remove(0, VirtualDirNameLenght));
            }
            catch (Exception ex)
            { throw new Exception("Have not Rights", ex); }
        }
    }

    /// <summary>
    /// Returns User Modify Rights.
    /// </summary>
    /// <value><c>true</c> if this instance is modify access; otherwise, <c>false</c>.</value>
    /// <exception cref="System.Exception">Have not Rights</exception>
    private bool IsModifyAccess
    {
        get
        {
            try
            {
                int VirtualDirNameLenght = 0;
                VirtualDirNameLenght = int.Parse(System.Web.HttpContext.Current.Request.Url.AbsolutePath.IndexOf(@"/", 1).ToString());
                return IsModifyAllowed(System.Web.HttpContext.Current.Request.Url.AbsolutePath.Remove(0, VirtualDirNameLenght));
            }
            catch (Exception ex)
            { throw new Exception("Have not Rights", ex); }
        }
    }

    /// <summary>
    /// Returns User Delete Rights.
    /// </summary>
    /// <value><c>true</c> if this instance is delete access; otherwise, <c>false</c>.</value>
    /// <exception cref="System.Exception">Have not Rights</exception>
    private bool IsDeleteAccess
    {
        get
        {
            try
            {
                int VirtualDirNameLenght = 0;
                VirtualDirNameLenght = int.Parse(System.Web.HttpContext.Current.Request.Url.AbsolutePath.IndexOf(@"/", 1).ToString());
                return IsDeleteAllowed(System.Web.HttpContext.Current.Request.Url.AbsolutePath.Remove(0, VirtualDirNameLenght));
            }
            catch (Exception ex)
            { throw new Exception("Have not Rights", ex); }
        }
    }

    #endregion
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {

            txtDutyDate.Attributes.Add("readonly", "readonly");
            txtDutyDate.Text = DateTime.Now.ToString("dd-MMM-yyyy");
            txtTodate.Attributes.Add("readonly", "readonly");
            txtTodate.Text = DateTime.Now.ToString("dd-MMM-yyyy");
            gvAttendence.Visible = true;
            if (IsReadAccess == true)
            {
                //  FillddlAreaID();
                //    FillddlClientCode();
                //FillAsmtId();
                System.Web.UI.ScriptManager ToolkitScriptManager1 = (System.Web.UI.ScriptManager)Master.FindControl("ToolkitScriptManager1");
                //  ToolkitScriptManager1.SetFocus(ddlClientCode);
            }
            else
            {
                Response.Redirect("../UserManagement/Home.aspx");
            }
            FillddlState();
            flagData = 2;
            FillgvAttendence();
        }
    }
    protected void FillgvAttendence()
    {
        txtTodate.Text = txtDutyDate.Text;
        var objAssetMgmt = new BL.Sales();
        var ds = new DataSet();
        var dt = new DataTable();
        var dtflag = 1;
        ds = objAssetMgmt.GetDailyAttendenceAIA(BaseLocationAutoID, txtDutyDate.Text.Trim(), txtTodate.Text.Trim(), txtEmployeeNo.Text.Trim(),ddlstate.SelectedItem.Value,ddlbranch.SelectedItem.Value);
        if (flagData == 2)
        {
            dt = ds.Tables[2];

        }
        if (flagData == 1)
        {
            dt = ds.Tables[1];

        }
        if (flagData == 0)
        {
            dt = ds.Tables[0];

        }
       btnAll.Text = "Total Employees - " + ds.Tables[3].Rows[0]["Total"].ToString();
       Button2.Text = "Total Present - " + ds.Tables[3].Rows[0]["Present"].ToString();
       Button1.Text = "Total Absent - " + ds.Tables[3].Rows[0]["Absent"].ToString();
 
        if (dt.Rows.Count == 0)
        {
            dtflag = 0;
            dt.Rows.Add(dt.NewRow());
        }

        //DataColumn dc = new DataColumn("ImageBase64String", typeof(System.String));
        //ds.Tables[0].Columns.Add(dc);
        //for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
        //{
        //    if (ds.Tables[0].Rows[i]["EmployeeImage"].ToString() != "")
        //    {
        //        ds.Tables[0].Rows[i]["ImageBase64String"] = "data:image/jpeg;base64," + Convert.ToBase64String(((byte[])((object)ds.Tables[0].Rows[i]["EmployeeImage"])), 0, ((byte[])((object)ds.Tables[0].Rows[i]["EmployeeImage"])).Length);
        //    }
        //    else
        //    {
        //        ds.Tables[0].Rows[i]["ImageBase64String"] = string.Empty;
        //    }
        //}

        gvAttendence.DataSource = dt;
        gvAttendence.DataBind();

        //to fix empty gridview
        if (dtflag == 0)
        {
            gvAttendence.Rows[0].Visible = false;
            btnExport.Visible = false;
            lblmsg.Visible = true;
        }
        else
        {
            btnExport.Visible = true;
            lblmsg.Visible = false;
        }
    }
    protected void btnView_Click(object sender, EventArgs e)
    {
        FillgvAttendence();
    }
    protected void gvAttendence_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        GridViewRow objGridViewRow = e.Row;
        Label lblSerialNo = (Label)objGridViewRow.FindControl("lblSerialNo");
        if (lblSerialNo != null)
        {
            int serialNo = gvAttendence.PageIndex * gvAttendence.PageSize + int.Parse(objGridViewRow.RowIndex.ToString());
            lblSerialNo.Text = Convert.ToString((serialNo + 1));
        }

        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            Label lblEmployeeNumber = (Label)e.Row.FindControl("lblEmployeeNumber");
            lblEmployeeNumber.ForeColor = System.Drawing.Color.Black;
            lblEmployeeNumber.Font.Bold = true;

            Label lblSerialNo1 = (Label)e.Row.FindControl("lblSerialNo");
            lblSerialNo1.ForeColor = System.Drawing.Color.Black;
            lblSerialNo1.Font.Bold = true;

            Label lblEmployeeName = (Label)e.Row.FindControl("lblEmployeeName");
            lblEmployeeName.ForeColor = System.Drawing.Color.Black;
            lblEmployeeName.Font.Bold = true;
            //Label lblIMEI = (Label)e.Row.FindControl("lblIMEI");
            //lblIMEI.ForeColor = System.Drawing.Color.Black;
            //lblIMEI.Font.Bold = true;
            Label lblDesignation = (Label)e.Row.FindControl("lblDesignation");
            lblDesignation.ForeColor = System.Drawing.Color.Black;
            lblDesignation.Font.Bold = true;
            Label lblLongitude = (Label)e.Row.FindControl("lblLongitude");
            lblLongitude.ForeColor = System.Drawing.Color.Black;
            lblLongitude.Font.Bold = true;
            Label lblDate = (Label)e.Row.FindControl("lblDate");
            lblDate.ForeColor = System.Drawing.Color.Black;
            lblDate.Font.Bold = true;
            Label lblZone = (Label)e.Row.FindControl("lblZone");
            lblZone.ForeColor = System.Drawing.Color.Black;
            lblZone.Font.Bold = true;
            Label lblstate = (Label)e.Row.FindControl("lblstate");
            lblstate.ForeColor = System.Drawing.Color.Black;
            lblstate.Font.Bold = true;
            Label lblBranchcode = (Label)e.Row.FindControl("lblBranchcode");
            lblBranchcode.ForeColor = System.Drawing.Color.Black;
            lblBranchcode.Font.Bold = true;
            Label lblSAPcode = (Label)e.Row.FindControl("lblSAPcode");
            lblSAPcode.ForeColor = System.Drawing.Color.Black;
            lblSAPcode.Font.Bold = true;
            Label lblbranchname = (Label)e.Row.FindControl("lblbranchname");
            lblbranchname.ForeColor = System.Drawing.Color.Black;
            lblbranchname.Font.Bold = true;

            Label lblTime = (Label)e.Row.FindControl("lblTime");
            Label lblOuttime = (Label)e.Row.FindControl("lblOuttime");

            lblOuttime.ForeColor = System.Drawing.Color.Red;
            lblOuttime.Font.Bold = true;

            lblTime.ForeColor = System.Drawing.Color.Green;
            lblTime.Font.Bold = true;


            Label lblCategory = (Label)e.Row.FindControl("lblCategory");
            {
                if (lblCategory.Text == "High")
                {
                    lblCategory.ForeColor = System.Drawing.Color.Red;
                    lblCategory.Font.Bold = true;
                }
                else if (lblCategory.Text == "Low")
                {
                    lblCategory.ForeColor = System.Drawing.Color.Green;
                    lblCategory.Font.Bold = true;
                }
                else
                {
                    lblCategory.ForeColor = System.Drawing.Color.Black;
                    lblCategory.Font.Bold = true;

                }

            }

            Label lblStaus = (Label)e.Row.FindControl("lblStaus");
            {
                if (lblStaus.Text == "A")
                {
                    lblStaus.ForeColor = System.Drawing.Color.Red;
                    lblStaus.Font.Bold = true;
                    lblStaus.Attributes.Add("style", "font-size:15px; ");
                 
                }
                else
                {
                    lblStaus.ForeColor = System.Drawing.Color.Green;
                    lblStaus.Font.Bold = true;
                   lblStaus.Attributes.Add("style", "font-size:15px; ");
                }

            }
        }
    }
    protected void gvAttendence_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvAttendence.PageIndex = e.NewPageIndex;
        gvAttendence.EditIndex = -1;
        FillgvAttendence();
    }
    protected void btnExport_Click(object sender, EventArgs e)
    {
        Response.Clear();
        Response.Buffer = true;
        if (flagData == 2)
        {
            Response.AddHeader("content-disposition", "attachment;filename=AIA-TotalEmployeesAttendenceReport-" + txtDutyDate.Text + ".xls");

        }
        if (flagData == 1)
        {
            Response.AddHeader("content-disposition", "attachment;filename=AIA-AbsentEmployeesAttendenceReport-" + txtDutyDate.Text + ".xls");

        }
        if (flagData == 0)
        {
            Response.AddHeader("content-disposition", "attachment;filename=AIA-PresentEmployeesAttendenceReport-" + txtDutyDate.Text + ".xls");

        }
     
        Response.Charset = "";
        Response.ContentType = "application/vnd.ms-excel";
        using (StringWriter sw = new StringWriter())
        {
            HtmlTextWriter hw = new HtmlTextWriter(sw);

            //To Export all pages
            gvAttendence.AllowPaging = false;
            FillgvAttendence();
            gvAttendence.Columns[0].Visible = false;

            gvAttendence.HeaderRow.BackColor = Color.White;
            foreach (TableCell cell in gvAttendence.HeaderRow.Cells)
            {
                cell.BackColor = gvAttendence.HeaderStyle.BackColor;
            }
            foreach (GridViewRow row in gvAttendence.Rows)
            {
                row.BackColor = Color.White;
                foreach (TableCell cell in row.Cells)
                {
                    if (row.RowIndex % 2 == 0)
                    {
                        cell.BackColor = gvAttendence.AlternatingRowStyle.BackColor;
                    }
                    else
                    {
                        cell.BackColor = gvAttendence.RowStyle.BackColor;
                    }
                    cell.CssClass = "textmode";
                }
            }
            gvAttendence.RenderControl(hw);
            //style to format numbers to string
            string style = @"<style> .textmode { } </style>";
            Response.Write(style);
            Response.Output.Write(sw.ToString());
            Response.Flush();
            Response.End();
        }
    }
    protected void ddlClientCode_SelectedIndexChanged(object sender, EventArgs e)
    {
        FillgvAttendence();
    }
    protected void txtDutyDate_TextChanged(object sender, EventArgs e)
    {
        FillgvAttendence();
    }
    protected void txtTodate_TextChanged(object sender, EventArgs e)
    {
        FillgvAttendence();
    }
    public override void VerifyRenderingInServerForm(Control control)
    {
        // controller   
    }
    protected void ddlstate_SelectedIndexChanged(object sender, EventArgs e)
    {
        txtEmployeeNo.Text = "";
        FillddlBranch();
        FillgvAttendence();
    }
   
    protected void FillddlState()
    {
        DataSet ds = new DataSet();
        BL.Sales objsales = new BL.Sales();

        ds = objsales.GetAIAState(BaseLocationAutoID);

        if (ds != null)
        {
            if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                ddlstate.DataSource = ds.Tables[0];
                ddlstate.DataTextField = "State";
                ddlstate.DataValueField = "State";
                ddlstate.DataBind();

                ddlstate.Items.Insert(0, new ListItem("All", "All"));
                FillddlBranch();

            }
            else
            {
                ListItem li = new ListItem();
                li.Text = Resources.Resource.NoData;
                li.Value = "0";
                ddlstate.Items.Add(li);
            }
        }
        else
        {
            ListItem li = new ListItem();
            li.Text = Resources.Resource.NoData;
            li.Value = "0";
            ddlstate.Items.Add(li);
        }
    }
    protected void ddlbranch_SelectedIndexChanged(object sender, EventArgs e)
    {
        txtEmployeeNo.Text = "";
        FillgvAttendence();
    }
    protected void FillddlBranch()
    {
        DataSet ds = new DataSet();
        BL.Sales objsales = new BL.Sales();

        ds = objsales.GetAIABranch(BaseLocationAutoID,ddlstate.SelectedItem.Value);

        if (ds != null)
        {
            if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                ddlbranch.DataSource = ds.Tables[0];
                ddlbranch.DataTextField = "BranchName";
                ddlbranch.DataValueField = "BranchName";
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

    protected void btnAll_Click(object sender, EventArgs e)
    {
        flagData = 2;
        FillgvAttendence();
    }
    protected void Button2_Click(object sender, EventArgs e)
    {
        flagData = 0;
        FillgvAttendence();
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        flagData = 1;
        FillgvAttendence();
    }
}