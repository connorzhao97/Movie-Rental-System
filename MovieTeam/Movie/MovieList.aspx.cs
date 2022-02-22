using System;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI.WebControls;

namespace MovieTeam.MovieInfo
{
    public partial class MovieList : System.Web.UI.Page
    {
        #region 数据库方法,应该封装成类
        /// <summary>
        /// 数据库连接对象
        /// </summary>
        SqlConnection sqlConn;
        private void InitGlobal()
        {
            string strConn = System.Configuration.ConfigurationManager.ConnectionStrings["ConnToTest"].ConnectionString;
            sqlConn = new SqlConnection(strConn);
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

        #region 全局常量
        public const int TYPE = 0;
        public const int LOCATION = 1;
        public const int DATE = 2;
        #endregion

        /// <summary>
        /// 初始化DataTable
        /// </summary>
        /// <param name="data_name">电影名</param>
        /// <param name="data_grade">电影评分</param>
        /// <param name="data_type">导演</param>
        /// <param name="data_area">演员</param>
        private void InitDataTable(string data_name, string data_grade, string data_type, string data_area)
        {
            da = new DataTable();//创建表  
            da.Columns.Add("M_Id", typeof(string));//表中的第一列  
            da.Columns.Add("M_Name", typeof(string));//表中的第一列  
            da.Columns.Add("M_Grade", typeof(string));//表中的第二列  
            da.Columns.Add("M_Type", typeof(string));//表中的第二列  
            da.Columns.Add("M_Area", typeof(string));//表中的第二列  

            int nListIndex = 0;
            while (nListIndex < 26)//循环添加行  
            {
                DataRow dr = da.NewRow();//新创建一行  
                dr["M_Id"] = "id";//对这个新建的行的第一列赋值  
                dr["M_Name"] = data_name + "-" + nListIndex; ;//对这个新建的行的第一列赋值  
                dr["M_Grade"] = data_grade;//对这个新建的行的第二列赋值  
                dr["M_Type"] = data_type;//对这个新建的行的第二列赋值  
                dr["M_Area"] = data_area;//对这个新建的行的第二列赋值  

                da.Rows.Add(dr);//把填入的值加入到表中  

                nListIndex++;
            }
        }

        /// <summary>
        /// 根据提供的查询字符串查询数据 填充datatable
        /// </summary>
        /// <param name="whereClause"></param>
        private void InitDataTable(string whereClause)
        {
            #region 查询数据库
            // 默认查询全部数据
            if ("".Equals(whereClause))
            {
                BLL.Movie bllMovie = new BLL.Movie("ConnectionString");
                da = bllMovie.MoviesView();
            }
            else
            {
                BLL.Movie bllMovie = new BLL.Movie("ConnectionString");                
                da = bllMovie.MovieQueryByQuery(whereClause);
            }
            #endregion
        }

        private void InitDataTable(int type, String value)
        {           
            #region 查询数据库
            // 默认查询全部数据
            if (type == TYPE)
            {
                BLL.Movie bllMovie = new BLL.Movie("ConnectionString");
                da = bllMovie.MovieQueryByType(value);
            }
            else if(type == LOCATION)
            {
                BLL.Movie bllMovie = new BLL.Movie("ConnectionString");
                da = bllMovie.MovieQueryByArea(value);
            }
            else if(type == DATE)
            {
                BLL.Movie bllMovie = new BLL.Movie("ConnectionString");
                da = bllMovie.MovieQueryByDate(value);
            }
            #endregion
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            InitGlobal();            

            //first
            if (!IsPostBack)
            {
                String type = Request.QueryString["Type"];
                Session["Type"] = type;

                String location = Request.QueryString["Location"];
                Session["Location"] = location;

                String date = Request.QueryString["Date"];
                Session["Date"] = date;

                String whereClause = makeSqlClause();
                BindToLV(whereClause);


                // 选中菜单项样式设置
                if (!"".Equals(type))
                {
                    SetMenuItemStyle(type, TYPE);
                }
                if (!"".Equals(location))
                {
                    SetMenuItemStyle(location, LOCATION);
                }
                if (!"".Equals(date))
                {
                    SetMenuItemStyle(date,DATE);
                }
            }
            else
            {
            }           
        }

        private void SetMenuItemStyle(string value, int type)
        {
            for (int col = 1; col < Table1.Rows[type].Cells.Count; col++)
            {
                Button btn = (Button)Table1.Rows[type].Cells[col].Controls[0];
                if (btn.Text.Equals(value))
                {
                    btn.ForeColor = System.Drawing.Color.Tomato;
                    btn.Font.Bold = true;
                }
            }
        }

        private void BindToLV(String data_name, String data_grade, String data_type, String data_area )
        {
            // 根据当前菜单选项信息（session中保存，可全局获取）
            // 查询数据库数据 填充datatable
            InitDataTable(data_name, data_grade, data_type, data_area);

            this.ListView1.DataSource = da;//绑定datalist  
            this.ListView1.DataBind();
        }

        private void BindToLV(String whereClause)
        {
            // 根据查询字符串
            // 查询数据库数据 填充datatable
            InitDataTable(whereClause);

            this.ListView1.DataSource = da;//绑定datalist  
            this.ListView1.DataBind();
        }

        private void BindToLV(int type, String value)
        {
            // 根据查询字符串
            // 查询数据库数据 填充datatable
            InitDataTable(type, value);

            this.ListView1.DataSource = da;//绑定datalist  
            this.ListView1.DataBind();
        }

        protected void submit_Click(object sender, EventArgs e)
        {
            String category = "";
            String value = "";

            //记住table中被选中的项       
            Button btn = sender as Button;
            // 获取点击控件的内容
            value = btn.Text;
            category = btn.Parent.Parent.ID.ToString();

            //WriteAlert("btn:" + value + "parent:" + category);
            if(btn.ForeColor != System.Drawing.Color.Tomato)
            {                
                //保存选中内容
                Session[category] = value;               
            }
            else
            {
                // 取消选中
                Session[category] = null;
            }

            Response.Redirect("~/Movie/MovieList.aspx" + "?" + makeUrlClause());
        }

        private void resetMenuItemStyle(string value, int type)
        {            
            for (int col = 1; col < Table1.Rows[type].Cells.Count; col++)
            {
                Button btn = (Button)Table1.Rows[type].Cells[col].Controls[0];
                if (!btn.Text.Equals(value) && 
                    btn.ForeColor == System.Drawing.Color.Tomato)
                {
                    btn.ForeColor = System.Drawing.Color.Black;
                    btn.Font.Bold = false;
                }
            }
              
        }

        private String makeSqlClause()
        {
            String result = "";
            String type = "", date = "", location = "";

            if (Session["Type"] != null)
            {
                type = Session["Type"].ToString();
            }
            if (Session["Location"] != null)
            {
                location = Session["Location"].ToString();
            }
            if (Session["Date"] != null)
            {
                date = Session["Date"].ToString();
            }

            if(!"".Equals(type))
            {
                result += " M_Type like N'%" + type + "%'";
                if(!"".Equals(location))
                {
                    result += " and M_Area like N'%" + location + "%'";
                    if (!"".Equals(date))
                    {
                        result += " and M_Date like N'%" + date + "%'"; 
                    }
                }
                else
                {
                    if (!"".Equals(date))
                    {
                        result += " and M_Date like N'%" + date + "%'";
                    }
                }
            }
            else
            {
                if (!"".Equals(location))
                {
                    result += " M_Area like N'%" + location + "%'";
                    if (!"".Equals(date))
                    {
                        result += " and M_Date like N'%" + date + "%'";
                    }
                }
                else
                {
                    if (!"".Equals(date))
                    {
                        result += " M_Date like N'%" + date + "%'";
                    }
                }
            }


            //if("".Equals(result))
            //{
            //    return "";
            //}
            return result;
        }

        private String makeUrlClause()
        {
            String result = "";
            String type = "", date = "", location = "";

            if (Session["Type"] != null)
            {
                type = Session["Type"].ToString();
            }
            if (Session["Location"] != null)
            {
                location = Session["Location"].ToString();
            }
            if (Session["Date"] != null)
            {
                date = Session["Date"].ToString();
            }

            if (!"".Equals(type))
            {
                result += "Type=" + type;
                if (!"".Equals(location))
                {
                    result += "&Location=" + location;
                    if (!"".Equals(date))
                    {
                        result += "&Date=" + date;
                    }
                }
                else
                {
                    if (!"".Equals(date))
                    {
                        result += "&Date=" + date;
                    }
                }
            }
            else
            {
                if (!"".Equals(location))
                {
                    result += "Location=" + location;
                    if (!"".Equals(date))
                    {
                        result += "&Date=" + date;
                    }
                }
                else
                {
                    if (!"".Equals(date))
                    {
                        result += "Date=" + date;
                    }
                }
            }
            return result;
        }
        public void WriteAlert(String msg)
        {
            Response.Write("<script>alert('" +  msg + "')</script>");
        }

        protected void ListView1_PagePropertiesChanging(object sender, PagePropertiesChangingEventArgs e)
        {
            DataPager1.SetPageProperties(e.StartRowIndex, e.MaximumRows, false);
            String whereClause = makeSqlClause();
            //WriteAlert(whereClause);
            BindToLV(whereClause);
        }
    }
}