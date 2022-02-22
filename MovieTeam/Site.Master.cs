using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MovieTeam
{
    public partial class SiteMaster : MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            HttpCookie cookie = Request.Cookies["username"];
            if (cookie != null)
            {
                
            }
            else
            {

            }
            String url = Request.RawUrl;
            //Response.Write("<script>alert('" + url + "')</script>");
            //"/Movie/MovieList"
            if (url.Contains("/Movie/MovieList"))
            {
                searchinputbox.Visible = true;
            }
        }

        protected void Unnamed_LoggedOut(object sender, EventArgs e)
        {
            HttpCookie cookie = Response.Cookies["username"];
            if (cookie != null)
            {
                cookie.Expires = DateTime.Now.AddDays(-1);
            }
        }

        protected void Unnamed5_TextChanged(object sender, EventArgs e)
        {
            TextBox textBox = sender as TextBox;
            Response.Redirect("~/Movie/Search.aspx?query=" + textBox.Text);

        }
    }
}