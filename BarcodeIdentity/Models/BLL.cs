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
        public Bitmap GenerateQR(string url)
        {
            Bitmap qrCodeImage;
            QRCodeGenerator qrGenerator = new QRCodeGenerator();
            QRCodeData qrCodeData = qrGenerator.CreateQrCode(url, QRCodeGenerator.ECCLevel.Q);
            QRCode qrCode = new QRCode(qrCodeData);
            qrCodeImage = qrCode.GetGraphic(20);
            return qrCodeImage;
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

        //public void GenerateQrcode(string profileurl, string userfullname)
        //{
        //    QRCode qrcode = new QRCode();
        //    qrcode.Data = profileurl;
        //    qrcode.DataMode = QRCodeDataMode.Byte;
        //    qrcode.UOM = UnitOfMeasure.PIXEL;
        //    qrcode.X = 3;
        //    qrcode.LeftMargin = 0;
        //    qrcode.RightMargin = 0;
        //    qrcode.TopMargin = 0;
        //    qrcode.BottomMargin = 0;
        //    qrcode.Resolution = 72;
        //    qrcode.Rotate = Rotate.Rotate0;
        //    qrcode.ImageFormat = ImageFormat.Gif;
        //    qrcode.drawBarcode(userfullname);
        //}
    }
}