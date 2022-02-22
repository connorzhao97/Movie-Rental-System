using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

namespace MovieTeam.Account.Member
{
    public partial class UserManagement : System.Web.UI.Page
    {
        #region==全局对象==
        BLL.User bllUser;
        Model.User modelUser;
        #endregion
        #region==全局函数==
        private void InitGlobal()
        {
            bllUser = new BLL.User("ConnectionString");
            modelUser = new Model.User();
        }
        private void BindToGv()
        {
            GridView1.DataSource = bllUser.UsersSelectByEnable(bool.Parse(rblEnable.SelectedValue));
            GridView1.DataBind();
        }
        #endregion
        protected void Page_Load(object sender, EventArgs e)
        {
            HttpCookie cookie = Request.Cookies["username"];
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

        protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
        {
            GridView1.EditIndex = e.NewEditIndex;
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

        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)//只对数据行进行处理
            {
                LinkButton lbtn;
                lbtn = (LinkButton)e.Row.Cells[8].Controls[0];
                if (rblEnable.SelectedIndex == 0)//根据单选按钮的状态，决定界面上的文字提示
                {
                    lbtn.Text = "禁用";
                }
                else
                {
                    lbtn.Text = "启用";
                }
            }

        }

        protected void rblEnable_SelectedIndexChanged(object sender, EventArgs e)
        {
            BindToGv();
        }

        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int nRow = e.RowIndex;
            modelUser.U_Id = int.Parse(GridView1.Rows[nRow].Cells[0].Text);
            bllUser.UsersDelete(modelUser);
            BindToGv();          
        }

        protected void GridView1_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
        {
            int nRow = e.NewSelectedIndex;
            modelUser.U_Id = int.Parse(GridView1.Rows[nRow].Cells[0].Text);

            if (rblEnable.SelectedIndex == 0)
            {
                modelUser.U_Enable = bool.Parse(rblEnable.Items[1].Value);//如果当前显示的是已启用，则修改为禁用
            }
            else
            {
                modelUser.U_Enable = bool.Parse(rblEnable.Items[0].Value);//如果当前显示的是已启用，则修改为禁用
            }
            bllUser.UsersEnable(modelUser);
            BindToGv();
        }
    }
}