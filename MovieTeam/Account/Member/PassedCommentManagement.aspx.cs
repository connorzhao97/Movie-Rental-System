using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MovieTeam.Account.Member
{
    public partial class PassedCommentManage : System.Web.UI.Page
    {
        #region==全局对象==
        BLL.Comment bllCom;
        Model.Comment modelCom;
        #endregion
        #region==全局函数==
        private void InitGlobal()
        {
            bllCom = new BLL.Comment("ConnectionString");
            modelCom = new Model.Comment();
        }
        private void BindToGv()
        {
            gvCommet.DataSource = bllCom.CommentsSelectByEnable(true);
            gvCommet.DataBind();
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

        protected void gvCommet_RowEditing(object sender, GridViewEditEventArgs e)
        {
            gvCommet.EditIndex = e.NewEditIndex;//指定当前控件被编辑的行号      
            BindToGv();
        }

        protected void gvCommet_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            gvCommet.EditIndex = -1;
            BindToGv();
        }


        protected void gvCommet_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvCommet.PageIndex = e.NewPageIndex;
            BindToGv();
        }

        protected void gvCommet_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)//只对数据行进行处理
            {
                LinkButton lbtn;
                try//因为点击编辑按钮后，选择、删除按钮都被隐藏了，不可用
                {
                    lbtn = (LinkButton)e.Row.Cells[7].Controls[0];
                }
                catch
                {
                    return;
                }
            }
        }

        protected void gvCommet_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int nRow = e.RowIndex;
            modelCom.Com_Id = int.Parse(gvCommet.Rows[nRow].Cells[0].Text);
            bllCom.CommentsDelete(modelCom);
            BindToGv();
        }

        protected void gvCommet_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            int nRow = e.RowIndex;//获取当前的行号

            modelCom.Com_Id = int.Parse(gvCommet.Rows[nRow].Cells[0].Text);//评论编号，用户ID，用户名，电影ID是只读的，因此直接获取该单元格的文本

            modelCom.U_Id = int.Parse(gvCommet.Rows[nRow].Cells[1].Text);

            modelCom.U_Name = (gvCommet.Rows[nRow].Cells[2].Text).Trim();

            modelCom.M_Id = int.Parse(gvCommet.Rows[nRow].Cells[3].Text);

            TextBox tb = (TextBox)gvCommet.Rows[nRow].Cells[4].Controls[0];
            modelCom.Com_Grade = float.Parse(tb.Text.Trim());

            tb = (TextBox)gvCommet.Rows[nRow].Cells[5].Controls[0];
            modelCom.Com_Date = DateTime.Parse(tb.Text.Trim());

            tb = (TextBox)gvCommet.Rows[nRow].Cells[6].Controls[0];
            modelCom.Com_Content = tb.Text.Trim();

            modelCom.Com_Enable = true;

            string updateMsg = bllCom.CommentsUpdate(modelCom);

            gvCommet.EditIndex = -1;
            BindToGv();
            //存储过程执行后，Result参数中将会有值
            Response.Write("<Script>alert('" + updateMsg + "')</Script>");//在页面上输出一段脚本
        }

        protected void gvCommet_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
        {
            int nRow = e.NewSelectedIndex;
            modelCom.Com_Id = int.Parse(gvCommet.Rows[nRow].Cells[0].Text);
            modelCom.Com_Enable = false;

            bllCom.UpdateEnable(modelCom);
            BindToGv();
        }
    }
}