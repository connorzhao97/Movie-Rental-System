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
   public class ShoppingCar
    {
        sqlHelpers sql = null;
        /// <summary>
        /// 构造函数初始化
        /// </summary>
        /// <param name="strConnectionStringName"></param>
        public ShoppingCar(string strConnectionStringName)
        {
            sql = new sqlHelpers(strConnectionStringName);
        }

        /// <summary>
        /// 用户Id参训购物车里面电影Id
        /// </summary>
        /// <param name="U_Id"></param>
        /// <returns></returns>
        public DataTable SelectedByU_Id(int U_Id)
        {
            String sq = "select * from [ShoppingCar] Where U_Id='" + U_Id +"'";
            sql.ExecuteTextReturnDataTable(sq);
            DataTable SCar = new DataTable();
            SCar = sql.ExecuteTextReturnDataTable(sq);
            return SCar;
        }

        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="modelS"></param>
        public string SCarInserts(Model.ShoppingCar modelS)
        {
            string cmdText = "P_SCarInserts";
            SqlParameter[] Sps = new SqlParameter[7];

            Sps[0] = new SqlParameter("@U_Id", SqlDbType.Int);
            Sps[0].Value = modelS.U_Id;

            Sps[1] = new SqlParameter("@M_Id", SqlDbType.Int);
            Sps[1].Value = modelS.M_Id;

            Sps[2] = new SqlParameter("@M_Name", SqlDbType.NChar, 10);
            Sps[2].Value = modelS.M_Name;

            Sps[3] = new SqlParameter("@M_eName", SqlDbType.NChar, 10);
            Sps[3].Value = modelS.M_eName;

            Sps[4] = new SqlParameter("@M_Picture", SqlDbType.NVarChar, 255);
            Sps[4].Value = modelS.M_Picture;

            Sps[5] = new SqlParameter("@M_Intro", SqlDbType.NText);
            Sps[5].Value = modelS.M_Intro;

            Sps[6] = new SqlParameter("@Result", SqlDbType.NVarChar, 100);
            Sps[6].Direction = ParameterDirection.Output;

            sql.ExecuteProcReturnString(cmdText, Sps);
            return Sps[6].Value.ToString();
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="Smodel"></param>
        public void SCarDelete(Model.ShoppingCar Smodel)
        {
            String sq = "delete from [ShoppingCar] where S_Id ='" + Smodel.S_Id + "'";
            sql.ExecuteTextReturnVoid(sq);
        }
    }
}
