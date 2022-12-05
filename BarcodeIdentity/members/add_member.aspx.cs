using BarcodeIdentity.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace BarcodeIdentity.members
{
    public partial class add_member : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                GetState();
                GetCountry();
            }
        }
        public void GetState()
        {
            if (!IsPostBack)
            {
                string query = "select * from State";
                BLL.BindDropDownList(statedll, query, "StateName", "StateId"/*, "Select Status"*/);
            }
        }
        public void GetCountry()
        {
            if (!IsPostBack)
            {
                string query = "select * from Country";
                BLL.BindDropDownList(countrydll, query, "LocationName", "LocationId"/*, "Select Status"*/);
            }
        }
        protected void AddMemmber(object sender, EventArgs e)
        {
            try
            {
                string url = Guid.NewGuid().ToString();
                string password = Guid.NewGuid().ToString();
                string firstname = firstnametxt.Value;
                string lastname = lastnametxt.Value;
                string phone = phonetxt.Value;
                string email = emailtxt.Value;
                string nickname = nicknametxt.Value;
                string country = countrydll.SelectedValue;
                string state = statedll.SelectedValue;
                string active = "1";
                string dob = dobtxt.Value;
                string about = abouttxt.Value;
                //Bitmap bmpp = BLL.GenerateQR(ConfigurationManager.AppSettings["domainurl"] +"/view/"+ url);
                //var imagery = Convert.ToBase64String(BLL.BitmapToBytes(bmpp));
                //qr.Save($"~/qrcodes/{qr}");
                string update = $"Insert into Users (MemberUniqueId,FirstName,LastName,Email,Password,Phone,NickName,CountryId,StateId,DOB,Active,About) values('{url}','{firstname}','{lastname}','{email}','{password}','{phone}','{nickname}','{country}','{state}','{dob}','{active}','{about}')";
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
            catch (Exception ex)
            {
                exceptiondiv.Visible = true;
                exceptiontxt.InnerHtml = ex.Message;
            }
        }
    }
}