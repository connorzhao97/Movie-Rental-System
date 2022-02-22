using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;

namespace MovieTeam.Account.Member
{
    public partial class DirectorAndActorManagement : System.Web.UI.Page
    {
        #region==全局对象==
        BLL.DirectorAndActor bllDA;
        Model.DirectorAndActor modelDA;
        #endregion
        #region==全局函数==
        private void InitGlobal()
        {
            bllDA = new BLL.DirectorAndActor("ConnectionString");
            modelDA = new Model.DirectorAndActor();
        }
        private void BindToGv()
        {
            gvDirectorAndActor.DataSource = bllDA.DandASelectByDA_DorA(bool.Parse(rblEnable.SelectedValue));
            gvDirectorAndActor.DataBind();
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

        protected void gvDirectorAndActor_RowEditing(object sender, GridViewEditEventArgs e)
        {
            gvDirectorAndActor.EditIndex = e.NewEditIndex;//指定当前控件被编辑的行号      
            BindToGv();                                    //先绑定数据，在显示按钮
            FileUpload fUpload = (FileUpload)gvDirectorAndActor.Rows[gvDirectorAndActor.EditIndex].Cells[6].FindControl("FileUpload_DA");
            Button btn = (Button)gvDirectorAndActor.Rows[gvDirectorAndActor.EditIndex].Cells[6].FindControl("DA_PictureBt");
            btn.Enabled = true;
            fUpload.Enabled = true;
        }

        protected void gvDirectorAndActor_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            gvDirectorAndActor.EditIndex = -1;
            BindToGv();
        }


        protected void gvDirectorAndActor_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvDirectorAndActor.PageIndex = e.NewPageIndex;
            BindToGv();
        }

        protected void gvDirectorAndActor_RowDataBound(object sender, GridViewRowEventArgs e)
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
                if (rblEnable.SelectedIndex == 0)//根据单选按钮的状态，决定界面上的文字提示
                {
                    lbtn.Text = "导演";
                }
                else
                {
                    lbtn.Text = "演员";
                }
            }
        }

        protected void rblEnable_SelectedIndexChanged(object sender, EventArgs e)
        {
            BindToGv();
        }

        protected void gvDirectorAndActor_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int nRow = e.RowIndex;
            modelDA.DA_Id = int.Parse(gvDirectorAndActor.Rows[nRow].Cells[0].Text);
            bllDA.DirectorAndActorDelete(modelDA);
            BindToGv();
        }

        protected void gvDirectorAndActor_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            int nRow = e.RowIndex;//获取当前的行号

            modelDA.DA_Id = int.Parse(gvDirectorAndActor.Rows[nRow].Cells[0].Text);//导演/演员编号列是只读的，因此直接获取该单元格的文本

            TextBox tb = (TextBox)gvDirectorAndActor.Rows[nRow].Cells[1].Controls[0];//用户名是放在文本框里面的（文本框即为该单元格的第一个控件）
            modelDA.M_Id = int.Parse(tb.Text.Trim());

            tb = (TextBox)gvDirectorAndActor.Rows[nRow].Cells[2].Controls[0];
            modelDA.DA_Name = tb.Text.Trim();

            tb = (TextBox)gvDirectorAndActor.Rows[nRow].Cells[3].Controls[0];
            modelDA.DA_EName = tb.Text.Trim();

            tb = (TextBox)gvDirectorAndActor.Rows[nRow].Cells[5].Controls[0];
            modelDA.DA_Intro = tb.Text.Trim();

            modelDA.DA_DorA = bool.Parse(rblEnable.SelectedValue);

            string updateMsg=bllDA.DirectorAndActorUpdate(modelDA);

            gvDirectorAndActor.EditIndex = -1;
            BindToGv();
            //存储过程执行后，Result参数中将会有值
            Response.Write("<Script>alert('" + updateMsg + "')</Script>");//在页面上输出一段脚本
        }

        protected void DA_Picture_Click(object sender, EventArgs e)
        {
            int nRow = gvDirectorAndActor.EditIndex;
            FileUpload fUpload = (FileUpload)gvDirectorAndActor.Rows[nRow].Cells[6].FindControl("FileUpload_DA");

            if (fUpload.HasFile)
            {
                string upPath = "/Image/DA_Picture/";  //上传文件路径
                int upLength = 5;        //上传文件大小
                string upFileType = "|image/bmp|image/x-png|image/pjpeg|image/gif|image/png|image/jpeg|";

                string fileContentType = fUpload.PostedFile.ContentType;    //文件类型

                if (upFileType.IndexOf(fileContentType.ToLower()) > 0)
                {
                    string name = fUpload.PostedFile.FileName;                  // 客户端文件路径

                    FileInfo file = new FileInfo(name);
                    TextBox tb = (TextBox)gvDirectorAndActor.Rows[nRow].Cells[2].Controls[0];
                    string fileName = tb.Text.Trim() + DateTime.Now.ToString("yyyyMMdd") + file.Extension; // 
                    string webFilePath = Server.MapPath(upPath) + fileName;        // 服务器端文件路径

                    string FilePath = upPath + fileName;   //页面中使用的路径

                    if ((fUpload.FileBytes.Length / (1024 * 1024)) > upLength)
                    {
                        ClientScript.RegisterStartupScript(this.GetType(), "upfileOK", "alert('大小超出 " + upLength + " M的限制，请处理后再上传！');", true);
                        return;
                    }

                    if (File.Exists(webFilePath))          //图片存在，删除此图片换成新上传的。
                    {
                        File.Delete(webFilePath);
                    }

                    try
                    {
                        fUpload.SaveAs(webFilePath);                                // 使用 SaveAs 方法保存文件


                        ClientScript.RegisterStartupScript(this.GetType(), "upfileOK", "alert('提示：文件上传成功');", true);
                        //绑定到数据库
                        modelDA.DA_Id = UInt16.Parse(gvDirectorAndActor.Rows[nRow].Cells[0].Text);
                        modelDA.DA_Picture = "~" + FilePath;
                            
                        string strMsg = bllDA.DAPictureUpdate(modelDA);
                            

                        //上传后设置按钮不可用
                        Button btn = (Button)gvDirectorAndActor.Rows[gvDirectorAndActor.EditIndex].Cells[6].FindControl("DA_PictureBt");
                        btn.Enabled = false;
                        fUpload.Enabled = false;

                        gvDirectorAndActor.EditIndex = -1;
                        BindToGv();
                    }
                    catch (Exception ex)
                    {
                        ClientScript.RegisterStartupScript(this.GetType(), "upfileOK", "alert('提示：文件上传失败" + ex.Message + "');", true);
                    }
                }
                else
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "upfileOK", "alert('提示：文件类型不符" + fileContentType + "');", true);
                }
            }

        }

        protected void gvDirectorAndActor_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
        {
            int nRow = e.NewSelectedIndex;
            modelDA.DA_Id = int.Parse(gvDirectorAndActor.Rows[nRow].Cells[0].Text);

            if (rblEnable.SelectedIndex == 0)
            {
                modelDA.DA_DorA = bool.Parse(rblEnable.Items[1].Value);//如果当前显示的是演员，则修改为导演
            }
            else
            {
                modelDA.DA_DorA = bool.Parse(rblEnable.Items[0].Value);//如果当前显示的是演员，则修改为导演
            }
            bllDA.UpdateDA_DorA(modelDA);
            BindToGv();
        }
    }
}