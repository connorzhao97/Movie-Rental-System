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
    public class Limit
    {
        /// <summary>
        /// 全局变量
        /// </summary>
        sqlHelpers sql = null;
        /// <summary>
        /// 构造函数初始化
        /// </summary>
        /// <param name="strConnectionStringName"></param>
        public Limit(string strConnectionStringName)
        {
            sql = new sqlHelpers(strConnectionStringName);
        }

        /// <summary>
        /// 查询全部权限 返回DataTable(Cdt)
        /// </summary>
        /// <returns></returns>
        public DataTable LimitView()
        {
            String sq = "select * from V_Limit";
            sql.ExecuteTextReturnDataTable(sq);
            DataTable Cdt = new DataTable();
            Cdt = sql.ExecuteTextReturnDataTable(sq);
            return Cdt;
        }

        /// <summary>
        /// 查询全部功能 返回DataTable(Cdt)
        /// </summary>
        /// <returns></returns>
        public DataTable FunctionName()
        {
            String sq = "select * from [Function]";
            sql.ExecuteTextReturnDataTable(sq);
            DataTable Cdt = new DataTable();
            Cdt = sql.ExecuteTextReturnDataTable(sq);
            return Cdt;
        }
        /// <summary>
        /// 查询全部角色 返回DataTable(Cdt)
        /// </summary>
        /// <returns></returns>
        public DataTable CharacterName()
        {
            String sq = "select * from [Character]";
            sql.ExecuteTextReturnDataTable(sq);
            DataTable Cdt = new DataTable();
            Cdt = sql.ExecuteTextReturnDataTable(sq);
            return Cdt;
        }

        /// <summary>
        /// 添加权限（函数名就是存储过程名，建议去掉P_）
        /// </summary>
        /// <param name="model">权限表模型层对象</param>
        /// <returns>是否添加成功的提示</returns>
        public string LimitInsert(Model.Limit model)
        {
            string cmdText = "P_LimitInsert";
            SqlParameter[] Sps = new SqlParameter[3];
            Sps[0] = new SqlParameter("@F_Id", SqlDbType.Int);
            Sps[0].Value = model.F_Id;

            Sps[1] = new SqlParameter("@Ch_Id", SqlDbType.Int);
            Sps[1].Value = model.Ch_Id;

            Sps[2] = new SqlParameter("@Result", SqlDbType.NVarChar, 100);
            Sps[2].Direction = ParameterDirection.Output;

            sql.ExecuteProcReturnString(cmdText, Sps);
            return Sps[2].Value.ToString();
        }

        /// <summary>
        /// 修改权限
        /// </summary>
        /// <param name="model">权限表模型层对象</param>
        /// <returns>是否添加成功的提示</returns>
        public string LimitUpdate(Model.Limit model)
        {
            string cmdText = "P_LimitUpdate";
            SqlParameter[] Sps = new SqlParameter[4];

            Sps[0] = new SqlParameter("@L_Id", SqlDbType.Int);
            Sps[0].Value = model.L_Id;

            Sps[1] = new SqlParameter("@F_Name", SqlDbType.NChar,10);
            Sps[1].Value = model.F_Name;

            Sps[2] = new SqlParameter("@Ch_Name", SqlDbType.NChar, 10);
            Sps[2].Value = model.Ch_Name;


            
            Sps[3] = new SqlParameter("@Result", SqlDbType.NVarChar, 100);
            Sps[3].Direction = ParameterDirection.Output;

            sql.ExecuteProcReturnString(cmdText, Sps);
            return Sps[3].Value.ToString();
        }

        /// <summary>
        /// 删除权限
        /// </summary>
        /// <param name="model">权限表模型层对象</param>
        /// <returns></returns>
        public void LimitDelete(Model.Limit model)
        {
            string cmdText = "P_LimitDelete";
            SqlParameter[] Sps = new SqlParameter[1];

            Sps[0] = new SqlParameter("@L_Id", SqlDbType.Int);
            Sps[0].Value = model.L_Id;



            sql.ExecuteProcReturnVoid(cmdText, Sps);

        }

        /// <summary>
        /// 修改权限是否可用
        /// </summary>
        /// <param name="model">权限表模型层对象</param>
        /// <returns></returns>
        public void LimitUpdateEnable(Model.Limit model)
        {
            string cmdText = "P_LimitUpdateEnable";
            SqlParameter[] Sps = new SqlParameter[2];

            Sps[0] = new SqlParameter("@L_Id", SqlDbType.Int);
            Sps[0].Value = model.L_Id;

            
            Sps[1] = new SqlParameter("@L_Enable", SqlDbType.Bit);
            Sps[1].Value = model.L_Enable;



            sql.ExecuteProcReturnVoid(cmdText, Sps);

        }
    }
}
