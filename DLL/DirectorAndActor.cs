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
    public class DirectorAndActor
    {
        sqlHelpers sql = null;
        /// <summary>
        /// 构造函数初始化
        /// </summary>
        /// <param name="strConnectionStringName"></param>
        public DirectorAndActor(string strConnectionStringName)
        {
            sql = new sqlHelpers(strConnectionStringName);
        }

        /// <summary>
        /// 查询全部演员和导演 返回DataTable(Udt)
        /// </summary>
        /// <returns></returns>
        public DataTable DirectorAndActorView()
        {
            String sq = "select * from [DirectorAndActor]";
            sql.ExecuteTextReturnDataTable(sq);
            DataTable DAdt = new DataTable();
            DAdt = sql.ExecuteTextReturnDataTable(sq);
            return DAdt;
        }

        /// <summary>
        /// 按电影ID查询导演演员。
        /// </summary>
        /// <param name="M_Id"></param>
        /// <returns></returns>
        public DataTable DandASelectByMid(int M_Id)
        {
            String sq = "select * from [DirectorAndActor] Where M_Id= " + M_Id;
            sql.ExecuteTextReturnDataTable(sq);
            DataTable DAdt = new DataTable();
            DAdt = sql.ExecuteTextReturnDataTable(sq);
            return DAdt;
        }

        /// <summary>
        /// 电影Id查询导演
        /// </summary>
        /// <param name="M_Id"></param>
        /// <returns></returns>
        public DataTable DirectorSelectByMid(int M_Id)
        {
            String sq = "select * from [DirectorAndActor] Where DA_DorA = 1 And M_Id='" + M_Id + "'";
            sql.ExecuteTextReturnDataTable(sq);
            DataTable DAdt = new DataTable();
            DAdt = sql.ExecuteTextReturnDataTable(sq);
            return DAdt;
        }

        /// <summary>
        /// 电影ID查询演员
        /// </summary>
        /// <param name="M_Id"></param>
        /// <returns></returns>
        public DataTable ActorSelectByMid(int M_Id)
        {
            String sq = "select * from [DirectorAndActor] Where DA_DorA = 0 And M_Id='" + M_Id + "'";
            sql.ExecuteTextReturnDataTable(sq);
            DataTable DAdt = new DataTable();
            DAdt = sql.ExecuteTextReturnDataTable(sq);
            return DAdt;
        }


        /// <summary>
        /// 查询全部演员或导演 返回DataTable
        /// </summary>
        /// <param name="SelectedValue"></param>
        /// <returns></returns>
        public DataTable DandASelectByDA_DorA(bool SelectedValue)
        {
            string cmdText = "P_DirectorAndActorSelectedByDA_DorA";//命令文本为存储过程名 
            SqlParameter[] Sp = new SqlParameter[1];
            Sp[0] = new SqlParameter("@DA_DorA", SqlDbType.Bit);//设置存储过程的参数
            Sp[0].Value = SelectedValue;
            return sql.ExecuteProcReturnDataTable(cmdText, Sp);
        }


        ///<summary>
        ///添加新导演或者演员
        ///</summary>
        public string DirectorOrActorInsert(Model.DirectorAndActor DAmodel)
        {
            string cmdText = "P_DirectorOrActorInsert";
            SqlParameter[] Sps = new SqlParameter[7];

            Sps[0] = new SqlParameter("@M_Id", SqlDbType.Int);
            Sps[0].Value = DAmodel.M_Id;

            Sps[1] = new SqlParameter("@DA_Name", SqlDbType.NVarChar, 50);
            Sps[1].Value = DAmodel.DA_Name;

            Sps[2] = new SqlParameter("@DA_EName", SqlDbType.NVarChar, 50);
            Sps[2].Value = DAmodel.DA_EName;

            Sps[3] = new SqlParameter("@DA_Picture", SqlDbType.NVarChar, 255);
            Sps[3].Value = DAmodel.DA_Picture;

            Sps[4] = new SqlParameter("@DA_DorA", SqlDbType.Bit);
            Sps[4].Value = DAmodel.DA_DorA;

            Sps[5] = new SqlParameter("@DA_Intro", SqlDbType.NText);
            Sps[5].Value = DAmodel.DA_Intro;

            Sps[6] = new SqlParameter("@Result", SqlDbType.NVarChar, 100);
            Sps[6].Direction = ParameterDirection.Output;

            sql.ExecuteProcReturnString(cmdText, Sps);
            return Sps[6].Value.ToString();
        }

        /// <summary>
        /// 导演/演员信息修改
        /// </summary>
        /// <param name="DAmodel"></param>
        /// <returns></returns>
        public string DirectorAndActorUpdate(Model.DirectorAndActor DAmodel)
        {
            string cmdText = "P_DirectorAndActorUpdate";
            SqlParameter[] Sps = new SqlParameter[7];

            Sps[0] = new SqlParameter("@M_Id", SqlDbType.Int);
            Sps[0].Value = DAmodel.M_Id;

            Sps[1] = new SqlParameter("@DA_Name", SqlDbType.NVarChar, 50);
            Sps[1].Value = DAmodel.DA_Name;

            Sps[2] = new SqlParameter("@DA_EName", SqlDbType.NVarChar, 50);
            Sps[2].Value = DAmodel.DA_EName;

            Sps[3] = new SqlParameter("@DA_DorA", SqlDbType.Bit);
            Sps[3].Value = DAmodel.DA_DorA;

            Sps[4] = new SqlParameter("@DA_Intro", SqlDbType.NText);
            Sps[4].Value = DAmodel.DA_Intro;

            Sps[5] = new SqlParameter("@DA_Id", SqlDbType.Int);
            Sps[5].Value = DAmodel.DA_Id;

            Sps[6] = new SqlParameter("@Result", SqlDbType.NVarChar, 100);
            Sps[6].Direction = ParameterDirection.Output;

            sql.ExecuteProcReturnString(cmdText, Sps);
            return Sps[6].Value.ToString();
        }

        /// <summary>
        /// 删除导演或演员
        /// </summary>
        /// <param name="DAmodel"></param>
        public void DirectorAndActorDelete(Model.DirectorAndActor DAmodel)
        {
            string cmdText = "P_DirectorAndActorDelete";
            SqlParameter[] Sps = new SqlParameter[1];

            Sps[0] = new SqlParameter("@DA_Id", SqlDbType.Int);
            Sps[0].Value = DAmodel.DA_Id;

            sql.ExecuteProcReturnVoid(cmdText, Sps);
        }

        /// <summary>
        /// 更改导演或演员身份
        /// </summary>
        /// <param name="DAmodel"></param>
        public void UpdateDA_DorA(Model.DirectorAndActor DAmodel)
        {
            string cmdText = "P_DA_DorAUpdate";//命令文本为存储过程名 
            SqlParameter[] Sp = new SqlParameter[2];

            Sp[0] = new SqlParameter("@DA_Id", SqlDbType.Int);//设置存储过程的参数
            Sp[0].Value = DAmodel.DA_Id;

            Sp[1] = new SqlParameter("@DA_DorA", SqlDbType.Bit);//设置存储过程的参数
            Sp[1].Value = DAmodel.DA_DorA;

            sql.ExecuteProcReturnVoid(cmdText, Sp);
        }

        /// <summary>
        /// 更新图片
        /// </summary>
        /// <param name="DAmodel"></param>
        /// <returns></returns>
        public string DAPictureUpdate(Model.DirectorAndActor DAmodel)
        {
            string cmdText = "P_DAPictureUpdate";
            SqlParameter[] Sps = new SqlParameter[3];
            Sps[0] = new SqlParameter("@DA_Id", SqlDbType.Int);
            Sps[0].Value = DAmodel.DA_Id;

            Sps[1] = new SqlParameter("@DA_Picture", SqlDbType.NVarChar, 255);
            Sps[1].Value = DAmodel.DA_Picture;

            Sps[2] = new SqlParameter("@Result", SqlDbType.NVarChar, 100);
            Sps[2].Direction = ParameterDirection.Output;

            sql.ExecuteProcReturnString(cmdText, Sps);
            return Sps[2].Value.ToString();

        }
    }
}
