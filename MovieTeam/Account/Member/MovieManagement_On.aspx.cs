using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

using System.IO;

namespace MovieTeam.Account.Member
{
    public partial class MovieManagement_On : System.Web.UI.Page
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
        /// <summary>
        /// 将表数据绑定到GridView控件上
        /// </summary>
        private void BindToGv()
        {
            GridView1.DataSource = bllMovie.MoviesView_On();
            GridView1.DataBind();
        }
        #endregion
        //初始化
        protected void Page_Load(object sender, EventArgs e)
        {
            HttpCookie cookie = Request.Cookies["username"];//初始化函数，使用cookie来验证是否登录
            if (cookie != null)
            {
                InitGlobal();
                if (!IsPostBack)
                {
                    BindToGv();
                }
            }
            else
            {
                Response.Redirect("~/Account/Login.aspx");
            }

        }
        //点击编辑触发事件
        protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
        {
            GridView1.EditIndex = e.NewEditIndex;
            //在点击编辑之前设置按钮不可用
            FileUpload fUpload = (FileUpload)GridView1.Rows[GridView1.EditIndex].Cells[10].FindControl("FileUpload2");
            Button btn = (Button)GridView1.Rows[GridView1.EditIndex].Cells[10].FindControl("Button1");
            btn.Enabled =true;
            fUpload.Enabled = true;
            
        }
        //取消编辑触发事件
        protected void GridView1_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            GridView1.EditIndex = -1;
            BindToGv();
        }
        //保存编辑触发事件
        protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            int nRow = e.RowIndex;
            modelMovie.M_Id = UInt16.Parse(GridView1.Rows[nRow].Cells[0].Text);

            TextBox tb = (TextBox)GridView1.Rows[nRow].Cells[1].Controls[0];
            modelMovie.M_Name = tb.Text.Trim();

            tb = (TextBox)GridView1.Rows[nRow].Cells[2].Controls[0];
            modelMovie.M_Grade = tb.Text.Trim();
            tb = (TextBox)GridView1.Rows[nRow].Cells[3].Controls[0];
            modelMovie.M_Type = tb.Text.Trim();

            tb = (TextBox)GridView1.Rows[nRow].Cells[4].Controls[0];
            modelMovie.M_Area = tb.Text.Trim();

            tb = (TextBox)GridView1.Rows[nRow].Cells[5].Controls[0];
            modelMovie.M_Date = tb.Text.Trim();

            tb = (TextBox)GridView1.Rows[nRow].Cells[6].Controls[0];
            modelMovie.M_Stock = int.Parse(tb.Text.Trim());

            tb = (TextBox)GridView1.Rows[nRow].Cells[7].Controls[0];
            modelMovie.M_Frequency = int.Parse(tb.Text.Trim());

            tb = (TextBox)GridView1.Rows[nRow].Cells[8].Controls[0];
            modelMovie.M_Intro = tb.Text.Trim();

           
            //写入数据库
            string strMsg = bllMovie.MovieUpdate(modelMovie);
            ShowMsg(strMsg);
            
            GridView1.EditIndex = -1;
            BindToGv();

        }
        //页码改变触发事件
        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView1.PageIndex = e.NewPageIndex;
            BindToGv();
        }

        //单击上传触发事件
        protected void UpLoad_Click(object sender, EventArgs e)
        {
            int nRow = GridView1.EditIndex;
            FileUpload fUpload = (FileUpload)GridView1.Rows[nRow].Cells[13].FindControl("FileUpload2");

            if (fUpload.HasFile)
            {
                string upPath = "/Image/MoviePicture/";  //上传文件路径
                int upLength = 5;        //上传文件大小
                string upFileType = "|image/bmp|image/x-png|image/pjpeg|image/gif|image/png|image/jpeg|";

                string fileContentType = fUpload.PostedFile.ContentType;    //文件类型

                if (upFileType.IndexOf(fileContentType.ToLower()) > 0)
                {
                    string name = fUpload.PostedFile.FileName;                  // 客户端文件路径

                    FileInfo file = new FileInfo(name);

                    string fileName = DateTime.Now.ToString("yyyyMMddhhmmssfff") + file.Extension; // 文件名称，当前时间（yyyyMMddhhmmssfff）
                    string webFilePath = Server.MapPath(upPath) + fileName;        // 服务器端文件路径

                    string FilePath = upPath + fileName;   //页面中使用的路径

                    if (!File.Exists(webFilePath))
                    {
                        if ((fUpload.FileBytes.Length / (1024 * 1024)) > upLength)
                        {
                            ClientScript.RegisterStartupScript(this.GetType(), "upfileOK", "alert('大小超出 " + upLength + " M的限制，请处理后再上传！');", true);
                            return;
                        }

                        try
                        {
                            fUpload.SaveAs(webFilePath);                                // 使用 SaveAs 方法保存文件


                            ClientScript.RegisterStartupScript(this.GetType(), "upfileOK", "alert('提示：文件上传成功');", true);
                            //绑定到数据库
                            modelMovie.M_Id = UInt16.Parse(GridView1.Rows[nRow].Cells[0].Text);
                            modelMovie.M_Picture = "~"+FilePath;

                            string strMsg = bllMovie.MoviePictureUpdate(modelMovie);
                            ShowMsg(strMsg);

                            //上传后设置按钮不可用
                            Button btn = (Button)GridView1.Rows[GridView1.EditIndex].Cells[10].FindControl("Button1");
                            btn.Enabled = false;
                            fUpload.Enabled = false;

                            GridView1.EditIndex = -1;
                            BindToGv();
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

        }
        //单击禁用触发事件
        protected void GridView1_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
        {
            int nRow = e.NewSelectedIndex;
            modelMovie.M_Id = UInt16.Parse(GridView1.Rows[nRow].Cells[0].Text);

            modelMovie.M_Enable = false;

         
            bllMovie.MovieEnableUpdate(modelMovie);
            BindToGv();

        }
        //单击删除触发事件
        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int nRow = e.RowIndex;
            modelMovie.M_Id = UInt16.Parse(GridView1.Rows[nRow].Cells[0].Text);
            bllMovie.MovieDelete(modelMovie);
            BindToGv();
        }
    }
}
