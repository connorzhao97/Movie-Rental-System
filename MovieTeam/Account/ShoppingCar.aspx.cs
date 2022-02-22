using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Windows.Forms;
using System.IO;

namespace MovieTeam.Account
{
    public partial class ShoppingCar : System.Web.UI.Page
    {
        #region==全局对象==
        BLL.Movie bllMovie;
        BLL.ShoppingCar bllS;
        BLL.BringAndReturn bllBR;
        Model.BringAndReturn modelBR;
        Model.Movie modelMovie;
        Model.ShoppingCar modelS;
        #endregion
        #region==全局函数==
        /// <summary>
        /// 初始化函数
        /// </summary>
        private void InitGlobal()
        {
            
            bllMovie = new BLL.Movie("ConnectionString");   //ConnectionString是在Web.Config文件中配置的数据库连接字符串
            bllS = new BLL.ShoppingCar("ConnectionString");
            bllBR = new BLL.BringAndReturn("ConnectionString");
            modelBR = new Model.BringAndReturn();
            modelMovie = new Model.Movie();
            modelS = new Model.ShoppingCar();
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
            HttpCookie cookie = Request.Cookies["username"];
            if (cookie == null)
            {
                Response.Write("<script>alert('请先登录！');window.location='Login.aspx';</script>");
            }
            GridView1.DataSource = bllMovie.MoviesView();
            GridView2.DataSource = bllS.SelectedByU_Id(int.Parse(cookie["U_Id"]));
            GridView1.DataBind();
            GridView2.DataBind();
        }
        #endregion
        protected void Page_Load(object sender, EventArgs e)
        {
            HttpCookie cookie = Request.Cookies["username"];
            if (cookie == null)
            {
                Response.Write("<script>alert('请先登录！');window.location='Login.aspx';</script>");
            }
            else
            {
                InitGlobal();
                if (!IsPostBack)
                {
                    BindToGv();
                }
            }
           
        }

        protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
        {
            GridView1.EditIndex = e.NewEditIndex;
            //在点击编辑之前设置按钮不可用
            FileUpload fUpload = (FileUpload)GridView1.Rows[GridView1.EditIndex].Cells[10].FindControl("FileUpload2");
            System.Web.UI.WebControls.Button btn = (System.Web.UI.WebControls.Button)GridView1.Rows[GridView1.EditIndex].Cells[10].FindControl("Button1");
            btn.Enabled = true;
            fUpload.Enabled = true;
            BindToGv();
        }

        protected void GridView1_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            GridView1.EditIndex = -1;
            BindToGv();
        }


        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView1.PageIndex = e.NewPageIndex;
            BindToGv();
        }

        /// <summary>
        /// 点击下面选择租赁时候，添加到租赁单，同时清空购物车
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Button2_Click(object sender, EventArgs e)
        {
            HttpCookie cookie = Request.Cookies["username"];
            DataRow Dr;

            if (cookie == null)
            {
                Response.Write("<script>alert('请先登录！');window.location='Login.aspx';</script>");
            }

            else
            {
                DataTable Dt = bllS.SelectedByU_Id(int.Parse(cookie["U_Id"]));
                if (Dt.Rows.Count == 0)
                {
                    Response.Write("<script>alert('购物车为空，请先添加电影！');</script>");
                }
                else
                {
                    modelBR.B_Date = DateTime.Parse(DateTime.Now.ToString("yyyy-MM-dd"));
                    modelBR.R_Date = modelBR.B_Date.AddDays(1);
                    modelBR.B_Rent = 5;

                    for (int i = 0; i < Dt.Rows.Count; i++)
                    {
                        Dr = Dt.Rows[i];
                        modelS.S_Id = int.Parse(Dr["S_Id"].ToString());
                        modelBR.U_Id = int.Parse(Dr["U_Id"].ToString());
                        modelBR.M_Id = int.Parse(Dr["M_Id"].ToString());
                        modelMovie.M_Id = int.Parse(Dr["M_Id"].ToString());

                        bllMovie.MovieUpdateFrequency(modelMovie);
                        bllBR.BringAndReturnsInsert(modelBR);
                        bllS.SCarDelete(modelS);
                    }

                    Response.Write("<script>alert('租赁成功!点击确定购买！');window.location='/Home/Home.aspx';</script>");
                }
            }
        }

        protected void Button3_Click(object sender, EventArgs e)
        {

            HttpCookie cookie = Request.Cookies["username"];
            DataRow Dr;

            if (cookie == null)
            {
                Response.Write("<script>alert('请先登录！');window.location='Login.aspx';</script>");
            }

            else
            {
                DataTable Dt = bllS.SelectedByU_Id(int.Parse(cookie["U_Id"]));
                if (Dt.Rows.Count == 0)
                {
                    Response.Write("<script>alert('购物车为空，请先添加电影！');</script>");
                }
                else
                {
                    if (int.Parse(cookie["U_Level"].ToString()) == 1)   //等级 2 3
                    {
                        Response.Write("<script>alert('等级不够！');</script>");
                    }

                    if (int.Parse(cookie["U_Level"].ToString()) > 1)   //等级 2 3
                    {
                        modelBR.B_Date = DateTime.Parse(DateTime.Now.ToString("yyyy-MM-dd"));
                        modelBR.R_Date = modelBR.B_Date.AddDays(7);         //一周
                        modelBR.B_Rent = 15;                                  //租金15
                        
                        for (int i = 0; i < Dt.Rows.Count; i++)
                        {
                            Dr = Dt.Rows[i];
                            modelS.S_Id = int.Parse(Dr["S_Id"].ToString());
                            modelBR.U_Id = int.Parse(Dr["U_Id"].ToString());
                            modelBR.M_Id = int.Parse(Dr["M_Id"].ToString());
                            modelMovie.M_Id = int.Parse(Dr["M_Id"].ToString());

                            bllMovie.MovieUpdateFrequency(modelMovie);
                            bllBR.BringAndReturnsInsert(modelBR);
                            bllS.SCarDelete(modelS);
                        }

                        Response.Write("<script>alert('租赁成功!点击确定购买！');window.location='/Home/Home.aspx';</script>");
                    }
                }
            }
        }

        protected void Button4_Click(object sender, EventArgs e)
        {

            HttpCookie cookie = Request.Cookies["username"];
            DataRow Dr;

            if (cookie == null)
            {
                Response.Write("<script>alert('请先登录！');window.location='Login.aspx';</script>");
            }

            else
            {
                DataTable Dt = bllS.SelectedByU_Id(int.Parse(cookie["U_Id"]));
                if (Dt.Rows.Count == 0)
                {
                    Response.Write("<script>alert('购物车为空，请先添加电影！');</script>");
                }
                else
                {
                    if (int.Parse(cookie["U_Level"].ToString()) < 3)   //等级 1 2
                    {
                        Response.Write("<script>alert('等级不够！');</script>");
                    }

                    if (int.Parse(cookie["U_Level"].ToString()) > 2)   //等级 3
                    {
                        modelBR.B_Date = DateTime.Parse(DateTime.Now.ToString("yyyy-MM-dd"));
                        modelBR.R_Date = modelBR.B_Date.AddDays(30);         //一周
                        modelBR.B_Rent = 30;                                  //租金15

                        for (int i = 0; i < Dt.Rows.Count; i++)
                        {
                            Dr = Dt.Rows[i];
                            modelS.S_Id = int.Parse(Dr["S_Id"].ToString());
                            modelBR.U_Id = int.Parse(Dr["U_Id"].ToString());
                            modelBR.M_Id = int.Parse(Dr["M_Id"].ToString());
                            modelMovie.M_Id = int.Parse(Dr["M_Id"].ToString());

                            bllMovie.MovieUpdateFrequency(modelMovie);
                            bllBR.BringAndReturnsInsert(modelBR);
                            bllS.SCarDelete(modelS);
                        }

                        Response.Write("<script>alert('租赁成功!点击确定购买！');window.location='/Home/Home.aspx';</script>");
                    }
                }
            }
        }


        protected void GridView2_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int nRow = e.RowIndex;
            DataRow Dr;

            modelS.S_Id = int.Parse(GridView2.Rows[nRow].Cells[0].Text);
            modelMovie.M_Id = int.Parse(GridView2.Rows[nRow].Cells[2].Text);
            DataTable Dt = bllMovie.MovieQueryById(modelMovie.M_Id);

            if (Dt.Rows.Count == 0)
            {
                Response.Write("<Script>alert('没有此订单相关电影，相关电影存货变更失败。');</Script>");//在页面上输出一段脚本
                bllS.SCarDelete(modelS);
            }

            else
            {
                Dr = Dt.Rows[0];
                modelMovie.M_Id = int.Parse(Dr["M_Id"].ToString());
                modelMovie.M_Stock = int.Parse(Dr["M_Stock"].ToString()) + 1;                  //存货加一

                bllMovie.MovieUpdateStock(modelMovie);  
                bllS.SCarDelete(modelS);
            }
                      
            BindToGv();
        }

        protected void GridView1_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
        {
            int nRow = e.NewSelectedIndex;
            DataRow Dr;
            HttpCookie cookie = Request.Cookies["username"];
            if (cookie == null)
            {
                Response.Write("<script>alert('请先登录!');</script>");
                Response.Redirect("~/Account/Login.aspx");
            }
            else
            {
                modelMovie.M_Id = int.Parse(GridView1.Rows[nRow].Cells[0].Text);
                DataTable Dt = bllMovie.MovieQueryById(modelMovie.M_Id);
                Dr = Dt.Rows[0];

                if (int.Parse(Dr["M_Stock"].ToString()) < 1)
                {
                    Response.Write("<script>alert('暂时没有此电影存货！');</script>");
                }

                else
                {
                    modelS.U_Id = int.Parse(cookie["U_Id"]);
                    modelS.M_Id = int.Parse(Dr["M_Id"].ToString());
                    modelS.M_Name = Dr["M_Name"].ToString();
                    modelS.M_eName = Dr["M_eName"].ToString();
                    modelS.M_Picture = Dr["M_Picture"].ToString();
                    modelS.M_Intro = Dr["M_Intro"].ToString();

                    modelMovie.M_Id = int.Parse(Dr["M_Id"].ToString());
                    modelMovie.M_Stock = int.Parse(Dr["M_Stock"].ToString());

                    modelMovie.M_Stock--;
                    bllMovie.MovieUpdateStock(modelMovie);              //存货减一
                    bllS.SCarInserts(modelS);
                    Response.Write("<script>alert('添加到购物车成功！');</script>");
                    BindToGv();
                }
            }
        }
    }
}