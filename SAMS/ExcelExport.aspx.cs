using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.OleDb;
using System.Data.SqlClient; 

public partial class ExcelExport : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void ImportFromExcel(object sender, EventArgs e)
    {
       
    }
    protected void btninsert_Click(object sender, EventArgs e)
    {
        // CHECK IF A FILE HAS BEEN SELECTED.
        if ((FileUpload.HasFile))
        {

            if (!Convert.IsDBNull(FileUpload.PostedFile) &
                FileUpload.PostedFile.ContentLength > 0)
            {

                //FIRST, SAVE THE SELECTED FILE IN THE ROOT DIRECTORY.
                FileUpload.SaveAs(Server.MapPath(".") + "\\" + FileUpload.FileName);

                SqlBulkCopy oSqlBulk = null;

                // SET A CONNECTION WITH THE EXCEL FILE.
                OleDbConnection myExcelConn = new OleDbConnection
                    ("Provider=Microsoft.ACE.OLEDB.12.0; " +
                        "Data Source=" + Server.MapPath(".") + "\\" + FileUpload.FileName +
                        ";Extended Properties=Excel 12.0;");
                try
                {
                    myExcelConn.Open();

                    // GET DATA FROM EXCEL SHEET.
                    OleDbCommand objOleDB =
                        new OleDbCommand("SELECT *FROM [Sheet1$]", myExcelConn);

                    // READ THE DATA EXTRACTED FROM THE EXCEL FILE.
                    OleDbDataReader objBulkReader = null;
                    objBulkReader = objOleDB.ExecuteReader();

                    // SET THE CONNECTION STRING.
                    string sCon = "Data Source=DNA;Persist Security Info=False;" +
                        "Integrated Security=SSPI;" +
                        "Initial Catalog=DNA_Classified;User Id=sa;Password=;" +
                        "Connect Timeout=30;";

                    using (SqlConnection con = new SqlConnection(sCon))
                    {
                        con.Open();

                        // FINALLY, LOAD DATA INTO THE DATABASE TABLE.
                        oSqlBulk = new SqlBulkCopy(con);
                        oSqlBulk.DestinationTableName = "EmployeeDetails"; // TABLE NAME.
                        oSqlBulk.WriteToServer(objBulkReader);
                    }

                    lblConfirm.Text = "DATA IMPORTED SUCCESSFULLY.";
                    lblConfirm.Attributes.Add("style", "color:green");

                }
                catch (Exception ex)
                {

                    lblConfirm.Text = ex.Message;
                    lblConfirm.Attributes.Add("style", "color:red");

                }
                finally
                {
                    // CLEAR.
                    //oSqlBulk.Close();
                    //oSqlBulk = null;
                    //myExcelConn.Close();
                    //myExcelConn = null;
                }
            }
        }
    }
}