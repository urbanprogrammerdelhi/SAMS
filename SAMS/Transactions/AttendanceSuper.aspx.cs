using System;
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

public partial class Transactions_AttendanceSuper : BasePage
{
    static int flag;
    string TimeId = "0";
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
            ShowRecord();
          
        }

    }
    protected void FillgvAttendence()
    {
        txtTodate.Text = txtDutyDate.Text;
        var objAssetMgmt = new BL.Sales();
        var ds = new DataSet();
        var dt = new DataTable();
        var dtflag = 1;
        ds = objAssetMgmt.GetDailyAttendenceNewMB(BaseLocationAutoID, txtDutyDate.Text.Trim(), txtTodate.Text.Trim(), txtEmployeeNo.Text.Trim());
        dt = ds.Tables[0];

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

        var approveValue = ds.Tables[0].Rows[0]["Flag"].ToString();
        if (approveValue == "0")
        {
            btnActual.Visible = true;
            btnExport.Visible = true;
            if((BaseLocationAutoID=="33") || (BaseLocationAutoID == "34") || (BaseLocationAutoID == "37") || (BaseLocationAutoID == "39") || (BaseLocationAutoID == "41") || (BaseLocationAutoID == "160"))
            {
                btnAdd.Visible = false;
            }
            else
            {
                btnAdd.Visible = true;
            }


          
         //   btnDelete.Visible = true;
            //hfFlag.Value = "0";
            gvAttendence.Columns[0].Visible = true;
          //  gvAttendence.Columns[1].Visible = false;
        }
        else
        {
            btnActual.Visible = false;
            btnAdd.Visible = false;
       //     btnDelete.Visible = false;
         //   btnDelete.Visible = false;
         //   hfFlag.Value = "1";
              gvAttendence.Columns[0].Visible = false;
        }
        //if (validDate > 0 && (approveValue == "0" || approveValue == ""))
        //{
        //    btnAdd.Visible = true;
        //}
        //else
        //{
        //    btnAdd.Visible = false;
        //}

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
        ShowRecord();
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

            //Label lblSerialNo1 = (Label)e.Row.FindControl("lblSerialNo");
            //lblSerialNo1.ForeColor = System.Drawing.Color.Black;
            //lblSerialNo1.Font.Bold = true;

            Label lblEmployeeName = (Label)e.Row.FindControl("lblEmployeeName");
            lblEmployeeName.ForeColor = System.Drawing.Color.Black;
            lblEmployeeName.Font.Bold = true;
            Label lblDesignation = (Label)e.Row.FindControl("lblDesignation");
            lblDesignation.ForeColor = System.Drawing.Color.Black;
            lblDesignation.Font.Bold = true;
            Label lblLongitude = (Label)e.Row.FindControl("lblLongitude");
            lblLongitude.ForeColor = System.Drawing.Color.Black;
            lblLongitude.Font.Bold = true;
            Label lblDate = (Label)e.Row.FindControl("lblDate");
            lblDate.ForeColor = System.Drawing.Color.Black;
            lblDate.Font.Bold = true;

            Label lblTime = (Label)e.Row.FindControl("lblTime");
            if (lblTime != null)
            {
                lblTime.ForeColor = System.Drawing.Color.Green;
                lblTime.Font.Bold = true;
                if (lblTime.Text == "") //IN
                {
                    TimeId = "1";
                    Session["TimeId"] = TimeId.ToString();
                }
            }
            Label lblOuttime = (Label)e.Row.FindControl("lblOuttime");
            if (lblOuttime != null)
            {
                lblOuttime.ForeColor = System.Drawing.Color.Red;
                lblOuttime.Font.Bold = true;
                if (lblOuttime.Text == "") //IN
                {
                    TimeId = "2";
                    Session["TimeId"] = TimeId.ToString();
                }
               
            }       
            }
        if (e.Row.RowIndex == gvAttendence.EditIndex)
        {
            TextBox lblOuttime = (TextBox)e.Row.FindControl("txtOuttime");
            if (lblOuttime != null)
            {
                lblOuttime.ForeColor = System.Drawing.Color.Red;
                lblOuttime.Font.Bold = true;
               
            }
            TextBox lblTime = (TextBox)e.Row.FindControl("txtInTime");
            if (lblTime != null)
            {
                lblTime.ForeColor = System.Drawing.Color.Green;
                lblTime.Font.Bold = true;
               
            }
          
        }
    }
    protected void gvAttendence_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvAttendence.PageIndex = e.NewPageIndex;
        gvAttendence.EditIndex = -1;
        ShowRecord();
    }
    protected void btnExport_Click(object sender, EventArgs e)
    {
        Response.Clear();
        Response.Buffer = true;
        Response.AddHeader("content-disposition", "attachment;filename=DailyAttendenceReport-" + txtDutyDate.Text + ".xls");
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
        ShowRecord();
    }
    protected void txtDutyDate_TextChanged(object sender, EventArgs e)
    {
        ShowRecord();
    }
    protected void txtTodate_TextChanged(object sender, EventArgs e)
    {
        ShowRecord();
    }
    public override void VerifyRenderingInServerForm(Control control)
    {
        // controller   
    }

    protected void gvAttendence_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        gvAttendence.EditIndex = -1;
        ShowRecord();
        lblerrormsg.Text = "";
    }
   
   
    protected void gvAttendence_RowEditing(object sender, GridViewEditEventArgs e)
    {
        gvAttendence.EditIndex = e.NewEditIndex;
        ShowRecord();
        lblerrormsg.Text = "";
    }
    protected void gvAttendence_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        DataSet ds = new DataSet();
        BL.Sales objsales = new BL.Sales();
        TextBox txtInTime = (TextBox)gvAttendence.Rows[e.RowIndex].FindControl("txtInTime");
        TextBox txtOutTime = (TextBox)gvAttendence.Rows[e.RowIndex].FindControl("txtOuttime");
        Label EmpNo = (Label)gvAttendence.Rows[e.RowIndex].FindControl("lblEmployeeNumber");
        Label Date = (Label)gvAttendence.Rows[e.RowIndex].FindControl("lblDate");
        //if (System.Text.RegularExpressions.Regex.IsMatch(txtOutTime.Text, "[^0-9:]"))
        //{
        //    Show("Please Enter valid Time");
        //    txtOutTime.Focus();
        //    txtOutTime.Text = "";
        //    return;
        //}
        //if (System.Text.RegularExpressions.Regex.IsMatch(txtInTime.Text, "[^0-9:]"))
        //{
        //    Show("Please Enter valid Time");
        //    txtInTime.Focus();
        //    txtInTime.Text = "";
        //    return;
        //}
        if((txtInTime.Text !="")||(txtOutTime.Text!=""))
        {
            if ((txtInTime.Text != "") && (txtOutTime.Text != ""))
            {
                string Hr = txtInTime.Text.Substring(0, 2);
                string Min = txtInTime.Text.Substring(2, 2);
                string Hr1 = txtOutTime.Text.Substring(0, 2);
                string Min1 = txtOutTime.Text.Substring(2, 2);
                if ((Convert.ToInt32(Hr) < 24) && (Convert.ToInt32(Min) <= 59))
                {
                    if (((Convert.ToInt32(Hr1) < 24) && (Convert.ToInt32(Min1) <= 59)))
                    {
                        string str = txtInTime.Text;
                        string FromInTime = str.Insert(2, ":");
                        string str1 = txtOutTime.Text;
                        string ToInTime = str1.Insert(2, ":");
                        //    string Date = lblgvSchShiftTime.Text;
                        ds = objsales.UpdateAttendanceMilkBasket(EmpNo.Text, Date.Text, FromInTime, ToInTime, BaseUserID, BaseLocationAutoID);

                        lblerrormsg.Text = ds.Tables[0].Rows[0]["MessageString"].ToString();
                    }
                    else
                    {
                        lblerrormsg.Text = "Unable to update Attendance as User enter Invalid Time ";
                    }
                }
                else
                {
                    lblerrormsg.Text = "Unable to update Attendance as User enter Invalid Time ";
                }

            }
            else
            {
                lblerrormsg.Text = "Unable to update Attendance !! ";
            }
        }
        else
        {
            lblerrormsg.Text = "Both the times cannot be blank !!";
        }
        gvAttendence.EditIndex = -1;
        ShowRecord();
      
    }
    protected void btnAll_Click(object sender, EventArgs e)
    {
        txtEmployeeNo.Text = "";
        ShowRecord();
    }
    protected void btnActual_Click(object sender, EventArgs e)
    {
        //int res = Convert.ToInt32(Session["res"].ToString());
        //if (res > 1)
        //{
        //    string getTimeId = Session["TimeId"].ToString();
        //    if (getTimeId == "0")
        //    {
        //        ScriptManager.RegisterClientScriptBlock(this, GetType(), "none", "<script>executeGreen();</script>", false);
        //    }
        //    else
        //    {
        //        ScriptManager.RegisterClientScriptBlock(this, GetType(), "none", "<script>executeError();</script>", false);
        //    }
        //}
        //else
        //{
        //    ScriptManager.RegisterClientScriptBlock(this, GetType(), "none", "<script>executeRed();</script>", false);
        //}
        var ds = new DataSet();
        var objAssetMgmt = new BL.AssetManagement();
        try
        {
            lblmsg.Visible = true;
            ds = objAssetMgmt.ConvertToActual(BaseLocationAutoID, BaseUserID, txtDutyDate.Text);
            ShowRecord();
        }
        catch (Exception ex)
        { }

    }
    protected void ShowRecord()
    {
       var dt1 = Convert.ToDateTime(txtDutyDate.Text).ToString("dd-MMM-yyyy");
        var dt2 = DateTime.Now.ToString("dd-MMM-yyyy");
        DateTime d1 = Convert.ToDateTime(dt1);
        DateTime d2 = Convert.ToDateTime(dt2);
        var res = Convert.ToInt32((d2 - d1).TotalDays);
        if (res > 0)
        {
            btnActual.BackColor = Color.Green;
            btnActual.ToolTip = "Click here for Approving Attendance";
            btnActual.Enabled = true;
        }
        else
        {
            btnActual.BackColor = Color.Red;
            btnActual.ToolTip = "You can't Approved the Attendance before 24 Hrs";
            btnActual.Enabled = false;
        }
       Session["res"] = res;
       lblerrormsg.Text = "";
       FillgvAttendence();
    }
    protected void btnYes_Click(object sender, EventArgs e)
    {
       
    }
    protected void btnAdd_Click(object sender, EventArgs e)
    {
        AddMissing.Visible = true;
        divGV.Visible = false;
    }
    protected void txtPopEmpNo_TextChanged(object sender, EventArgs e)
    {
        if (txtPopEmpNo.Text != "")
        {
            BL.Sales objSales = new BL.Sales();
            DataSet ds = objSales.GetEmployeeName(txtPopEmpNo.Text, Convert.ToInt32(BaseLocationAutoID));
            if (ds.Tables[0].Rows.Count != 0)
            {
                txtPopEmpName.Text = ds.Tables[0].Rows[0]["EmployeeName"].ToString();
                txtPopEmpNo.Text = ds.Tables[0].Rows[0]["EmployeeNumber"].ToString();
            //    txtPopDate.Text = txtDutyDate.Text;
          //      tr2.Visible = true;
           //     tr3.Visible = true;
                tr4.Visible = true;
                btnPopSubmit.Visible = true;
                lblPopMsg.Visible = false;
                btnPopReset.Visible = true;
            }
            else
            {
                lblPopMsg.Visible = true;
                txtPopEmpName.Text = "";
          //      tr2.Visible = false;
           //     tr3.Visible = false;
                tr4.Visible = false;
                btnPopSubmit.Visible = false;
            }
        }
    }
    protected void btnPopCancel_Click(object sender, EventArgs e)
    {
        AddMissing.Visible = false;
        divGV.Visible = true;
        txtPopEmpNo.Text = "";
        txtPopEmpName.Text = "";
        tr4.Visible = false;
    }
    protected void btnPopReset_Click(object sender, EventArgs e)
    {
        txtPopEmpNo.Text = "";
        txtPopEmpName.Text = "";
        tr4.Visible = false;
    }
    protected void btnPopSubmit_Click(object sender, EventArgs e)
    {
        try
        {
            if (txtPopInTime.Text != "" && txtPopOutTime.Text != "")
            {
                int flag = 0;
                int intime = Convert.ToInt32(txtPopInTime.Text);
                var outtime = Convert.ToInt32(txtPopOutTime.Text);
                if (intime > 2359 || txtPopInTime.Text.Length <= 3)
                {
                    lblPopInTime.Visible = true;
                    lblPopInTime.Text = "Please enter valid In-Time";
                    flag = 1;
                }
                else
                {
                    lblPopInTime.Visible = false;
                }
                if (outtime > 2359 || txtPopOutTime.Text.Length <= 3)
                {
                    lblPopOutTime.Visible = true;
                    lblPopOutTime.Text = "Please enter valid Out-Time";
                    flag = 2;
                }
                else
                {
                    lblPopOutTime.Visible = false;
                }
                if (flag == 0)
                {
                    //final code                    
                    var timeIn = Convert.ToDateTime(txtDutyDate.Text).ToString("MM-dd-yyyy") + ' ' + txtPopInTime.Text.Substring(0, 2) + ':' + txtPopInTime.Text.Substring(2, 2);
                    var timeOut = "";
                    //if (Convert.ToInt32(txtPopInTime.Text) > Convert.ToInt32(txtPopOutTime.Text))
                    //{
                    //    timeOut = Convert.ToDateTime(txtDutyDate.Text).AddDays(1).ToString("MM-dd-yyyy") + ' ' + txtPopOutTime.Text.Substring(0, 2) + ':' + txtPopOutTime.Text.Substring(2, 2);
                    //}
                    //else
                    //{
                        timeOut = Convert.ToDateTime(txtDutyDate.Text).ToString("MM-dd-yyyy") + ' ' + txtPopOutTime.Text.Substring(0, 2) + ':' + txtPopOutTime.Text.Substring(2, 2);
                   // }
                    BL.Sales objSales = new BL.Sales();
                    DataSet dsIn = objSales.ManualInsertEmployeeSAMS("1234567890", BaseUserID, txtPopEmpNo.Text, "IN", timeIn, Convert.ToInt32(BaseLocationAutoID),"");
                    if (dsIn.Tables[0].Rows.Count != 0)
                    {
                        int msgIdIn = Convert.ToInt32(dsIn.Tables[0].Rows[0]["MessageId"].ToString());
                        if (msgIdIn == 1)
                        {
                            DataSet dsOut = objSales.ManualInsertEmployeeSAMS("1234567890", BaseUserID, txtPopEmpNo.Text, "OUT", timeOut, Convert.ToInt32(BaseLocationAutoID), "");
                            if (dsOut.Tables[0].Rows.Count != 0)
                            {
                                int msgIdOut = Convert.ToInt32(dsIn.Tables[0].Rows[0]["MessageId"].ToString());
                                if (msgIdOut == 1)
                                {
                                    Flush();
                                    AddMissing.Visible = false;
                                    divGV.Visible = true;
                                    txtPopEmpNo.Text = "";
                                    txtPopEmpName.Text = "";
                                    tr4.Visible = false;
                                 //   ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "", false);
                                    FillgvAttendence();
                                    lblErrorMsgAdd.Text = dsOut.Tables[0].Rows[0]["MessageString"].ToString();
                                }
                            }
                        }
                        else
                        {
                            Flush();
                          //  ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "", false);
                            lblErrorMsgAdd.Text = dsIn.Tables[0].Rows[0]["MessageString"].ToString();
                        }
                    }
                }
            }
            else
            {
                if (txtPopInTime.Text == "")
                {
                    lblPopInTime.Visible = true;
                    lblPopInTime.Text = "Please enter In-Time";
                }
                else
                {
                    lblPopInTime.Visible = false;
                }
                if (txtPopOutTime.Text == "")
                {
                    lblPopOutTime.Visible = true;
                    lblPopOutTime.Text = "Please enter Out-Time";
                }
                else
                {
                    lblPopOutTime.Visible = false;
                }
            }
           
        }
        catch (Exception ex)
        { }
    }
    private void Flush()
    {
        txtPopEmpNo.Text = "";
        txtPopEmpName.Text = "";
        txtPopInTime.Text = "";
        txtPopOutTime.Text = "";
        lblPopMsg.Visible = false;
        lblPopInTime.Visible = false;
        lblPopOutTime.Visible = false;
        //tr2.Visible = false;
      //  tr3.Visible = false;
        tr4.Visible = false;
        btnPopSubmit.Visible = false;
        btnPopReset.Visible = false;
        lblerrormsg.Text = "";
    }
    protected void btnDelete_Click(object sender, EventArgs e)
    {

    }
    protected void gvAttendence_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        var ds = new DataSet();
        var objAssetMgmt = new BL.Sales();
        Label ID = (Label)gvAttendence.Rows[e.RowIndex].FindControl("lblEmployeeNumber");
        ds = objAssetMgmt.DeleteAttendanceSAMS(ID.Text, BaseLocationAutoID,txtDutyDate.Text);
        lblerrormsg.Text = ds.Tables[0].Rows[0]["MessageString"].ToString();
        gvAttendence.EditIndex = -1;
        FillgvAttendence();
    }
}