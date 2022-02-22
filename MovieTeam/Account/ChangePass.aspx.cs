using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MovieTeam.Account
{
    public partial class ChangePass : System.Web.UI.Page
    {
        BLL.User bllUser;
        Model.User Umodel;

        private void InitGlobal()
        {
            bllUser = new BLL.User("ConnectionString");
            Umodel = new Model.User();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            InitGlobal();

            HttpCookie cookie = Request.Cookies["username"];
            if (cookie == null)
            {
                Response.Write("<script>alert('请先登录用户');window.location='/Account/Login.aspx';</script>");
            }
            else
            {
                TextBox1.Value = cookie["U_Name"];
                TextBox4.Value = cookie["U_Pass"];
            }
        }

        protected void ChangePass_Click(object sender, EventArgs e)
        {
            HttpCookie cookie = Request.Cookies["username"];
            Umodel.U_Name = cookie["U_Name"];
            if (TextBox2.Value.Trim() != null && TextBox3.Value.Trim() != null)
            {
                Umodel.U_Pass = TextBox3.Value.Trim();
                bllUser.UserPassUpdate(Umodel);
            }
            Response.Write("<script>alert('修改成功!');window.location='../Home/Home.aspx';</script>");
        }
    }
}