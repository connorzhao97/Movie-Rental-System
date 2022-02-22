using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DBUtility;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace DAL
{
    public class Character
    {
        sqlHelpers sql = null;
        /// <summary>
        /// 构造函数初始化
        /// </summary>
        /// <param name="strConnectionStringName"></param>
        public Character(string strConnectionStringName)
        {
            sql = new sqlHelpers(strConnectionStringName);
        }

        /// <summary>
        /// 查询全部角色 返回DataTable(Cdt)
        /// </summary>
        /// <returns></returns>
        public DataTable CharactersView()
        {
            String sq = "select * from Character";
            sql.ExecuteTextReturnDataTable(sq);
            DataTable Cdt = new DataTable();
            Cdt = sql.ExecuteTextReturnDataTable(sq);
            return Cdt;
        }

        /// <summary>
        /// 添加角色（函数名就是存储过程名，建议去掉P_）
        /// </summary>
        /// <param name="model">角色表模型层对象</param>
        /// <returns>是否添加成功的提示</returns>
        public string CharactersInsert(Model.Character model)
        {
            string cmdText = "P_CharacterInsert";
            SqlParameter[] Sps = new SqlParameter[3];
            Sps[0] = new SqlParameter("@Ch_Name", SqlDbType.NChar, 10);
            Sps[0].Value = model.Ch_Name;

            Sps[1] = new SqlParameter("@Ch_Intro", SqlDbType.NVarChar, 50);
            Sps[1].Value = model.Ch_Intro;

            Sps[2] = new SqlParameter("@Result", SqlDbType.NVarChar, 100);
            Sps[2].Direction = ParameterDirection.Output;

            sql.ExecuteProcReturnString(cmdText, Sps);
            return Sps[2].Value.ToString();
        }

        /// <summary>
        /// 修改角色
        /// </summary>
        /// <param name="model">角色表模型层对象</param>
        /// <returns>是否添加成功的提示</returns>
        public string CharactersUpdate(Model.Character model)
        {
            string cmdText = "P_CharacterUpdate";
            SqlParameter[] Sps = new SqlParameter[4];

            Sps[0] = new SqlParameter("@Ch_Id", SqlDbType.Int);
            Sps[0].Value = model.Ch_Id;

            Sps[1] = new SqlParameter("@Ch_Name", SqlDbType.NChar, 10);
            Sps[1].Value = model.Ch_Name;

            Sps[2] = new SqlParameter("@Ch_Intro", SqlDbType.NVarChar, 50);
            Sps[2].Value = model.Ch_Intro;

            Sps[3] = new SqlParameter("@Result", SqlDbType.NVarChar, 100);
            Sps[3].Direction = ParameterDirection.Output;

            sql.ExecuteProcReturnString(cmdText, Sps);
            return Sps[3].Value.ToString();
        }

        /// <summary>
        /// 删除角色
        /// </summary>
        /// <param name="model">角色表模型层对象</param>
        /// <returns></returns>
        public void CharactersDelete(Model.Character model)
        {
            string cmdText = "P_CharacterDelete";
            SqlParameter[] Sps = new SqlParameter[1];

            Sps[0] = new SqlParameter("@Ch_Id", SqlDbType.Int);
            Sps[0].Value = model.Ch_Id;

            

            sql.ExecuteProcReturnVoid(cmdText, Sps);

        }

        /// <summary>
        /// 修改角色是否可用
        /// </summary>
        /// <param name="model">角色表模型层对象</param>
        /// <returns></returns>
        public void CharactersUpdateEnable(Model.Character model)
        {
            string cmdText = "P_CharacterUpdateEnable";
            SqlParameter[] Sps = new SqlParameter[2];

            Sps[0] = new SqlParameter("@Ch_Id", SqlDbType.Int);
            Sps[0].Value = model.Ch_Id;

            Sps[1] = new SqlParameter("@Ch_Enable", SqlDbType.Bit);
            Sps[1].Value = model.Ch_Enable;

            

            sql.ExecuteProcReturnVoid(cmdText, Sps);

        }
    }
}
