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


[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]

public class Ashirbad : System.Web.Services.WebService
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
    public void InsertUserAttendance(string connectionKey, string userId, string employeeNumber,
    string InOutStatus, string DutyDateTime, string latitude, string longitude, string altitude, string employeeImageBase64, int LocationAutoId, string BranchCode)
    {
        byte[] employeeImage = System.Convert.FromBase64String(employeeImageBase64);
        DevicePerformerInOutInsert(connectionKey, userId, employeeNumber,
        InOutStatus, DutyDateTime, latitude, longitude, altitude, employeeImage, LocationAutoId, BranchCode);
    }
    public void DevicePerformerInOutInsert(string connectionKey, string userId, string employeeNumber,
    string InOutStatus, string DutyDateTime, string latitude, string longitude, string altitude, byte[] employeeImage, int LocationAutoId, string ClientCode)
    {
        var objCon = new ConnectionString();
        var connect = objCon.ConnectionStringGet(connectionKey);
        var ds = new DataSet();

        using (var scn = new SqlConnection(connect))
        {
            SqlCommand command;
            command = new SqlCommand("UdpEmpDeviceAttendanceInsertAshirbad", scn);
            command.CommandType = CommandType.StoredProcedure;

            command.Parameters.Add(DL.Properties.Resources.UserId, SqlDbType.NVarChar).Value = userId;

            command.Parameters.Add(DL.Properties.Resources.EmployeeNumber, SqlDbType.NVarChar).Value = employeeNumber;
            command.Parameters.Add(DL.Properties.Resources.Status, SqlDbType.NVarChar).Value = InOutStatus;
            command.Parameters.Add(DL.Properties.Resources.DutyDate, SqlDbType.NVarChar).Value = DL.Common.DateFormat(DutyDateTime);
            command.Parameters.Add(DL.Properties.Resources.Latitude, SqlDbType.NVarChar).Value = latitude;
            command.Parameters.Add(DL.Properties.Resources.Longitude, SqlDbType.NVarChar).Value = longitude;
            command.Parameters.Add(DL.Properties.Resources.Altitude, SqlDbType.NVarChar).Value = altitude;
            command.Parameters.Add(DL.Properties.Resources.LocationAutoId, SqlDbType.Int).Value = LocationAutoId;
            command.Parameters.Add(DL.Properties.Resources.ClientCode, SqlDbType.NVarChar).Value = ClientCode;
            if (employeeImage != null && employeeImage.Length > 0)
            {
                command.Parameters.Add(DL.Properties.Resources.EmployeeImage, SqlDbType.Image).Value = (object)employeeImage;
            }
            else
            {
                command.Parameters.Add(DL.Properties.Resources.EmployeeImage, SqlDbType.Image).Value = DBNull.Value;
            }

            scn.Open();
            var adapter = new SqlDataAdapter(command);
            adapter.Fill(ds);
        }
        var objConvertDatatableToJson = new ConvertDatatableToJson();
        string jsonString = objConvertDatatableToJson.DataTableToJson(ds.Tables[0]);

        Context.Response.Clear();
        Context.Response.ContentType = "application/json";
        Context.Response.Write(jsonString);
    }



}
