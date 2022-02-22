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
    public class BringAndReturn
    {
        sqlHelpers sql = null;
        /// <summary>
        /// 构造函数初始化
        /// </summary>
        /// <param name="strConnectionStringName"></param>
        public BringAndReturn(string strConnectionStringName)
        {
            sql = new sqlHelpers(strConnectionStringName);
        }

        /// <summary>
        /// 查看所有租赁单
        /// </summary>
        /// <returns></returns>
        public DataTable BringAndReturnsView()
        {
            String sq = "select * from [BringAndReturn]";
            sql.ExecuteTextReturnDataTable(sq);
            DataTable BRdt = new DataTable();
            BRdt = sql.ExecuteTextReturnDataTable(sq);
            return BRdt;
        }
        
        /// <summary>
        /// 用户Id查询租赁单
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public DataTable BR_SelectedByU_Id(int id)
        {
            String sq = "select * from [BringAndReturn ] where U_Id ='" + id + "'";
            sql.ExecuteTextReturnDataTable(sq);
            DataTable BRdt = new DataTable();
            BRdt = sql.ExecuteTextReturnDataTable(sq);
            return BRdt;
        }
        /// <summary>
        /// 查询归还或未归还租赁表 返回DataTable
        /// </summary>
        /// <param name="SelectedValue"></param>
        /// <returns></returns>
        public DataTable BR_SelectedByBR_Return(bool SelectedValue)
        {
            String sq = "select * from [BringAndReturn ] where BR_Return ='" + SelectedValue + "'";
            sql.ExecuteTextReturnDataTable(sq);
            DataTable Comdt = new DataTable();
            Comdt = sql.ExecuteTextReturnDataTable(sq);
            return Comdt;
        }
        
        /// <summary>
        /// 逾期欠费计算
        /// </summary>
        /// <param name="BRmodel"></param>
        public void BR_RentChange(Model.BringAndReturn BRmodel)
        {
            DateTime dt = DateTime.Now;
            TimeSpan ts = dt - BRmodel.R_Date;  // 未归还逾期天数
            double rsB_Rent = (1 + (ts.Days) * 0.05) * BRmodel.B_Rent;  //逾期缴费=原价+逾期天数*0.05原价
            BRmodel.B_Rent = float.Parse(rsB_Rent.ToString());          //转为Float

            String sq = "Update [BringAndReturn] set B_Rent ='" + BRmodel.B_Rent + "'where BR_Id = '" + BRmodel.BR_Id + "'";
            sql.ExecuteTextReturnVoid(sq);

        }
        ///<summary>
        ///添加新租赁单 租赁时使用
        ///</summary>
        public string BringAndReturnsInsert(Model.BringAndReturn BRmodel)
        {
            string cmdText = "P_BringAndReturnsInsert";
            SqlParameter[] Sps = new SqlParameter[7];

            Sps[0] = new SqlParameter("@U_Id", SqlDbType.Int);
            Sps[0].Value = BRmodel.U_Id;

            Sps[1] = new SqlParameter("@M_Id", SqlDbType.Int);
            Sps[1].Value = BRmodel.M_Id;

            Sps[2] = new SqlParameter("@B_Date", SqlDbType.Date);
            Sps[2].Value = BRmodel.B_Date;

            Sps[3] = new SqlParameter("R_Date", SqlDbType.Date);
            Sps[3].Value = BRmodel.R_Date;

            Sps[4] = new SqlParameter("@B_Rent", SqlDbType.Float,2);
            Sps[4].Value = BRmodel.B_Rent;

            Sps[5] = new SqlParameter("@BR_Return", SqlDbType.Bit);
            Sps[5].Value = BRmodel.BR_Return;

            Sps[6] = new SqlParameter("@Result", SqlDbType.NVarChar, 100);
            Sps[6].Direction = ParameterDirection.Output;

            sql.ExecuteProcReturnVoid(cmdText, Sps);
            return Sps[6].Value.ToString();
        }

        /// <summary>
        /// 租赁单修改
        /// </summary>
        /// <param name="BRmodel"></param>
        /// <returns></returns>
        public string BringAndReturnsUpdate(Model.BringAndReturn BRmodel)
        {
            string cmdText = "P_BringAndReturnsUpdate";
            SqlParameter[] Sps = new SqlParameter[8];

            Sps[0] = new SqlParameter("@U_Id", SqlDbType.Int);
            Sps[0].Value = BRmodel.U_Id;

            Sps[1] = new SqlParameter("@M_Id", SqlDbType.Int);
            Sps[1].Value = BRmodel.M_Id;

            Sps[2] = new SqlParameter("@B_Date", SqlDbType.Date);
            Sps[2].Value = BRmodel.B_Date;

            Sps[3] = new SqlParameter("R_Date", SqlDbType.Date);
            Sps[3].Value = BRmodel.R_Date;

            Sps[4] = new SqlParameter("@B_Rent", SqlDbType.Float, 2);
            Sps[4].Value = BRmodel.B_Rent;

            Sps[5] = new SqlParameter("@BR_Return", SqlDbType.Bit);
            Sps[5].Value = BRmodel.BR_Return;

            Sps[6] = new SqlParameter("@BR_Id", SqlDbType.Int);
            Sps[6].Value = BRmodel.BR_Id;

            Sps[7] = new SqlParameter("@Result", SqlDbType.NVarChar, 100);
            Sps[7].Direction = ParameterDirection.Output;

            sql.ExecuteProcReturnVoid(cmdText, Sps);
            return Sps[7].Value.ToString();

        }

        /// <summary>
        /// 删除租赁单
        /// </summary>
        /// <param name="BRmodel"></param>
        public void BringAndReturnsDelete(Model.BringAndReturn BRmodel)
        {
            String sq = "delete from [BringAndReturn] where BR_Id ='" + BRmodel.BR_Id + "'";
            sql.ExecuteTextReturnVoid(sq);
        }

        /// <summary>
        /// 设置归还标志为1 归还时候改变
        /// </summary>
        /// <param name="BRmodel"></param>
        public void UpdateBR_Return(Model.BringAndReturn BRmodel)
        {
            String sq = "Update [BringAndReturn] set BR_Return ='" + BRmodel.BR_Return + "' where BR_Id = '" + BRmodel.BR_Id + "'";
            sql.ExecuteTextReturnVoid(sq);
        }
    }
}
