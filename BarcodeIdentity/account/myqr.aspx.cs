using BarcodeIdentity.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace BarcodeIdentity.account
{
    public partial class myqr : System.Web.UI.Page
    {
        int memberId;
        protected void Page_Load(object sender, EventArgs e)
        {
            SessionCheck();
            getquerystring();
            getadminuserdetails();
        }

        public void SessionCheck()
        {

            if (Session["Email"] == null || Session["AdminId"] == null)
            {
                Response.Redirect("~/account/login?url=" + Server.UrlEncode(Request.Url.AbsoluteUri));
            }

        }
        public void getquerystring() => memberId = Convert.ToInt32(Session["AdminId"].ToString());

        public void getadminuserdetails()
        {
            try
            {
             
                if (memberId != 0)
                {
                    //RENDER USER DETAILS
                    string gtusr = $"select a.* from AdminUser a where AdminId={memberId}";
                    DataTable dt = BLL.GetRequest(gtusr);
                    if (dt.Rows.Count > 0)
                        Repeater1.DataSource = dt;
                        Repeater1.DataBind();

                }
            }
            catch (Exception e)
            {
                exceptiondiv.Visible = true;
                exceptiontxt.InnerHtml = e.Message.ToString();
            }
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
                    string profilename = (drView["LastName"].ToString());
                    Bitmap bmpp = BLL.GenerateQR(ConfigurationManager.AppSettings["domainurl"] + "account/profile/");
                    //var imagery = Convert.ToBase64String(BLL.BitmapToBytes(bmpp));
                    (item.FindControl("image2") as HtmlImage).Src = "data:image/png;base64," + Convert.ToBase64String(BLL.BitmapToBytes(bmpp));
                    (item.FindControl("profilename") as Label).Text = profilename;
                    (item.FindControl("Label1") as Label).Text = profilename;

                }
            }

        }
    }
}