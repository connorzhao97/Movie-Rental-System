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
    public class Movie
    {
        sqlHelpers sql = null;
        /// <summary>
        /// 构造函数初始化
        /// </summary>
        /// <param name="strConnectionStringName"></param>
        public Movie(string strConnectionStringName)
        {
            sql = new sqlHelpers(strConnectionStringName);
        }
        /// <summary>
        /// 查询全部电影导演演员 返回DataTable
        /// </summary>
        /// <returns></returns>
        public DataTable MoviesAllView()
        {
            String sq = "select * from V_MovieAll";
            sql.ExecuteTextReturnDataTable(sq);
            DataTable Mdt = new DataTable();
            Mdt = sql.ExecuteTextReturnDataTable(sq);
            return Mdt;
        }

        /// <summary>
        /// 查询全部电影 返回DataTable
        /// </summary>
        /// <returns></returns>
        public DataTable MoviesView()
        {        
            String sq = "select * from Movie";
            sql.ExecuteTextReturnDataTable(sq);
            DataTable Mdt = new DataTable();
            Mdt=sql.ExecuteTextReturnDataTable(sq);
            return Mdt;
        }

        /// <summary>
        /// 查询电影热度排行 返回DataTable
        /// </summary>
        /// <returns></returns>
        public DataTable MoviesListView()
        {
            String sq = "SELECT M_Id, M_Name, M_Frequency, M_Stock FROM Movie order by M_Frequency DESC";
            sql.ExecuteTextReturnDataTable(sq);
            DataTable Mdt = new DataTable();
            Mdt = sql.ExecuteTextReturnDataTable(sq);
            return Mdt;
        }

        /// <summary>
        /// 查询启用电影 返回DataTable
        /// </summary>
        /// <returns></returns>
        public DataTable MoviesView_On()
        {
            String sq = "select * from Movie where M_Enable=1";
            sql.ExecuteTextReturnDataTable(sq);
            DataTable Mdt = new DataTable();
            Mdt = sql.ExecuteTextReturnDataTable(sq);
            return Mdt;
        }
        /// <summary>
        /// 查询禁用电影 返回DataTable
        /// </summary>
        /// <returns></returns>
        public DataTable MoviesView_Off()
        {
            String sq = "select * from Movie where M_Enable=0";
            sql.ExecuteTextReturnDataTable(sq);
            DataTable Mdt = new DataTable();
            Mdt = sql.ExecuteTextReturnDataTable(sq);
            return Mdt;
        }
        /// <summary>
        /// 按电影名字查询 返回DataTable
        /// </summary>
        /// <param name="Mname"></param>
        /// <returns></returns>
        public DataTable MovieQueryByName(String Mname)
        {
            String sq = "select * from Movie where M_Name ='"+Mname +"'" ;
            sql.ExecuteTextReturnDataTable(sq);
            DataTable Mdt = new DataTable();
            Mdt = sql.ExecuteTextReturnDataTable(sq);
            return Mdt;
        }
        /// <summary>
        /// 按电影Id查询 返回DataTable
        /// </summary>
        /// <param name="Mname"></param>
        /// <returns></returns>
        public DataTable MovieQueryById(int Mid)
        {
            String sq = "select * from Movie where M_Id= '" + Mid + "'";
            sql.ExecuteTextReturnDataTable(sq);
            DataTable Mdt = new DataTable();
            Mdt = sql.ExecuteTextReturnDataTable(sq);
            return Mdt;
        }
        /// <summary>
        /// 按电影类型查询 返回DataTable
        /// </summary>
        /// <param name="M_Type"></param>
        /// <returns></returns>
        public DataTable MovieQueryByType(String M_Type)
        {
            
            String sq = "select * from Movie where M_Type like N'%"+M_Type+"%'";
            sql.ExecuteTextReturnDataTable(sq);
            DataTable Mdt = new DataTable();
            Mdt = sql.ExecuteTextReturnDataTable(sq);
            return Mdt;
        }
        /// <summary>
        /// 按电影地区查询 返回DataTable
        /// </summary>
        /// <param name="M_Area"></param>
        /// <returns></returns>
        public DataTable MovieQueryByArea(String M_Area)
        {
        
            String sq = "select * from Movie where M_Area like N'%" + M_Area + "%'";
            sql.ExecuteTextReturnDataTable(sq);
            DataTable Mdt = new DataTable();
            Mdt = sql.ExecuteTextReturnDataTable(sq);
            return Mdt;
        }
        /// <summary>
        /// 按电影时间查询 返回DataTable
        /// </summary>
        /// <param name="M_Date"></param>
        /// <returns></returns>
        public DataTable MovieQueryByDate(String M_Date)
        {
            
            String sq = "select * from Movie where M_Date like N'%" + M_Date + "%'";
            sql.ExecuteTextReturnDataTable(sq);
            DataTable Mdt = new DataTable();
            Mdt = sql.ExecuteTextReturnDataTable(sq);
            return Mdt;
        }
        /// <summary>
        /// 自定义查询 返回DataTable
        /// </summary>
        /// <param name="Query"></param>
        /// <returns></returns>
        public DataTable MovieQueryByQuery(String Query)
        {

            String sq = "select * from Movie where " + Query;  //注意格式大致为  M_Type like N'%动作%' and M_Date like N'%2016%' and M_Area like N'%中国%'
            sql.ExecuteTextReturnDataTable(sq);
            DataTable Mdt = new DataTable();
            Mdt = sql.ExecuteTextReturnDataTable(sq);
            return Mdt;
        }
        ///<summary>
        ///添加新电影
        ///</summary>
        public string MovieInsert(Model.Movie Mmodel)
        {
            string cmdText = "P_MovieInsert";
            SqlParameter[] Sps = new SqlParameter[11];

            Sps[0] = new SqlParameter("@M_Name", SqlDbType.NChar, 10);
            Sps[0].Value = Mmodel.M_Name;

            Sps[1] = new SqlParameter("@M_eName", SqlDbType.NChar, 10);
            Sps[1].Value = Mmodel.M_eName;

            Sps[2] = new SqlParameter("@M_Grade", SqlDbType.Float);
            Sps[2].Value = Mmodel.M_Grade;

            Sps[3] = new SqlParameter("@M_Length", SqlDbType.NChar, 10);
            Sps[3].Value = Mmodel.M_Length;

            Sps[4] = new SqlParameter("@M_Type", SqlDbType.NChar, 10);
            Sps[4].Value = Mmodel.M_Type;

            Sps[5] = new SqlParameter("@M_Area", SqlDbType.NChar, 10);
            Sps[5].Value = Mmodel.M_Area;

            Sps[6] = new SqlParameter("@M_Date", SqlDbType.NChar, 10);
            Sps[6].Value = Mmodel.M_Date;

            Sps[7] = new SqlParameter("@M_Stock", SqlDbType.Int);
            Sps[7].Value = Mmodel.M_Stock;

            Sps[8] = new SqlParameter("@M_Picture", SqlDbType.NVarChar,255);
            Sps[8].Value = Mmodel.M_Picture;

            Sps[9] = new SqlParameter("@M_Intro", SqlDbType.NText);
            Sps[9].Value = Mmodel.M_Intro;

            Sps[10] = new SqlParameter("@Result", SqlDbType.NVarChar, 100);
            Sps[10].Direction = ParameterDirection.Output;

            sql.ExecuteProcReturnString(cmdText, Sps);
            return Sps[10].Value.ToString();
        }

        ///<summary>
        ///更新电影表
        ///</summary>
        ///<param name="model">电影表模型层对象</param>
        ///<returns>是否修改成功提示</returns>
        public string MovieUpdate(Model.Movie model)
        {
            string cmdText = "P_MovieUpdate";
            SqlParameter[] Sps = new SqlParameter[12];
            Sps[0] = new SqlParameter("@M_Id", SqlDbType.Int);
            Sps[0].Value = model.M_Id;

            Sps[1] = new SqlParameter("@M_Name", SqlDbType.NVarChar, 10);
            Sps[1].Value = model.M_Name;

            Sps[2] = new SqlParameter("@M_eName", SqlDbType.NVarChar, 10);
            Sps[2].Value = model.M_eName;

            Sps[3] = new SqlParameter("@M_Grade", SqlDbType.Float);
            Sps[3].Value = model.M_Grade;

            Sps[4] = new SqlParameter("@M_Length", SqlDbType.NVarChar, 10);
            Sps[4].Value = model.M_Length;

            Sps[5] = new SqlParameter("@M_Type", SqlDbType.NVarChar, 10);
            Sps[5].Value = model.M_Type;

            Sps[6] = new SqlParameter("@M_Area", SqlDbType.NVarChar, 10);
            Sps[6].Value = model.M_Area;

            Sps[7] = new SqlParameter("@M_Date", SqlDbType.Date);
            Sps[7].Value = model.M_Date;

            Sps[8] = new SqlParameter("@M_Stock", SqlDbType.Int);
            Sps[8].Value = model.M_Stock;

            Sps[9] = new SqlParameter("@M_Frequency", SqlDbType.Int);
            Sps[9].Value = model.M_Frequency;

            Sps[10] = new SqlParameter("@M_Intro", SqlDbType.NText);
            Sps[10].Value = model.M_Intro;

            Sps[11] = new SqlParameter("@Result", SqlDbType.NVarChar, 100);
            Sps[11].Direction = ParameterDirection.Output;

            sql.ExecuteProcReturnString(cmdText, Sps);
            return Sps[11].Value.ToString();

        }
        ///<summary>
        ///更新电影图片
        ///</summary>
        ///<param name="model">电影表模型层对象</param>
        ///<returns>是否修改成功提示</returns>
        public string MoviePictureUpdate(Model.Movie model)
        {
            string cmdText = "P_MoviePictureUpdate";
            SqlParameter[] Sps = new SqlParameter[3];
            Sps[0] = new SqlParameter("@M_Id", SqlDbType.Int);
            Sps[0].Value = model.M_Id;

            Sps[1] = new SqlParameter("@M_Picture", SqlDbType.NVarChar, 255);
            Sps[1].Value = model.M_Picture;


            Sps[2] = new SqlParameter("@Result", SqlDbType.NVarChar, 100);
            Sps[2].Direction = ParameterDirection.Output;

            sql.ExecuteProcReturnString(cmdText, Sps);
            return Sps[2].Value.ToString();

        }
        ///<summary>
        ///更新电影禁用/启用
        ///</summary>
        ///<param name="model">电影表模型层对象</param>
        ///<returns>是否修改成功提示</returns>
        public void MovieEnableUpdate(Model.Movie model)
        {
            string cmdText = "P_MovieUpdateEnable";
            SqlParameter[] Sps = new SqlParameter[2];
            Sps[0] = new SqlParameter("@M_Id", SqlDbType.Int);
            Sps[0].Value = model.M_Id;

            Sps[1] = new SqlParameter("@M_Enable", SqlDbType.Bit);
            Sps[1].Value = model.M_Enable;

            sql.ExecuteProcReturnString(cmdText, Sps);


        }

        /// <summary>
        /// 删除电影
        /// </summary>
        /// <param name="model">电影表模型层对象</param>
        public void MovieDelete(Model.Movie model)
        {
            string cmdText = "P_MovieDelete";
            SqlParameter[] Sps = new SqlParameter[1];
            Sps[0] = new SqlParameter("@M_Id", SqlDbType.Int);
            Sps[0].Value = model.M_Id;
            sql.ExecuteProcReturnVoid(cmdText, Sps);
        }

        /// <summary>
        /// 更新存货，租赁或归还时候使用
        /// </summary>
        /// <param name="Mmodel"></param>
        public void MovieUpdateStock(Model.Movie Mmodel)
        {
            string cmdText = "P_MovieStockUpdate";
            SqlParameter[] Sps = new SqlParameter[3];
            Sps[0] = new SqlParameter("@M_Id", SqlDbType.Int);
            Sps[0].Value = Mmodel.M_Id;

            Sps[1] = new SqlParameter("@M_Stock", SqlDbType.Int);
            Sps[1].Value = Mmodel.M_Stock;

            Sps[2] = new SqlParameter("@Result", SqlDbType.NVarChar, 100);
            Sps[2].Direction = ParameterDirection.Output;

            sql.ExecuteProcReturnVoid(cmdText, Sps);
            
        }

        /// <summary>
        /// 更新租赁次数
        /// </summary>
        /// <param name="Mmodel"></param>
        public void MovieUpdateFrequency(Model.Movie Mmodel)
        {
            string cmdText = "P_MovieFrequencyAddUpdate";
            SqlParameter[] Sps = new SqlParameter[2];
            Sps[0] = new SqlParameter("@M_Id", SqlDbType.Int);
            Sps[0].Value = Mmodel.M_Id;

            Sps[1] = new SqlParameter("@Result", SqlDbType.NVarChar, 100);
            Sps[1].Direction = ParameterDirection.Output;

            sql.ExecuteProcReturnVoid(cmdText, Sps);

        }
    }
}
