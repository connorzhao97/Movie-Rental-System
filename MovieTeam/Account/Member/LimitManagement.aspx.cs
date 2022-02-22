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
    public partial class LimitManagement : System.Web.UI.Page
    {
        #region==全局对象==
        BLL.Limit bllLimit;
        Model.Limit modelLimit;

        #endregion
        #region==全局函数==
        /// <summary>
        /// 初始化函数
        /// </summary>
        private void InitGlobal()
        {
            bllLimit = new BLL.Limit("ConnectionString");//ConnectionString是在Web.Config文件中配置的数据库连接字符串
            modelLimit = new Model.Limit();
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
            GridView1.DataSource = bllLimit.LimitView();
            GridView1.DataBind();
        }
        /// <summary>
        /// 将角色名数据绑定到DropDownList控件上
        /// </summary>
        private void BindToDDLC()
        {
            DropDownList_cname.DataSource = bllLimit.CharacterName();
            DropDownList_cname.DataTextField = "Ch_Name";
            DropDownList_cname.DataValueField = "Ch_Id";
            DropDownList_cname.DataBind();
            DropDownList_cname.Items.Insert(0, new ListItem("", ""));//插入空项，此项必须放到数据绑定之后
        }
        /// <summary>
        /// 将角色名数据绑定到DropDownList控件上
        /// </summary>
        private void BindToDDLF()
        {
            DropDownList_fname.DataSource = bllLimit.FunctionName();
            DropDownList_fname.DataTextField = "F_Name";
            DropDownList_fname.DataValueField = "F_Id";
            DropDownList_fname.DataBind();
            DropDownList_fname.Items.Insert(0, new ListItem("", ""));//插入空项，此项必须放到数据绑定之后
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
                    BindToDDLF();
                    BindToDDLC();
                    BindToGv();

                }
            }
            else
            {
                Response.Redirect("~/Account/Login.aspx");
            }
            
        }

        protected void Button_insert_Click(object sender, EventArgs e)
        {
            modelLimit.Ch_Id= UInt16.Parse(DropDownList_cname.Text.Trim());
            modelLimit.F_Id = UInt16.Parse(DropDownList_fname.Text.Trim());

            string strMsg = bllLimit.LimitInsert(modelLimit);
            ShowMsg(strMsg);

            BindToGv();
        }

        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView1.PageIndex = e.NewPageIndex;
            BindToGv();
        }

        protected void GridView1_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            GridView1.EditIndex = -1;
            BindToGv();
        }

        protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
        {
            GridView1.EditIndex = e.NewEditIndex;

            BindToGv();
        }

        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int nRow = e.RowIndex;
            modelLimit.L_Id = UInt16.Parse(GridView1.Rows[nRow].Cells[0].Text);
            bllLimit.LimitDelete(modelLimit);
            BindToGv();
        }

      

        protected void GridView1_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
        {
            int nRow = e.NewSelectedIndex;
            modelLimit.L_Id = UInt16.Parse(GridView1.Rows[nRow].Cells[0].Text);
            if (GridView1.Rows[nRow].Cells[3].Text == "已启用")
            {
                modelLimit.L_Enable = false;
            }
            else
            {
                modelLimit.L_Enable = true;
            }
            bllLimit.LimitUpdateEnable(modelLimit);
            BindToGv();
        }

        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                //设置禁用/启用按钮的文本
                try//当点击编辑按钮后，其他的按钮控件都被隐藏了，因此，这里要用异常处理
                {
                    LinkButton lbtn = (LinkButton)e.Row.Cells[6].Controls[0];
                    if (e.Row.Cells[3].Text == "True")
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
                if (e.Row.Cells[3].Text == "True")
                {
                    e.Row.Cells[3].Text = "已启用";
                }
                else
                {
                    e.Row.Cells[3].Text = "已禁用";
                }
            }
        }

        protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            int nRow = e.RowIndex;
            modelLimit.L_Id = UInt16.Parse(GridView1.Rows[nRow].Cells[0].Text);

            TextBox tb = (TextBox)GridView1.Rows[nRow].Cells[1].Controls[0];
            modelLimit.Ch_Name = tb.Text.Trim();

            tb = (TextBox)GridView1.Rows[nRow].Cells[2].Controls[0];
            modelLimit.F_Name = tb.Text.Trim();

  

            string strMsg = bllLimit.LimitUpdate(modelLimit);
            ShowMsg(strMsg);

            GridView1.EditIndex = -1;
            BindToGv();
        }
    }
}