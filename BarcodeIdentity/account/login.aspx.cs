using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.EnterpriseServices.CompensatingResourceManager;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BarcodeIdentity
{
    public partial class Default : System.Web.UI.Page
    {
        string ReturnUrl;
        SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["BarcodeAppDB"].ConnectionString);
        protected void Page_Load(object sender, EventArgs e)
        {
            Session["Email"] = null;
            ReturnUrl = Convert.ToString(Request.QueryString["url"]);

            if (ReturnUrl == null)
            {
                if (Session["URLRedirect"] == null)
                {
                    ReturnUrl = "/home/";
                }
                else
                {
                    ReturnUrl = Session["URLRedirect"].ToString();
                    Session["URLRedirect"] = null;
                }
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            try
            {
                //int userId = 0;
                string emailid = emailtxt.Value.Trim();
                string passkey = passwordtxt.Value.Trim();

                DateTime timeofreg = DateTime.Now;

                //CHECK TO CONFIRM THAT USER DOES NOT ALREADY EXIST
                conn.Open();

                SqlCommand authcheck = new SqlCommand("select * from AdminUser where Email=@Email and Password=@password", conn);
                SqlDataReader rd;
                authcheck.Parameters.AddWithValue("@Email", emailid);
                authcheck.Parameters.AddWithValue("@password", passkey);
                rd = authcheck.ExecuteReader();
                int count = 0;
                while (rd.Read())
                {
                    count += 1;
                }
                rd.Close();
                if (count == 0)
                {
                    exceptiondiv.Visible = true;
                    exceptiontxt.InnerHtml = "Login failed: invalid email or password";
                }

                else if (count == 1)
                {
                    rd = authcheck.ExecuteReader();
                    while (rd.Read())
                    {
                        string firstname = rd["FirstName"] == DBNull.Value ? "" : rd["FirstName"].ToString();
                        string lastname = rd["LastName"] == DBNull.Value ? "" : rd["LastName"].ToString();
                        int activationtatus = Convert.ToInt32(rd["Active"]);
                        int userId = Convert.ToInt32(rd["AdminId"]);
                        string fullname = firstname + " " + lastname;
                        DateTime lastlogin = rd["LastLoginDate"] == DBNull.Value ? Convert.ToDateTime("00:00:00") : Convert.ToDateTime(rd["LastLoginDate"]);
                        DateTime date = DateTime.Now; // 
                        if (activationtatus == 1)
                        {
                            SqlCommand updtrec = new SqlCommand("Update AdminUser set LastLoginDate=@lastlogin WHERE email=@email", conn);
                            updtrec.Parameters.AddWithValue("@lastlogin", date);
                            updtrec.Parameters.AddWithValue("@email", emailid);
                            updtrec.ExecuteNonQuery();
                            string activityType = "Successful Login";

                            //Candidate.AuditTrail(activityType, emailid, DateTime.Now);
                            Session["AdminId"] = userId;
                            Session["Email"] = emailid;
                            Session["LastName"] = lastname;
                            Session["LastLogin"] = lastlogin.ToString("dd/MM/yyyy HH:mm");
                            // Session["lastlogin"] = lastlogs;
                            // Task another =  SendMail.Execute(emailid, firstname,"New Login","You just logged in to your NYSC Portal");
                            // ReturnUrl = Convert.ToString(Request.QueryString["url"]);
                            
                            ClientScript.RegisterStartupScript(GetType(), "JavaScript", " setTimeout(function ref() { location.href = '" + ReturnUrl + "'; }, 200);", true);
                            Response.AddHeader("REFRESH", "0;URL=" + ReturnUrl + "");
                            //   Response.Redirect("~/account/Overview/");
                        }
                        else
                        {
                            exceptiondiv.Visible = true;
                            exceptiontxt.InnerHtml = "Login failed: User account is inactive";
                            // alert.InnerHtml = "Failed!" + exception.ToString() + "";
                        }
                    }

                }
            }
            catch (Exception exception)
            {
                exceptiondiv.Visible = true;
                exceptiontxt.InnerHtml = "Login failed:" + exception.ToString() + "";
            }
        }
    }
}