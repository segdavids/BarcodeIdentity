using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Drawing.Imaging;
using System.Web.Routing;
using QRCoder;
using System.Drawing;
using System.Web.UI.WebControls;
using System.IO;
//using OnBarcode.Barcode;

namespace BarcodeIdentity.Models
{
    public class BLL
    {

        public static DataTable GetRequest(string Query)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["BarcodeAppDB"].ConnectionString))
                {

                    using (SqlDataAdapter sda = new SqlDataAdapter(Query, conn))
                    {
                        DataTable dt = new DataTable();
                        sda.Fill(dt);
                        return dt;

                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static string NonQeryRequest(string Query)
        {
            string Statcode = string.Empty;
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["BarcodeAppDB"].ConnectionString);
            conn.Open();
            SqlCommand cmd = new SqlCommand(Query, conn);
            int result = cmd.ExecuteNonQuery();
            if (result > 0)
                Statcode = "200";
            else
                Statcode = "400";
            conn.Close();

            return Statcode;
        }
        public static Bitmap GenerateQR(string url)
        {
            Bitmap qrCodeImage;
            QRCodeGenerator qrGenerator = new QRCodeGenerator();
            QRCodeData qrCodeData = qrGenerator.CreateQrCode(url, QRCodeGenerator.ECCLevel.Q);
            QRCode qrCode = new QRCode(qrCodeData);
            qrCodeImage = qrCode.GetGraphic(20);
            return qrCodeImage;
        }

        public static Byte[] BitmapToBytes(Bitmap img)
        {
            using (MemoryStream stream = new MemoryStream())
            {
                img.Save(stream, System.Drawing.Imaging.ImageFormat.Png);
                return stream.ToArray();
            }
        }

        public static void BindDropDownList(DropDownList ddl, string query, string text, string value /*string defaultText*/)
        {
            string conString = ConfigurationManager.ConnectionStrings["BarcodeAppDB"].ConnectionString;
            SqlCommand cmd = new SqlCommand(query);
            using (SqlConnection con = new SqlConnection(conString))
            {
                using (SqlDataAdapter sda = new SqlDataAdapter())
                {
                    cmd.Connection = con;
                    con.Open();
                    ddl.DataSource = cmd.ExecuteReader();
                    ddl.DataTextField = text;
                    ddl.DataValueField = value;
                    ddl.DataBind();
                    con.Close();
                }
            }
            //    ddl.Items.Insert(0, new ListItem(defaultText, "0"));
        }

        public static string ChangePassword(string newpassword, string passkey, string emailid)
        {
            string returnvalue = string.Empty;
            try
            {
                SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["BarcodeAppDB"].ConnectionString);
                //string encryptedpk = encryptpass(passkey);
                //string newencryptedpk = encryptpass(newpassword);
                DateTime timeofreg = DateTime.Now;

                //CHECK TO CONFIRM THAT USER DOES NOT ALREADY EXIST
                conn.Open();

                SqlCommand authcheck = new SqlCommand("select * from AdminUser where AdminId=@adminId and Password=@password", conn);
                SqlDataReader rd;
                authcheck.Parameters.AddWithValue("@adminId", emailid);
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
                    returnvalue = "404";
                    //return returnvalue;
                }
                else if (count == 1)
                {
                    rd = authcheck.ExecuteReader();
                    while (rd.Read())
                    {
                        DateTime date = DateTime.Now; // 
                        SqlCommand updtrec = new SqlCommand("Update AdminUser set Password=@newpasskey, LastUpdatedDate = @datetimenow WHERE AdminId=@adminId", conn);
                        updtrec.Parameters.AddWithValue("@newpasskey", newpassword);
                        updtrec.Parameters.AddWithValue("@datetimenow", date);
                        updtrec.Parameters.AddWithValue("@adminId", emailid);
                        updtrec.ExecuteNonQuery();
                        string activityType = "Password Changed";
                        returnvalue = "200";
                    }

                }
            }
            catch (Exception exception)
            {
                returnvalue = "Failed!" + exception.ToString() + "";
                //return returnvalue; 
            }
            return returnvalue;
        }
    }
}