using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using BarcodeIdentity.Models;

namespace BarcodeIdentity.home
{
    public partial class dashboard : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            getcounts();
        }

        public void getcounts()
        {
            try
            {
                string select = "select count(distinct MemberId) as qrids, sum(case when Active=1 then 1 else 0 end) as active,sum(case when Active=0 then 1 else 0 end) as inactive FROM Users";
                DataTable dt = BLL.GetRequest(select);
                Repeater1.DataSource = dt;
                Repeater1.DataBind();
            }
            catch(Exception e)
            {
                exceptiondiv.Visible = true;
                exceptiontxt.InnerHtml = e.Message.ToString();
            }
        }
    }
}