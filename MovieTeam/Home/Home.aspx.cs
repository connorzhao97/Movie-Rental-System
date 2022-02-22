using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace MovieTeam.Home
{
    public partial class Home : System.Web.UI.Page
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

        #region 数据容器
        DataTable da;

        bool[,] table;

        #endregion

        #region 电影类型
        private List<Movie> Action = new List<Movie>();//动作片
        private List<Movie> Cartoon = new List<Movie>();//动画片
        private List<Movie> Comedy = new List<Movie>();//喜剧片
        private List<Movie> Feature = new List<Movie>();//剧情片
        private List<Movie> Horror = new List<Movie>();//恐怖片
        private List<Movie> Romance = new List<Movie>();//爱情片
        private List<Movie> Science = new List<Movie>();//科幻片
        private List<Movie> Thriller = new List<Movie>();//惊悚片
        #endregion

        /// <summary>
        /// 初始化绑定数据
        /// </summary>
        private void InitDataTable()
        {
            da = new DataTable();
            da.Columns.Add("M_id", typeof(string));
            da.Columns.Add("M_Type", typeof(string));
            da.Columns.Add("M_Picture", typeof(string));
            da.Columns.Add("M_Frequency", typeof(int));
        }
        /// <summary>
        /// 添加绑定数据
        /// </summary>
        /// <param name="Id">电影编号</param>
        /// <param name="Type">电影类型</param>
        /// <param name="Picture">电影图片地址</param>
        /// <param name="Frequency">租赁次数</param>
        private void AddDataTable(string Id, string Type, string Picture,int Frequency)
        {
            DataRow row = da.NewRow();//新建一行
            row["M_id"] = Id;
            row["M_Type"] = Type;
            row["M_Picture"] = Picture;
            row["M_Frequency"] = Frequency;
            da.Rows.Add(row);
        }

        public void Sort()//利用委托对frequency进行排序
        {
            Action.Sort(delegate (Movie a, Movie b)
            {
                return a.M_Frequency.CompareTo(b.M_Frequency);
            });
            Cartoon.Sort(delegate (Movie a, Movie b)
            {
                return a.M_Frequency.CompareTo(b.M_Frequency);
            });
            Comedy.Sort(delegate (Movie a, Movie b)
            {
                return a.M_Frequency.CompareTo(b.M_Frequency);
            });
            Feature.Sort(delegate (Movie a, Movie b)
            {
                return a.M_Frequency.CompareTo(b.M_Frequency);
            });
            Horror.Sort(delegate (Movie a, Movie b)
            {
                return a.M_Frequency.CompareTo(b.M_Frequency);
            });
            Romance.Sort(delegate (Movie a, Movie b)
            {
                return a.M_Frequency.CompareTo(b.M_Frequency);
            });
            Science.Sort(delegate (Movie a, Movie b)
            {
                return a.M_Frequency.CompareTo(b.M_Frequency);
            });
            Thriller.Sort(delegate (Movie a, Movie b)
            {
                return a.M_Frequency.CompareTo(b.M_Frequency);
            });
            putImage();
        }

        public void putImage()//添加借阅最高的电影和图片
        {
            Ac_Ib1.ImageUrl = Action[0].M_Picture;
            Ac_Ib1.PostBackUrl = "~/Movie/MovieInfo?id=" + Action[0].M_Id;
            Ac_Ib2.ImageUrl = Action[1].M_Picture;
            Ac_Ib2.PostBackUrl = "~/Movie/MovieInfo?id=" + Action[1].M_Id;
            Ac_Ib3.ImageUrl = Action[2].M_Picture;
            Ac_Ib3.PostBackUrl = "~/Movie/MovieInfo?id=" + Action[2].M_Id;

            Co_Ib1.ImageUrl = Comedy[0].M_Picture;
            Co_Ib1.PostBackUrl = "~/Movie/MovieInfo?id=" + Comedy[0].M_Id;
            Co_Ib2.ImageUrl = Comedy[1].M_Picture;
            Co_Ib2.PostBackUrl = "~/Movie/MovieInfo?id=" + Comedy[1].M_Id;
            Co_Ib3.ImageUrl = Comedy[2].M_Picture;
            Co_Ib3.PostBackUrl = "~/Movie/MovieInfo?id=" + Comedy[2].M_Id;

            Ro_Ib1.ImageUrl = Romance[0].M_Picture;
            Ro_Ib1.PostBackUrl = "~/Movie/MovieInfo?id=" + Romance[0].M_Id;
            Ro_Ib2.ImageUrl = Romance[1].M_Picture;
            Ro_Ib2.PostBackUrl = "~/Movie/MovieInfo?id=" + Romance[1].M_Id;
            Ro_Ib3.ImageUrl = Romance[2].M_Picture;
            Ro_Ib3.PostBackUrl = "~/Movie/MovieInfo?id=" + Romance[2].M_Id;

            Sc_Ib1.ImageUrl = Science[0].M_Picture;
            Sc_Ib1.PostBackUrl = "~/Movie/MovieInfo?id=" + Science[0].M_Id;
            Sc_Ib2.ImageUrl = Science[1].M_Picture;
            Sc_Ib2.PostBackUrl = "~/Movie/MovieInfo?id=" + Science[1].M_Id;
            Sc_Ib3.ImageUrl = Science[2].M_Picture;
            Sc_Ib3.PostBackUrl = "~/Movie/MovieInfo?id=" + Science[2].M_Id;

            Th_Ib1.ImageUrl = Thriller[0].M_Picture;
            Th_Ib1.PostBackUrl = "~/Movie/MovieInfo?id=" + Thriller[0].M_Id;
            Th_Ib2.ImageUrl = Thriller[1].M_Picture;
            Th_Ib2.PostBackUrl = "~/Movie/MovieInfo?id=" + Thriller[1].M_Id;
            Th_Ib3.ImageUrl = Thriller[2].M_Picture;
            Th_Ib3.PostBackUrl = "~/Movie/MovieInfo?id=" + Thriller[2].M_Id;

            Ho_Ib1.ImageUrl = Horror[0].M_Picture;
            Ho_Ib1.PostBackUrl = "~/Movie/MovieInfo?id=" + Horror[0].M_Id;
            Ho_Ib2.ImageUrl = Horror[1].M_Picture;
            Ho_Ib2.PostBackUrl = "~/Movie/MovieInfo?id=" + Horror[1].M_Id;
            Ho_Ib3.ImageUrl = Horror[2].M_Picture;
            Ho_Ib3.PostBackUrl = "~/Movie/MovieInfo?id=" + Horror[2].M_Id;

            Fe_Ib1.ImageUrl = Feature[0].M_Picture;
            Fe_Ib1.PostBackUrl = "~/Movie/MovieInfo?id=" + Feature[0].M_Id;
            Fe_Ib2.ImageUrl = Feature[1].M_Picture;
            Fe_Ib2.PostBackUrl = "~/Movie/MovieInfo?id=" + Feature[1].M_Id;
            Fe_Ib3.ImageUrl = Feature[2].M_Picture;
            Fe_Ib3.PostBackUrl = "~/Movie/MovieInfo?id=" + Feature[2].M_Id;

            Ca_Ib1.ImageUrl = Cartoon[0].M_Picture;
            Ca_Ib1.PostBackUrl = "~/Movie/MovieInfo?id=" + Cartoon[0].M_Id;
            Ca_Ib2.ImageUrl = Cartoon[1].M_Picture;
            Ca_Ib2.PostBackUrl = "~/Movie/MovieInfo?id=" + Cartoon[1].M_Id;
            Ca_Ib3.ImageUrl = Cartoon[2].M_Picture;
            Ca_Ib3.PostBackUrl = "~/Movie/MovieInfo?id=" + Cartoon[2].M_Id;
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                InitGlobal();
                if (sqlConn.State == ConnectionState.Open)
                {
                    InitDataTable();
                    String cmdStr = "select M_Id,M_Type,M_Picture,M_Frequency from Movie";
                    SqlCommand command = new SqlCommand(cmdStr, sqlConn);
                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        AddDataTable(reader.GetInt32(0).ToString().Trim(), reader.GetString(1).Trim(), reader.GetString(2).Trim(),reader.GetInt32(3));
                    }
                }

                foreach (DataRow item in da.Rows)
                {
                    String[] SplitItem = new string[3];
                    SplitItem = item[1].ToString().Split('/');
                    Movie movie = new Movie(item[0].ToString(), SplitItem[0], item[2].ToString(), Int32.Parse(item[3].ToString()));
                    switch (SplitItem[0])
                    {
                        case "动作":
                            {
                                Action.Add(movie);
                                break;
                            }
                        case "动画":
                            {
                                Cartoon.Add(movie);
                                break;
                            }
                        case "喜剧":
                            {
                                Comedy.Add(movie);
                                break;
                            }
                        case "剧情":
                            {
                                Feature.Add(movie);
                                break;
                            }
                        case "恐怖":
                            {
                                Horror.Add(movie);
                                break;
                            }
                        case "爱情":
                            {
                                Romance.Add(movie);
                                break;
                            }
                        case "科幻":
                            {
                                Science.Add(movie);
                                break;
                            }
                        case "惊悚":
                            {
                                Thriller.Add(movie);
                                break;
                            }
                    }
                }
                Sort();
            }
        }
    }
    public class Movie
    {
        public Movie(String id, String type, String Picture,int Frequency)
        {
            M_Id = id;
            M_Type = type;
            M_Picture = Picture;
            M_Frequency = Frequency;
        }
       public String M_Id;
       public String M_Type;
       public String M_Picture;
       public int M_Frequency;//租赁次数
    }
}