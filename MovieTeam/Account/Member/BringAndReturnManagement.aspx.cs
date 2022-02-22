using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MovieTeam.Account.Member
{
    public partial class BringAndReturnManagement : System.Web.UI.Page
    {
        #region==全局对象==
        BLL.BringAndReturn bllBR;
        BLL.Movie bllM;
        Model.Movie modelM;
        Model.BringAndReturn modelBR;
        #endregion
        #region==全局函数==
        private void InitGlobal()
        {
            bllBR = new BLL.BringAndReturn("ConnectionString");
            bllM = new BLL.Movie("ConnectionString");
            modelM = new Model.Movie();
            modelBR = new Model.BringAndReturn();
        }
        private void BindToGv()
        {
            gvBringAndReturn.DataSource = bllBR.BR_SelectedByBR_Return(bool.Parse(rblEnable.SelectedValue));
            gvBringAndReturn.DataBind();
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

        protected void gvBringAndReturn_RowEditing(object sender, GridViewEditEventArgs e)
        {
            gvBringAndReturn.EditIndex = e.NewEditIndex;//指定当前控件被编辑的行号      
            BindToGv();
        }

        protected void gvBringAndReturn_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            gvBringAndReturn.EditIndex = -1;
            BindToGv();
        }


        protected void gvBringAndReturn_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvBringAndReturn.PageIndex = e.NewPageIndex;
            BindToGv();
        }

        protected void gvBringAndReturn_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)//只对数据行进行处理
            {
                LinkButton lbtn;
                try//因为点击编辑按钮后，选择、删除按钮都被隐藏了，不可用
                {
                    lbtn = (LinkButton)e.Row.Cells[8].Controls[0];
                }
                catch
                {
                    return;
                }
                if (rblEnable.SelectedIndex == 0)//根据单选按钮的状态，决定界面上的文字提示
                {
                    lbtn.Text = "已经归还";
                }
                else
                {
                    lbtn.Text = "未归还(点击设为归还）";
                }
            }
        }

        protected void rblEnable_SelectedIndexChanged(object sender, EventArgs e)
        {
            BindToGv();
        }


        protected void gvBringAndReturn_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int nRow = e.RowIndex;
            modelBR.BR_Id = int.Parse(gvBringAndReturn.Rows[nRow].Cells[0].Text);
            bllBR.BringAndReturnsDelete(modelBR);
            BindToGv();
        }

        protected void gvBringAndReturn_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            int nRow = e.RowIndex;//获取当前的行号

            modelBR.BR_Id = int.Parse(gvBringAndReturn.Rows[nRow].Cells[0].Text);//评论编号，用户ID，用户名，电影ID是只读的，因此直接获取该单元格的文本

            modelBR.U_Id = int.Parse(gvBringAndReturn.Rows[nRow].Cells[1].Text);

            modelBR.M_Id = int.Parse(gvBringAndReturn.Rows[nRow].Cells[2].Text);

            modelBR.B_Date = DateTime.Parse(gvBringAndReturn.Rows[nRow].Cells[3].Text);

            TextBox tb = (TextBox)gvBringAndReturn.Rows[nRow].Cells[4].Controls[0];
            modelBR.R_Date = DateTime.Parse(tb.Text.Trim());

            tb = (TextBox)gvBringAndReturn.Rows[nRow].Cells[5].Controls[0];
            modelBR.B_Rent = float.Parse(tb.Text.Trim());

            modelBR.BR_Return = bool.Parse(rblEnable.Items[rblEnable.SelectedIndex].Value);

            string updateMsg = bllBR.BringAndReturnsUpdate(modelBR);

            gvBringAndReturn.EditIndex = -1;
            BindToGv();
            //存储过程执行后，Result参数中将会有值
            Response.Write("<Script>alert('" + updateMsg + "')</Script>");//在页面上输出一段脚本
        }

        protected void gvBringAndReturn_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
        {
            int nRow = e.NewSelectedIndex;
            modelBR.BR_Id = int.Parse(gvBringAndReturn.Rows[nRow].Cells[0].Text);

            if (rblEnable.SelectedIndex == 1)   //如果当前未归还，可以设为归还，归还了就不可以设为未归还
            {
                modelBR.BR_Return = bool.Parse(rblEnable.Items[0].Value);

                modelM.M_Id = int.Parse(gvBringAndReturn.Rows[nRow].Cells[2].Text);     //获取电影ID，存货 规划存货+1
                DataTable Dt = bllM.MovieQueryById(modelM.M_Id);
                if (Dt.Rows.Count == 0)
                {
                    Response.Write("<Script>alert('没有此订单相关电影Id，相关电影存货变更失败。');</Script>");//在页面上输出一段脚本
                    bllBR.UpdateEnable(modelBR);
                }
                else
                {
                    DataRow Dr = Dt.Rows[0];
                    modelM.M_Stock = int.Parse(Dr["M_Stock"].ToString()) + 1;

                    bllM.MovieUpdateStock(modelM);
                    bllBR.UpdateEnable(modelBR);
                }
            }
            BindToGv();
        }
    }
}