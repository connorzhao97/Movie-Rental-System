using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace BLL
{
    public class User
    {
        DAL.User dal;
        public User(string strConnectionStringName)
        {
            dal = new DAL.User(strConnectionStringName);
        }

        /// <summary>
        /// 查询全部用户
        /// </summary>
        public DataTable UsersView()
        {
            return dal.UsersView();
        }
        /// <summary>
        /// 按用户名查询用户
        /// </summary>
        /// <param name="Uname"></param>
        /// <returns></returns>
        public DataTable UsersSelectByName(String Uname)
        {
            return dal.UsersSelectByName(Uname);
        }

        /// <summary>
        /// 忘记密码用是否存在邮箱
        /// </summary>
        /// <param name="Uname"></param>
        /// <returns></returns>
        public int UserSelectByEmail(String U_Email)
        {
            return dal.UserSelectByEmail(U_Email);
        }

        /// <summary>
        /// 按用户等级查询
        /// </summary>
        /// <param name="Level"></param>
        /// <returns></returns>
        public DataTable UserSelectedByLevel(int Level)
        {
            return dal.UserSelectedByLevel(Level);
        }

        /// <summary>
        /// 按用户名和密码查询用户 登录使用
        /// </summary>
        /// <param name="Umodel"></param>
        public string UsersLogin(Model.User Umodel)
        {
            return dal.UsersLogin(Umodel);
        }

        /// <summary>
        /// 添加用户
        /// </summary>
        /// <param name="Umodel"></param>
        public string UsersInsert(Model.User Umodel)
        {
            return dal.UsersInsert(Umodel);
        }

        /// <summary>
        /// 查询禁用/启用用户
        /// </summary>
        /// <param name="SelectedValue"></param>
        /// <returns></returns>
        public DataTable UsersSelectByEnable(bool SelectedValue)
        {
            return dal.UsersSelectByEnable(SelectedValue);
        }

        /// <summary>
        /// 用户信息修改
        /// </summary>
        /// <param name="Umodel"></param>
        /// <returns></returns>
        public string UsersUpdate(Model.User Umodel)
        {
            return dal.UsersUpdate(Umodel);
        }

        /// <summary>
        /// 密码修改
        /// </summary>
        /// <param name="Umodel"></param>
        public void UserPassUpdate(Model.User Umodel)
        {
            dal.UserPassUpdate(Umodel);
        }

        /// <summary>
        /// 用户图片修改
        /// </summary>
        /// <param name="Umodel"></param>
        /// <returns></returns>
        public string UsersPictureUpdate(Model.User Umodel)
        {
            return dal.UsersPictureUpdate(Umodel);
        }

        /// <summary>
        /// 删除用户
        /// </summary>
        /// <param name="Umodel"></param>
        public void UsersDelete(Model.User Umodel)
        {
            dal.UsersDelete(Umodel);
        }

        /// <summary>
        /// 启用/禁用用户
        /// </summary>
        /// <param name="Umodel"></param>
        public void UsersEnable(Model.User Umodel)
        {
            dal.UsersEnable(Umodel);
        }

        /// <summary>
        /// 用户个人信息修改（不带图）
        /// </summary>
        /// <param name="Umodel"></param>
        /// <returns></returns>
        public string UserInformationUpdate(Model.User Umodel)
        {
            return dal.UserInformationUpdate(Umodel);
        }
        /// <summary>
        /// 用户个人信息修改（带图）
        /// </summary>
        /// <param name="Umodel"></param>
        /// <returns></returns>
        public string pUserInformationUpdate(Model.User Umodel)
        {
            return dal.pUserInformationUpdate(Umodel);
        }
        /// <summary>
        /// 将验证码写入数据库
        /// </summary>
        /// <param name="U_Code"></param>
        /// <returns></returns>
        public void UsersCodeIn(String U_Code, String U_Name)
        {
            dal.UsersCodeIn( U_Code, U_Name);
        }

        public void UserCodeByE(String U_Code, String U_Email)
        {
            dal.UserCodeByE(U_Code, U_Email);
        }
        /// <summary>
        /// 将验证码读出数据库
        /// </summary>
        /// <param name="U_Name"></param>
        /// <returns></returns>
        public String UsersCodeOut(String U_Name)
        {
            return dal.UsersCodeOut(U_Name);
        }
        /// <summary>
        /// 将验证码读出数据库
        /// </summary>
        /// <param name="U_Name"></param>
        /// <returns></returns>
        public String UsersCodeOutByE(String U_Email)
        {
            return dal.UsersCodeOutByE(U_Email);
        }
        /// <summary>
        /// 将验证通过写入数据库
        /// </summary>
        /// <param name="U_Confirm"></param>
        /// <returns></returns>
        public void UsersConfirmPass(String U_Name)
        {
            dal.UsersConfirmPass(U_Name);
        }
        /// <summary>
        /// 忘记密码返回密码
        /// </summary>
        /// <param name="U_Email"></param>
        public String Pass(String U_Email)
        {
            return dal.Pass(U_Email);
        }
    }
}
