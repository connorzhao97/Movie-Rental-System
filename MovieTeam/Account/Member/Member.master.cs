using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MovieTeam.Account.Member
{
    public partial class Member : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.Cookies["username"] != null)
            {
                String Ch_Id = Request.Cookies["username"]["Ch_Id"];
                if (!Ch_Id.Equals("3"))
                {
                    MovieManagement.Visible = false;
                    CharactorManagement.Visible = false;
                    CommentManagement.Visible = false;
                }
            }
        }
    }
}