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
    public partial class view_profile : System.Web.UI.Page
    {
        int memberId;
        protected void Page_Load(object sender, EventArgs e)
        {
            getsuqetrstring();
        }

        public void getsuqetrstring()
        {
            try
            {
                string MemberId = !string.IsNullOrEmpty(Request.QueryString["mid"]) ? Request.QueryString["mid"] : 0.ToString();
                memberId = Convert.ToInt32(MemberId);
               
                if (memberId != 0)
                {
                    //RENDER USER DETAILS
                    string gtusr = $"select a.*, st.StateName,ct.LocationName from Users a left join State st on a.StateId = st.StateId left join Country ct on a.CountryId=ct.LocationId where MemberId={memberId}";
                    DataTable dt = BLL.GetRequest(gtusr);
                    if (dt.Rows.Count>0)
                        Repeater1.DataSource = dt;
                        Repeater1.DataBind();
                    //Button1.Visible = false;
                    //candidateprofilediv.Visible = false;
                }            
            }
            catch(Exception e)
            {
                exceptiondiv.Visible = true;
                exceptiontxt.InnerHtml = e.Message.ToString();
            }
        }


    }
}