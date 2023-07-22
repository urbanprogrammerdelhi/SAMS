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

public class APSAttendance : System.Web.Services.WebService
{
    [WebMethod]
    [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    public void EmployeeLogin(string connectionKey, string EmployeeID)
    {
        var objCon = new ConnectionString();
        var connect = objCon.ConnectionStringGet(connectionKey);
        using (var scn = new SqlConnection(connect))
        {
            SqlCommand command;
            command = new SqlCommand("UdpEmployeeLoginAPSATT", scn);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add(DL.Properties.Resources.UserId, SqlDbType.NVarChar).Value = EmployeeID;

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
    public void GetGeoMppedSiteAddress(string connectionKey, int LocationAutoId, string Latitude, string Longitude)
    {
        var objCon = new ConnectionString();
        var connect = objCon.ConnectionStringGet(connectionKey);
        using (var scn = new SqlConnection(connect))
        {
            SqlCommand command;
            command = new SqlCommand("udp_GetGeoMappedSites", scn);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add(DL.Properties.Resources.LocationAutoId, SqlDbType.Int).Value = LocationAutoId;
            command.Parameters.Add(DL.Properties.Resources.Latitude, SqlDbType.NVarChar).Value = Latitude;
            command.Parameters.Add(DL.Properties.Resources.Longitude, SqlDbType.NVarChar).Value = Longitude;
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
    public void EmployeeAttendanceInsert(string connectionKey,  string employeeNumber,
   string InOutStatus, string DutyDateTime, string latitude, string longitude, string employeeImageBase64, int LocationAutoId, string ClientCode,string ShiftCode, string LocationName)
    {
        byte[] employeeImage = System.Convert.FromBase64String(employeeImageBase64);
        EmployeeAttendanceInsertDB(connectionKey, employeeNumber,
        InOutStatus, DutyDateTime, latitude, longitude, employeeImage, LocationAutoId, ClientCode, ShiftCode, LocationName);

    }
    public void EmployeeAttendanceInsertDB(string connectionKey, string employeeNumber,
    string InOutStatus, string DutyDateTime, string latitude, string longitude,  byte[] employeeImage, int LocationAutoId, string ClientCode,string ShiftCode,string LocationName)
    {
        var objCon = new ConnectionString();
        var connect = objCon.ConnectionStringGet(connectionKey);
        var ds = new DataSet();

        using (var scn = new SqlConnection(connect))
        {
            SqlCommand command;
            command = new SqlCommand("UdpEmpDeviceAttendanceInsertAPS", scn);
            command.CommandType = CommandType.StoredProcedure;
          
            command.Parameters.Add(DL.Properties.Resources.EmployeeNumber, SqlDbType.NVarChar).Value = employeeNumber;
            command.Parameters.Add(DL.Properties.Resources.Status, SqlDbType.NVarChar).Value = InOutStatus;
            command.Parameters.Add(DL.Properties.Resources.DutyDate, SqlDbType.NVarChar).Value = DL.Common.DateFormat(DutyDateTime);
            command.Parameters.Add(DL.Properties.Resources.Latitude, SqlDbType.NVarChar).Value = latitude;
            command.Parameters.Add(DL.Properties.Resources.Longitude, SqlDbType.NVarChar).Value = longitude;
            command.Parameters.Add(DL.Properties.Resources.LocationAutoId, SqlDbType.Int).Value = LocationAutoId;
            command.Parameters.Add(DL.Properties.Resources.ClientCode, SqlDbType.NVarChar).Value = ClientCode;
            command.Parameters.Add(DL.Properties.Resources.ShiftCode, SqlDbType.NVarChar).Value = ShiftCode;
            command.Parameters.Add(DL.Properties.Resources.LocationCode, SqlDbType.NVarChar).Value = LocationName;
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

    [WebMethod]
    [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    public void InsertReliever(string connectionKey, string EmpNo, string EmpName, string EmpDesignation,string BranchCode)
    {
        var objCon = new ConnectionString();
        var connect = objCon.ConnectionStringGet(connectionKey);
        using (var scn = new SqlConnection(connect))
        {
            SqlCommand command;
            command = new SqlCommand("udp_InsertReliever", scn);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add(DL.Properties.Resources.EmpNo, SqlDbType.NVarChar).Value = EmpNo;
            command.Parameters.Add(DL.Properties.Resources.Name, SqlDbType.NVarChar).Value = EmpName;
            command.Parameters.Add(DL.Properties.Resources.Designation, SqlDbType.NVarChar).Value = EmpDesignation;
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
    public void GetStandardShifts(string connectionKey, string EmployeeID)
    {
        var objCon = new ConnectionString();
        var connect = objCon.ConnectionStringGet(connectionKey);
        using (var scn = new SqlConnection(connect))
        {
            SqlCommand command;
            command = new SqlCommand("UdpGetStandardShiftsAPS", scn);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add(DL.Properties.Resources.UserId, SqlDbType.NVarChar).Value = EmployeeID;
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
    public void GetGeoMappedBranch(string connectionKey,  string Latitude, string Longitude)
    {
        var objCon = new ConnectionString();
        var connect = objCon.ConnectionStringGet(connectionKey);
        using (var scn = new SqlConnection(connect))
        {
            SqlCommand command;
            command = new SqlCommand("udp_GetGeoMappedBranch", scn);
            command.CommandType = CommandType.StoredProcedure;
          
            command.Parameters.Add(DL.Properties.Resources.Latitude, SqlDbType.NVarChar).Value = Latitude;
            command.Parameters.Add(DL.Properties.Resources.Longitude, SqlDbType.NVarChar).Value = Longitude;
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
