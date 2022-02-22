using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MovieTeam.Account.Member
{
    public partial class FunctionManagement : System.Web.UI.Page
    {
        #region==全局对象==
        BLL.Function bllFunction;
        Model.Function modelFunction;

        #endregion
        #region==全局函数==
        /// <summary>
        /// 初始化函数
        /// </summary>
        private void InitGlobal()
        {
            bllFunction = new BLL.Function("ConnectionString");//ConnectionString是在Web.Config文件中配置的数据库连接字符串
            modelFunction = new Model.Function();
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
            GridView1.DataSource = bllFunction.FunctionView();
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

        protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            int nRow = e.RowIndex;
            modelFunction.F_Id = UInt16.Parse(GridView1.Rows[nRow].Cells[0].Text);

            TextBox tb = (TextBox)GridView1.Rows[nRow].Cells[1].Controls[0];
            modelFunction.F_Name = tb.Text.Trim();

            tb = (TextBox)GridView1.Rows[nRow].Cells[2].Controls[0];
            modelFunction.F_Path = tb.Text.Trim();

            tb = (TextBox)GridView1.Rows[nRow].Cells[3].Controls[0];
            modelFunction.F_ParentId = UInt16.Parse(tb.Text.Trim());

            string strMsg = bllFunction.FunctionUpdate(modelFunction);
            ShowMsg(strMsg);

            GridView1.EditIndex = -1;
            BindToGv();
        }

        protected void GridView1_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
        {
            int nRow = e.NewSelectedIndex;
            modelFunction.F_Id = UInt16.Parse(GridView1.Rows[nRow].Cells[0].Text);
            if (GridView1.Rows[nRow].Cells[4].Text == "已启用")
            {
                modelFunction.F_Enable = false;
            }
            else
            {
                modelFunction.F_Enable = true;
            }
            bllFunction.FunctionUpdateEnable(modelFunction);
            BindToGv();
        }

        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int nRow = e.RowIndex;
            modelFunction.F_Id = UInt16.Parse(GridView1.Rows[nRow].Cells[0].Text);
            bllFunction.FunctionDelete(modelFunction);
            BindToGv();

        }

        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                //设置禁用/启用按钮的文本
                try//当点击编辑按钮后，其他的按钮控件都被隐藏了，因此，这里要用异常处理
                {
                    LinkButton lbtn = (LinkButton)e.Row.Cells[7].Controls[0];
                    if (e.Row.Cells[4].Text == "True")
                    {
                        lbtn.Text = "禁用";
                    }
                    else
                    {
                        lbtn.Text = "启用";
                    }
                }
                catch
                { }
                //设置禁用/启用状态的文本
                if (e.Row.Cells[4].Text == "True")
                {
                    e.Row.Cells[4].Text = "已启用";
                }
                else
                {
                    e.Row.Cells[4].Text = "已禁用";
                }
            }

        }

        protected void Button_insert_Click(object sender, EventArgs e)
        {
            TextBox tb = (TextBox)TextBox_name;
            modelFunction.F_Name = tb.Text.Trim();

            tb = (TextBox)TextBox_path;
            modelFunction.F_Path = tb.Text.Trim();

            tb = (TextBox)TextBox_pid;
            modelFunction.F_ParentId = UInt16.Parse(tb.Text.Trim());

            string strMsg = bllFunction.FunctionInsert(modelFunction);
            ShowMsg(strMsg);

            BindToGv();
        }
    }
}