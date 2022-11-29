using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BarcodeIdentity.Models;

namespace BarcodeIdentity.users
{
    public partial class members : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                fetchusers();
            }    

        }

        protected void Download_profile(object sender, EventArgs e)
        {
            try
            {

            }
            catch (Exception ex)
            {
                exceptiondiv.Visible = true;
                exceptiontxt.InnerHtml = ex.Message;
            }
        }

        public void fetchusers()
        {
            try
            {
                string fetch = $"select * from Users";
                DataTable dt = BLL.GetRequest(fetch);
                Repeater1.DataSource = dt;
                Repeater1.DataBind();
            }
            catch(Exception e)
            {
                exceptiondiv.Visible = true;
                exceptiontxt.InnerHtml=e.Message;
            }
        }

        protected void activate_user(object sender, EventArgs e)
        {
            try
            {
                RepeaterItem item = (sender as LinkButton).Parent as RepeaterItem;
                int MemberId = int.Parse((item.FindControl("entrytxt") as Label).Text);
                string activate = $"update Users set Active='true' where MemberId={MemberId}";
                string resp = BLL.NonQeryRequest(activate);
                switch(resp)
                {
                    case "200":
                        fetchusers();
                        exceptiondiv.Visible = true;
                        exceptiondiv.Attributes.Add("class", "alert alert-success");
                        exceptiontxt.InnerText = "Member Activated successfully";
                        break;
                    case "400":
                        fetchusers();
                        exceptiondiv.Visible = true;
                        exceptiontxt.InnerText = "Member account could not be activated: no changes made";
                        break;
                    default:
                        fetchusers();
                        break;
                }
            }
            catch (Exception ex)
            {
                exceptiondiv.Visible = true;
                exceptiontxt.InnerHtml = ex.Message;
            }
        }

        protected void deactivate_user(object sender, EventArgs e)
        {
            try
            {
                RepeaterItem item = (sender as LinkButton).Parent as RepeaterItem;
                int MemberId = int.Parse((item.FindControl("entrytxt") as Label).Text);
                string activate = $"update Users set Active='false' where MemberId={MemberId}";
                string resp = BLL.NonQeryRequest(activate);
                switch (resp)
                {
                    case "200":
                        fetchusers();
                        exceptiondiv.Visible = true;
                        exceptiondiv.Attributes.Add("class", "alert alert-success");
                        exceptiontxt.InnerText = "Member deactivated successfully";
                        break;
                    case "400":
                        fetchusers();
                        exceptiondiv.Visible = true;
                        exceptiontxt.InnerText = "Member account could not be deactivated: no changes made";
                        break;
                    default :
                        fetchusers();
                        break;
                }
            }
            catch (Exception ex)
            {
                exceptiondiv.Visible = true;
                exceptiontxt.InnerHtml = ex.Message;
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
                    status = Convert.ToBoolean(drView["Active"]);
                    switch(status)
                    {
                        case true:
                            item.FindControl("deactivtaeuser").Visible = true;
                            break;
                        case false:
                            item.FindControl("activateuser").Visible = true;
                            break;
                        default:
                            break;

                    }                   

                }
            }
        }

        protected void add_member_clk(object sender, EventArgs e)
        {

        }

        protected void filteractive(object sender, EventArgs e)
        {
            try
            {
                switch(activechkbx.Checked)
                {
                    case true :

                        break;
                }
            }
            catch (Exception ex)
            {
                exceptiondiv.Visible = true;
                exceptiontxt.InnerHtml = ex.Message;
            }
        }

        protected void filterinactive(object sender, EventArgs e)
        {
            string query;
            try
            {
                // int conditioncount = 0;
                query = $"select * from Users where Email is not null";
               
                string condition1 = string.Empty;
                string condition2 = string.Empty;
                condition1 +=  activechkbx.Checked == true ? string.Format("'{0}',", "true") : string.Format("'{0}',", "false");
                condition2 += inactivechkbx.Checked == true ? string.Format("'{0}',", "false") : string.Format("'{0}',", "true");
                if (!string.IsNullOrEmpty(condition1))
                {
                    condition1 = string.Format(" AND Active IN ({0})", condition1.Substring(0, condition1.Length - 1));
                }
                if (!string.IsNullOrEmpty(condition2))
                {
                    condition2 = string.Format(" OR Active IN ({0})", condition2.Substring(0, condition2.Length - 1));
                }           
                string finalquery = query + condition1 + condition2 ;
                Repeater1.DataSource = BLL.GetRequest(finalquery);
                Repeater1.DataBind();
            }
            catch (Exception ex)
            {
                exceptiondiv.Visible = true;
                exceptiontxt.InnerHtml = ex.Message;
            }
        }

        
    }
}