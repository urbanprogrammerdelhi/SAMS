// ***********************************************************************
// Assembly         : 
// Author           : manish
// Created          : 09-13-2013
//
// Last Modified By : manish
// Last Modified On : 04-02-2014
// ***********************************************************************
// <copyright file="Paysum_Greece_Weekly.aspx.cs" company="Magnon">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Data;

/// <summary>
/// Class Transactions_PaySum_Greece_Weekly.
/// </summary>
public partial class Transactions_PaySum_Greece_Weekly : BasePage
{

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

    /// <summary>
    /// Handles the Load event of the Page control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            //Label lblPageHdrTitle = (Label)Master.FindControl("lblPageHdrTitle");
            //if (lblPageHdrTitle != null)
            //{ lblPageHdrTitle.Text = Resources.Resource.PaySum; }

            //Code added by Manoj on 16 Jan 2012
            //Page Title from resource file
            System.Text.StringBuilder javaScript = new System.Text.StringBuilder();
            javaScript.Append("<script type='text/javascript'>");
            javaScript.Append("window.document.body.onload = function ()");
            javaScript.Append("{\n");
            javaScript.Append("PageTitle('" + Resources.Resource.PaySum + "');");
            javaScript.Append("};\n");
            javaScript.Append("// -->\n");
            javaScript.Append("</script>");
            this.Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "BodyLoadUnloadScript", javaScript.ToString());

            if (IsReadAccess == true)
            {

                Panel2.Visible = false;

                ImgFDate.NavigateUrl = "javascript:calendarPicker('aspnetForm." + TxtFDate.ClientID.ToString() + "');";
                ImgTDate.NavigateUrl = "javascript:calendarPicker('aspnetForm." + TxtTDate.ClientID.ToString() + "');";

                TxtFDate.Text = FirstDateOfCurrentMonth_Get();
                TxtTDate.Text = DateTime.Parse(TxtFDate.Text).AddDays(double.Parse("6")).ToString("dd-MMM-yyyy");
                // TxtFDate.Text = "02-May-2010";
                // TxtTDate.Text = "08-May-2010";
            }
            else
            {
                Response.Redirect("../UserManagement/Home.aspx");
            }

        }
        FillDataGrid();

    }

    /// <summary>
    /// Handles the TextChanged event of the TxtFDate control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    protected void TxtFDate_TextChanged(object sender, EventArgs e)
    {
        ConvertStringToDateFormat(TxtFDate,lblErrorMsg );
    }
    /// <summary>
    /// Handles the TextChanged event of the TxtTDate control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    protected void TxtTDate_TextChanged(object sender, EventArgs e)
    {
        ConvertStringToDateFormat(TxtTDate,lblErrorMsg );
    }


    /// <summary>
    /// Handles the submit event of the btn control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    protected void btn_submit(object sender, EventArgs e)
    {
        ASPxGridViewExporter1.GridViewID = "ASPxGridView1";
        ASPxGridViewExporter1.WriteCsvToResponse();

    }

    /// <summary>
    /// Fills the data grid.
    /// </summary>
    protected void FillDataGrid()
    {
        Panel2.Visible = true;
        BL.Roster objRoster = new BL.Roster();
        DataSet ds = new DataSet();
        ds = objRoster.GenerateWeeklyPaysumGreece(BaseCompanyCode, BaseHrLocationCode, BaseLocationCode, TxtFDate.Text, TxtTDate.Text, BaseUserID, "1");
        ASPxGridView1.DataSource = ds;
        ASPxGridView1.DataBind();

    }

    //protected void btnPaySum_OnClick(object sender, EventArgs e)
    //{
    //    Response.Redirect("PaySumTextFormatGreece.aspx?FromDate=" + TxtFDate.Text + "&ToDate=" + TxtTDate.Text);
    //}
    /// <summary>
    /// Handles the OnClick event of the btnGenerateData control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    protected void btnGenerateData_OnClick(object sender, EventArgs e)
    {
         FillDataGrid();
    }



}

