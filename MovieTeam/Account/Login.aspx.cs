using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Web.Security;
using Model;

namespace MovieTeam.Account
{
    public partial class Login : System.Web.UI.Page
    {
        #region==全局对象==
        BLL.User bllUser;
        Model.User modelUser;
        #endregion
        private void InitGlobal()
        {
            bllUser = new BLL.User("ConnectionString");
            modelUser = new Model.User();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            InitGlobal();
        }

        protected void TextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        protected void Login_Click(object sender, EventArgs e)
        {
            if (TextBox1.Value != null && TextBox2.Value != null)
            {
                modelUser.U_Name = TextBox1.Value.Trim();
                modelUser.U_Pass = TextBox2.Value.Trim();

                string rs = bllUser.UsersLogin(modelUser);
                if (rs == "1")    //登录成功
                {
                    DataRow LoginUser = (bllUser.UsersSelectByName(TextBox1.Value.Trim())).Rows[0];                   
                    HttpCookie logincookie = new HttpCookie("username");//设置cookies名称
                    logincookie.Values.Add("U_Name", modelUser.U_Name);
                    logincookie.Values.Add("U_Pass", modelUser.U_Pass);
                    logincookie.Values.Add("U_Level", LoginUser["U_Level"].ToString());
                    logincookie.Values.Add("U_Id", LoginUser["U_Id"].ToString());
                    logincookie.Values.Add("Ch_Id", LoginUser["Ch_Id"].ToString());
                    if (RememberMe.Checked)
                    {
                        logincookie.Expires = DateTime.Now.AddMonths(1);
                    }
                    else
                    {
                        logincookie.Expires = DateTime.Now.AddHours(1); //这个是设置cookies有效时间，你可以随意设置
                    }
                    Response.Cookies.Add(logincookie);//保存
                    FormsAuthentication.SetAuthCookie(modelUser.U_Name, true);
                    Response.Write("<script>alert('登录成功！');window.location='../Home/Home.aspx';</script>");//../Home/Home.aspx
                }
                else Response.Write("<script>alert('用户名/密码错误！');window.location='Login.aspx';</script>"); //用户名已被注册*/
            }
        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            Response.Write("<script>window.location='ForgotPass.aspx';</script>");
        }

        protected void LinkButton2_Click(object sender, EventArgs e)
        {
            Response.Write("<script>window.location='ChangePass.aspx';</script>");
        }

        protected void Button4_Click(object sender, EventArgs e)
        {
            Response.Write("<script>window.location='Register.aspx';</script>");
        }
    }
}