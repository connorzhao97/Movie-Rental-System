using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MovieTeam.Account.Member
{
    public partial class MovieAdd : System.Web.UI.Page
    {
        #region==全局对象==
        BLL.Movie bllMovie;
        Model.Movie modelMovie;

        #endregion
        #region==全局函数==
        /// <summary>
        /// 初始化函数
        /// </summary>
        private void InitGlobal()
        {
            bllMovie = new BLL.Movie("ConnectionString");//ConnectionString是在Web.Config文件中配置的数据库连接字符串
            modelMovie = new Model.Movie();
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
            HttpCookie cookie = Request.Cookies["username"];
            if (cookie != null)
            {
                InitGlobal();
                
            }
            else
            {
                Response.Redirect("~/Account/Login.aspx");
            }
        }

        protected void Button_pic_Click(object sender, EventArgs e)
        {
            
        }

        protected void Button_insert_Click(object sender, EventArgs e)
        {
            if (FileUpload_pic.HasFile)
            {
                string upPath = "/Image/MoviePicture/";  //上传文件路径
                int upLength = 5;        //上传文件大小
                string upFileType = "|image/bmp|image/x-png|image/pjpeg|image/gif|image/png|image/jpeg|";

                string fileContentType = FileUpload_pic.PostedFile.ContentType;    //文件类型

                if (upFileType.IndexOf(fileContentType.ToLower()) > 0)
                {
                    string name = FileUpload_pic.PostedFile.FileName;                  // 客户端文件路径

                    FileInfo file = new FileInfo(name);

                    string fileName = DateTime.Now.ToString("yyyyMMddhhmmssfff") + file.Extension; // 文件名称，当前时间（yyyyMMddhhmmssfff）
                    string webFilePath = Server.MapPath(upPath) + fileName;        // 服务器端文件路径

                    string FilePath = upPath + fileName;   //页面中使用的路径

                    if (!File.Exists(webFilePath))
                    {
                        if ((FileUpload_pic.FileBytes.Length / (1024 * 1024)) > upLength)
                        {
                            ClientScript.RegisterStartupScript(this.GetType(), "upfileOK", "alert('大小超出 " + upLength + " M的限制，请处理后再上传！');", true);
                            return;
                        }

                        try
                        {
                            FileUpload_pic.SaveAs(webFilePath);                                // 使用 SaveAs 方法保存文件




                            //全部一起绑定到数据库
                            TextBox tb = (TextBox)TextBox_name;
                            modelMovie.M_Name = tb.Text.Trim();

                            tb = (TextBox)TextBox_Ename;
                            modelMovie.M_eName = tb.Text.Trim();

                            tb = (TextBox)TextBox_grade;
                            modelMovie.M_Grade = tb.Text.Trim();

                            tb = (TextBox)TextBox_length;
                            modelMovie.M_Length = tb.Text.Trim();

                            tb = (TextBox)TextBox_type;
                            modelMovie.M_Type = tb.Text.Trim();

                            tb = (TextBox)TextBox_area;
                            modelMovie.M_Area = tb.Text.Trim();

                            tb = (TextBox)TextBox_date;
                            modelMovie.M_Date = tb.Text.Trim();

                            tb = (TextBox)TextBox_stock;
                            modelMovie.M_Stock = UInt16.Parse(tb.Text.Trim());

                            modelMovie.M_Picture = "~" + FilePath;

                            tb = (TextBox)TextBox_intro;
                            modelMovie.M_Intro = tb.Text.Trim();

                            string strMsg = bllMovie.MovieInsert(modelMovie);
                            ShowMsg(strMsg);
                            
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

            //TextBox tb = (TextBox)TextBox_name;
            //modelMovie.M_Name = tb.Text.Trim();

            //tb = (TextBox)TextBox_Ename;
            //modelMovie.M_eName = tb.Text.Trim();

            //tb = (TextBox)TextBox_grade;
            //modelMovie.M_Grade = float.Parse(float.Parse(tb.Text.Trim()).ToString("f2"));

            //tb = (TextBox)TextBox_length;
            //modelMovie.M_Length = tb.Text.Trim();

            //tb = (TextBox)TextBox_type;
            //modelMovie.M_Type = tb.Text.Trim();

            //tb = (TextBox)TextBox_area;
            //modelMovie.M_Area = tb.Text.Trim();

            //tb = (TextBox)TextBox_date;
            //modelMovie.M_Date = tb.Text.Trim();

            //tb = (TextBox)TextBox_stock;
            //modelMovie.M_Stock = UInt16.Parse(tb.Text.Trim());

            

            //tb = (TextBox)TextBox_intro;
            //modelMovie.M_Intro = tb.Text.Trim();

            //string strMsg = bllMovie.MovieInsert(modelMovie);
            //ShowMsg(strMsg);
        }
    }
}