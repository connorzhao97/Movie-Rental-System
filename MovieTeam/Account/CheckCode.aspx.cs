using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MovieTeam.Account
{
    public partial class CheckCode : System.Web.UI.Page
    {
        #region==全局对象==
        BLL.User bllUser;
        Model.User modelUser;
        String U_Name, U_Email;
        #endregion
        #region==全局函数==
        private void InitGlobal()
        {
            bllUser = new BLL.User("ConnectionString");
            modelUser = new Model.User();
        }
        /// <summary>
        /// 显示消息对话框
        /// </summary>
        /// <param name="strMsg"></param>
        private void ShowMsg(string strMsg)
        {
            Response.Write("<script>alert('" + strMsg + "')</script>");
        }
        #endregion
        protected void Page_Load(object sender, EventArgs e)
        {
            if ((U_Name = Request.Params["Name"]) != null)
            {
                InitGlobal();
            }
            else if((U_Email = Request.Params["Email"]) != null)
            {
                InitGlobal();
            }
            else
            {
                Response.Redirect("~/Home/Home.aspx");
            }
            
        }

        protected void Button_check_Click(object sender, EventArgs e)
        {
            if ((U_Name = Request.Params["Name"]) != null && (U_Email = Request.Params["Email"]) == null)
            {
                String code = bllUser.UsersCodeOut(U_Name);
                if (code == TextBox_check.Text)
                {
                    bllUser.UsersConfirmPass(U_Name);
                    Response.Write("<script>alert('验证成功！');window.location='/Account/Login.aspx';</script>");//../Home/Home.aspx
                }
                else
                {
                    ShowMsg("验证码错误！");
                }
            }else if((U_Name = Request.Params["Name"]) == null && (U_Email = Request.Params["Email"]) != null)
            {
                String code = bllUser.UsersCodeOutByE(U_Email);
                {
                    if (code == TextBox_check.Text)
                    {
                        Label2.Visible = true;
                        Label2.Text = Label2.Text + bllUser.Pass(U_Email);
                    }
                    else
                    {
                        ShowMsg("验证码错误！");
                    }
                }
            }
               
        }
    }
}