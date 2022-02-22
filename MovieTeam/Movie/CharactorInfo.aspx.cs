using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MovieTeam.Movie
{

    public partial class CharactorInfo : System.Web.UI.Page
    {
        #region 数据库方法,应该封装成类
        /// <summary>
        /// 数据库连接对象
        /// </summary>
        SqlConnection sqlConn;
        private void InitGlobal()
        {
            string strConn = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
            sqlConn = new SqlConnection(strConn);
            OpenDB();
        }
        /// <summary>
        /// 打开数据库
        /// </summary>
        private void OpenDB()
        {
            if (sqlConn.State == ConnectionState.Closed)
            {
                sqlConn.Open();
            }
        }
        /// <summary>
        /// 关闭数据库
        /// </summary>
        private void CloseDB()
        {
            if (sqlConn.State != ConnectionState.Closed)
            {
                sqlConn.Close();
            }
        }

        #endregion

        Int32 M_id;
        String DA_Name;
        String DA_Ename;
        String DA_Picture;
        String DA_Intro;
        Boolean isExist;
        String M_Picture;
        String DA_id;

        protected void Page_Load(object sender, EventArgs e)
        {
            if ((DA_id = Request.Params["DA_id"]) != null)
            {
                if (!IsPostBack)
                {
                    InitGlobal();
                    if (sqlConn.State == ConnectionState.Open)
                    {
                        String cmdStr = "select * from [DirectorAndActor] where [DA_Id] = " + DA_id;//值根据传进来的id变
                        SqlCommand sqlCommand = new SqlCommand(cmdStr, sqlConn);
                        SqlDataReader reader = sqlCommand.ExecuteReader();
                        if (reader.Read() == true)
                        {
                            M_id = reader.GetInt32(1);
                            DA_Name = reader.GetString(2).Trim();
                            DA_Ename = reader.GetString(3).Trim();
                            DA_Picture = reader.GetString(4).Trim();
                            DA_Intro = reader.GetString(6).Trim();
                            isExist = true;

                            HttpCookie DA_cookie = new HttpCookie("DA");
                            DA_cookie.Values.Add("M_Id", M_id.ToString());
                            DA_cookie.Values.Add("DA_Name", DA_Name);
                            DA_cookie.Values.Add("DA_Ename", DA_Ename);
                            DA_cookie.Values.Add("DA_Picture", DA_Picture);
                            DA_cookie.Values.Add("DA_Intro", DA_Intro);
                            DA_cookie.Values.Add("isExist", isExist.ToString());

                            reader.Close();
                            sqlCommand.Dispose();

                            cmdStr = "select M_Picture from [Movie] where [M_Id]=" + M_id;
                            sqlCommand = new SqlCommand(cmdStr, sqlConn);
                            reader = sqlCommand.ExecuteReader();
                            if (reader.Read() == true)
                            {
                                M_Picture = reader.GetString(0);
                                DA_cookie.Values.Add("M_Priture", DA_Intro);
                            }

                            Response.AppendCookie(DA_cookie);
                        }
                        Show(isExist);
                        reader.Close();
                        sqlCommand.Dispose();
                        CloseDB();
                    }
                }
                else
                {
                    if (Request.Cookies["DA"] != null)
                    {
                        M_id = Int32.Parse(Request.Cookies["DA"]["M_Id"]);
                        DA_Name = Request.Cookies["DA"]["DA_Name"];
                        DA_Ename = Request.Cookies["DA"]["DA_Ename"];
                        DA_Picture = Request.Cookies["DA"]["DA_Picture"];
                        DA_Intro = Request.Cookies["DA"]["DA_Intro"];
                        isExist = Boolean.Parse(Request.Cookies["DA"]["isExist"]);
                        M_Picture = Request.Cookies["DA"]["M_Priture"];
                        Show(isExist);
                    }

                }
            }
            else
            {
                Response.Redirect("~/Home/Home.aspx");
            }
        }
        public void Show(bool isExist)
        {
            if (isExist)
            {
                Cha_Image.ImageUrl = DA_Picture;
                chname.InnerText = DA_Name;
                enname.InnerText = DA_Ename;
                Cha_Intro.Text = DA_Intro;
                OtherMovie1.ImageUrl = M_Picture;
                OtherMovie1.PostBackUrl = "~/Movie/MovieInfo?id=" + M_id;
            }
        }
    }
}