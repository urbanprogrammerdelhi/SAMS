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
using System.Net.Mail;
using System.Configuration;

/// <summary>
/// Summary description for GroupL
/// </summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
// To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
// [System.Web.Script.Services.ScriptService]
public class GroupL : System.Web.Services.WebService
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
            command = new SqlCommand("UdpEmployeeLoginSAMS", scn);
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
    string GetDecryptkey(string strCountry)
    {
        DL.ConnectionString objConString = new DL.ConnectionString();
        return objConString.DecryptKeyGet(strCountry);

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
    public void InsertEmployeeAttendance(string connectionKey, string IMEI, string userId, string AsmtID, string employeeNumber,
    string InOutStatus, string DutyDateTime, string latitude, string longitude, string altitude, string employeeImageBase64, int LocationAutoId, string ClientCode, string ShiftCode, string LocationName)
    {
        byte[] employeeImage = System.Convert.FromBase64String(employeeImageBase64);
        ShiftWiseAttendanceBase64(connectionKey, IMEI, userId, AsmtID, employeeNumber,
        InOutStatus, DutyDateTime, latitude, longitude, altitude, employeeImage, LocationAutoId, ClientCode, ShiftCode, LocationName);

    }
    public void ShiftWiseAttendanceBase64(string connectionKey, string IMEI, string userId, string AsmtID, string employeeNumber,
    string InOutStatus, string DutyDateTime, string latitude, string longitude, string altitude, byte[] employeeImage, int LocationAutoId, string ClientCode, string ShiftCode, string LocationName)
    {
        var objCon = new ConnectionString();
        var connect = objCon.ConnectionStringGet(connectionKey);
        var ds = new DataSet();

        using (var scn = new SqlConnection(connect))
        {
            SqlCommand command;
            command = new SqlCommand("UdpEmpDeviceAttendanceInsertSAMSWithShift", scn);
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
    public void UpdateChecklistStatustoCompleted(string connectionKey, string EmployeeID,string EmployeeName,int ChecklistID, int LocationAutoId, string ClientCode)
    {
        var objCon = new ConnectionString();
        var connect = objCon.ConnectionStringGet(connectionKey);
        using (var scn = new SqlConnection(connect))
        {
            SqlCommand command;
            command = new SqlCommand("udp_UpdateChecklistStatusGroupL", scn);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add(DL.Properties.Resources.EmployeeId, SqlDbType.NVarChar).Value = EmployeeID;
            command.Parameters.Add(DL.Properties.Resources.EmployeeNameCondition, SqlDbType.NVarChar).Value = EmployeeName;
            command.Parameters.Add(DL.Properties.Resources.CheckListAutoId, SqlDbType.Int).Value = ChecklistID;
            command.Parameters.Add(DL.Properties.Resources.LocationAutoId, SqlDbType.Int).Value = LocationAutoId;
            command.Parameters.Add(DL.Properties.Resources.ClientCode, SqlDbType.NVarChar).Value = ClientCode;
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
    public void InsertCheckListImage(string connectionKey, string EmployeeID, string EmployeeName,
 int ChecklistId, string ChecklistImageBase64, int LocationAutoId, string ClientCode, string DutyDateTime)
    {
        byte[] ChecklistImage = System.Convert.FromBase64String(ChecklistImageBase64);
        InsertCheckListImageBaseUpdated(connectionKey, EmployeeID, EmployeeName,
       ChecklistId, ChecklistImage, LocationAutoId, ClientCode, DutyDateTime);
    }
    public void InsertCheckListImageBaseUpdated(string connectionKey, string EmployeeID, string EmployeeName,
 int ChecklistId, byte[] employeeImage, int LocationAutoId, string ClientCode,string DutyDateTime)
    {
        var objCon = new ConnectionString();
        var connect = objCon.ConnectionStringGet(connectionKey);
        var ds = new DataSet();

        using (var scn = new SqlConnection(connect))
        {
            SqlCommand command;
            command = new SqlCommand("UdpInsertChecklistImageGroupL", scn);
            command.CommandType = CommandType.StoredProcedure;

            command.Parameters.Add(DL.Properties.Resources.EmployeeId, SqlDbType.NVarChar).Value = EmployeeID;

            command.Parameters.Add(DL.Properties.Resources.EmployeeNumber, SqlDbType.NVarChar).Value = EmployeeName;

            command.Parameters.Add(DL.Properties.Resources.CheckListAutoId, SqlDbType.Int).Value = ChecklistId;
            command.Parameters.Add(DL.Properties.Resources.LocationAutoId, SqlDbType.Int).Value = LocationAutoId;
            command.Parameters.Add(DL.Properties.Resources.ClientCode, SqlDbType.NVarChar).Value = ClientCode;
            command.Parameters.Add(DL.Properties.Resources.DutyDate, SqlDbType.NVarChar).Value = DL.Common.DateFormat(DutyDateTime);
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

            //string ID = ds.Tables[0].Rows[0]["ImageAutoid"].ToString();
            //string filePath = $"C:\\Projects\\MaxNewPDF\\WebApplication6\\WebApplication6\\Image\\{ID}.png";
            //File.WriteAllBytes(Server.MapPath(filePath), employeeImage);          

        }
        var objConvertDatatableToJson = new ConvertDatatableToJson();
        string jsonString = objConvertDatatableToJson.DataTableToJson(ds.Tables[0]);

        Context.Response.Clear();
        Context.Response.ContentType = "application/json";
        Context.Response.Write(jsonString);
    }

    [WebMethod]
    [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    public void GetChecklistImageUpdated(string connectionKey, string EmployeeID, 
 string DutyDateTime, int ChecklistId, int LocationAutoId, string ClientCode)
    {
        var objCon = new ConnectionString();
        var connect = objCon.ConnectionStringGet(connectionKey);
        using (var scn = new SqlConnection(connect))
        {
            SqlCommand command;
            command = new SqlCommand("UdpViewChecklistImageGroupL", scn);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add(DL.Properties.Resources.EmployeeId, SqlDbType.NVarChar).Value = EmployeeID;
         
            command.Parameters.Add(DL.Properties.Resources.DutyDate, SqlDbType.NVarChar).Value = DL.Common.DateFormat(DutyDateTime);
            command.Parameters.Add(DL.Properties.Resources.CheckListAutoId, SqlDbType.Int).Value = ChecklistId;
            command.Parameters.Add(DL.Properties.Resources.LocationAutoId, SqlDbType.Int).Value = LocationAutoId;
            command.Parameters.Add(DL.Properties.Resources.ClientCode, SqlDbType.NVarChar).Value = ClientCode;

            scn.Open();
            var adapter = new SqlDataAdapter(command);
            var ds = new DataSet();
            adapter.Fill(ds);

            if (ds != null && ds.Tables[0] != null && ds.Tables[0].Rows.Count > 0)
            {
                DataTable dt = new DataTable();
                dt = ds.Tables[0];
                DataColumn dc = new DataColumn("ImageBase64String", typeof(System.String));
                ds.Tables[0].Columns.Add(dc);
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    if (ds.Tables[0].Rows[i]["image"].ToString() != "")
                    {
                        ds.Tables[0].Rows[i]["ImageBase64String"] = Convert.ToBase64String(((byte[])((object)ds.Tables[0].Rows[i]["image"])));
                    }
                    else
                    {
                        ds.Tables[0].Rows[i]["ImageBase64String"] = string.Empty;
                    }
                }

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
    public void InsertRegisterEntry(string connectionKey, string EmployeeID, string EmployeeName,
 string VisitorImageBase64, int LocationAutoId, string ClientCode, string VisitorName,string Purpose, string Mobile)
    {
        byte[] ChecklistImage = System.Convert.FromBase64String(VisitorImageBase64);
        InsertRegisterEntryUpdated(connectionKey, EmployeeID, EmployeeName,
        ChecklistImage, LocationAutoId, ClientCode, VisitorName, Purpose, Mobile);
    }
    public void InsertRegisterEntryUpdated(string connectionKey, string EmployeeID, string EmployeeName,
 byte[] employeeImage, int LocationAutoId, string ClientCode, string VisitorName, string Purpose, string Mobile)
    {
        var objCon = new ConnectionString();
        var connect = objCon.ConnectionStringGet(connectionKey);
        var ds = new DataSet();

        using (var scn = new SqlConnection(connect))
        {
            SqlCommand command;
            command = new SqlCommand("UdpInsertRegisterDataGroupL", scn);
            command.CommandType = CommandType.StoredProcedure;

            command.Parameters.Add(DL.Properties.Resources.EmployeeId, SqlDbType.NVarChar).Value = EmployeeID;

            command.Parameters.Add(DL.Properties.Resources.EmployeeNumber, SqlDbType.NVarChar).Value = EmployeeName;

        
            command.Parameters.Add(DL.Properties.Resources.LocationAutoId, SqlDbType.Int).Value = LocationAutoId;
            command.Parameters.Add(DL.Properties.Resources.ClientCode, SqlDbType.NVarChar).Value = ClientCode;
            command.Parameters.Add("@VisitorName", SqlDbType.NVarChar).Value = VisitorName;
            command.Parameters.Add("@Purpose", SqlDbType.NVarChar).Value = Purpose;
            command.Parameters.Add("@Mobile", SqlDbType.NVarChar).Value = Mobile;
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

            //string ID = ds.Tables[0].Rows[0]["ImageAutoid"].ToString();
            //string filePath = $"C:\\Projects\\MaxNewPDF\\WebApplication6\\WebApplication6\\Image\\{ID}.png";
            //File.WriteAllBytes(Server.MapPath(filePath), employeeImage);          

        }
        var objConvertDatatableToJson = new ConvertDatatableToJson();
        string jsonString = objConvertDatatableToJson.DataTableToJson(ds.Tables[0]);

        Context.Response.Clear();
        Context.Response.ContentType = "application/json";
        Context.Response.Write(jsonString);
    }

    [WebMethod]
    [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    public void GetTaskCompletionStatus(string connectionKey,  string EmployeeID, string ClientCode)
    {
        var objCon = new ConnectionString();
        var connect = objCon.ConnectionStringGet(connectionKey);
        using (var scn = new SqlConnection(connect))
        {
            SqlCommand command;
            command = new SqlCommand("udp_GetTaskCompletionStatus", scn);
            command.CommandType = CommandType.StoredProcedure;
          
            command.Parameters.Add(DL.Properties.Resources.EmployeeId, SqlDbType.NVarChar).Value = EmployeeID;
            command.Parameters.Add(DL.Properties.Resources.ClientCode, SqlDbType.NVarChar).Value = ClientCode;
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
