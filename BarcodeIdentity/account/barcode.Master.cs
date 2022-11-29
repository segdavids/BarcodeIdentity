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

namespace BarcodeIdentity.account
{
    public partial class barcode : System.Web.UI.MasterPage
    {
        SqlConnection sc = new SqlConnection(ConfigurationManager.ConnectionStrings["BarcodeAppDB"].ConnectionString);
        public class uploadparams
        {
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public string DOB { get; set; }
            public string Email { get; set; }
            public string NickName { get; set; }
            public string Phone { get; set; }
            public string About { get; set; }

        }
        protected void Page_Load(object sender, EventArgs e)
        {
            featuredmemeber();
        }

        protected void add_member_clk(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            dt.Columns.AddRange(new DataColumn[7] { new DataColumn("FirstName", typeof(string)),
                        new DataColumn("LastName", typeof(string)),
                        new DataColumn("DOB", typeof(string)),
                        new DataColumn("Email", typeof(string)),
                        new DataColumn("NickName", typeof(string)),
                        new DataColumn("Phone", typeof(string)),
                        new DataColumn("About", typeof(string)),
                        //new DataColumn("State", typeof(string)),

                });
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

                                searchParameters.Add(new uploadparams { FirstName = csvTable.Rows[i][0].ToString(), LastName = csvTable.Rows[i][1].ToString(), DOB = (csvTable.Rows[i][2].ToString()), Email = csvTable.Rows[i][3].ToString(), NickName = csvTable.Rows[i][4].ToString(), Phone = csvTable.Rows[i][5].ToString(), About = csvTable.Rows[i][6].ToString() });
                            }
                            foreach (DataRow row in csvTable.Rows) // FOR EACH ROW IN CSV
                            {

                                string firstname = row["FirstName"].ToString(); //FOR EACH COORDINATE
                                string lastname = row["LastName"].ToString(); //FOR EACH COORDINATE
                                string email = row["Email"].ToString();
                                string dob = row["DOB"].ToString();
                                string about = row["About"].ToString();
                                string nickname = row["NickName"].ToString();
                                string phone = row["Phone"].ToString();

                                DateTime created = DateTime.Now;
                                int activated = 1;
                                string update = $"Insert into Users (FirstName,LastName,Email,Phone,NickName,DOB,Active,About, DateCreated) values('{firstname}','{lastname}','{email}','{phone}','{nickname}','{dob}','{activated}','{about}','{created}')";
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
            Repeater1.DataSource = BLL.GetRequest("select top 5 * from Users where Active=1 order by NEWID()");
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
    }
}