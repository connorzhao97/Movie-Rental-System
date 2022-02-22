using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DBUtility;
using System.Data;
using System.Data.SqlClient;

namespace DAL
{
    public class User
    {
        sqlHelpers sql = null;
        /// <summary>
        /// 构造函数初始化
        /// </summary>
        /// <param name="strConnectionStringName"></param>
        public User(string strConnectionStringName)
        {
            sql = new sqlHelpers(strConnectionStringName);
        }

        /// <summary>
        /// 查询全部用户 返回DataTable(Udt)
        /// </summary>
        /// <returns></returns>
        public DataTable UsersView()
        {
            String sq = "select * from [User]";
            sql.ExecuteTextReturnDataTable(sq);
            DataTable Udt = new DataTable();
            Udt = sql.ExecuteTextReturnDataTable(sq);
            return Udt;
        }

        /// <summary>
        /// 按用户等级查询
        /// </summary>
        /// <param name="Level"></param>
        /// <returns></returns>
        public DataTable UserSelectedByLevel(int Level)
        {

            String sq = "select * from [User] where U_Level = '" + Level + "'";
            sql.ExecuteTextReturnDataTable(sq);
            DataTable Udt = new DataTable();
            Udt = sql.ExecuteTextReturnDataTable(sq);
            return Udt;
        }

        /// <summary>
        /// 按用户名查询 返回DataTable
        /// </summary>
        /// <param name="Mname"></param>
        /// <returns></returns>
        public DataTable UsersSelectByName(String Uname)
        {
            String sq = "select * from [User] where U_Name = '" + Uname + "'";
            sql.ExecuteTextReturnDataTable(sq);
            DataTable Udt = new DataTable();
            Udt = sql.ExecuteTextReturnDataTable(sq);
            return Udt;
        }

        public int UserSelectByEmail(String U_Email)
        {
            String sq = "select * from [User] where U_Email = '" + U_Email + "'";
            return sql.ExecuteTextReturnDataTable(sq).Rows.Count;
        }

        /// <summary>
        /// 按用户名和密码查询用户 登录使用
        /// </summary>
        /// <param name="Umodel"></param>
        /// <returns></returns>
        public string UsersLogin(Model.User Umodel)
        {
            string cmdText = "P_UsersLogin";
            SqlParameter[] Sps = new SqlParameter[3];

            Sps[0] = new SqlParameter("@U_Name", SqlDbType.NVarChar, 50);
            Sps[0].Value = Umodel.U_Name;

            Sps[1] = new SqlParameter("@U_Pass", SqlDbType.NVarChar, 50);
            Sps[1].Value = Umodel.U_Pass;

            Sps[2] = new SqlParameter("@Result", SqlDbType.Int);
            Sps[2].Direction = ParameterDirection.Output;

            sql.ExecuteProcReturnString(cmdText, Sps);
            return Convert.ToString(Sps[2].Value);
        }

        ///<summary>
        ///添加新用户 注册使用
        ///</summary>
        public string UsersInsert(Model.User Umodel)
        {
            string cmdText = "P_UsersInsert";
            SqlParameter[] Sps = new SqlParameter[4];

            Sps[0] = new SqlParameter("@U_Name", SqlDbType.NVarChar, 50);
            Sps[0].Value = Umodel.U_Name;

            Sps[1] = new SqlParameter("@U_Pass", SqlDbType.NVarChar, 50);
            Sps[1].Value = Umodel.U_Pass;

            Sps[2] = new SqlParameter("@U_Email", SqlDbType.NVarChar, 50);
            Sps[2].Value = Umodel.U_Email;

            Sps[3] = new SqlParameter("@Result", SqlDbType.Int);
            Sps[3].Direction = ParameterDirection.Output;

            sql.ExecuteProcReturnString(cmdText, Sps);
            return Convert.ToString(Sps[3].Value);
        }

        /// <summary>
        /// 用户信息修改
        /// </summary>
        /// <param name="Umodel"></param>
        /// <returns></returns>
        public string UsersUpdate(Model.User Umodel)
        {
            string cmdText = "P_UsersUpdate";
            SqlParameter[] Sps = new SqlParameter[9];
            Sps[0] = new SqlParameter("@U_Id", SqlDbType.Int);
            Sps[0].Value = Umodel.U_Id;

            Sps[1] = new SqlParameter("@U_Name", SqlDbType.NVarChar, 50);
            Sps[1].Value = Umodel.U_Name;

            Sps[2] = new SqlParameter("@U_Pass", SqlDbType.NVarChar, 50);
            Sps[2].Value = Umodel.U_Pass;

            Sps[3] = new SqlParameter("@U_Email", SqlDbType.NVarChar, 50);
            Sps[3].Value = Umodel.U_Email;

            Sps[4] = new SqlParameter("@U_Nickname", SqlDbType.NVarChar, 50);
            Sps[4].Value = Umodel.U_Nickname;

            Sps[5] = new SqlParameter("@U_Gender", SqlDbType.NVarChar, 50);
            Sps[5].Value = Umodel.U_Gender;

            Sps[6] = new SqlParameter("@U_Address", SqlDbType.NVarChar, 50);
            Sps[6].Value = Umodel.U_Address;

            Sps[7] = new SqlParameter("@U_Level", SqlDbType.Int);
            Sps[7].Value = Umodel.U_Level;

            Sps[8] = new SqlParameter("@Result", SqlDbType.NVarChar, 100);
            Sps[8].Direction = ParameterDirection.Output;

            sql.ExecuteProcReturnString(cmdText, Sps);
            return Sps[8].Value.ToString();

        }

        /// <summary>
        /// 修改密码
        /// </summary>
        /// <param name="Umodel"></param>
        public void UserPassUpdate(Model.User Umodel)
        {
            String sq = "Update [User] set U_Pass ='" + Umodel.U_Pass + "'" + "where U_Name = '" + Umodel.U_Name + "'";
            sql.ExecuteTextReturnVoid(sq);
        }

        /// <summary>
        /// 个人信息修改（不带图）
        /// </summary>
        /// <param name="Umodel"></param>
        /// <returns></returns>
        public string UserInformationUpdate(Model.User Umodel)
        {
            string cmdText = "P_UserInformationUpdate";
            SqlParameter[] Sps = new SqlParameter[6];
            Sps[0] = new SqlParameter("@U_Name", SqlDbType.NVarChar, 50);
            Sps[0].Value = Umodel.U_Name;

            Sps[1] = new SqlParameter("@U_Nickname", SqlDbType.NVarChar, 50);
            Sps[1].Value = Umodel.U_Nickname;

            Sps[2] = new SqlParameter("@U_Gender", SqlDbType.NVarChar, 50);
            Sps[2].Value = Umodel.U_Gender;

            Sps[3] = new SqlParameter("@U_Email", SqlDbType.NVarChar, 50);
            Sps[3].Value = Umodel.U_Email;

            Sps[4] = new SqlParameter("@U_Address", SqlDbType.NVarChar, 50);
            Sps[4].Value = Umodel.U_Address;

            Sps[5] = new SqlParameter("@Result", SqlDbType.NVarChar, 100);
            Sps[5].Direction = ParameterDirection.Output;

            sql.ExecuteProcReturnString(cmdText, Sps);
            return Sps[5].Value.ToString();

        }
        /// <summary>
        /// 个人信息修改（带图）
        /// </summary>
        /// <param name="Umodel"></param>
        /// <returns></returns>
        public string pUserInformationUpdate(Model.User Umodel)
        {
            string cmdText = "P_pUserInformationUpdate";
            SqlParameter[] Sps = new SqlParameter[7];
            Sps[0] = new SqlParameter("@U_Name", SqlDbType.NVarChar, 50);
            Sps[0].Value = Umodel.U_Name;

            Sps[1] = new SqlParameter("@U_Nickname", SqlDbType.NVarChar, 50);
            Sps[1].Value = Umodel.U_Nickname;

            Sps[2] = new SqlParameter("@U_Gender", SqlDbType.NVarChar, 50);
            Sps[2].Value = Umodel.U_Gender;

            Sps[3] = new SqlParameter("@U_Email", SqlDbType.NVarChar, 50);
            Sps[3].Value = Umodel.U_Email;

            Sps[4] = new SqlParameter("@U_Address", SqlDbType.NVarChar, 50);
            Sps[4].Value = Umodel.U_Address;

            Sps[5] = new SqlParameter("@U_Picture", SqlDbType.NVarChar, 255);
            Sps[5].Value = Umodel.U_Picture;

            Sps[6] = new SqlParameter("@Result", SqlDbType.NVarChar, 100);
            Sps[6].Direction = ParameterDirection.Output;

            sql.ExecuteProcReturnString(cmdText, Sps);
            return Sps[6].Value.ToString();

        }
        /// <summary>
        /// 删除用户
        /// </summary>
        /// <param name="Umodel"></param>
        public void UsersDelete(Model.User Umodel)
        {
            string cmdText = "P_UsersDelete";
            SqlParameter[] Sps = new SqlParameter[1];

            Sps[0] = new SqlParameter("@U_Id", SqlDbType.Int);
            Sps[0].Value = Umodel.U_Id;

            sql.ExecuteProcReturnVoid(cmdText, Sps);
        }

        /// <summary>
        /// 查询禁用/启用用户
        /// </summary>
        /// <param name="SelectedValue"></param>
        /// <returns></returns>
        public DataTable UsersSelectByEnable(bool SelectedValue)
        {
            string cmdText = "P_UsersSelectByEnable";//命令文本为存储过程名 
            SqlParameter[] Sp = new SqlParameter[1];
            Sp[0] = new SqlParameter("@U_Enable", SqlDbType.Bit);//设置存储过程的参数
            Sp[0].Value = SelectedValue;
            return sql.ExecuteProcReturnDataTable(cmdText, Sp);
        }

        /// <summary>
        /// 启用/禁用用户
        /// </summary>
        /// <param name="Umodel"></param>
        public void UsersEnable(Model.User Umodel)
        {
            string cmdText = "P_UsersEnable";//命令文本为存储过程名 
            SqlParameter[] Sp = new SqlParameter[2];

            Sp[0] = new SqlParameter("@U_Id", SqlDbType.Int);//设置存储过程的参数
            Sp[0].Value = Umodel.U_Id;

            Sp[1] = new SqlParameter("@U_Enable", SqlDbType.Bit);//设置存储过程的参数
            Sp[1].Value = Umodel.U_Enable;

            sql.ExecuteProcReturnVoid(cmdText, Sp);
        }

        /// <summary>
        /// 更新用户图片
        /// </summary>
        /// <param name="Umodel"></param>
        /// <returns></returns>
        public string UsersPictureUpdate(Model.User Umodel)
        {
            string cmdText = "P_UsersPictureUpdate";
            SqlParameter[] Sps = new SqlParameter[3];
            Sps[0] = new SqlParameter("@U_Id", SqlDbType.Int);
            Sps[0].Value = Umodel.U_Id;

            Sps[1] = new SqlParameter("@U_Picture", SqlDbType.NVarChar, 255);
            Sps[1].Value = Umodel.U_Picture;

            Sps[2] = new SqlParameter("@Result", SqlDbType.NVarChar, 100);
            Sps[2].Direction = ParameterDirection.Output;

            sql.ExecuteProcReturnString(cmdText, Sps);
            return Sps[2].Value.ToString();

        }
        /// <summary>
        /// 将验证码写入数据库
        /// </summary>
        /// <param name="U_Code"></param>
        /// <returns></returns>
        public void UsersCodeIn(String U_Code, String U_Name)
        {
            String sq = "update [User] set U_Code='" + U_Code + "' where U_Name= '" + U_Name + "'";
            sql.ExecuteTextReturnVoid(sq);

        }
        public void UserCodeByE(String U_Code, String U_Email)
        {
            String sq = "update [User] set U_Code='" + U_Code + "' where U_Email= '" + U_Email + "'";
            sql.ExecuteTextReturnVoid(sq);
        }
        /// <summary>
        /// 将验证码读出数据库
        /// </summary>
        /// <param name="U_Code"></param>
        /// <returns></returns>
        public String UsersCodeOut(String U_Name)
        {
            String sq = "select U_Code from [User] where U_Name= '" + U_Name + "'";
            String U_Code = sql.ExecuteTextReturnString(sq);
            return U_Code;

        }
        /// <summary>
        /// 将验证码读出数据库
        /// </summary>
        /// <param name="U_Code"></param>
        /// <returns></returns>
        public String UsersCodeOutByE(String U_Email)
        {
            String sq = "select U_Code from [User] where U_Email= '" + U_Email + "'";
            String U_Code = sql.ExecuteTextReturnString(sq);
            return U_Code;
        }
        /// <summary>
        /// 将验证通过写入数据库
        /// </summary>
        /// <param name="U_Confirm"></param>
        /// <returns></returns>
        public void UsersConfirmPass(String U_Name)
        {
            String sq = "update [User] set U_Confirm = 1  where U_Name= '" + U_Name + "'";
            sql.ExecuteTextReturnString(sq);


        }
        /// <summary>
        /// 忘记密码返回密码
        /// </summary>
        /// <param name="U_Email"></param>
        /// <returns></returns>
        public String Pass(String U_Email)
        {
            String sq = "select U_Pass from [User] where U_Email= '" + U_Email + "'";
            return sql.ExecuteTextReturnString(sq);
        }
    }
}
