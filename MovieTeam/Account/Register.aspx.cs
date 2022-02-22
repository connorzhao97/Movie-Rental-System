using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Net.Mail;
using System.Text.RegularExpressions;

namespace MovieTeam.Account
{
    public partial class Register : System.Web.UI.Page
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
            AddInlineStyle("body { padding:10px; margin:5px 0; }");
            InitGlobal();
        }

        protected void AddInlineStyle(string style)

        {

            System.Web.UI.HtmlControls.HtmlGenericControl node = new HtmlGenericControl("style");

            node.Attributes.Add("type", "text/css");

            node.InnerText = style;

            Page.Header.Controls.Add(node);

        }
        protected void Register_Click(object sender, EventArgs e)
        {
            if (CheckBox1.Checked)
            {
                if (TextBox1.Value != null && TextBox2.Value != null && TextBox3.Value != null)
                {
                    modelUser.U_Name = TextBox1.Value.Trim();
                    modelUser.U_Pass = TextBox2.Value.Trim();
                    modelUser.U_Email = Email.Value.Trim();//插入数据库
                    string rs = bllUser.UsersInsert(modelUser);
                    if (rs == "1")    //数据库没有此用户，添加
                    {
                        SendEmail(modelUser.U_Email);

                        Response.Write("<script>alert('注册成功!点击确定登录账户！');window.location='Login.aspx';</script>");
                    }
                    else Response.Write("<script>alert('用户名已被注册！');window.location='Register.aspx';</script>"); //用户名已被注册*/
                }
            }
            else
            {
                Response.Write("<script>alert('请同意规范和协议！');window.location='Login.aspx';</script>");
            }

        }

        private void SendEmail(String M_To)
        {
            MailAddress address = new MailAddress("314802163@qq.com");
            String MessageTo = M_To;
            String MessageSubject = "测试邮件";
            String StrRandom = GenCode(6);

            //插入验证码
            bllUser.UsersCodeIn(StrRandom, modelUser.U_Name);
            System.Text.StringBuilder strBody = new System.Text.StringBuilder();
            strBody.Append("点击下面链接激活账号，48小时生效，否则重新注册账号，链接只能使用一次，请尽快激活！</br>");
            strBody.Append("<a href='http://localhost:7049/Account/CheckCode?Name=" + modelUser.U_Name + "'>点击这里</a></br>");
            strBody.Append("请填写您的验证码，48小时生效，否则重新注册账号，请尽快激活！</br>");
            strBody.Append("验证码为：" + StrRandom);
            string MessageBody = strBody.ToString();
            if (Send(address, MessageTo, MessageSubject, MessageBody))

            {
                Response.Write("发送邮件成功");
            }
            else
            {
                Response.Write("发送邮件失败");
            }
        }
        /// <summary> 
        /// 发送电子邮件 
        /// </summary> 
        /// <param name="MessageFrom">发件人邮箱地址</param> 
        /// <param name="MessageTo">收件人邮箱地址</param> 
        /// <param name="MessageSubject">邮件主题</param> 
        /// <param name="MessageBody">邮件内容</param> 
        /// <returns></returns> 
        public bool Send(MailAddress MessageFrom, string MessageTo, string MessageSubject, string MessageBody)
        {
            MailMessage message = new MailMessage();
            message.From = MessageFrom;
            message.To.Add(MessageTo); //收件人邮箱地址可以是多个以实现群发 
            message.Subject = MessageSubject;
            message.Body = MessageBody;
            message.IsBodyHtml = true; //是否为html格式 
            message.Priority = MailPriority.High; //发送邮件的优先等级 


            SmtpClient sc = new SmtpClient();
            sc.EnableSsl = true;
            sc.UseDefaultCredentials = false;
            sc.Host = "smtp.qq.com"; //指定发送邮件的服务器地址或IP 
            sc.Port = 25; //指定发送邮件端口 
            sc.Credentials = new System.Net.NetworkCredential("314802163@qq.com", "qntmuzoifezybihc"); //指定登录服务器的用户名和密码(发件人的邮箱登陆密码)


            try
            {
                sc.Send(message); //发送邮件 
            }
            catch (Exception ex)
            {
                return false;
            }
            return true;


        }


        /// <summary>
        /// 产生随机字符串
        /// </summary>
        /// <param name="num">随机出几个字符</param>
        /// <returns>随机出的字符串</returns>
        private string GenCode(int num)
        {
            string str = "0123456789ABCDEFGHiJKLMNOPQRSTUVWXYZ";//图片上随机文字
            char[] chastr = str.ToCharArray();
            string code = "";
            Random rd = new Random();
            int i;
            for (i = 0; i < num; i++)
            {
                code += str.Substring(rd.Next(0, str.Length), 1);
            }
            return code;
        }
    }

}