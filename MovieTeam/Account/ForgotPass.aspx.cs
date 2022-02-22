using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net.Mail;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MovieTeam.Account
{
    public partial class ForgotPass : System.Web.UI.Page
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
        protected void ForgotPass_Click(object sender, EventArgs e)
        {
            if (TextBox1.Value.Trim() != null)
            {
                if (bllUser.UserSelectByEmail(TextBox1.Value.Trim())==1)
                {
                    SendEmail(TextBox1.Value.Trim());
                }
                else
                {
                    Response.Write("<script>alert('没有此邮箱！');</script>");
                }

            }
        }


        private void SendEmail(String M_To)
        {
            MailAddress address = new MailAddress("314802163@qq.com");
            String MessageTo = M_To;
            String MessageSubject = "测试邮件";
            String StrRandom = GenCode(6);

            //插入验证码
            bllUser.UsersCodeIn(StrRandom, TextBox1.Value.Trim());
            System.Text.StringBuilder strBody = new System.Text.StringBuilder();
            strBody.Append("点击下面链接获得密码，48小时生效！</br>");
            strBody.Append("<a href='http://localhost:7049/Account/CheckCode?Email=" + M_To + "'>点击这里</a></br>");
            strBody.Append("请填写您的验证码，48小时生效！</br>");
            strBody.Append("验证码为：" + StrRandom);
            string MessageBody = strBody.ToString();
            Send(address, MessageTo, MessageSubject, MessageBody);
  
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