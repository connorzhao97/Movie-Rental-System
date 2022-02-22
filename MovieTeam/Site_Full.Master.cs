using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MovieTeam
{
    public partial class Site_Full : MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void Unnamed_LoggedOut(object sender, EventArgs e)
        {
            HttpCookie cookie = Response.Cookies["username"];
            if (cookie != null)
            {

                cookie.Expires = DateTime.Now.AddDays(-1);
            }
        }
    }
}