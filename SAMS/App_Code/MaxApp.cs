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
/// Summary description for MaxApp
/// </summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
// To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
// [System.Web.Script.Services.ScriptService]
public class MaxApp : System.Web.Services.WebService
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
    public void SupervisorLogin(string connectionKey, string UserId, string Password)
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
    public void GetBranchDetail(string connectionKey,  string BranchQRValue, int LocationAutoID)
    {
        var objCon = new ConnectionString();
        var connect = objCon.ConnectionStringGet(connectionKey);
        using (var scn = new SqlConnection(connect))
        {
            SqlCommand command;
            command = new SqlCommand("UdpGetBranchDetails", scn);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add(DL.Properties.Resources.ClientCode, SqlDbType.NVarChar).Value = BranchQRValue;
            command.Parameters.Add(DL.Properties.Resources.LocationAutoId, SqlDbType.Int).Value = LocationAutoID;

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
    public void InsertSuperVisorAttendance(string connectionKey, string userId,  string employeeNumber,
  string InOutStatus, string DutyDateTime, string latitude, string longitude, string altitude, string employeeImageBase64, int LocationAutoId, string BranchCode)
    {
        byte[] employeeImage = System.Convert.FromBase64String(employeeImageBase64);
        DevicePerformerInOutInsert(connectionKey, userId,  employeeNumber,
        InOutStatus, DutyDateTime, latitude, longitude, altitude, employeeImage, LocationAutoId, BranchCode);
    }
    public void DevicePerformerInOutInsert(string connectionKey,  string userId,  string employeeNumber,
    string InOutStatus, string DutyDateTime, string latitude, string longitude, string altitude, byte[] employeeImage, int LocationAutoId, string ClientCode)
    {
        var objCon = new ConnectionString();
        var connect = objCon.ConnectionStringGet(connectionKey);
        var ds = new DataSet();

        using (var scn = new SqlConnection(connect))
        {
            SqlCommand command;
            command = new SqlCommand("UdpEmpDeviceAttendanceInsertMax", scn);
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

    [WebMethod]
    [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    public void InsertCheckListImage(string connectionKey, string userId, string employeeNumber,
  string DutyDateTime, int ChecklistId, string ChecklistImageBase64, int LocationAutoId, string BranchCode)
    {
        byte[] ChecklistImage = System.Convert.FromBase64String(ChecklistImageBase64);
        InsertCheckListImageBase(connectionKey, userId, employeeNumber,
        DutyDateTime, ChecklistId,  ChecklistImage, LocationAutoId, BranchCode);
    }
    public void InsertCheckListImageBase(string connectionKey, string userId, string employeeNumber,
    string DutyDateTime, int ChecklistId, byte[] employeeImage, int LocationAutoId, string ClientCode)
    {
        var objCon = new ConnectionString();
        var connect = objCon.ConnectionStringGet(connectionKey);
        var ds = new DataSet();

        using (var scn = new SqlConnection(connect))
        {
            SqlCommand command;
            command = new SqlCommand("UdpInsertChecklistImageMax", scn);
            command.CommandType = CommandType.StoredProcedure;

            command.Parameters.Add(DL.Properties.Resources.UserId, SqlDbType.NVarChar).Value = userId;

            command.Parameters.Add(DL.Properties.Resources.EmployeeNumber, SqlDbType.NVarChar).Value = employeeNumber;
           
            command.Parameters.Add(DL.Properties.Resources.DutyDate, SqlDbType.NVarChar).Value = DL.Common.DateFormat(DutyDateTime);
            command.Parameters.Add(DL.Properties.Resources.CheckListAutoId, SqlDbType.Int).Value = ChecklistId;
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
    public void GetChecklistImage(string connectionKey, string userId, string employeeNumber,
  string DutyDateTime, int ChecklistId,  int LocationAutoId, string BranchCode)
    {
        var objCon = new ConnectionString();
        var connect = objCon.ConnectionStringGet(connectionKey);
        using (var scn = new SqlConnection(connect))
        {
            SqlCommand command;
           command = new SqlCommand("UdpViewChecklistImageMax", scn);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add(DL.Properties.Resources.UserId, SqlDbType.NVarChar).Value = userId;
            command.Parameters.Add(DL.Properties.Resources.EmployeeNumber, SqlDbType.NVarChar).Value = employeeNumber;
            command.Parameters.Add(DL.Properties.Resources.DutyDate, SqlDbType.NVarChar).Value = DL.Common.DateFormat(DutyDateTime);
            command.Parameters.Add(DL.Properties.Resources.CheckListAutoId, SqlDbType.Int).Value = ChecklistId;
            command.Parameters.Add(DL.Properties.Resources.LocationAutoId, SqlDbType.Int).Value = LocationAutoId;
            command.Parameters.Add(DL.Properties.Resources.ClientCode, SqlDbType.NVarChar).Value = BranchCode;

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
    public void InsertChecklist(string connectionKey, string Json)
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
                command = new SqlCommand("udp_InsertChecklist", scn);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add(DL.Properties.Resources.UserId, SqlDbType.NVarChar).Value = obj.UserId;
                command.Parameters.Add("@CheckListId", SqlDbType.Int).Value = obj.CheckListId;
                command.Parameters.Add("@Text", SqlDbType.NVarChar).Value = obj.Text;
                command.Parameters.Add("@Remarks", SqlDbType.NVarChar).Value = obj.Remarks ;
                command.Parameters.Add("@SPOCName", SqlDbType.NVarChar).Value = obj.SPOCName;
                command.Parameters.Add("@SPOCNo", SqlDbType.NVarChar).Value = obj.SPOCNo;
                command.Parameters.Add("@EmpID", SqlDbType.NVarChar).Value = obj.EmpID;
                command.Parameters.Add(DL.Properties.Resources.LocationAutoId, SqlDbType.Int).Value = obj.LocationAutoID;
                command.Parameters.Add(DL.Properties.Resources.ClientCode, SqlDbType.NVarChar).Value = obj.BranchCode;
              
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
        public int CheckListId;
        public string Text;
        public string Remarks;
        public string SPOCName;
        public string SPOCNo;
        public string EmpID;
        public int LocationAutoID;
        public string BranchCode;
    }
    [WebMethod]
    [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    public void InsertCheckListImageUpdated(string connectionKey, string userId, string employeeNumber,
 string DutyDateTime, int ChecklistId, string ChecklistImageBase64, int LocationAutoId, string BranchCode)
    {
        byte[] ChecklistImage = System.Convert.FromBase64String(ChecklistImageBase64);
        InsertCheckListImageBaseUpdated(connectionKey, userId, employeeNumber,
        DutyDateTime, ChecklistId, ChecklistImage, LocationAutoId, BranchCode);
    }
    public void InsertCheckListImageBaseUpdated(string connectionKey, string userId, string employeeNumber,
    string DutyDateTime, int ChecklistId, byte[] employeeImage, int LocationAutoId, string ClientCode)
    {
        var objCon = new ConnectionString();
        var connect = objCon.ConnectionStringGet(connectionKey);
        var ds = new DataSet();

        using (var scn = new SqlConnection(connect))
        {
            SqlCommand command;
            command = new SqlCommand("UdpInsertChecklistImageMaxUpdated", scn);
            command.CommandType = CommandType.StoredProcedure;

            command.Parameters.Add(DL.Properties.Resources.UserId, SqlDbType.NVarChar).Value = userId;

            command.Parameters.Add(DL.Properties.Resources.EmployeeNumber, SqlDbType.NVarChar).Value = employeeNumber;

            command.Parameters.Add(DL.Properties.Resources.DutyDate, SqlDbType.NVarChar).Value = DL.Common.DateFormat(DutyDateTime);
            command.Parameters.Add(DL.Properties.Resources.CheckListAutoId, SqlDbType.Int).Value = ChecklistId;
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
    public void GetChecklistImageUpdated(string connectionKey, string userId, string employeeNumber,
 string DutyDateTime, int ChecklistId, int LocationAutoId, string BranchCode)
    {
        var objCon = new ConnectionString();
        var connect = objCon.ConnectionStringGet(connectionKey);
        using (var scn = new SqlConnection(connect))
        {
            SqlCommand command;
            command = new SqlCommand("UdpViewChecklistImageMaxUpdated", scn);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add(DL.Properties.Resources.UserId, SqlDbType.NVarChar).Value = userId;
            command.Parameters.Add(DL.Properties.Resources.EmployeeNumber, SqlDbType.NVarChar).Value = employeeNumber;
            command.Parameters.Add(DL.Properties.Resources.DutyDate, SqlDbType.NVarChar).Value = DL.Common.DateFormat(DutyDateTime);
            command.Parameters.Add(DL.Properties.Resources.CheckListAutoId, SqlDbType.Int).Value = ChecklistId;
            command.Parameters.Add(DL.Properties.Resources.LocationAutoId, SqlDbType.Int).Value = LocationAutoId;
            command.Parameters.Add(DL.Properties.Resources.ClientCode, SqlDbType.NVarChar).Value = BranchCode;

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
    public void InsertChecklistUpdated(string connectionKey, string Json)
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
                command = new SqlCommand("udp_InsertChecklistUpdated", scn);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add(DL.Properties.Resources.UserId, SqlDbType.NVarChar).Value = obj.UserId;
                command.Parameters.Add("@CheckListId", SqlDbType.Int).Value = obj.CheckListId;
                command.Parameters.Add("@Text", SqlDbType.NVarChar).Value = obj.Text;
                command.Parameters.Add("@Remarks", SqlDbType.NVarChar).Value = obj.Remarks;
                command.Parameters.Add("@SPOCName", SqlDbType.NVarChar).Value = obj.SPOCName;
                command.Parameters.Add("@SPOCNo", SqlDbType.NVarChar).Value = obj.SPOCNo;
                command.Parameters.Add("@EmpID", SqlDbType.NVarChar).Value = obj.EmpID;
                command.Parameters.Add(DL.Properties.Resources.LocationAutoId, SqlDbType.Int).Value = obj.LocationAutoID;
                command.Parameters.Add(DL.Properties.Resources.ClientCode, SqlDbType.NVarChar).Value = obj.BranchCode;

                command.ExecuteNonQuery();
                //adapter = new SqlDataAdapter(command);
            }
            scn.Close();

            Context.Response.Clear();
            Context.Response.ContentType = "application/json";
            Context.Response.Write("[{'Message':'Record Saved Successfully !!'}]");


        }
    }
    //public class ChecklistName
    //{
    //    public List<ChecklistItem> Checklist;
    //}
    //public class ChecklistItem
    //{
    //    public string UserId;
    //    public int CheckListId;
    //    public string Text;
    //    public string Remarks;
    //    public string SPOCName;
    //    public string SPOCNo;
    //    public string EmpID;
    //    public int LocationAutoID;
    //    public string BranchCode;
    //}


}
