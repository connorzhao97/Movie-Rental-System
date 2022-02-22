using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MovieTeam.Account.Member
{
	public partial class UserInformation : System.Web.UI.Page
	{
        #region==全局对象==
        BLL.User bllUser;
        Model.User modelUser;

        string U_Name = "Text1";
        #endregion
        #region==全局函数==
        /// <summary>
        /// 初始化函数
        /// </summary>
        private void InitGlobal()
        {
            bllUser = new BLL.User("ConnectionString");//ConnectionString是在Web.Config文件中配置的数据库连接字符串
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


        /// <summary>
        /// 将表数据绑定到文本框控件上
        /// </summary>
        private void BindToTb()
        {
            Image_p.ImageUrl = bllUser.UsersSelectByName(U_Name).Rows[0][9].ToString();
            TextBox_nname.Text=bllUser.UsersSelectByName(U_Name).Rows[0][6].ToString();
            TextBox_gender.Text = bllUser.UsersSelectByName(U_Name).Rows[0][7].ToString();
            TextBox_email.Text = bllUser.UsersSelectByName(U_Name).Rows[0][3].ToString();
            TextBox_address.Text = bllUser.UsersSelectByName(U_Name).Rows[0][8].ToString();
        }
        #endregion
        protected void Page_Load(object sender, EventArgs e)
		{
            HttpCookie cookie = Request.Cookies["username"];
            if (cookie != null)
            {
                U_Name = cookie["U_Name"];
                InitGlobal();
                if (!IsPostBack)
                {
                    BindToTb();

                }
            }
            else
            {
                Response.Redirect("~/Account/Login.aspx");
            }
        }


        protected void Button_update_Click(object sender, EventArgs e)
        {
            if (FileUpload_p.HasFile)
            {
                string upPath = "/Image/UserPictures/";  //上传文件路径
                int upLength = 5;        //上传文件大小
                string upFileType = "|image/bmp|image/x-png|image/pjpeg|image/gif|image/png|image/jpeg|";

                string fileContentType = FileUpload_p.PostedFile.ContentType;    //文件类型

                if (upFileType.IndexOf(fileContentType.ToLower()) > 0)
                {
                    string name = FileUpload_p.PostedFile.FileName;                  // 客户端文件路径

                    FileInfo file = new FileInfo(name);

                    string fileName = DateTime.Now.ToString("yyyyMMddhhmmssfff") + file.Extension; // 文件名称，当前时间（yyyyMMddhhmmssfff）
                    string webFilePath = Server.MapPath(upPath) + fileName;        // 服务器端文件路径

                    string FilePath = upPath + fileName;   //页面中使用的路径

                    if (!File.Exists(webFilePath))
                    {
                        if ((FileUpload_p.FileBytes.Length / (1024 * 1024)) > upLength)
                        {
                            ClientScript.RegisterStartupScript(this.GetType(), "upfileOK", "alert('大小超出 " + upLength + " M的限制，请处理后再上传！');", true);
                            return;
                        }

                        try
                        {
                            FileUpload_p.SaveAs(webFilePath);                                // 使用 SaveAs 方法保存文件




                            //全部一起绑定到数据库
                            modelUser.U_Name = U_Name;

                            TextBox tb = (TextBox)TextBox_nname;
                            modelUser.U_Nickname = tb.Text.Trim();


                            tb = (TextBox)TextBox_gender;
                            modelUser.U_Gender = tb.Text.Trim();

                            tb = (TextBox)TextBox_email;
                            modelUser.U_Email = tb.Text.Trim();

                            tb = (TextBox)TextBox_address;
                            modelUser.U_Address = tb.Text.Trim();

                            modelUser.U_Picture = "~" + FilePath;

                            string strMsg = bllUser.pUserInformationUpdate(modelUser);
                            ShowMsg(strMsg);

                            BindToTb();
                        }
                        catch (Exception ex)
                        {
                            ClientScript.RegisterStartupScript(this.GetType(), "upfileOK", "alert('提示：文件上传失败" + ex.Message + "');", true);
                        }
                    }
                    else
                    {
                        ClientScript.RegisterStartupScript(this.GetType(), "upfileOK", "alert('提示：文件已经存在，请重命名后上传');", true);
                    }
                }
                else
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "upfileOK", "alert('提示：文件类型不符" + fileContentType + "');", true);
                }
            }
            else
            {
                modelUser.U_Name = U_Name;

                TextBox tb = (TextBox)TextBox_nname;
                modelUser.U_Nickname = tb.Text.Trim();

                
                tb = (TextBox)TextBox_gender;
                modelUser.U_Gender = tb.Text.Trim();

                tb = (TextBox)TextBox_email;
                modelUser.U_Email = tb.Text.Trim();

                tb = (TextBox)TextBox_address;
                modelUser.U_Address = tb.Text.Trim();

                string strMsg = bllUser.UserInformationUpdate(modelUser);
                ShowMsg(strMsg);
            }
            
        }
    }
}