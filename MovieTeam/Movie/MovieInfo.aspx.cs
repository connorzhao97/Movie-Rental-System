using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;

namespace MovieTeam.Movie
{
    public partial class MovieInfo : System.Web.UI.Page
    {
        /// <summary>
        /// 电影评分
        /// </summary>
        public float MovieStar;
        /// <summary>
        /// 我的评分
        /// </summary>
        public float Stars = 1.0f;
        /// <summary>
        /// 电影库存
        /// </summary>
        public String Stock;
        /// <summary>
        /// 电影剧情介绍
        /// </summary>
        public String Intro;
        /// <summary>
        /// 电影上映时间
        /// </summary>
        public String Date;
        BLL.DirectorAndActor bllDA = new BLL.DirectorAndActor("ConnectionString");
        BLL.Comment bllComment = new BLL.Comment("ConnectionString");
        BLL.Movie bllM = new BLL.Movie("ConnectionString");
        BLL.ShoppingCar bllS = new BLL.ShoppingCar("ConnectionString");
        Model.Comment comment = new Model.Comment();
        Model.Movie Mmodel = new Model.Movie();
        Model.ShoppingCar modelS = new Model.ShoppingCar();

        public String M_Name;
        public String M_eName;
        public String M_Grade;
        public String M_Length;
        public String M_Type;
        public String M_Area;
        public String M_Date;
        public int M_Stock;
        public String M_Picture;
        public String M_Intro;
        private bool isExist;
        public String id;


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



        protected void Page_Load(object sender, EventArgs e)
        {
            if ((id = Request.Params["id"]) != null)
            {
                if (!IsPostBack)
                {
                    InitGlobal();
                    if (sqlConn.State == ConnectionState.Open)
                    {
                        String cmdStr = "select * from Movie where M_id = " + id;//值根据传进来的id变
                        SqlCommand sqlCommand = new SqlCommand(cmdStr, sqlConn);
                        SqlDataReader reader = sqlCommand.ExecuteReader();
                        if (reader.Read() == true)
                        {
                            M_Name = reader.GetString(1);
                            M_eName = reader.GetString(2);
                            M_Grade = reader.GetString(3);
                            M_Length = reader.GetString(4);
                            M_Type = reader.GetString(5);
                            M_Area = reader.GetString(6);
                            M_Date = reader.GetString(7);
                            M_Stock = reader.GetInt32(8);
                            M_Picture = reader.GetString(10);
                            M_Intro = reader.GetString(11);
                            isExist = true;
                            if (M_Stock == 0)
                            {
                                AddShopping.Enabled = false;
                                AddShopping.Text = "没有存货";
                            }
                            DataTable table = bllDA.DirectorSelectByMid(int.Parse(id));
                            if (table.Rows.Count != 0)
                            {
                                LinkButtonDirector.Text = table.Rows[0][2].ToString().Trim();
                                LinkButtonDirector.PostBackUrl = "~/Movie/CharactorInfo?DA_id=" + table.Rows[0][0];
                            }
                            table = bllDA.ActorSelectByMid(Int32.Parse(id));

                            if (table.Rows.Count != 0)
                            {
                                if (table.Rows.Count > 3)
                                {
                                    LBmore.Visible = true;
                                }
                                switch (table.Rows.Count)
                                {
                                    case 1:
                                        {
                                            LinkButton1.Text = table.Rows[0][2].ToString().Trim();
                                            LinkButton1.PostBackUrl = "~/Movie/CharactorInfo?DA_id=" + table.Rows[0][0];
                                            break;
                                        }
                                    case 2:
                                        {
                                            LinkButton1.Text = table.Rows[0][2].ToString().Trim();
                                            LinkButton1.PostBackUrl = "~/Movie/CharactorInfo?DA_id=" + table.Rows[0][0];
                                            Label1.Visible = true;
                                            LinkButton2.Text = table.Rows[1][2].ToString().Trim();
                                            LinkButton2.PostBackUrl = "~/Movie/CharactorInfo?DA_id=" + table.Rows[1][0];
                                            LinkButton2.Visible = true;
                                            break;
                                        }
                                    case 3:
                                        {
                                            LinkButton1.Text = table.Rows[0][2].ToString().Trim();
                                            LinkButton1.PostBackUrl = "~/Movie/CharactorInfo?DA_id=" + table.Rows[0][0];
                                            Label1.Visible = true;
                                            LinkButton2.Text = table.Rows[1][2].ToString().Trim();
                                            LinkButton2.PostBackUrl = "~/Movie/CharactorInfo?DA_id=" + table.Rows[1][0];
                                            LinkButton2.Visible = true;
                                            Label2.Visible = true;
                                            LinkButton3.Text = table.Rows[2][2].ToString().Trim();
                                            LinkButton3.PostBackUrl = "~/Movie/CharactorInfo?DA_id=" + table.Rows[2][0];
                                            LinkButton3.Visible = true;
                                            break;
                                        }
                                    case 4:
                                        {
                                            LinkButton1.Text = table.Rows[0][2].ToString().Trim();
                                            LinkButton1.PostBackUrl = "~/Movie/CharactorInfo?DA_id=" + table.Rows[0][0];
                                            Label1.Visible = true;
                                            LinkButton2.Text = table.Rows[1][2].ToString().Trim();
                                            LinkButton2.PostBackUrl = "~/Movie/CharactorInfo?DA_id=" + table.Rows[1][0];
                                            LinkButton2.Visible = true;
                                            Label2.Visible = true;
                                            LinkButton3.Text = table.Rows[2][2].ToString().Trim();
                                            LinkButton3.PostBackUrl = "~/Movie/CharactorInfo?DA_id=" + table.Rows[2][0];
                                            LinkButton3.Visible = true;
                                            Label3.Visible = true;
                                            LinkButton4.Text = table.Rows[3][2].ToString().Trim();
                                            LinkButton4.PostBackUrl = "~/Movie/CharactorInfo?DA_id=" + table.Rows[3][0];
                                            LinkButton4.Visible = true;
                                            break;
                                        }
                                    case 5:
                                        {
                                            LinkButton1.Text = table.Rows[0][2].ToString().Trim();
                                            LinkButton1.PostBackUrl = "~/Movie/CharactorInfo?DA_id=" + table.Rows[0][0];
                                            Label1.Visible = true;
                                            LinkButton2.Text = table.Rows[1][2].ToString().Trim();
                                            LinkButton2.PostBackUrl = "~/Movie/CharactorInfo?DA_id=" + table.Rows[1][0];
                                            LinkButton2.Visible = true;
                                            Label2.Visible = true;
                                            LinkButton3.Text = table.Rows[2][2].ToString().Trim();
                                            LinkButton3.PostBackUrl = "~/Movie/CharactorInfo?DA_id=" + table.Rows[2][0];
                                            LinkButton3.Visible = true;
                                            Label3.Visible = true;
                                            LinkButton4.Text = table.Rows[3][2].ToString().Trim();
                                            LinkButton4.PostBackUrl = "~/Movie/CharactorInfo?DA_id=" + table.Rows[3][0];
                                            LinkButton4.Visible = true;
                                            Label4.Visible = true;
                                            LinkButton5.Text = table.Rows[4][2].ToString().Trim();
                                            LinkButton5.PostBackUrl = "~/Movie/CharactorInfo?DA_id=" + table.Rows[3][0];
                                            break;
                                        }
                                }
                            }

                            DataTable comment = bllComment.CommentsSelectByMid(id);
                            if (comment.Rows.Count != 0)
                            {
                                switch (comment.Rows.Count)
                                {
                                    case 1:
                                        {
                                            comment1.Visible = true;
                                            Lb_comment1.Visible = true;
                                            Lb_Star_comment1.Visible = true;
                                            h3_comment1.Visible = true;

                                            Lb_comment1.InnerText = comment.Rows[0][2].ToString().Trim();
                                            Lb_Star_comment1.InnerText = comment.Rows[0][4].ToString().Trim();
                                            h3_comment1.InnerText = comment.Rows[0][6].ToString().Trim();
                                            if (h3_comment1.InnerText.Length > 100)
                                            {
                                                h3_comment1.InnerText = h3_comment1.InnerText.Remove(100) + "...";
                                            }
                                            break;
                                        }
                                    case 2:
                                        {
                                            comment1.Visible = true;
                                            Lb_comment1.Visible = true;
                                            Lb_Star_comment1.Visible = true;
                                            h3_comment1.Visible = true;

                                            Lb_comment1.InnerText = comment.Rows[0][2].ToString().Trim();
                                            Lb_Star_comment1.InnerText = comment.Rows[0][4].ToString().Trim();
                                            h3_comment1.InnerText = comment.Rows[0][6].ToString().Trim();
                                            if (h3_comment1.InnerText.Length > 100)
                                            {
                                                h3_comment1.InnerText = h3_comment1.InnerText.Remove(100) + "...";
                                            }
                                            comment2.Visible = true;
                                            Lb_comment2.Visible = true;
                                            Lb_Star_comment2.Visible = true;
                                            h3_comment2.Visible = true;

                                            Lb_comment2.InnerText = comment.Rows[1][2].ToString().Trim();
                                            Lb_Star_comment2.InnerText = comment.Rows[1][4].ToString().Trim();
                                            h3_comment2.InnerText = comment.Rows[1][6].ToString().Trim();
                                            if (h3_comment2.InnerText.Length > 100)
                                            {
                                                h3_comment2.InnerText = h3_comment2.InnerText.Remove(100) + "...";
                                            }
                                            break;
                                        }
                                    case 3:
                                        {
                                            comment1.Visible = true;
                                            Lb_comment1.Visible = true;
                                            Lb_Star_comment1.Visible = true;
                                            h3_comment1.Visible = true;

                                            Lb_comment1.InnerText = comment.Rows[0][2].ToString().Trim();
                                            Lb_Star_comment1.InnerText = comment.Rows[0][4].ToString().Trim();
                                            h3_comment1.InnerText = comment.Rows[0][6].ToString().Trim();
                                            if (h3_comment1.InnerText.Length > 100)
                                            {
                                                h3_comment1.InnerText = h3_comment1.InnerText.Remove(100) + "...";
                                            }
                                            comment2.Visible = true;
                                            Lb_comment2.Visible = true;
                                            Lb_Star_comment2.Visible = true;
                                            h3_comment2.Visible = true;

                                            Lb_comment2.InnerText = comment.Rows[1][2].ToString().Trim();
                                            Lb_Star_comment2.InnerText = comment.Rows[1][4].ToString().Trim();
                                            h3_comment2.InnerText = comment.Rows[1][6].ToString().Trim();
                                            if (h3_comment2.InnerText.Length > 100)
                                            {
                                                h3_comment2.InnerText = h3_comment2.InnerText.Remove(100) + "...";
                                            }
                                            comment3.Visible = true;
                                            Lb_comment3.Visible = true;
                                            Lb_Star_comment3.Visible = true;
                                            h3_comment3.Visible = true;

                                            Lb_comment3.InnerText = comment.Rows[2][2].ToString().Trim();
                                            Lb_Star_comment3.InnerText = comment.Rows[2][4].ToString().Trim();
                                            h3_comment3.InnerText = comment.Rows[2][6].ToString().Trim();
                                            if (h3_comment3.InnerText.Length > 100)
                                            {
                                                h3_comment3.InnerText = h3_comment3.InnerText.Remove(100) + "...";
                                            }
                                            break;
                                        }
                                }
                            }


                            HttpCookie cookie = new HttpCookie("Movie");
                            cookie.Values.Add("M_Name", M_Name);
                            cookie.Values.Add("M_eName", M_eName);
                            cookie.Values.Add("M_Grade", M_Grade);
                            cookie.Values.Add("M_Length", M_Length);
                            cookie.Values.Add("M_Type", M_Type);
                            cookie.Values.Add("M_Area", M_Area);
                            cookie.Values.Add("M_Date", M_Date);
                            cookie.Values.Add("M_Stock", M_Stock.ToString());
                            cookie.Values.Add("M_pricture", M_Picture);
                            cookie.Values.Add("M_Intro", M_Intro);
                            cookie.Values.Add("isExist", isExist.ToString());
                            Response.AppendCookie(cookie);
                            if (M_Stock == 0)
                            {
                                AddShopping.Enabled = false;
                                AddShopping.Text = "没有存货";
                            }
                        }
                        Show(isExist);
                    }
                }
                else
                {
                    if (Request.Cookies["Movie"] != null)
                    {
                        M_Name = Request.Cookies["Movie"]["M_Name"];
                        M_eName = Request.Cookies["Movie"]["M_eName"];
                        M_Grade = Request.Cookies["Movie"]["M_Grade"];
                        M_Length = Request.Cookies["Movie"]["M_Length"];
                        M_Type = Request.Cookies["Movie"]["M_Type"];
                        M_Area = Request.Cookies["Movie"]["M_Area"];
                        M_Date = Request.Cookies["Movie"]["M_Date"];
                        M_Stock = Int32.Parse(Request.Cookies["Movie"]["M_Stock"]);
                        M_Picture = Request.Cookies["Movie"]["M_pricture"];
                        M_Intro = Request.Cookies["Movie"]["M_Intro"];
                        isExist = Boolean.Parse(Request.Cookies["Movie"]["isExist"]);
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
                if (M_Intro.Length > 130)
                {
                    M_Intro = M_Intro.Remove(130) + "...";
                }
                MovieStar = float.Parse(M_Grade);
                M_Image.ImageUrl = M_Picture;
                string[] Date = new string[3];
                Date = M_Date.Split('-');
                year.InnerText = "(" + Date[0] + ")";
                string[] Type = new string[3];
                Type = M_Type.Split('/');
                switch (Type.Length)
                {
                    case 1:
                        {
                            Type1.HRef = "~/Movie/MovieList?Type=" + Type[0];
                            Type1.InnerText = Type[0];
                            break;
                        }
                    case 2:
                        {
                            Type1.HRef = "~/Movie/MovieList?Type=" + Type[0];
                            Type1.InnerText = Type[0] + "/";
                            Type2.Visible = true;
                            Type2.HRef = "~/Movie/MovieList?Type=" + Type[1];
                            Type2.InnerText = Type[1];
                            break;
                        }
                    case 3:
                        {
                            Type1.HRef = "~/Movie/MovieList?Type=" + Type[0];
                            Type1.InnerText = Type[0] + "/";
                            Type2.Visible = true;
                            Type2.HRef = "~/Movie/MovieList?Type=" + Type[1];
                            Type2.InnerText = Type[1] + "/";
                            Type3.Visible = true;
                            Type3.HRef = "~/Movie/MovieList?Type=" + Type[2];
                            Type3.InnerText = Type[2];
                            break;
                        }
                }
                Area.HRef = "~/Movie/MovieList?Location=" + M_Area;
            }
            else
            {
                Response.Redirect("~/Home/Home.aspx");
            }
        }
        protected void LBmore_Click(object sender, EventArgs e)
        {
            LinkButton4.Visible = true;
            Label4.Visible = true;
            LinkButton5.Visible = true;
            LBmore.Visible = false;
        }

        protected void AddShopping_Click(object sender, EventArgs e)
        {
            HttpCookie cookie = Request.Cookies["username"];
            if (cookie == null)
            {
                Response.Write("<script>alert('请先登录!');</script>");
                Response.Redirect("~/Account/Login.aspx");
            }
            else
            {
                if (M_Stock < 1)
                {
                    Response.Write("<script>alert('暂时没有此电影存货！');</script>");
                    AddShopping.Enabled = false;
                    AddShopping.Text = "没有存货";
                }

                else
                {
                    modelS.U_Id = int.Parse(cookie["U_Id"]);
                    modelS.M_Id = int.Parse(id);
                    modelS.M_Name = M_Name;
                    modelS.M_eName = M_eName;
                    modelS.M_Picture = M_Picture;
                    modelS.M_Intro = M_Intro;
                    string str = bllS.SCarInserts(modelS);

                    Mmodel.M_Id = int.Parse(id);
                    Mmodel.M_Stock = --M_Stock;
                    AddShopping.Enabled = false;
                    AddShopping.Text = "没有存货";
                    HttpCookie temp = Request.Cookies["Movie"];
                    temp["M_Stock"] = Mmodel.M_Stock.ToString().Trim();
                    Response.AppendCookie(temp);
                    bllM.MovieUpdateStock(Mmodel);
                    Response.Write("<script>alert('" + str + "');</script>");
                }
            }
        }

        protected void Btn_message_Click(object sender, EventArgs e)
        {
            HttpCookie cookie = Request.Cookies["username"];
            if (cookie != null)
            {
                comment.U_Id = Int32.Parse(cookie["U_Id"]);
                comment.U_Name = cookie["U_Name"];
                comment.M_Id = Int32.Parse(id);
                comment.Com_Grade = float.Parse(HFStar.Value);
                comment.Com_Date = DateTime.Now;
                comment.Com_Content = TBmessage.Text.Trim();
                comment.Com_Enable = false;
                bllComment.CommentsInsert(comment);
                TBmessage.Text = "";
                Response.Write(" <script>alert( '评论成功！' ); </script> ");
            }
            else
            {
                Response.Write(" <script>alert( ' 请先登录！' ); </script> ");
            }
        }
    }
}