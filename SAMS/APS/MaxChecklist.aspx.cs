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
using System.Data.SqlClient;
using System.IO;
using System.Configuration;
using System.Threading;
using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.text.html.simpleparser;
using iTextSharp.tool.xml;



public partial class APS_MaxChecklist : BasePage
{
    static int flag;
    static int dtflag;
    static int dtflag1;
    static string Branchcode = "";
    static string Date = "";
    static string ImageId = "";

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
            txtFromDate.Attributes.Add("readonly", "readonly");
            txtFromDate.Text = DateTime.Now.AddDays(-15).ToString("dd-MMM-yyyy");
            gvAttendence.Visible = true;
            if (IsReadAccess == true)
            {
                //  FillddlAreaID();
                //  FillddlClientCode();
                FillgvBranchCode();
                //FillAsmtId();
             //   FillgvAttendence(Branchcode.ToString(), Date.ToString());
                System.Web.UI.ScriptManager ToolkitScriptManager1 = (System.Web.UI.ScriptManager)Master.FindControl("ToolkitScriptManager1");
                ToolkitScriptManager1.SetFocus(ddlClientCode);
            }
            else
            {
                Response.Redirect("../UserManagement/Home.aspx");
            }
           
        }
    }
    protected void FillddlClientCode()
    {
        DataSet ds = new DataSet();
        BL.Sales objsales = new BL.Sales();

        ds = objsales.GetClientDetailsAPS(BaseLocationAutoID,txtDutyDate.Text);

        if (ds != null)
        {
            if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                ddlClientCode.DataSource = ds.Tables[0];
                ddlClientCode.DataTextField = "ClientCodeName";
                ddlClientCode.DataValueField = "ClientCode";
                ddlClientCode.DataBind();
                if (Request.QueryString["ClientCode"] != null)
                {
                    ddlClientCode.SelectedIndex = ddlClientCode.Items.IndexOf(ddlClientCode.Items.FindByValue(Request.QueryString["ClientCode"].ToString()));
                }
                lblmsg.Visible = false;
                //  ddlClientCode.Items.Insert(0, new ListItem("All", "All"));

            }
            else
            {
                ddlClientCode.Items.Clear();
                System.Web.UI.WebControls.ListItem li = new System.Web.UI.WebControls.ListItem();
                li.Text = "No Audit Branch Available on Selected Date";
                li.Value = "0";
                ddlClientCode.Items.Add(li);
                lblmsg.Visible = true;
            }
        }
        else
        {
            ddlClientCode.Items.Clear();
            System.Web.UI.WebControls.ListItem li = new System.Web.UI.WebControls.ListItem();
            li.Text = "No Audit Branch Available on Selected Date";
            li.Value = "0";
            ddlClientCode.Items.Add(li);
            lblmsg.Visible = true;
        }
    }
    protected void FillgvAttendence(string BranchCode,string Date)
    {
        var objAssetMgmt = new BL.Sales();
        var ds = new DataSet();
        var dt = new DataTable();
        var dt1 = new DataTable();
        var dtflag = 1;
      //  ds = objAssetMgmt.GetChecklistReportMax(BaseLocationAutoID, BranchCode.ToString(), Date.ToString());
        ds = objAssetMgmt.GetChecklistReportMaxWithImage(BaseLocationAutoID, BranchCode.ToString(), Date.ToString());
        dt = ds.Tables[1];
        dt1 = ds.Tables[0];


        if (dt1.Rows.Count == 0)
        {
            dtflag = 0;
            dt.Rows.Add(dt.NewRow());
        }

        //DataColumn dc = new DataColumn("ImageBase64String", typeof(System.String));
        //ds.Tables[1].Columns.Add(dc);
        //for (int i = 0; i < ds.Tables[1].Rows.Count; i++)
        //{
        //    if (ds.Tables[1].Rows[i]["ChecklistImage"].ToString() != "")
        //    {
        //        //ds.Tables[1].Rows[i]["ImageBase64String"] = ds.Tables[1].Rows[i]["ChecklistImage"];
        //      ds.Tables[1].Rows[i]["ImageBase64String"] = "data:image/jpeg;base64," + Convert.ToBase64String(((byte[])((object)ds.Tables[1].Rows[i]["ChecklistImage"])), 0, ((byte[])((object)ds.Tables[1].Rows[i]["ChecklistImage"])).Length);
        //    }
        //    else
        //    {
        //        ds.Tables[1].Rows[i]["ImageBase64String"] = string.Empty;
        //    }
        //}
        HttpContext.Current.Session["gvAttendence"] = dt;
        gvAttendence.DataSource = dt;
        gvAttendence.DataBind();


        if (dtflag == 0)
        {
            divGV.Visible = false;
            divBranchCode.Visible = true;
            gvAttendence.Rows[0].Visible = false;

            lblmsg.Visible = true;
        }
        else
        {
            divGV.Visible = true;
            divBranchCode.Visible = false;
            lblBranchCode.Text = ds.Tables[0].Rows[0]["BranchCode"].ToString();
            lblBranchName.Text = ds.Tables[0].Rows[0]["BranchName"].ToString();
            lblspocname.Text = ds.Tables[0].Rows[0]["SpocName"].ToString();
            lblspocno.Text = ds.Tables[0].Rows[0]["SpocNo"].ToString();
            lblfo.Text = ds.Tables[0].Rows[0]["FOName"].ToString();
            lbldate.Text = ds.Tables[0].Rows[0]["AuditTime"].ToString();
            lblmsg.Visible = false;
        }


    }
    protected void btnView_Click(object sender, EventArgs e)
    {
        FillgvBranchCode();
        divBranchCode.Visible = true;
        divGV.Visible = false;
    }
    protected void FillgvBranchCode()
    {
        var objAssetMgmt = new BL.Sales();
        var ds = new DataSet();
        var dt = new DataTable();
        var dtflag = 1;
        ds = objAssetMgmt.GetAuditBranchDetails(BaseLocationAutoID, txtFromDate.Text.Trim(), txtDutyDate.Text.Trim());
        dt = ds.Tables[0];
      


        if (dt.Rows.Count == 0)
        {
            dtflag = 0;
            dt.Rows.Add(dt.NewRow());
        }

        gvBranchCode.DataSource = dt;
        gvBranchCode.DataBind();


        if (dtflag == 0)
        {
            divBranchCode.Visible = false;
            gvBranchCode.Rows[0].Visible = false;

            lblmsg.Visible = true;
        }
        else
        {
            divBranchCode.Visible = true;
            lblmsg.Visible = false;
        }
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
            Label lblEmployeeRemarks = (Label)e.Row.FindControl("lblEmployeeRemarks");
            lblEmployeeRemarks.ForeColor = System.Drawing.Color.Black;
            lblEmployeeRemarks.Font.Bold = true;
            Label lblId = (Label)e.Row.FindControl("lblId");
            LinkButton lblimage = (LinkButton)e.Row.FindControl("lblimage");
            //  ImageButton imgEmpImage = (ImageButton)e.Row.FindControl("imgEmpImage");
            System.Web.UI.WebControls.Image imgEmpImage = (System.Web.UI.WebControls.Image)e.Row.FindControl("imgEmpImage");

            HiddenField hfflag = (HiddenField)e.Row.FindControl("hfflag");
            if (hfflag.Value == "True")
            {
                    lblimage.Visible = true;
                  imgEmpImage.Visible = true;
               
            }
            else
            {
                    lblimage.Visible = false;
                   imgEmpImage.Visible = false;              
            }

            if (lblId.Text == "1")
            {
                lblimage.Visible = false;
               imgEmpImage.Visible = false;
            }
            if (lblId.Text == "3")
            {
                lblimage.Visible = false;
                imgEmpImage.Visible = false;
            }
                if (lblId.Text == "10")
            {
                lblimage.Visible = false;
               imgEmpImage.Visible = false;
            }
            if (lblId.Text == "19")
            {
                lblimage.Visible = false;
                imgEmpImage.Visible = false;
            }
            if (lblId.Text == "23")
            {
                lblimage.Visible = false;
                imgEmpImage.Visible = false;
            }
            if (lblId.Text == "24")
            {
                lblimage.Visible = false;
                imgEmpImage.Visible = false;
            }
            if (lblId.Text == "25")
            {
                lblimage.Visible = false;
                imgEmpImage.Visible = false;
            }
            if (lblId.Text == "26")
            {
                lblimage.Visible = false;
                imgEmpImage.Visible = false;
            }
            if (lblId.Text == "28")
            {
                lblimage.Visible = false;
               imgEmpImage.Visible = false;
            }
            if (lblId.Text == "29")
            {
                lblimage.Visible = false;
               imgEmpImage.Visible = false;
            }
            if (lblId.Text == "31")
            {
                lblimage.Visible = false;
               imgEmpImage.Visible = false;
            }
            if (lblId.Text == "32")
            {
                lblimage.Visible = false;
               imgEmpImage.Visible = false;
            }
            if (lblId.Text == "34")
            {
                lblimage.Visible = false;
                imgEmpImage.Visible = false;
            }
            if (lblId.Text == "35")
            {
                lblimage.Visible = false;
                imgEmpImage.Visible = false;
            }
            if (lblId.Text == "40")
            {
                lblimage.Visible = false;
                imgEmpImage.Visible = false;
            }
            if (lblId.Text == "43")
            {
                lblimage.Visible = false;
                imgEmpImage.Visible = false;
            }
            if (lblId.Text == "44")
            {
                lblimage.Visible = false;
                imgEmpImage.Visible = false;
            }

            if ((e.Row.DataItem as DataRowView)["ImageId"] != DBNull.Value)
            {
                Uri uri = Request.Url;

                //Generate Absolute Path for the Images folder.
                string applicationUrl = string.Format("{0}://{1}{2}", uri.Scheme, uri.Authority, uri.AbsolutePath);
                applicationUrl = applicationUrl.Replace(Request.Url.Segments[Request.Url.Segments.Length - 1], "");

                //Fetch the Image ID from the DataKeyNames property.
                int id = Convert.ToInt32((e.Row.DataItem as DataRowView)["ImageId"]);

                //Generate and set the Handler Absolute URL in the Image control.
                string imageUrl = string.Format("{0}ImageWriter.ashx?id={1}", applicationUrl, id);
                imgEmpImage.ImageUrl = imageUrl;
                //imgEmpImage.ImageUrl = "data:image/png;base64," + Convert.ToBase64String((Byte[])(e.Row.DataItem as DataRowView)["ChecklistImage"]);
            }

        }

       
    }
    protected void gvAttendence_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        //gvAttendence.PageIndex = e.NewPageIndex;
        //gvAttendence.EditIndex = -1;
        //FillgvAttendence();
    }
    public override void VerifyRenderingInServerForm(Control control)
    {
        // controller   
    }
    protected void btnExport_Click1(object sender, EventArgs e)
    {
        try
        {
            Response.Clear();
            Response.Buffer = true;
            Response.AddHeader("content-disposition", "attachment;filename=MaxAuditReport-" + lblBranchCode.Text +" -" +lbldate.Text+ ".xls");
            Response.Charset = "";
            Response.ContentType = "application/vnd.ms-excel";
            using (StringWriter sw = new StringWriter())
            {
                HtmlTextWriter hw = new HtmlTextWriter(sw);

                //To Export all pages
                gvAttendence.AllowPaging = false;
              //  FillgvAttendence();
                   gvAttendence.Columns[4].Visible = false;

                gvAttendence.HeaderRow.BackColor = System.Drawing.Color.White;
                foreach (TableCell cell in gvAttendence.HeaderRow.Cells)
                {
                    cell.BackColor = gvAttendence.HeaderStyle.BackColor;
                }
                foreach (GridViewRow row in gvAttendence.Rows)
                {
                    row.BackColor = System.Drawing.Color.White;
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
                divspoc.RenderControl(hw);
                gvAttendence.RenderControl(hw);
                //style to format numbers to string
                string style = @"<style> .textmode { } </style>";
                Response.Write(style);
                Response.Output.Write(sw.ToString());
                HttpContext.Current.Response.Flush(); // Sends all currently buffered output to the client.
                HttpContext.Current.Response.SuppressContent = true;  // Gets or sets a value indicating whether to send HTTP content to the client.
                HttpContext.Current.ApplicationInstance.CompleteRequest();

            }
        }
        catch (ThreadAbortException ex1)
        {
            //this is special for the Response.end exception
        }
        catch (Exception ex)
        {

        }
        finally
        {
           
        }

        //Response.Clear();
        //Response.Buffer = true;
        //Response.ClearContent();
        //Response.ClearHeaders();
        //Response.Charset = "";
        //string FileName = "Vithal" + DateTime.Now + ".xls";
        //StringWriter strwritter = new StringWriter();
        //HtmlTextWriter htmltextwrtter = new HtmlTextWriter(strwritter);
        //Response.Cache.SetCacheability(HttpCacheability.NoCache);
        //Response.ContentType = "application/vnd.ms-excel";
        //Response.AddHeader("Content-Disposition", "attachment;filename=" + FileName);
        //gvAttendence.GridLines = GridLines.Both;
        //gvAttendence.HeaderStyle.Font.Bold = true;
        //gvAttendence.RenderControl(htmltextwrtter);
        //Response.Write(strwritter.ToString());
        //Response.End();

    }
    protected void lblimage_Click(object sender, EventArgs e)
    {
        pnlTaskImage.Visible = true;
        divGV.Visible = false;
        LinkButton objLinkButton = (LinkButton)sender;
        GridViewRow row = (GridViewRow)objLinkButton.NamingContainer;
        Label lblId = (Label)gvAttendence.Rows[row.RowIndex].FindControl("lblId");
        Label lblEmployeeName = (Label)gvAttendence.Rows[row.RowIndex].FindControl("lblEmployeeName");
        ImageId = lblId.Text;
        Label7.Text = "Below are the Images for - " + lblEmployeeName.Text;
        FillgvImage(lblId.Text);
    }
    protected void FillgvImage(string TaskId)
    {     

        var objsales = new BL.Sales();
        var ds = new DataSet();
        var dt = new DataTable();
        dtflag = 1;
        ds = objsales.GetAuditImage(BaseLocationAutoID,TaskId.ToString(),Branchcode.ToString(),Date.ToString());
        dt = ds.Tables[0];

        if (dt.Rows.Count == 0)
        {
            dtflag = 0;
            dt.Rows.Add(dt.NewRow());
        }

        DataColumn dc = new DataColumn("ImageBase64String", typeof(System.String));
        ds.Tables[0].Columns.Add(dc);
        for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
        {
            if (ds.Tables[0].Rows[i]["ItemImage"].ToString() != "")
            {
                ds.Tables[0].Rows[i]["ImageBase64String"] = "data:image/jpeg;base64," + Convert.ToBase64String(((byte[])((object)ds.Tables[0].Rows[i]["ItemImage"])), 0, ((byte[])((object)ds.Tables[0].Rows[i]["ItemImage"])).Length);
            }
            else
            {
                ds.Tables[0].Rows[i]["ImageBase64String"] = string.Empty;
            }
        }

        gvImage.DataSource = dt;
        gvImage.DataBind();

        if (dtflag == 0)//to fix empety gridview
        {
            gvImage.Rows[0].Visible = false;
        }
    }
    protected void gvImage_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvImage.PageIndex = e.NewPageIndex;
        gvImage.EditIndex = -1;
        FillgvImage(ImageId.ToString());
    }
    protected void btnbacktaskList_Click(object sender, EventArgs e)
    {
        pnlTaskImage.Visible = false;
        divGV.Visible = true;
    }
    protected void txtDutyDate_TextChanged(object sender, EventArgs e)
    {
        divGV.Visible = false;
        FillddlClientCode();

    }
    protected void ddlClientCode_SelectedIndexChanged(object sender, EventArgs e)
    {
        divGV.Visible = false;
    }

    protected void gvBranchCode_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        GridViewRow objGridViewRow = e.Row;
        Label lblSerialNo = (Label)objGridViewRow.FindControl("lblSerialNo");
        if (lblSerialNo != null)
        {
            int serialNo = gvBranchCode.PageIndex * gvBranchCode.PageSize + int.Parse(objGridViewRow.RowIndex.ToString());
            lblSerialNo.Text = Convert.ToString((serialNo + 1));
        }
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            Label lblSerialNo1 = (Label)e.Row.FindControl("lblSerialNo");
            lblSerialNo1.ForeColor = System.Drawing.Color.Black;
            lblSerialNo1.Font.Bold = true;
            Label lblBranchCode = (Label)e.Row.FindControl("lblBranchCode");
            lblBranchCode.ForeColor = System.Drawing.Color.Green;
            lblBranchCode.Font.Bold = true;
            Label lblBranchName = (Label)e.Row.FindControl("lblBranchName");
            lblBranchName.ForeColor = System.Drawing.Color.Black;
            lblBranchName.Font.Bold = true;
            Label lblAuditDate = (Label)e.Row.FindControl("lblAuditDate");
            lblAuditDate.ForeColor = System.Drawing.Color.Red;
            lblAuditDate.Font.Bold = true;
          
        }
        }

    protected void gvBranchCode_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvBranchCode.PageIndex = e.NewPageIndex;
        gvBranchCode.EditIndex = -1;
        FillgvBranchCode();
    }

    protected void lblFetchReport_Click(object sender, EventArgs e)
    {
        LinkButton objLinkButton = (LinkButton)sender;
        GridViewRow row = (GridViewRow)objLinkButton.NamingContainer;
        Label lblBranchCode = (Label)gvBranchCode.Rows[row.RowIndex].FindControl("lblBranchCode");
        Label lblAuditDate = (Label)gvBranchCode.Rows[row.RowIndex].FindControl("lblAuditDate");
        Branchcode = lblBranchCode.Text;
        Date = lblAuditDate.Text;
        FillgvAttendence(lblBranchCode.Text,lblAuditDate.Text);
    }

    protected void btnBack_Click(object sender, EventArgs e)
    {
        divBranchCode.Visible = true;
        divGV.Visible = false;
    }

    protected void btnExporttoPDF_Click(object sender, EventArgs e)
    {

        Response.Write("<script>window.open ('../MaxPDFReport.aspx','_blank');</script>");

        //Response.ContentType = "application/pdf";
        //Response.AddHeader("content-disposition", "attachment;filename=MaxAuditReport-" + lblBranchCode.Text + " -" + lbldate.Text + ".pdf");
        //Response.Cache.SetCacheability(HttpCacheability.NoCache);
        //StringWriter stringWriter = new StringWriter();
        //HtmlTextWriter htmlTextWriter = new HtmlTextWriter(stringWriter);

        //divspoc.RenderControl(htmlTextWriter);
        //gvAttendence.RenderControl(htmlTextWriter);
        //StringReader stringReader = new StringReader(stringWriter.ToString());
        //Document Doc = new Document(PageSize.A4, 10f, 10f, 10f, 0f);
        //HTMLWorker htmlparser = new HTMLWorker(Doc);
        //PdfWriter.GetInstance(Doc, Response.OutputStream);
        //Doc.Open();
        //htmlparser.Parse(stringReader);
        //Doc.Close();
        //Response.Write(Doc);
        //   Response.End();


        //Response.Clear();
        //Response.Buffer = true;
        //Response.AddHeader("content-disposition", "attachment;filename=MaxAuditReport-" + lblBranchCode.Text + " -" + lbldate.Text + ".pdf");
        //Response.Charset = "";
        //Response.ContentType = "application/pdf";

        ////To Export all pages.
        //gvAttendence.AllowPaging = false;
        //FillgvAttendence(Branchcode.ToString(), Date.ToString());

        //using (StringWriter sw = new StringWriter())
        //{
        //    using (HtmlTextWriter hw = new HtmlTextWriter(sw))
        //    {
        //        divspoc.RenderControl(hw);
        //        gvAttendence.RenderControl(hw);
        //        StringReader sr = new StringReader(sw.ToString());
        //        Document pdfDoc = new Document(PageSize.A4, 10f, 10f, 10f, 0f);
        //        PdfWriter writer = PdfWriter.GetInstance(pdfDoc, Response.OutputStream);
        //        pdfDoc.Open();
        //        XMLWorkerHelper.GetInstance().ParseXHtml(writer, pdfDoc, sr);
        //        pdfDoc.Close();
        //        Response.Cache.SetCacheability(HttpCacheability.NoCache);
        //        Response.Write(pdfDoc);
        //        Response.End();
        //    }
        //}


        //Response.Clear();
        //Response.Buffer = true;
        //Response.AddHeader("content-disposition", "attachment;filename=GridViewExport.pdf");
        //Response.Charset = "";
        //Response.ContentType = "application/pdf";

        ////To Export all pages.
        //gvAttendence.AllowPaging = false;
        //FillgvAttendence(Branchcode.ToString(), Date.ToString());

        //using (StringWriter sw = new StringWriter())
        //{
        //    using (HtmlTextWriter hw = new HtmlTextWriter(sw))
        //    {
        //        try
        //        {
        //            gvAttendence.RenderControl(hw);
        //            StringReader sr = new StringReader(sw.ToString());
        //            Document pdfDoc = new Document(PageSize.A4, 10f, 10f, 10f, 0f);
        //            PdfWriter writer = PdfWriter.GetInstance(pdfDoc, Response.OutputStream);
        //            pdfDoc.Open();
        //            XMLWorkerHelper.GetInstance().ParseXHtml(writer, pdfDoc, sr);
        //            pdfDoc.Close();
        //            Response.Cache.SetCacheability(HttpCacheability.NoCache);
        //            Response.Write(pdfDoc);
        //            //  Response.End();
        //            HttpContext.Current.ApplicationInstance.CompleteRequest();
        //        }
        //        catch (Exception ex)
        //        {

        //        }
        //    }
        //}
    }
}