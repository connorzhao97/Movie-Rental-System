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
    public class Function
    {
        sqlHelpers sql = null;
        /// <summary>
        /// 构造函数初始化
        /// </summary>
        /// <param name="strConnectionStringName"></param>
        public Function(string strConnectionStringName)
        {
            sql = new sqlHelpers(strConnectionStringName);
        }

        /// <summary>
        /// 查询全部功能 返回DataTable(Cdt)
        /// </summary>
        /// <returns></returns>
        public DataTable FunctionView()
        {
            String sq = "select * from [Function]";
            sql.ExecuteTextReturnDataTable(sq);
            DataTable Cdt = new DataTable();
            Cdt = sql.ExecuteTextReturnDataTable(sq);
            return Cdt;
        }

        /// <summary>
        /// 添加功能（函数名就是存储过程名，建议去掉P_）
        /// </summary>
        /// <param name="model">功能表模型层对象</param>
        /// <returns>是否添加成功的提示</returns>
        public string FunctionInsert(Model.Function model)
        {
            string cmdText = "P_FunctionInsert";
            SqlParameter[] Sps = new SqlParameter[4];
            Sps[0] = new SqlParameter("@F_Name", SqlDbType.NChar, 10);
            Sps[0].Value = model.F_Name;

            Sps[1] = new SqlParameter("@F_Path", SqlDbType.NVarChar, 50);
            Sps[1].Value = model.F_Path;

            Sps[2] = new SqlParameter("@F_ParentId", SqlDbType.Int);
            Sps[2].Value = model.F_ParentId;

            Sps[3] = new SqlParameter("@Result", SqlDbType.NVarChar, 100);
            Sps[3].Direction = ParameterDirection.Output;

            sql.ExecuteProcReturnString(cmdText, Sps);
            return Sps[3].Value.ToString();
        }

        /// <summary>
        /// 修改功能
        /// </summary>
        /// <param name="model">功能表模型层对象</param>
        /// <returns>是否添加成功的提示</returns>
        public string FunctionUpdate(Model.Function model)
        {
            string cmdText = "P_FunctionUpdate";
            SqlParameter[] Sps = new SqlParameter[5];

            Sps[0] = new SqlParameter("@F_Id", SqlDbType.Int);
            Sps[0].Value = model.F_Id;

            Sps[1] = new SqlParameter("@F_Name", SqlDbType.NChar, 10);
            Sps[1].Value = model.F_Name;

            Sps[2] = new SqlParameter("@F_Path", SqlDbType.NVarChar, 50);
            Sps[2].Value = model.F_Path;


            Sps[3] = new SqlParameter("@F_ParentId", SqlDbType.Int);
            Sps[3].Value = model.F_ParentId;

            Sps[4] = new SqlParameter("@Result", SqlDbType.NVarChar, 100);
            Sps[4].Direction = ParameterDirection.Output;

            sql.ExecuteProcReturnString(cmdText, Sps);
            return Sps[4].Value.ToString();
        }

        /// <summary>
        /// 删除功能
        /// </summary>
        /// <param name="model">功能表模型层对象</param>
        /// <returns></returns>
        public void FunctionDelete(Model.Function model)
        {
            string cmdText = "P_FunctionDelete";
            SqlParameter[] Sps = new SqlParameter[1];

            Sps[0] = new SqlParameter("@F_Id", SqlDbType.Int);
            Sps[0].Value = model.F_Id;



            sql.ExecuteProcReturnVoid(cmdText, Sps);

        }

        /// <summary>
        /// 修改角色是否可用
        /// </summary>
        /// <param name="model">角色表模型层对象</param>
        /// <returns></returns>
        public void FunctionUpdateEnable(Model.Function model)
        {
            string cmdText = "P_FunctionUpdateEnable";
            SqlParameter[] Sps = new SqlParameter[2];

            Sps[0] = new SqlParameter("@F_Id", SqlDbType.Int);
            Sps[0].Value = model.F_Id;

            Sps[1] = new SqlParameter("@F_Enable", SqlDbType.Bit);
            Sps[1].Value = model.F_Enable;



            sql.ExecuteProcReturnVoid(cmdText, Sps);

        }
    }
}
