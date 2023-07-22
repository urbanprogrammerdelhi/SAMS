<%@ WebHandler Language="C#" Class="ImageWriter" %>

using System;
using System.Web;
using System.Data;
using System.Configuration;
using System.Data.SqlClient;

public class ImageWriter :IHttpHandler, System.Web.SessionState.IRequiresSessionState
{
    public void ProcessRequest(HttpContext context)
    {
        int id = 0;
        int.TryParse(context.Request.QueryString["id"], out id);
        if (id > 0)
        {
            string constr = ConfigurationManager.ConnectionStrings["dbconnection"].ConnectionString;
            using (SqlConnection con = new SqlConnection(constr))
            {
                string sql = "SELECT Image FROM MaxBupaChecklistImageMaster WHERE ImageAutoId =" + id.ToString();

                //var objAssetMgmt = new BL.Sales();
                //var ds = new DataSet();
                //var dt = new DataTable();
                //ds = objAssetMgmt.GetImageForMax(id.ToString());
                //dt = ds.Tables[0];

                using (SqlDataAdapter sda = new SqlDataAdapter(sql, con))
                {
                   // SqlDataAdapter sda = new SqlDataAdapter();
                      DataTable dt = new DataTable();
                    sda.Fill(dt);
                    byte[] bytes = (byte[])dt.Rows[0]["Image"];
                    context.Response.ContentType = "image/jpeg";
                    context.Response.BinaryWrite(bytes);
                    context.Response.End();
                     }
                }
            }
            //int id = 0;
            //int.TryParse(context.Request.QueryString["id"], out id);
            //if (id > 0)
            //{
            //    //string constr = ConfigurationManager.ConnectionStrings["constr"].ConnectionString;
            //    //using (SqlConnection con = new SqlConnection(constr))
            //    //{
            //    //    string sql = "SELECT Data, ContentType FROM tblFiles WHERE Id =" + id;
            //    //    using (SqlDataAdapter sda = new SqlDataAdapter(sql, con))
            //    //    {
            //    DataTable dt = HttpContext.Current.Session["gvAttendence"] as DataTable;
            //    if (dt != null)
            //    {
            //        //sda.Fill(dt);
            //        var dr = dt.Select("ChecklistId=" + id.ToString());
            //        byte[] bytes = (byte[])dr[0]["ChecklistImage"];
            //        context.Response.ContentType = "image/jpeg";//dt.Rows[0]["ContentType"].ToString();
            //        context.Response.BinaryWrite(bytes);
            //        context.Response.End();
            //    }
            //    // }
            //    //}
            //}
        }

    public bool IsReusable
    {
        get
        {
            return false;
        }
    }
}
