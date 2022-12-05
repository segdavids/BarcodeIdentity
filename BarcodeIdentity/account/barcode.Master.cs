using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BarcodeIdentity.Models;
using System.Data.SqlClient;
using System.Data;
using System.EnterpriseServices.CompensatingResourceManager;
using System.IO;
using System.Windows.Controls;
using System.Configuration;
using LumenWorks.Framework.IO.Csv;
using Antlr.Runtime.Misc;
using System.Drawing;
using System.Drawing.Imaging;
using System.Web.UI.HtmlControls;
using static System.Net.Mime.MediaTypeNames;
using System.Web.Profile;
using Label = System.Web.UI.WebControls.Label;

namespace BarcodeIdentity.account
{
    public partial class barcode : System.Web.UI.MasterPage
    {
        SqlConnection sc = new SqlConnection(ConfigurationManager.ConnectionStrings["BarcodeAppDB"].ConnectionString);
        public class uploadparams
        {
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public string MemberUniqueId { get; set; }
            public string DOB { get; set; }
            public string Email { get; set; }
            public string NickName { get; set; }
            public string Phone { get; set; }
            public string About { get; set; }

        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Email"] == null || Session["AdminId"] == null)
            {
                Response.Redirect("~/account/login?url=" + Server.UrlEncode(Request.Url.AbsoluteUri));
            }
            else
            {
                featuredmemeber();
            }
            
        }

        protected void add_member_clk(object sender, EventArgs e)
        {
            try
            {
                string url = Guid.NewGuid().ToString();
                string password = Guid.NewGuid().ToString();
                string firstname = firstnametxt.Value;
                string lastname = lastnametxt.Value;
                string phone = phonetxt.Value;
                string email = emailaddtxt.Value;
                string nickname = nicknametxt.Value;
                string active = "1";
                //Bitmap qr = BLL.GenerateQR(url);
                //img.jpg", ImageFormat.Jpeg
                //qr.Save("img.jpg", ImageFormat.Jpeg);
                string update = $"Insert into Users (MemberUniqueId,FirstName,LastName,Email,Password,Phone,NickName,Active) values('{url}','{firstname}','{lastname}','{email}','{password}','{phone}','{nickname}','{active}')";
                string resp = BLL.NonQeryRequest(update);
                switch (resp)
                {
                    case "200":
                        exceptiondiv.Visible = true;
                        exceptiondiv.Attributes.Add("class", "alert alert-success");
                        exceptiontxt.InnerText = "Member profile added successfully";
                        break;
                    case "400":
                        exceptiondiv.Visible = true;
                        exceptiontxt.InnerText = "Member profile could not be added: no changes made";
                        break;
                    default:
                        break;
                }
            }
            catch(Exception ex)
            {
                exceptiondiv.Visible = true;
                exceptiontxt.InnerHtml = ex.ToString();
            }
        }

        protected void upload_member_clk (object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            dt.Columns.AddRange(new DataColumn[8] {
                        new DataColumn("MemberUniqueId", typeof(string)),
                        new DataColumn("FirstName", typeof(string)),
                        new DataColumn("LastName", typeof(string)),
                        new DataColumn("DOB", typeof(string)),
                        new DataColumn("Email", typeof(string)),
                        new DataColumn("NickName", typeof(string)),
                        new DataColumn("Phone", typeof(string)),
                        new DataColumn("About", typeof(string)),
                        //new DataColumn("State", typeof(string)),

                });
            string memberuniqueId = string.Empty;
            try
            {
                int count = 0;
                int failcount = 0;
                if (!FileUpload2.HasFile)
                {
                    Response.Write("<script>alert('No file attached! ');</script>");
                }
                else if (FileUpload2.HasFile)
                {
                    string excelPath = Server.MapPath("~/uploads/") + Path.GetFileName(FileUpload2.PostedFile.FileName);
                    FileUpload2.SaveAs(excelPath);

                    string conString = string.Empty;
                    string extension = Path.GetExtension(FileUpload2.PostedFile.FileName);
                    if (extension != ".csv")
                    {
                        Response.Write("<script>alert('Only .csv files are allowed ');</script>");
                    }
                    else
                    {
                        var csvTable = new DataTable();
                        using (var csvReader = new CsvReader(new StreamReader(System.IO.File.OpenRead(excelPath)), true))
                        {
                            csvTable.Load(csvReader);
                            List<uploadparams> searchParameters = new List<uploadparams>();
                            for (int i = 0; i < csvTable.Rows.Count; i++)
                            {
                                 memberuniqueId = new Guid().ToString();

                                searchParameters.Add(new uploadparams { MemberUniqueId=memberuniqueId, FirstName = csvTable.Rows[i][0].ToString(), LastName = csvTable.Rows[i][1].ToString(), DOB = (csvTable.Rows[i][2].ToString()), Email = csvTable.Rows[i][3].ToString(), NickName = csvTable.Rows[i][4].ToString(), Phone = csvTable.Rows[i][5].ToString(), About = csvTable.Rows[i][6].ToString() });
                            }
                            foreach (DataRow row in csvTable.Rows) // FOR EACH ROW IN CSV
                            {

                                string firstname = row["FirstName"].ToString(); //FOR EACH COORDINATE
                                string lastname = row["LastName"].ToString(); //FOR EACH COORDINATE
                                string password = new Guid().ToString();
                                string email = row["Email"].ToString();
                                string dob = row["DOB"].ToString();
                                string about = row["About"].ToString();
                                string nickname = row["NickName"].ToString();
                                string phone = row["Phone"].ToString();
                                DateTime created = DateTime.Now;
                                int activated = 1;
                                string update = $"Insert into Users (MemberUniqueId,FirstName,LastName,Email,Password,Phone,NickName,DOB,Active,About, DateCreated) values('{memberuniqueId}','{firstname}','{lastname}','{email}','{password}','{phone}','{nickname}','{dob}','{activated}','{about}','{created}')";
                                string resp = BLL.NonQeryRequest(update);
                                switch (resp)
                                {
                                    case "200":
                                        count = count + 1;
                                        break;
                                    case "400":
                                        failcount = failcount + 1;
                                        break;
                                    default:
                                        break;
                                }
                            }
                            exceptiondiv.Visible = true;
                            exceptiondiv.Attributes.Add("class", "alert alert-success");
                            exceptiontxt.InnerHtml = $"Upload complete: <br> {count} Members uploaded successfully. <br>{failcount} failed to upload";

                        }
                    }

                }
            }
            catch (Exception ex)
            {
                exceptiondiv.Visible = true;
                exceptiontxt.InnerHtml = ex.Message.ToString();
            }
        }

        public void featuredmemeber()
        {
            Repeater1.DataSource = BLL.GetRequest("select top 5 * from Users order by NEWID()");
            Repeater1.DataBind();
        }

        protected void download_temp(object sender, EventArgs e)
        {
            string doctype = "Upload_Template.csv";
            string filePath = Server.MapPath(string.Format("~/Template/{0}", doctype));
            Response.ContentType = "text/csv";
            Response.AppendHeader("Content-Disposition", "attachment; filename=" + doctype);
            Response.WriteFile(filePath);
            Response.End();
        }

        protected void Repeater1_ItemCreated(object sender, RepeaterItemEventArgs e)
        {
            bool status;
            if ((e.Item.ItemType == ListItemType.Item) || (e.Item.ItemType == ListItemType.AlternatingItem))
            {
                RepeaterItem item = e.Item;

                //  DataRow dr = (item.DataItem as DataRowView).Row;
                DataRowView drView = e.Item.DataItem as DataRowView;
                if (drView != null)
                {
                     status = Convert.ToBoolean(drView["Active"].ToString());
                    switch (status)
                    {
                        case true:
                            (item.FindControl("activelabel") as Label).Visible = true;
                            break;
                        case false:
                            (item.FindControl("inactivelabel") as Label).Visible = true;
                            break;
                        default:
                            break;
                    }
                }
            }

        }
    }
}