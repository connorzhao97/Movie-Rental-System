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
    public class Comment
    {
        sqlHelpers sql = null;
        /// <summary>
        /// 构造函数初始化
        /// </summary>
        /// <param name="strConnectionStringName"></param>
        public Comment(string strConnectionStringName)
        {
            sql = new sqlHelpers(strConnectionStringName);
        }

        /// <summary>
        /// 查询全部评论 返回DataTable(Udt)
        /// </summary>
        /// <returns></returns>
        public DataTable CommentsView()
        {
            String sq = "select * from [Comment]";
            sql.ExecuteTextReturnDataTable(sq);
            DataTable Comdt = new DataTable();
            Comdt = sql.ExecuteTextReturnDataTable(sq);
            return Comdt;
        }

        /// <summary>
        /// 查询已经审查通过评论或未通过的评论 返回DataTable
        /// </summary>
        /// <param name="SelectedValue"></param>
        /// <returns></returns>
        public DataTable CommentsSelectByEnable(bool SelectedValue)
        {
            String sq = "select * from [Comment] where Com_Enable ='" + SelectedValue +"'";
            sql.ExecuteTextReturnDataTable(sq);
            DataTable Comdt = new DataTable();
            Comdt = sql.ExecuteTextReturnDataTable(sq);
            return Comdt;
        }


        ///<summary>
        ///添加新评论 电影评论使用
        ///</summary>
        public string CommentsInsert(Model.Comment Cmodel)
        {
            string cmdText = "P_CommentsInsert";
            SqlParameter[] Sps = new SqlParameter[8];

            Sps[0] = new SqlParameter("@U_Id", SqlDbType.Int);
            Sps[0].Value = Cmodel.U_Id;

            Sps[1] = new SqlParameter("@U_Name", SqlDbType.Float, 2);
            Sps[1].Value = Cmodel.U_Name;

            Sps[2] = new SqlParameter("@M_Id", SqlDbType.Int);
            Sps[2].Value = Cmodel.M_Id;

            Sps[3] = new SqlParameter("@Com_Grade", SqlDbType.Float, 2);
            Sps[3].Value = Cmodel.Com_Grade;

            Sps[4] = new SqlParameter("@Com_Date", SqlDbType.Date);
            Sps[4].Value = Cmodel.Com_Date;

            Sps[5] = new SqlParameter("@Com_Content", SqlDbType.NText);
            Sps[5].Value = Cmodel.Com_Content;

            Sps[6] = new SqlParameter("@Com_Enable", SqlDbType.Bit);
            Sps[6].Value = Cmodel.Com_Enable;

            Sps[7] = new SqlParameter("@Result", SqlDbType.NVarChar, 100);
            Sps[7].Direction = ParameterDirection.Output;

            sql.ExecuteProcReturnVoid(cmdText, Sps);
            return Sps[7].Value.ToString();
        }

        /// <summary>
        /// 评论修改
        /// </summary>
        /// <param name="Cmodel"></param>
        /// <returns></returns>
        public string CommentsUpdate(Model.Comment Cmodel)
        {
            string cmdText = "P_CommentsUpdate";
            SqlParameter[] Sps = new SqlParameter[9];

            Sps[0] = new SqlParameter("@U_Id", SqlDbType.Int);
            Sps[0].Value = Cmodel.U_Id;

            Sps[1] = new SqlParameter("@U_Name", SqlDbType.NVarChar,10);
            Sps[1].Value = Cmodel.U_Name;

            Sps[2] = new SqlParameter("@M_Id", SqlDbType.Int);
            Sps[2].Value = Cmodel.M_Id;

            Sps[3] = new SqlParameter("@Com_Grade", SqlDbType.Float, 2);
            Sps[3].Value = Cmodel.Com_Grade;

            Sps[4] = new SqlParameter("@Com_Date", SqlDbType.Date);
            Sps[4].Value = Cmodel.Com_Date;

            Sps[5] = new SqlParameter("@Com_Content", SqlDbType.NText);
            Sps[5].Value = Cmodel.Com_Content;

            Sps[6] = new SqlParameter("@Com_Enable", SqlDbType.Bit);
            Sps[6].Value = Cmodel.Com_Enable;

            Sps[7] = new SqlParameter("@Com_Id", SqlDbType.Int);
            Sps[7].Value = Cmodel.Com_Id;

            Sps[8] = new SqlParameter("@Result", SqlDbType.NVarChar, 100);
            Sps[8].Direction = ParameterDirection.Output;

            sql.ExecuteProcReturnVoid(cmdText, Sps);
            return Sps[8].Value.ToString();

        }

        /// <summary>
        /// 删除评论
        /// </summary>
        /// <param name="Cmodel"></param>
        public void CommentsDelete(Model.Comment Cmodel)
        {
            String sq = "delete from [Comment] where Com_Id ='" + Cmodel.Com_Id + "'";
            sql.ExecuteTextReturnVoid(sq);
        }

        /// <summary>
        /// 审查评论通过或者不通过
        /// </summary>
        /// <param name="Cmodel"></param>
        public void UpdateEnable(Model.Comment Cmodel)
        {
            String sq = "Update [Comment] set Com_Enable ='" + Cmodel.Com_Enable + "'where Com_Id = '" + Cmodel.Com_Id +"'";
            sql.ExecuteTextReturnVoid(sq);
        }

        /// <summary>
        /// 根据电影id查询评论
        /// </summary>
        /// <param name="M_id"></param>
        /// <returns></returns>
        public DataTable CommentsSelectByMid(String M_id)
        {
            String sq = "Select * from [Comment] where M_id = " + M_id+ " And Com_Enable = 1";
            sql.ExecuteTextReturnDataTable(sq);
            DataTable Comdt = new DataTable();
            Comdt = sql.ExecuteTextReturnDataTable(sq);
            return Comdt;
        }
    }
}
