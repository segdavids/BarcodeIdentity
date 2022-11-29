using BarcodeIdentity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Web;
using System.Web.UI;
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
                string update = $"Insert into Users (FirstName,LastName,Email,Phone,NickName,CountryId,StateId,DOB,Active,About) values('{firstname}','{lastname}','{email}','{phone}','{nickname}','{country}','{state}','{dob}','{active}','{about}')";
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