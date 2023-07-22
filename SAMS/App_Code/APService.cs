﻿using System;
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
using System.Net.Mail;
using System.Configuration;

/// <summary>
/// Summary description for APService
/// </summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
// To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
// [System.Web.Script.Services.ScriptService]
public class APService : System.Web.Services.WebService
{

    [WebMethod]
    [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    public void EmployeeLogin(string connectionKey, string EmployeeID, string IMEI, string MobileNo)
    {
        var objCon = new ConnectionString();
        var connect = objCon.ConnectionStringGet(connectionKey);
        using (var scn = new SqlConnection(connect))
        {
            SqlCommand command;
            command = new SqlCommand("UdpEmployeeLoginAP", scn);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add(DL.Properties.Resources.UserId, SqlDbType.NVarChar).Value = EmployeeID;
            command.Parameters.Add(DL.Properties.Resources.IMEI, SqlDbType.NVarChar).Value = IMEI;
            command.Parameters.Add(DL.Properties.Resources.Mobile, SqlDbType.NVarChar).Value = MobileNo;
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
    public void DevicePerformerInOutInsertBase64(string connectionKey, string IMEI, string userId, string AsmtID, string employeeNumber,
    string InOutStatus, string DutyDateTime, string latitude, string longitude, string altitude, string employeeImageBase64, int LocationAutoId, string ClientCode)
    {
        byte[] employeeImage = System.Convert.FromBase64String(employeeImageBase64);
        DevicePerformerInOutInsert(connectionKey, IMEI, userId, AsmtID, employeeNumber,
        InOutStatus, DutyDateTime, latitude, longitude, altitude, employeeImage, LocationAutoId, ClientCode);

    }
    public void DevicePerformerInOutInsert(string connectionKey, string IMEI, string userId, string AsmtID, string employeeNumber,
    string InOutStatus, string DutyDateTime, string latitude, string longitude, string altitude, byte[] employeeImage, int LocationAutoId, string ClientCode)
    {
        var objCon = new ConnectionString();
        var connect = objCon.ConnectionStringGet(connectionKey);
        var ds = new DataSet();

        using (var scn = new SqlConnection(connect))
        {
            SqlCommand command;
            command = new SqlCommand("UdpEmpDeviceAttendanceInsertSAMS", scn);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add(DL.Properties.Resources.IMEI, SqlDbType.NVarChar).Value = IMEI;
            command.Parameters.Add(DL.Properties.Resources.UserId, SqlDbType.NVarChar).Value = userId;
            command.Parameters.Add(DL.Properties.Resources.AsmtId, SqlDbType.NVarChar).Value = AsmtID;
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

    [WebMethod]
    [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    public void GetSiteGeoLocation(string connectionKey, int LocationAutoId)
    {
        var objCon = new ConnectionString();
        var connect = objCon.ConnectionStringGet(connectionKey);
        using (var scn = new SqlConnection(connect))
        {
            SqlCommand command;
            command = new SqlCommand("udp_GetSiteGeoLocation", scn);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add(DL.Properties.Resources.LocationAutoId, SqlDbType.Int).Value = LocationAutoId;
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
    public void InsertSiteGeoLocation(string connectionKey, int LocationAutoId, string ClientCode, string AsmtID, string Latitude, string Longitude)
    {
        var objCon = new ConnectionString();
        var connect = objCon.ConnectionStringGet(connectionKey);
        using (var scn = new SqlConnection(connect))
        {
            SqlCommand command;
            command = new SqlCommand("udp_InsertSiteGeoLocation", scn);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add(DL.Properties.Resources.LocationAutoId, SqlDbType.Int).Value = LocationAutoId;
            command.Parameters.Add(DL.Properties.Resources.ClientCode, SqlDbType.NVarChar).Value = ClientCode;
            command.Parameters.Add(DL.Properties.Resources.AsmtId, SqlDbType.NVarChar).Value = AsmtID;
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
    public void UpdateSiteGeoLocation(string connectionKey, int LocationAutoId, string ClientCode, string AsmtID, string Latitude, string Longitude)
    {
        var objCon = new ConnectionString();
        var connect = objCon.ConnectionStringGet(connectionKey);
        using (var scn = new SqlConnection(connect))
        {
            SqlCommand command;
            command = new SqlCommand("udp_UpdateSiteGeoLocation", scn);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add(DL.Properties.Resources.LocationAutoId, SqlDbType.Int).Value = LocationAutoId;
            command.Parameters.Add(DL.Properties.Resources.ClientCode, SqlDbType.NVarChar).Value = ClientCode;
            command.Parameters.Add(DL.Properties.Resources.AsmtId, SqlDbType.NVarChar).Value = AsmtID;
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
    public void GetSiteChecklist(string connectionKey, int LocationAutoId)
    {
        var objCon = new ConnectionString();
        var connect = objCon.ConnectionStringGet(connectionKey);
        using (var scn = new SqlConnection(connect))
        {
            SqlCommand command;
            command = new SqlCommand("udp_GetSiteChecklist", scn);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add(DL.Properties.Resources.LocationAutoId, SqlDbType.Int).Value = LocationAutoId;
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
    public void InsertSiteChecklist(string connectionKey, string Json)
    {
        var objCon = new ConnectionString();
        var connect = objCon.ConnectionStringGet(connectionKey);

        using (var scn = new SqlConnection(connect))
        {
            ChecklistName ss = JsonConvert.DeserializeObject<ChecklistName>(Json);
            SqlCommand command;
            //  SqlDataAdapter adapter = null;
            scn.Open();

            foreach (var obj in ss.Checklist)
            {
                command = new SqlCommand("udp_InsertSiteChecklist", scn);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add(DL.Properties.Resources.UserId, SqlDbType.NVarChar).Value = obj.UserId;
                command.Parameters.Add(DL.Properties.Resources.AssetServiceTypeAutoId, SqlDbType.NVarChar).Value = obj.AssetServiceTypeAutoId;
                command.Parameters.Add(DL.Properties.Resources.AssetCheckListAutoId, SqlDbType.NVarChar).Value = obj.AssetchecklistDetailAutoID;
                command.Parameters.Add(DL.Properties.Resources.Status, SqlDbType.NVarChar).Value = obj.Status;
                command.Parameters.Add(DL.Properties.Resources.MessageTo, SqlDbType.NVarChar).Value = obj.Text;
                command.Parameters.Add(DL.Properties.Resources.Branch, SqlDbType.NVarChar).Value = obj.Branch;
                command.Parameters.Add(DL.Properties.Resources.PFRegion, SqlDbType.NVarChar).Value = obj.Zone;
                command.Parameters.Add(DL.Properties.Resources.ClientCode, SqlDbType.NVarChar).Value = obj.ClientCode;
                command.Parameters.Add(DL.Properties.Resources.AsmtId, SqlDbType.NVarChar).Value = obj.AsmtID;
                command.Parameters.Add(DL.Properties.Resources.LocationAutoId, SqlDbType.NVarChar).Value = obj.LocationAutoID;
                command.ExecuteNonQuery();
                //adapter = new SqlDataAdapter(command);
            }
            scn.Close();

            Context.Response.Clear();
            Context.Response.ContentType = "application/json";
            Context.Response.Write("[{'Message':'Record Saved Successfully !!'}]");


        }
    }

    public class ChecklistName
    {
        public List<ChecklistItem> Checklist;
    }
    public class ChecklistItem
    {
        public string UserId;
        public string AssetServiceTypeAutoId;
        public string AssetchecklistDetailAutoID;
        public string Status;
        public string Text;
        public string Branch;
        public string Zone;
        public string ClientCode;
        public string AsmtID;
        public string LocationAutoID;
    }

    [WebMethod]
    [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    public void InsertSpecialUpdate(string connectionKey, string Json)
    {
        var objCon = new ConnectionString();
        var connect = objCon.ConnectionStringGet(connectionKey);

        using (var scn = new SqlConnection(connect))
        {
            SpecialUpdateName ss = JsonConvert.DeserializeObject<SpecialUpdateName>(Json);
            SqlCommand command;
            //  SqlDataAdapter adapter = null;
            scn.Open();

            foreach (var obj in ss.SpecialUpdate)
            {
                command = new SqlCommand("udp_InsertSpecialUpdate", scn);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add(DL.Properties.Resources.UserId, SqlDbType.NVarChar).Value = obj.UserId;
                command.Parameters.Add(DL.Properties.Resources.MessageTo, SqlDbType.NVarChar).Value = obj.Text;
                command.Parameters.Add(DL.Properties.Resources.Branch, SqlDbType.NVarChar).Value = obj.Branch;
                command.Parameters.Add(DL.Properties.Resources.PFRegion, SqlDbType.NVarChar).Value = obj.Zone;
                command.Parameters.Add(DL.Properties.Resources.ClientCode, SqlDbType.NVarChar).Value = obj.ClientCode;
                command.Parameters.Add(DL.Properties.Resources.AsmtId, SqlDbType.NVarChar).Value = obj.AsmtID;
                command.Parameters.Add(DL.Properties.Resources.LocationAutoId, SqlDbType.NVarChar).Value = obj.LocationAutoID;
                byte[] AuditImage = System.Convert.FromBase64String(obj.image);
                if (AuditImage != null && AuditImage.Length > 0)
                {
                    command.Parameters.Add(DL.Properties.Resources.Image, SqlDbType.Image).Value = (object)AuditImage;
                }
                else
                {
                    command.Parameters.Add(DL.Properties.Resources.Image, SqlDbType.Image).Value = DBNull.Value;
                }
                command.ExecuteNonQuery();
                //adapter = new SqlDataAdapter(command);
            }
            scn.Close();

            Context.Response.Clear();
            Context.Response.ContentType = "application/json";
            Context.Response.Write("[{'Message':'Record Saved Successfully !!'}]");


        }
    }

    public class SpecialUpdateName
    {
        public List<SpecialUpdateItem> SpecialUpdate;
    }
    public class SpecialUpdateItem
    {
        public string UserId;
        public string image;
        public string Text;
        public string Branch;
        public string Zone;
        public string ClientCode;
        public string AsmtID;
        public string LocationAutoID;
    }

    [WebMethod]
    [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    public void GetCluster(string connectionKey)
    {
        var objCon = new ConnectionString();
        var connect = objCon.ConnectionStringGet(connectionKey);
        using (var scn = new SqlConnection(connect))
        {
            SqlCommand command;
            command = new SqlCommand("udp_GetCluster", scn);
            command.CommandType = CommandType.StoredProcedure;
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
    public void ClusterAttendance(string connectionKey, string IMEI, string userId, string AsmtID, string employeeNumber,
    string InOutStatus, string DutyDateTime, string latitude, string longitude, string altitude, string employeeImageBase64, int LocationAutoId, string ClientCode, string Cluster)
    {
        byte[] employeeImage = System.Convert.FromBase64String(employeeImageBase64);
        ClusterAttendanceBase64(connectionKey, IMEI, userId, AsmtID, employeeNumber,
        InOutStatus, DutyDateTime, latitude, longitude, altitude, employeeImage, LocationAutoId, ClientCode, Cluster);

    }
    public void ClusterAttendanceBase64(string connectionKey, string IMEI, string userId, string AsmtID, string employeeNumber,
    string InOutStatus, string DutyDateTime, string latitude, string longitude, string altitude, byte[] employeeImage, int LocationAutoId, string ClientCode, string Cluster)
    {
        var objCon = new ConnectionString();
        var connect = objCon.ConnectionStringGet(connectionKey);
        var ds = new DataSet();

        using (var scn = new SqlConnection(connect))
        {
            SqlCommand command;
            command = new SqlCommand("UdpEmpDeviceAttendanceInsertSAMSWithCluster", scn);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add(DL.Properties.Resources.IMEI, SqlDbType.NVarChar).Value = IMEI;
            command.Parameters.Add(DL.Properties.Resources.UserId, SqlDbType.NVarChar).Value = userId;
            command.Parameters.Add(DL.Properties.Resources.AsmtId, SqlDbType.NVarChar).Value = AsmtID;
            command.Parameters.Add(DL.Properties.Resources.EmployeeNumber, SqlDbType.NVarChar).Value = employeeNumber;
            command.Parameters.Add(DL.Properties.Resources.Status, SqlDbType.NVarChar).Value = InOutStatus;
            command.Parameters.Add(DL.Properties.Resources.DutyDate, SqlDbType.NVarChar).Value = DL.Common.DateFormat(DutyDateTime);
            command.Parameters.Add(DL.Properties.Resources.Latitude, SqlDbType.NVarChar).Value = latitude;
            command.Parameters.Add(DL.Properties.Resources.Longitude, SqlDbType.NVarChar).Value = longitude;
            command.Parameters.Add(DL.Properties.Resources.Altitude, SqlDbType.NVarChar).Value = altitude;
            command.Parameters.Add(DL.Properties.Resources.LocationAutoId, SqlDbType.Int).Value = LocationAutoId;
            command.Parameters.Add(DL.Properties.Resources.ClientCode, SqlDbType.NVarChar).Value = ClientCode;
            command.Parameters.Add(DL.Properties.Resources.Name, SqlDbType.NVarChar).Value = Cluster;
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
    public void VerifyCompanyCode(string connectionKey, string CompanyCode)
    {
        var objCon = new ConnectionString();
        var connect = objCon.ConnectionStringGet(connectionKey);
        using (var scn = new SqlConnection(connect))
        {
            SqlCommand command;
            command = new SqlCommand("udp_VerifyCompanyCode", scn);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add(DL.Properties.Resources.Company, SqlDbType.NVarChar).Value = CompanyCode;
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
    public void EmployeeLoginWithCompanyCode(string connectionKey, string EmployeeID, string CompanyCode)
    {
        var objCon = new ConnectionString();
        var connect = objCon.ConnectionStringGet(connectionKey);
        using (var scn = new SqlConnection(connect))
        {
            SqlCommand command;
            command = new SqlCommand("UdpEmployeeLoginSAMSWithCompany", scn);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add(DL.Properties.Resources.UserId, SqlDbType.NVarChar).Value = EmployeeID;
            command.Parameters.Add(DL.Properties.Resources.Company, SqlDbType.NVarChar).Value = CompanyCode;
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
    public void GeoAttendance(string connectionKey, string IMEI, string userId, string AsmtID, string employeeNumber,
    string InOutStatus, string DutyDateTime, string latitude, string longitude, string altitude, string employeeImageBase64, int LocationAutoId, string ClientCode, string Cluster, string LocationName)
    {
        byte[] employeeImage = System.Convert.FromBase64String(employeeImageBase64);
        GeoAttendanceBase64(connectionKey, IMEI, userId, AsmtID, employeeNumber,
        InOutStatus, DutyDateTime, latitude, longitude, altitude, employeeImage, LocationAutoId, ClientCode, Cluster, LocationName);

    }
    public void GeoAttendanceBase64(string connectionKey, string IMEI, string userId, string AsmtID, string employeeNumber,
    string InOutStatus, string DutyDateTime, string latitude, string longitude, string altitude, byte[] employeeImage, int LocationAutoId, string ClientCode, string Cluster, string LocationName)
    {
        var objCon = new ConnectionString();
        var connect = objCon.ConnectionStringGet(connectionKey);
        var ds = new DataSet();

        using (var scn = new SqlConnection(connect))
        {
            SqlCommand command;
            command = new SqlCommand("UdpEmpDeviceAttendanceInsertSAMSWithLocationName", scn);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add(DL.Properties.Resources.IMEI, SqlDbType.NVarChar).Value = IMEI;
            command.Parameters.Add(DL.Properties.Resources.UserId, SqlDbType.NVarChar).Value = userId;
            command.Parameters.Add(DL.Properties.Resources.AsmtId, SqlDbType.NVarChar).Value = AsmtID;
            command.Parameters.Add(DL.Properties.Resources.EmployeeNumber, SqlDbType.NVarChar).Value = employeeNumber;
            command.Parameters.Add(DL.Properties.Resources.Status, SqlDbType.NVarChar).Value = InOutStatus;
            command.Parameters.Add(DL.Properties.Resources.DutyDate, SqlDbType.NVarChar).Value = DL.Common.DateFormat(DutyDateTime);
            command.Parameters.Add(DL.Properties.Resources.Latitude, SqlDbType.NVarChar).Value = latitude;
            command.Parameters.Add(DL.Properties.Resources.Longitude, SqlDbType.NVarChar).Value = longitude;
            command.Parameters.Add(DL.Properties.Resources.Altitude, SqlDbType.NVarChar).Value = altitude;
            command.Parameters.Add(DL.Properties.Resources.LocationAutoId, SqlDbType.Int).Value = LocationAutoId;
            command.Parameters.Add(DL.Properties.Resources.ClientCode, SqlDbType.NVarChar).Value = ClientCode;
            command.Parameters.Add(DL.Properties.Resources.Name, SqlDbType.NVarChar).Value = Cluster;
            command.Parameters.Add(DL.Properties.Resources.Location, SqlDbType.NVarChar).Value = LocationName;
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
    public void GetDailyAttendanceHughesNewHOMayank()
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["dbconnection"].ToString());
        con.Open();
        SqlCommand command;
        command = new SqlCommand("udp_GetEmployeeHughesAttendanceCovid19", con);
        command.CommandType = CommandType.StoredProcedure;
        SqlDataAdapter da = new SqlDataAdapter();
        da.SelectCommand = command;
        DataSet ds = new DataSet();
        da.Fill(ds);
        //return ds;
        DataTable dt = new DataTable();
        dt = ds.Tables[0];
        dt.TableName = "GridView_Data_HO";
        using (XLWorkbook wb = new XLWorkbook())
        {
            //Add the DataTable as Excel Worksheet.
            wb.Worksheets.Add(dt);
            using (MemoryStream memoryStream = new MemoryStream())
            {
                //Save the Excel Workbook to MemoryStream.
                wb.SaveAs(memoryStream);

                //Convert MemoryStream to Byte array.
                byte[] bytes = memoryStream.ToArray();
                memoryStream.Close();

                //Send Email with Excel attachment.
                using (MailMessage mm = new MailMessage("v19softech@gmail.com", "mayank.mca1988@gmail.com"))
                {
                    mm.Subject = "Hughes-Daily Attendance-COVID-19";
                    mm.Body = "Hello Sir/Mam , <br/><br/> Please find the attached Hughes Daily Attendance Report-COVID-19";

                    //Add Byte array as Attachment.
                    mm.Attachments.Add(new Attachment(new MemoryStream(bytes), "Hughes-DailyAttendance-COVID-19.xlsx"));
                    mm.IsBodyHtml = true;
                    SmtpClient smtp = new SmtpClient();
                    smtp.Host = "smtp.gmail.com";
                    smtp.EnableSsl = true;
                    System.Net.NetworkCredential credentials = new System.Net.NetworkCredential();
                    credentials.UserName = "v19softech@gmail.com";
                    credentials.Password = "Password@V19";
                    smtp.UseDefaultCredentials = true;
                    smtp.Credentials = credentials;
                    smtp.Port = 587;
                    smtp.Send(mm);
                }
            }
        }

    }

    [WebMethod]
    public void GetDailyAttendanceHughesNewHORavin()
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["dbconnection"].ToString());
        con.Open();
        SqlCommand command;
        command = new SqlCommand("udp_GetEmployeeHughesAttendanceCovid19", con);
        command.CommandType = CommandType.StoredProcedure;
        SqlDataAdapter da = new SqlDataAdapter();
        da.SelectCommand = command;
        DataSet ds = new DataSet();
        da.Fill(ds);
        //return ds;
        DataTable dt = new DataTable();
        dt = ds.Tables[0];
        dt.TableName = "GridView_Data_HO";
        using (XLWorkbook wb = new XLWorkbook())
        {
            //Add the DataTable as Excel Worksheet.
            wb.Worksheets.Add(dt);
            using (MemoryStream memoryStream = new MemoryStream())
            {
                //Save the Excel Workbook to MemoryStream.
                wb.SaveAs(memoryStream);

                //Convert MemoryStream to Byte array.
                byte[] bytes = memoryStream.ToArray();
                memoryStream.Close();

                //Send Email with Excel attachment.
                using (MailMessage mm = new MailMessage("v19softech@gmail.com", "ravin.gulia@hughes.in"))
                {
                    mm.Subject = "Hughes-Daily Attendance-COVID-19";
                    mm.Body = "Hello Sir/Mam , <br/><br/> Please find the attached Hughes Daily Attendance Report-COVID-19";

                    //Add Byte array as Attachment.
                    mm.Attachments.Add(new Attachment(new MemoryStream(bytes), "Hughes-DailyAttendance-COVID-19.xlsx"));
                    mm.IsBodyHtml = true;
                    SmtpClient smtp = new SmtpClient();
                    smtp.Host = "smtp.gmail.com";
                    smtp.EnableSsl = true;
                    System.Net.NetworkCredential credentials = new System.Net.NetworkCredential();
                    credentials.UserName = "v19softech@gmail.com";
                    credentials.Password = "Password@V19";
                    smtp.UseDefaultCredentials = true;
                    smtp.Credentials = credentials;
                    smtp.Port = 587;
                    smtp.Send(mm);
                }
            }
        }

    }

    [WebMethod]
    public void GetDailyAttendanceHughesNewHOAlka()
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["dbconnection"].ToString());
        con.Open();
        SqlCommand command;
        command = new SqlCommand("udp_GetEmployeeHughesAttendanceCovid19", con);
        command.CommandType = CommandType.StoredProcedure;
        SqlDataAdapter da = new SqlDataAdapter();
        da.SelectCommand = command;
        DataSet ds = new DataSet();
        da.Fill(ds);
        //return ds;
        DataTable dt = new DataTable();
        dt = ds.Tables[0];
        dt.TableName = "GridView_Data_HO";
        using (XLWorkbook wb = new XLWorkbook())
        {
            //Add the DataTable as Excel Worksheet.
            wb.Worksheets.Add(dt);
            using (MemoryStream memoryStream = new MemoryStream())
            {
                //Save the Excel Workbook to MemoryStream.
                wb.SaveAs(memoryStream);

                //Convert MemoryStream to Byte array.
                byte[] bytes = memoryStream.ToArray();
                memoryStream.Close();

                //Send Email with Excel attachment.
                using (MailMessage mm = new MailMessage("v19softech@gmail.com", "alka.gulati@hughes.in"))
                {
                    mm.Subject = "Hughes-Daily Attendance-COVID-19";
                    mm.Body = "Hello Sir/Mam , <br/><br/> Please find the attached Hughes Daily Attendance Report-COVID-19";

                    //Add Byte array as Attachment.
                    mm.Attachments.Add(new Attachment(new MemoryStream(bytes), "Hughes-DailyAttendance-COVID-19.xlsx"));
                    mm.IsBodyHtml = true;
                    SmtpClient smtp = new SmtpClient();
                    smtp.Host = "smtp.gmail.com";
                    smtp.EnableSsl = true;
                    System.Net.NetworkCredential credentials = new System.Net.NetworkCredential();
                    credentials.UserName = "v19softech@gmail.com";
                    credentials.Password = "Password@V19";
                    smtp.UseDefaultCredentials = true;
                    smtp.Credentials = credentials;
                    smtp.Port = 587;
                    smtp.Send(mm);
                }
            }
        }

    }

    [WebMethod]
    public void GetDailyAttendanceHughesNewHOMidas()
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["dbconnection"].ToString());
        con.Open();
        SqlCommand command;
        command = new SqlCommand("udp_GetEmployeeHughesAttendanceCovid19", con);
        command.CommandType = CommandType.StoredProcedure;
        SqlDataAdapter da = new SqlDataAdapter();
        da.SelectCommand = command;
        DataSet ds = new DataSet();
        da.Fill(ds);
        //return ds;
        DataTable dt = new DataTable();
        dt = ds.Tables[0];
        dt.TableName = "GridView_Data_HO";
        using (XLWorkbook wb = new XLWorkbook())
        {
            //Add the DataTable as Excel Worksheet.
            wb.Worksheets.Add(dt);
            using (MemoryStream memoryStream = new MemoryStream())
            {
                //Save the Excel Workbook to MemoryStream.
                wb.SaveAs(memoryStream);

                //Convert MemoryStream to Byte array.
                byte[] bytes = memoryStream.ToArray();
                memoryStream.Close();

                //Send Email with Excel attachment.
                using (MailMessage mm = new MailMessage("v19softech@gmail.com", "midasadmin@hughes.in"))
                {
                    mm.Subject = "Hughes-Daily Attendance-COVID-19";
                    mm.Body = "Hello Sir/Mam , <br/><br/> Please find the attached Hughes Daily Attendance Report-COVID-19";

                    //Add Byte array as Attachment.
                    mm.Attachments.Add(new Attachment(new MemoryStream(bytes), "Hughes-DailyAttendance-COVID-19.xlsx"));
                    mm.IsBodyHtml = true;
                    SmtpClient smtp = new SmtpClient();
                    smtp.Host = "smtp.gmail.com";
                    smtp.EnableSsl = true;
                    System.Net.NetworkCredential credentials = new System.Net.NetworkCredential();
                    credentials.UserName = "v19softech@gmail.com";
                    credentials.Password = "Password@V19";
                    smtp.UseDefaultCredentials = true;
                    smtp.Credentials = credentials;
                    smtp.Port = 587;
                    smtp.Send(mm);
                }
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
            command = new SqlCommand("UdpGetStandardShiftsSAMS", scn);
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
    public void ShiftWiseAttendance(string connectionKey, string IMEI, string userId, string AsmtID, string employeeNumber,
    string InOutStatus, string DutyDateTime, string latitude, string longitude, string altitude, string employeeImageBase64, int LocationAutoId, string ClientCode, string ShiftCode, string LocationName, string MobileNo)
    {
        byte[] employeeImage = System.Convert.FromBase64String(employeeImageBase64);
        ShiftWiseAttendanceBase64(connectionKey, IMEI, userId, AsmtID, employeeNumber,
        InOutStatus, DutyDateTime, latitude, longitude, altitude, employeeImage, LocationAutoId, ClientCode, ShiftCode, LocationName, MobileNo);

    }
    public void ShiftWiseAttendanceBase64(string connectionKey, string IMEI, string userId, string AsmtID, string employeeNumber,
    string InOutStatus, string DutyDateTime, string latitude, string longitude, string altitude, byte[] employeeImage, int LocationAutoId, string ClientCode, string ShiftCode, string LocationName, string MobileNo)
    {
        var objCon = new ConnectionString();
        var connect = objCon.ConnectionStringGet(connectionKey);
        var ds = new DataSet();

        using (var scn = new SqlConnection(connect))
        {
            SqlCommand command;
            command = new SqlCommand("UdpEmpDeviceAttendanceInsertAPWithShift", scn);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add(DL.Properties.Resources.IMEI, SqlDbType.NVarChar).Value = IMEI;
            command.Parameters.Add(DL.Properties.Resources.UserId, SqlDbType.NVarChar).Value = userId;
            command.Parameters.Add(DL.Properties.Resources.AsmtId, SqlDbType.NVarChar).Value = AsmtID;
            command.Parameters.Add(DL.Properties.Resources.EmployeeNumber, SqlDbType.NVarChar).Value = employeeNumber;
            command.Parameters.Add(DL.Properties.Resources.Status, SqlDbType.NVarChar).Value = InOutStatus;
            command.Parameters.Add(DL.Properties.Resources.DutyDate, SqlDbType.NVarChar).Value = DL.Common.DateFormat(DutyDateTime);
            command.Parameters.Add(DL.Properties.Resources.Latitude, SqlDbType.NVarChar).Value = latitude;
            command.Parameters.Add(DL.Properties.Resources.Longitude, SqlDbType.NVarChar).Value = longitude;
            command.Parameters.Add(DL.Properties.Resources.Altitude, SqlDbType.NVarChar).Value = altitude;
            command.Parameters.Add(DL.Properties.Resources.LocationAutoId, SqlDbType.Int).Value = LocationAutoId;
            command.Parameters.Add(DL.Properties.Resources.ClientCode, SqlDbType.NVarChar).Value = ClientCode;
            command.Parameters.Add(DL.Properties.Resources.Name, SqlDbType.NVarChar).Value = ShiftCode;
            command.Parameters.Add(DL.Properties.Resources.LocationAddress, SqlDbType.NVarChar).Value = LocationName;
            if (employeeImage != null && employeeImage.Length > 0)
            {
                command.Parameters.Add(DL.Properties.Resources.EmployeeImage, SqlDbType.Image).Value = (object)employeeImage;
            }
            else
            {
                command.Parameters.Add(DL.Properties.Resources.EmployeeImage, SqlDbType.Image).Value = DBNull.Value;
            }
            command.Parameters.Add(DL.Properties.Resources.Mobile, SqlDbType.NVarChar).Value = MobileNo;
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
    public void VehicleCheckIn(string connectionKey, string userId,
    string DutyDateTime, string latitude, string longitude, string altitude, int LocationAutoId, string Vehicleno,
        string routename, string vehicletype, string vendername, string inkm, string VehicleImageBase64, string LocationName)
    {
        byte[] VehicleImage = System.Convert.FromBase64String(VehicleImageBase64);
        VehicleCheckInbase64(connectionKey, userId, DutyDateTime, latitude, longitude, altitude, LocationAutoId, Vehicleno, routename, vehicletype, vendername, inkm, VehicleImage, LocationName);

    }

    public void VehicleCheckInbase64(string connectionKey, string userId,
    string DutyDateTime, string latitude, string longitude, string altitude, int LocationAutoId, string Vehicleno,
        string routename, string vehicletype, string vendername, string inkm, byte[] VehicleImage, string LocationName)
    {
        var objCon = new ConnectionString();
        var connect = objCon.ConnectionStringGet(connectionKey);
        var ds = new DataSet();

        using (var scn = new SqlConnection(connect))
        {
            SqlCommand command;
            command = new SqlCommand("UdpVehicleCheckIn", scn);
            command.CommandType = CommandType.StoredProcedure;

            command.Parameters.Add(DL.Properties.Resources.UserId, SqlDbType.NVarChar).Value = userId;
            command.Parameters.Add(DL.Properties.Resources.DutyDate, SqlDbType.NVarChar).Value = DL.Common.DateFormat(DutyDateTime);
            command.Parameters.Add(DL.Properties.Resources.Latitude, SqlDbType.NVarChar).Value = latitude;
            command.Parameters.Add(DL.Properties.Resources.Longitude, SqlDbType.NVarChar).Value = longitude;
            command.Parameters.Add(DL.Properties.Resources.Altitude, SqlDbType.NVarChar).Value = altitude;
            command.Parameters.Add(DL.Properties.Resources.LocationAutoId, SqlDbType.Int).Value = LocationAutoId;
            command.Parameters.Add(DL.Properties.Resources.VehicleNumber, SqlDbType.NVarChar).Value = Vehicleno;
            command.Parameters.Add(DL.Properties.Resources.Name, SqlDbType.NVarChar).Value = routename;
            command.Parameters.Add(DL.Properties.Resources.type, SqlDbType.NVarChar).Value = vehicletype;
            command.Parameters.Add(DL.Properties.Resources.UserName, SqlDbType.NVarChar).Value = vendername;
            command.Parameters.Add(DL.Properties.Resources.Value, SqlDbType.NVarChar).Value = inkm;
            command.Parameters.Add(DL.Properties.Resources.LocationDesc, SqlDbType.NVarChar).Value = LocationName;

            if (VehicleImage != null && VehicleImage.Length > 0)
            {
                command.Parameters.Add(DL.Properties.Resources.Image, SqlDbType.Image).Value = (object)VehicleImage;
            }
            else
            {
                command.Parameters.Add(DL.Properties.Resources.Image, SqlDbType.Image).Value = DBNull.Value;
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
    public void VehicleCheckOut(string connectionKey, string userId,
    string DutyDateTime, string latitude, string longitude, string altitude, int LocationAutoId, string Vehicleno,
       string Outkm, string VehicleImageBase64)
    {
        byte[] VehicleImage = System.Convert.FromBase64String(VehicleImageBase64);
        VehicleCheckOutbase64(connectionKey, userId, DutyDateTime, latitude, longitude, altitude, LocationAutoId, Vehicleno, Outkm, VehicleImage);

    }
    public void VehicleCheckOutbase64(string connectionKey, string userId,
    string DutyDateTime, string latitude, string longitude, string altitude, int LocationAutoId, string Vehicleno,
        string Outkm, byte[] VehicleImage)
    {
        var objCon = new ConnectionString();
        var connect = objCon.ConnectionStringGet(connectionKey);
        var ds = new DataSet();

        using (var scn = new SqlConnection(connect))
        {
            SqlCommand command;
            command = new SqlCommand("UdpVehicleCheckOut", scn);
            command.CommandType = CommandType.StoredProcedure;

            command.Parameters.Add(DL.Properties.Resources.UserId, SqlDbType.NVarChar).Value = userId;
            command.Parameters.Add(DL.Properties.Resources.DutyDate, SqlDbType.NVarChar).Value = DL.Common.DateFormat(DutyDateTime);
            command.Parameters.Add(DL.Properties.Resources.Latitude, SqlDbType.NVarChar).Value = latitude;
            command.Parameters.Add(DL.Properties.Resources.Longitude, SqlDbType.NVarChar).Value = longitude;
            command.Parameters.Add(DL.Properties.Resources.Altitude, SqlDbType.NVarChar).Value = altitude;
            command.Parameters.Add(DL.Properties.Resources.LocationAutoId, SqlDbType.Int).Value = LocationAutoId;
            command.Parameters.Add(DL.Properties.Resources.VehicleNumber, SqlDbType.NVarChar).Value = Vehicleno;
            command.Parameters.Add(DL.Properties.Resources.Value, SqlDbType.NVarChar).Value = Outkm;

            if (VehicleImage != null && VehicleImage.Length > 0)
            {
                command.Parameters.Add(DL.Properties.Resources.Image, SqlDbType.Image).Value = (object)VehicleImage;
            }
            else
            {
                command.Parameters.Add(DL.Properties.Resources.Image, SqlDbType.Image).Value = DBNull.Value;
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
    public void GetVehicleNumber(string connectionKey, int LocationAutoId)
    {
        var objCon = new ConnectionString();
        var connect = objCon.ConnectionStringGet(connectionKey);
        using (var scn = new SqlConnection(connect))
        {
            SqlCommand command;
            command = new SqlCommand("udp_GetVehicleNo", scn);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add(DL.Properties.Resources.LocationAutoId, SqlDbType.Int).Value = LocationAutoId;
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
    public void GetVehicleType(string connectionKey, int LocationAutoId)
    {
        var objCon = new ConnectionString();
        var connect = objCon.ConnectionStringGet(connectionKey);
        using (var scn = new SqlConnection(connect))
        {
            SqlCommand command;
            command = new SqlCommand("udp_GetVehicleType", scn);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add(DL.Properties.Resources.LocationAutoId, SqlDbType.Int).Value = LocationAutoId;
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
    public void GetVehicleRoute(string connectionKey, int LocationAutoId)
    {
        var objCon = new ConnectionString();
        var connect = objCon.ConnectionStringGet(connectionKey);
        using (var scn = new SqlConnection(connect))
        {
            SqlCommand command;
            command = new SqlCommand("udp_GetVehicleRoute", scn);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add(DL.Properties.Resources.LocationAutoId, SqlDbType.Int).Value = LocationAutoId;
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
    public void GetVehicleVendor(string connectionKey, int LocationAutoId)
    { //string jsonString="";
        var objCon = new ConnectionString();
        var connect = objCon.ConnectionStringGet(connectionKey);
        using (var scn = new SqlConnection(connect))
        {
            SqlCommand command;
            command = new SqlCommand("udp_GetVehicleVendor", scn);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add(DL.Properties.Resources.LocationAutoId, SqlDbType.Int).Value = LocationAutoId;
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
            //else
            //{
            //    Context.Response.Clear();
            //    Context.Response.ContentType = "application/json";
            //    Context.Response.Write("[{'Message':'Invalid Post'}]");
            //}

            if (ds != null && ds.Tables[1] != null && ds.Tables[1].Rows.Count > 0)
            {
                var objConvertDatatableToJson1 = new ConvertDatatableToJson();
                string jsonString1 = objConvertDatatableToJson1.DataTableToJson(ds.Tables[1]);

                Context.Response.Clear();
                Context.Response.ContentType = "application/json";
                Context.Response.Write(jsonString1);
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
    public void DispatcherCheckIn(string connectionKey, string userId,
    string DutyDateTime, string latitude, string longitude, string altitude, int LocationAutoId, string Vehicleno,
        string routename, string vehicletype, string vendername, string NagNo, string CarateNo, string LargeItemNo, string VehicleImageBase64, string LocationName)
    {
        byte[] VehicleImage = System.Convert.FromBase64String(VehicleImageBase64);
        DispatcherCheckInbase64(connectionKey, userId, DutyDateTime, latitude, longitude, altitude, LocationAutoId, Vehicleno, routename, vehicletype, vendername, NagNo, CarateNo, LargeItemNo, VehicleImage, LocationName);

    }

    public void DispatcherCheckInbase64(string connectionKey, string userId,
    string DutyDateTime, string latitude, string longitude, string altitude, int LocationAutoId, string Vehicleno,
        string routename, string vehicletype, string vendername, string NagNo, string CarateNo, string LargeItemNo, byte[] VehicleImage, string LocationName)
    {
        var objCon = new ConnectionString();
        var connect = objCon.ConnectionStringGet(connectionKey);
        var ds = new DataSet();

        using (var scn = new SqlConnection(connect))
        {
            SqlCommand command;
            command = new SqlCommand("UdpDispatcherCheckIn", scn);
            command.CommandType = CommandType.StoredProcedure;

            command.Parameters.Add(DL.Properties.Resources.UserId, SqlDbType.NVarChar).Value = userId;
            command.Parameters.Add(DL.Properties.Resources.DutyDate, SqlDbType.NVarChar).Value = DL.Common.DateFormat(DutyDateTime);
            command.Parameters.Add(DL.Properties.Resources.Latitude, SqlDbType.NVarChar).Value = latitude;
            command.Parameters.Add(DL.Properties.Resources.Longitude, SqlDbType.NVarChar).Value = longitude;
            command.Parameters.Add(DL.Properties.Resources.Altitude, SqlDbType.NVarChar).Value = altitude;
            command.Parameters.Add(DL.Properties.Resources.LocationAutoId, SqlDbType.Int).Value = LocationAutoId;
            command.Parameters.Add(DL.Properties.Resources.VehicleNumber, SqlDbType.NVarChar).Value = Vehicleno;
            command.Parameters.Add(DL.Properties.Resources.Name, SqlDbType.NVarChar).Value = routename;
            command.Parameters.Add(DL.Properties.Resources.type, SqlDbType.NVarChar).Value = vehicletype;
            command.Parameters.Add(DL.Properties.Resources.UserName, SqlDbType.NVarChar).Value = vendername;
            command.Parameters.Add(DL.Properties.Resources.Value, SqlDbType.NVarChar).Value = NagNo;
            command.Parameters.Add(DL.Properties.Resources.NoOfPerson, SqlDbType.NVarChar).Value = CarateNo;
            command.Parameters.Add(DL.Properties.Resources.NoOfPost, SqlDbType.NVarChar).Value = LargeItemNo;
            command.Parameters.Add(DL.Properties.Resources.LocationDesc, SqlDbType.NVarChar).Value = LocationName;

            if (VehicleImage != null && VehicleImage.Length > 0)
            {
                command.Parameters.Add(DL.Properties.Resources.Image, SqlDbType.Image).Value = (object)VehicleImage;
            }
            else
            {
                command.Parameters.Add(DL.Properties.Resources.Image, SqlDbType.Image).Value = DBNull.Value;
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
    public void DispatcherCheckOut(string connectionKey, string userId,
    string DutyDateTime, string latitude, string longitude, string altitude, int LocationAutoId, string Vehicleno,
      string NagNo, string CarateNo, string LargeItemNo, string VehicleImageBase64)
    {
        byte[] VehicleImage = System.Convert.FromBase64String(VehicleImageBase64);
        DispatcherCheckOutbase64(connectionKey, userId, DutyDateTime, latitude, longitude, altitude, LocationAutoId, Vehicleno, NagNo, CarateNo, LargeItemNo, VehicleImage);

    }
    public void DispatcherCheckOutbase64(string connectionKey, string userId,
    string DutyDateTime, string latitude, string longitude, string altitude, int LocationAutoId, string Vehicleno,
        string NagNo, string CarateNo, string LargeItemNo, byte[] VehicleImage)
    {
        var objCon = new ConnectionString();
        var connect = objCon.ConnectionStringGet(connectionKey);
        var ds = new DataSet();

        using (var scn = new SqlConnection(connect))
        {
            SqlCommand command;
            command = new SqlCommand("UdpDispatcherCheckOut", scn);
            command.CommandType = CommandType.StoredProcedure;

            command.Parameters.Add(DL.Properties.Resources.UserId, SqlDbType.NVarChar).Value = userId;
            command.Parameters.Add(DL.Properties.Resources.DutyDate, SqlDbType.NVarChar).Value = DL.Common.DateFormat(DutyDateTime);
            command.Parameters.Add(DL.Properties.Resources.Latitude, SqlDbType.NVarChar).Value = latitude;
            command.Parameters.Add(DL.Properties.Resources.Longitude, SqlDbType.NVarChar).Value = longitude;
            command.Parameters.Add(DL.Properties.Resources.Altitude, SqlDbType.NVarChar).Value = altitude;
            command.Parameters.Add(DL.Properties.Resources.LocationAutoId, SqlDbType.Int).Value = LocationAutoId;
            command.Parameters.Add(DL.Properties.Resources.VehicleNumber, SqlDbType.NVarChar).Value = Vehicleno;
            command.Parameters.Add(DL.Properties.Resources.Value, SqlDbType.NVarChar).Value = NagNo;
            command.Parameters.Add(DL.Properties.Resources.NoOfPerson, SqlDbType.NVarChar).Value = CarateNo;
            command.Parameters.Add(DL.Properties.Resources.NoOfPost, SqlDbType.NVarChar).Value = LargeItemNo;

            if (VehicleImage != null && VehicleImage.Length > 0)
            {
                command.Parameters.Add(DL.Properties.Resources.Image, SqlDbType.Image).Value = (object)VehicleImage;
            }
            else
            {
                command.Parameters.Add(DL.Properties.Resources.Image, SqlDbType.Image).Value = DBNull.Value;
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
