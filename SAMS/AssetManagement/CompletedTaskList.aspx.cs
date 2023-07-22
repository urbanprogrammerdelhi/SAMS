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
using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;
using NPOI.HSSF.UserModel;

public partial class AssetManagement_CompletedTaskList : BasePage
{
    static int dtflag;
    static int dtflag1;
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
                var VirtualDirNameLenght = 0;
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
                var VirtualDirNameLenght = 0;
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
                var VirtualDirNameLenght = 0;
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
                var VirtualDirNameLenght = 0;
                VirtualDirNameLenght = int.Parse(System.Web.HttpContext.Current.Request.Url.AbsolutePath.IndexOf(@"/", 1).ToString());
                return IsDeleteAllowed(System.Web.HttpContext.Current.Request.Url.AbsolutePath.Remove(0, VirtualDirNameLenght));
            }
            catch (Exception ex)
            { throw new Exception("Have not Rights", ex); }
        }
    }
    /// <summary>
    /// Gets a value indicating whether the item is enabled. Returns User Authorization Rights.
    /// </summary>
    /// <value><c>true</c> if this instance is authorization access; otherwise, <c>false</c>.</value>
    /// <exception cref="System.Exception"></exception>
    protected bool IsAuthorizationAccess
    {
        get
        {
            try
            {
                var bp = new BasePage();
                int virtualDirNameLenght = int.Parse(System.Web.HttpContext.Current.Request.Url.AbsolutePath.IndexOf(@"/", 1).ToString());
                return bp.IsAuthorizationAllowed(System.Web.HttpContext.Current.Request.Url.AbsolutePath.Remove(0, virtualDirNameLenght));
            }
            catch (Exception ex)
            {
                throw new Exception(Resources.Resource.NOAccessRights, ex);
            }
        }
    }

    #endregion
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (IsReadAccess)
            {
                txtDate.Text = DateTime.Today.ToString("dd-MMM-yyyy");
                txtToDate.Text = DateTime.Today.ToString("dd-MMM-yyyy");
                FillddlClientCode();
                FillddlSiteId(ddlClientCode.SelectedItem.Value);
                FillddlPostCode(ddlClientCode.SelectedItem.Value, ddlSiteId.SelectedItem.Value);
                FillgvTaskMaster();
                pnlTaskMaster.Visible = true;
            }
        }
        txtDate.Attributes.Add("readonly", "readonly");
        txtToDate.Attributes.Add("readonly", "readonly");
    }
    private void FillddlClientCode()
    {
        var objAssetManagement = new BL.AssetManagement();
        ddlClientCode.DataSource = objAssetManagement.GetClientCode(BaseLocationAutoID);
        ddlClientCode.DataTextField = "ClientCodenName";
        ddlClientCode.DataValueField = "ClientCode";
        ddlClientCode.DataBind();
        // ddlClientCode.Items.Insert(0, new ListItem("ALL", "ALL"));
        if (ddlClientCode.SelectedValue == "")
        {
            var li = new ListItem { Text = Resources.Resource.NoData, Value = @"0" };
            ddlClientCode.Items.Add(li);
        }
    }
    private void FillddlSiteId(string ClientCode)
    {
        var objAssetManagement = new BL.AssetManagement();
        ddlSiteId.DataSource = objAssetManagement.GetAsmtId(ClientCode, BaseLocationAutoID);
        ddlSiteId.DataTextField = "SiteCodenName";
        ddlSiteId.DataValueField = "AsmtId";
        ddlSiteId.DataBind();
        // ddlSiteId.Items.Insert(0, new ListItem("ALL", "ALL"));
        if (ddlSiteId.SelectedValue == "")
        {
            var li = new ListItem { Text = Resources.Resource.NoData, Value = @"0" };
            ddlSiteId.Items.Add(li);
        }
    }
    private void FillddlPostCode(string ClientCode, string AsmtId)
    {
        var objAssetManagement = new BL.AssetManagement();
        ddlPostCode.DataSource = objAssetManagement.GetPostCode(ClientCode, AsmtId, BaseLocationAutoID);
        ddlPostCode.DataTextField = "PostCodenName";
        ddlPostCode.DataValueField = "PostAutoId";
        ddlPostCode.DataBind();
        ddlPostCode.Items.Insert(0, new ListItem("ALL", "ALL"));
        if (ddlPostCode.SelectedValue == "")
        {
            var li = new ListItem { Text = Resources.Resource.NoData, Value = @"0" };
            ddlPostCode.Items.Add(li);
        }
    }
    private void FillgvTaskMaster()
    {
        try
        {
            var objAssetMgmt = new BL.AssetManagement();
            var dsTaskMaster = new DataSet();
            var dtTaskMaster = new DataTable();
            dtflag1 = 1;
            dsTaskMaster = objAssetMgmt.GetCompletedTasklist(ddlClientCode.SelectedItem.Value, ddlSiteId.SelectedItem.Value, ddlPostCode.SelectedItem.Value, BaseLocationAutoID, txtDate.Text,txtToDate.Text,ddlStatus.SelectedItem.Value);
            dtTaskMaster = dsTaskMaster.Tables[0];
            if (dtTaskMaster.Rows.Count == 0)
            {
                dtflag1 = 0;
                dtTaskMaster.Rows.Add(dtTaskMaster.NewRow());
            }
            gvTaskMaster.DataSource = dtTaskMaster;
            gvTaskMaster.DataBind();

            if (dtflag1 == 0)
            {
                gvTaskMaster.Rows[0].Visible = false;
                dtflag1 = 0;
            }
            else
            {
                dtflag1 = 1;
            }

        }
        catch (Exception ex)
        {
        }
    }
    protected void ddlClientCode_SelectedIndexChanged(object sender, EventArgs e)
    {
        FillddlSiteId(ddlClientCode.SelectedItem.Value);
        FillddlPostCode(ddlClientCode.SelectedItem.Value, ddlSiteId.SelectedItem.Value);
        FillgvTaskMaster();
    }
    protected void ddlSiteId_SelectedIndexChanged(object sender, EventArgs e)
    {
        FillddlPostCode(ddlClientCode.SelectedItem.Value, ddlSiteId.SelectedItem.Value);
        FillgvTaskMaster();
    }
    protected void ddlPostCode_SelectedIndexChanged(object sender, EventArgs e)
    {
        FillgvTaskMaster();
    }
    protected void txtDate_TextChanged(object sender, EventArgs e)
    {
        FillgvTaskMaster();
    }
    protected void txtToDate_TextChanged(object sender, EventArgs e)
    {

        FillgvTaskMaster();
    }
    protected void gvTaskMaster_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvTaskMaster.PageIndex = e.NewPageIndex;
        gvTaskMaster.EditIndex = -1;
        FillgvTaskMaster();
    }
    protected void btnExport_Click(object sender, EventArgs e)
    {
        //Response.Clear();
        //Response.Buffer = true;        
        //Response.Charset = "";
        ////Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
        //Response.ContentType = "application/vnd.ms-excel";      
        ////Response.ContentType = "application/vnd.xls";
        //Response.AddHeader("content-disposition", "attachment;filename=TaskListReport-" + txtDate.Text + " to " + txtToDate.Text + ".xls");
        
        //using (StringWriter sw = new StringWriter())
        //{
        //    HtmlTextWriter hw = new HtmlTextWriter(sw);

        //    //To Export all pages
        //    gvTaskMaster.AllowPaging = false;
        //    FillgvTaskMaster();

        //    gvTaskMaster.HeaderRow.BackColor = Color.White;
        //    foreach (TableCell cell in gvTaskMaster.HeaderRow.Cells)
        //    {
        //        cell.BackColor = gvTaskMaster.HeaderStyle.BackColor;
        //    }
        //    foreach (GridViewRow row in gvTaskMaster.Rows)
        //    {
        //        row.BackColor = Color.White;
        //        foreach (TableCell cell in row.Cells)
        //        {
        //            if (row.RowIndex % 2 == 0)
        //            {
        //                cell.BackColor = gvTaskMaster.AlternatingRowStyle.BackColor;
        //            }
        //            else
        //            {
        //                cell.BackColor = gvTaskMaster.RowStyle.BackColor;
        //            }
        //            cell.CssClass = "textmode";
        //        }
        //    }

        //    gvTaskMaster.RenderControl(hw);

        //    //style to format numbers to string
        //    string style = @"<style> .textmode { } </style>";
        //    Response.Write(style);
        //    Response.Output.Write(sw.ToString());
        //    Response.Flush();
        //    Response.End();
        //}
        var objAssetMgmt = new BL.AssetManagement();
        var dsTaskMaster = new DataSet();
        var dtTaskMaster = new DataTable();
        dtflag1 = 1;
        dsTaskMaster = objAssetMgmt.GetCompletedTasklist(ddlClientCode.SelectedItem.Value, ddlSiteId.SelectedItem.Value, ddlPostCode.SelectedItem.Value, BaseLocationAutoID, txtDate.Text, txtToDate.Text, ddlStatus.SelectedItem.Value);
        dtTaskMaster = dsTaskMaster.Tables[1];
        WriteExcelWithNPOI("xls", dtTaskMaster);

       
    }
    public override void VerifyRenderingInServerForm(Control control)
    {
        // controller   
    }
    protected void ddlStatus_SelectedIndexChanged(object sender, EventArgs e)
    {
        FillgvTaskMaster();
    }

public void WriteExcelWithNPOI(String extension, DataTable dt)
   {
       // dll refered NPOI.dll and NPOI.OOXML

       IWorkbook workbook;

       if (extension == "xlsx")
       {
           workbook = new XSSFWorkbook();
       }
       else if (extension == "xls")
       {
           workbook = new HSSFWorkbook();
       }
       else
       {
           throw new Exception("This format is not supported");
       }

       ISheet sheet1 = workbook.CreateSheet("Sheet 1");

       //HSSFWorkbook templateWorkbook = new HSSFWorkbook(fs, true);
       //HSSFCellStyle style1 = templateWorkbook.CreateCellStyle();
       //style1.BorderRight = HSSFCellStyle.BORDER_MEDIUM;
       //style1.BorderBottom = HSSFCellStyle.BORDER_MEDIUM;
       //style1.Alignment = HSSFCellStyle.ALIGN_CENTER;
       ////style1.FillPattern = HSSFCellStyle.SOLID_FOREGROUND;
       ////style1.FillForegroundColor = NPOI.HSSF.Util.HSSFColor.GREEN.index;
       //HSSFFont font1 = templateWorkbook.CreateFont();
       ////font1.Color = NPOI.HSSF.Util.HSSFColor.BROWN.index;
       //font1.FontName = "B Nazanin";
       //style1.SetFont(font1);
       //formatRange.EntireRow.Font.Bold = true;

       //make a header row
       IRow row1 = sheet1.CreateRow(0);
      
       for (int j = 0; j < dt.Columns.Count; j++)
       {

           ICell cell = row1.CreateCell(j);
           
           String columnName = dt.Columns[j].ToString();
           cell.SetCellValue(columnName);
          // cell.CellStyle.EntireRow.Font.Bold = true;
          // cell.CellStyle.FillForegroundColor = IndexedColors.Blue.Index;
       }

       //loops through data
       for (int i = 0; i < dt.Rows.Count; i++)
       {
           IRow row = sheet1.CreateRow(i + 1);
           for (int j = 0; j < dt.Columns.Count; j++)
           {

               ICell cell = row.CreateCell(j);
               String columnName = dt.Columns[j].ToString();
               cell.SetCellValue(dt.Rows[i][columnName].ToString());
               
           }
       }

       using (var exportData = new MemoryStream())
       {
           Response.Clear();
           workbook.Write(exportData);
           if (extension == "xlsx") //xlsx file format
           {
               Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
               Response.AddHeader("Content-Disposition", string.Format("attachment;filename={0}", "tpms_Dict.xlsx"));
               Response.BinaryWrite(exportData.ToArray());
           }
           else if (extension == "xls")  //xls file format
           {
               Response.ContentType = "application/vnd.ms-excel";
               Response.AddHeader("Content-Disposition", string.Format("attachment;filename={0}", "TaskListReport-" + txtDate.Text + " to " + txtToDate.Text + ".xls"));
               Response.BinaryWrite(exportData.ToArray());
           }
           Response.End();
       }
   }

}