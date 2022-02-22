using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MovieTeam.Account.Member
{
    public partial class HasBring : System.Web.UI.Page
    {
        #region==全局对象==
        BLL.BringAndReturn bllBR;
        Model.BringAndReturn modelBR;
        string U_Name = "Text1";
        #endregion
        #region==全局函数==
        /// <summary>
        /// 初始化函数
        /// </summary>
        private void InitGlobal()
        {
           
            bllBR = new BLL.BringAndReturn("ConnectionString");
            modelBR = new Model.BringAndReturn();
        }
        /// <summary>
        /// 显示消息对话框
        /// </summary>
        /// <param name="strMsg"></param>
        private void ShowMsg(string strMsg)
        {
            Response.Write("<script>alert('" + strMsg + "')</script>");
        }

        private void BindToGv()
        {
            HttpCookie cookie = Request.Cookies["username"];
            gvBringAndReturn.DataSource = bllBR.BR_SelectedByU_Id(int.Parse(cookie["U_Id"].ToString()));
            gvBringAndReturn.DataBind();
        }
        
        #endregion
        
        protected void Page_Load(object sender, EventArgs e)
        {
            HttpCookie cookie = Request.Cookies["username"];
            if (cookie != null)
            {
                U_Name = cookie["U_Name"];
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
    }
}