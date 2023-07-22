using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Web.Services;
using System.Web.Script.Services;
using DL;
using System.Net;
using System.IO;
using System.Net.Mail;
using System.Configuration;
using System.Text;
using Newtonsoft.Json;
using ClosedXML.Excel;
using System.Configuration;
/// <summary>
/// Summary description for APInventory
/// </summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
// To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
// [System.Web.Script.Services.ScriptService]
public class APInventory : System.Web.Services.WebService
{

    protected DataSet PerformerLoginDs(string connectionKey, string UserId, string Password)
    {
        bool PasswordMatchStatus = false;
        string strkey = GetDecryptkey(connectionKey);
        var objCon = new ConnectionString();
        var connect = objCon.ConnectionStringGet(connectionKey);
        var ds = new DataSet();
        using (var scn = new SqlConnection(connect))
        {
            SqlCommand command = new SqlCommand("udp_GetPerformerPassword", scn);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@UserID", SqlDbType.NVarChar).Value = UserId;
            scn.Open();
            var adapter = new SqlDataAdapter(command);
            adapter.Fill(ds);
        }

        if (!String.IsNullOrEmpty(Password))
        {
            if (ds.Tables[0].Rows[0]["MessageID"].ToString() == "1")
            {

                BL.UserManagement objblUserManagement = new BL.UserManagement();
                PasswordMatchStatus = objblUserManagement.DoesPasswordMatch(ds.Tables[0].Rows[0]["password"].ToString(), UserId + Password, true, strkey);
                var ds1 = new DataSet();
                var objCon1 = new ConnectionString();
                var connect1 = objCon1.ConnectionStringGet(connectionKey);

                using (var scn = new SqlConnection(connect1))
                {
                    SqlCommand command = new SqlCommand("udp_PerformerLoginMax", scn);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.Add("@UserID", SqlDbType.NVarChar).Value = UserId;
                    command.Parameters.Add("@PasswordMatchStatus", SqlDbType.NVarChar).Value = PasswordMatchStatus;

                    scn.Open();
                    var adapter = new SqlDataAdapter(command);
                    adapter.Fill(ds1);
                }
                return ds1;

            }
            else
            {
                return ds;
            }
        }
        else
        {
            return ds;
        }
    }
    [WebMethod]
    [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    public void UserLogin(string connectionKey, string UserId, string Password)
    {
        var ds = new DataSet();
        ds = PerformerLoginDs(connectionKey, UserId, Password);
        var objConvertDatatableToJson = new ConvertDatatableToJson();
        string jsonString = objConvertDatatableToJson.DataTableToJson(ds.Tables[0]);
        Context.Response.Clear();
        Context.Response.ContentType = "application/json";
        Context.Response.Write(jsonString);
    }
    string GetDecryptkey(string strCountry)
    {
        DL.ConnectionString objConString = new DL.ConnectionString();
        return objConString.DecryptKeyGet(strCountry);

    }

    [WebMethod]
    [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    public void GetBranchDetails(string connectionKey, int LocationAutoId, string BranchCode)
    {
        var objCon = new ConnectionString();
        var connect = objCon.ConnectionStringGet(connectionKey);
        using (var scn = new SqlConnection(connect))
        {
            SqlCommand command;
            command = new SqlCommand("udp_GetBranchDetailAPS", scn);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add(DL.Properties.Resources.LocationAutoId, SqlDbType.Int).Value = LocationAutoId;
            command.Parameters.Add(DL.Properties.Resources.BranchCode, SqlDbType.NVarChar).Value = BranchCode;
          
            scn.Open();
            var adapter = new SqlDataAdapter(command);
            var ds = new DataSet();
            adapter.Fill(ds);
            if (ds != null && ds.Tables[0] != null && ds.Tables[0].Rows.Count > 0)
            {
                var objConvertDatatableToJson = new ConvertDatatableToJson();
                string jsonString = objConvertDatatableToJson.DataTableToJson(ds.Tables[0]);

                Context.Response.Clear();
                Context.Response.ContentType = "application/json";
                Context.Response.Write(jsonString);
            }
            else
            {
                Context.Response.Clear();
                Context.Response.ContentType = "application/json";
                Context.Response.Write("[{'Message':'Invalid Post'}]");
            }
        }
    }

    [WebMethod]
    [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    public void GetEquipmentDetails(string connectionKey, int LocationAutoId, string BranchCode)
    {
        var objCon = new ConnectionString();
        var connect = objCon.ConnectionStringGet(connectionKey);
        using (var scn = new SqlConnection(connect))
        {
            SqlCommand command;
            command = new SqlCommand("udp_GetEquipmentDetailAPS", scn);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add(DL.Properties.Resources.LocationAutoId, SqlDbType.Int).Value = LocationAutoId;
            command.Parameters.Add(DL.Properties.Resources.BranchCode, SqlDbType.NVarChar).Value = BranchCode;

            scn.Open();
            var adapter = new SqlDataAdapter(command);
            var ds = new DataSet();
            adapter.Fill(ds);
            if (ds != null && ds.Tables[0] != null && ds.Tables[0].Rows.Count > 0)
            {
                var objConvertDatatableToJson = new ConvertDatatableToJson();
                string jsonString = objConvertDatatableToJson.DataTableToJson(ds.Tables[0]);

                Context.Response.Clear();
                Context.Response.ContentType = "application/json";
                Context.Response.Write(jsonString);
            }
            else
            {
                Context.Response.Clear();
                Context.Response.ContentType = "application/json";
                Context.Response.Write("[{'Message':'Invalid Post'}]");
            }
        }
    }

    [WebMethod]
    [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    public void UpdateInstalledQty(string connectionKey, int LocationAutoId, string BranchCode,int MaterialAutoId, int Qty)
    {
        var objCon = new ConnectionString();
        var connect = objCon.ConnectionStringGet(connectionKey);
        using (var scn = new SqlConnection(connect))
        {
            SqlCommand command;
            command = new SqlCommand("udp_UdateInstalledQtyAPS", scn);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add(DL.Properties.Resources.LocationAutoId, SqlDbType.Int).Value = LocationAutoId;
            command.Parameters.Add(DL.Properties.Resources.BranchCode, SqlDbType.NVarChar).Value = BranchCode;
            command.Parameters.Add("@MaterialAutoId", SqlDbType.Int).Value = MaterialAutoId;
            command.Parameters.Add(DL.Properties.Resources.Quantity, SqlDbType.Int).Value = Qty;

            scn.Open();
            var adapter = new SqlDataAdapter(command);
            var ds = new DataSet();
            adapter.Fill(ds);
            if (ds != null && ds.Tables[0] != null && ds.Tables[0].Rows.Count > 0)
            {
                var objConvertDatatableToJson = new ConvertDatatableToJson();
                string jsonString = objConvertDatatableToJson.DataTableToJson(ds.Tables[0]);

                Context.Response.Clear();
                Context.Response.ContentType = "application/json";
                Context.Response.Write(jsonString);
            }
            else
            {
                Context.Response.Clear();
                Context.Response.ContentType = "application/json";
                Context.Response.Write("[{'Message':'Invalid Post'}]");
            }
        }
    }




}
