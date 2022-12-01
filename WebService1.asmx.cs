using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace AJX
{
    /// <summary>
    /// Summary description for WebService1
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    [System.Web.Script.Services.ScriptService]
    public class WebService1 : System.Web.Services.WebService
    {

        [WebMethod]
        public string HelloWorld()
        {
            return "Hello World";
        }

        [WebMethod]
        public string insertUser(string uname, string username, string uemail)
        {
            try
            {
                //Get connection string from web.config file  
                string strcon = ConfigurationManager.ConnectionStrings["dbconnection"].ConnectionString;
                //dbconnection

                SqlConnection conn = new SqlConnection(strcon);

                string sql = "insert into myuser(name, username, email ) values ('" + uname + "','" + username + "','" + uemail + "' )";

                SqlCommand cmd = new SqlCommand(sql, conn);
                conn.Open();
                int status = cmd.ExecuteNonQuery();

                if (status > 0)
                {
                    return "200";
                }
                else
                {
                    return "400";
                }


                // return "Insert Call" + uname + ""+ username+""+ uemail;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return null;
        }

        [WebMethod]
        public string update(string uname, string username, string uemail, string id)
        {
            try
            {
                //Get connection string from web.config file  
                string strcon = ConfigurationManager.ConnectionStrings["dbconnection"].ConnectionString;
                //dbconnection

                SqlConnection conn = new SqlConnection(strcon);

                string sql = "update myuser set name='" + uname + "',username='" + username + "',email='" + uemail + "' where id = '" + id + "'";
                SqlCommand cmd = new SqlCommand(sql, conn);
                conn.Open();
                int status = cmd.ExecuteNonQuery();

                if (status > 0)
                {
                    return "200";
                }
                else
                {
                    return "400";
                }


                // return "Insert Call" + uname + ""+ username+""+ uemail;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return null;
        }


        [WebMethod]
        public string Delete(string id)
        {
            try
            {
                string strcon = ConfigurationManager.ConnectionStrings["dbconnection"].ConnectionString;
                SqlConnection con = new SqlConnection(strcon);
                string sql = "delete from myuser where id= '" + id + "'";
                SqlCommand cmd = new SqlCommand(sql, con);
                con.Open();
                int status = cmd.ExecuteNonQuery();
                if (status > 0)
                {
                    return "success";
                }
                else
                {
                    return "fail";
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return null;
        }

    }
}
