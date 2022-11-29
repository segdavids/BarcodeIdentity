using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BarcodeIdentity.Models;

namespace BarcodeIdentity.members
{
    public partial class edit_profile : System.Web.UI.Page
    {
        int mid = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            getquerystring();
            if(!IsPostBack)
            {
                getuser();
                GetState();
                GetCountry();
            }
        }

        public void getquerystring() => mid = Convert.ToInt32(!string.IsNullOrEmpty(Request.QueryString["mid"]) ? Request.QueryString["mid"] : 0.ToString());

        public void getuser()
        {
            try
            {
                string getuser = $"select a.*, st.StateName,ct.LocationName from Users a left join State st on a.StateId = st.StateId left join Country ct on a.CountryId=ct.LocationId where MemberId={mid}";
                DataTable dt = BLL.GetRequest(getuser);
                if (dt != null)
                {
                    string firstname = string.IsNullOrEmpty(dt.Rows[0]["FirstName"].ToString()) ? "" : dt.Rows[0]["FirstName"].ToString();
                    string lastname = string.IsNullOrEmpty(dt.Rows[0]["LastName"].ToString()) ? "" : dt.Rows[0]["LastName"].ToString();
                    string email = string.IsNullOrEmpty(dt.Rows[0]["Email"].ToString()) ? "" : dt.Rows[0]["Email"].ToString();
                    firstnametxt.Value = firstname;
                    lastnametxt.Value = lastname;
                    fullnametxt.InnerHtml = firstname + " " + lastname;
                    emailadd.InnerHtml = email;
                    emailtxt.Value = email;
                    phonetxt.Value = string.IsNullOrEmpty(dt.Rows[0]["Phone"].ToString()) ? "" : dt.Rows[0]["Phone"].ToString();
                    dobtxt.Value = string.IsNullOrEmpty(dt.Rows[0]["DOB"].ToString()) ? "" : Convert.ToDateTime(dt.Rows[0]["DOB"].ToString()).ToString("yyyy-MM-dd");
                    nicknametxt.Value = string.IsNullOrEmpty(dt.Rows[0]["NickName"].ToString()) ? "" : dt.Rows[0]["NickName"].ToString();
                    statedll.SelectedValue = string.IsNullOrEmpty(dt.Rows[0]["StateId"].ToString()) ? "1" : dt.Rows[0]["StateId"].ToString();
                    countrydll.SelectedValue = string.IsNullOrEmpty(dt.Rows[0]["CountryId"].ToString()) ? "1" : dt.Rows[0]["CountryId"].ToString();
                    activedll.SelectedValue = dt.Rows[0]["Active"].ToString().ToLower() == "true" ? "1" : "0";
                    urltxt.Value = string.IsNullOrEmpty(dt.Rows[0]["URL"].ToString()) ? "" : dt.Rows[0]["URL"].ToString();
                    abouttxt.Value = string.IsNullOrEmpty(dt.Rows[0]["About"].ToString()) ? "" : dt.Rows[0]["About"].ToString();
                }
            }
            catch(Exception ex)
            {
                exceptiondiv.Visible = true;
                exceptiontxt.InnerHtml = ex.Message;
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

        protected void Update(object sender, EventArgs e)
        {
            try
            {
                string firstname = firstnametxt.Value;
                string lastname = lastnametxt.Value;
                string phone = phonetxt.Value;
                string nickname = nicknametxt.Value;
                string country = countrydll.SelectedValue;
                string state = statedll.SelectedValue;
                string active = activedll.SelectedValue;
                string dob = dobtxt.Value;
                string about = abouttxt.Value;
                string update = $"Update Users set FirstName='{firstname}',LastName='{lastname}',Phone='{phone}',NickName='{nickname}',CountryId='{country}',StateId='{state}',DOB='{dob}',Active='{active}',About='{about}' where MemberId = {mid}";
                string resp = BLL.NonQeryRequest(update);
                switch (resp)
                {
                    case "200":
                        exceptiondiv.Visible = true;
                        exceptiondiv.Attributes.Add("class", "alert alert-success");
                        exceptiontxt.InnerText = "Member profile updated successfully";
                        break;
                    case "400":
                        exceptiondiv.Visible = true;
                        exceptiontxt.InnerText = "Member profile could not be updated: no changes made";
                        break;
                    default:
                        break;
                }

            }
            catch(Exception ex)
            {
                exceptiondiv.Visible = true;
                exceptiontxt.InnerHtml = ex.Message;
            }
        }
    }
}