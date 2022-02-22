using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace BLL
{
    public class Movie
    {
        DAL.Movie dal;
        public Movie(string strConnectionStringName)
        {
            dal = new DAL.Movie(strConnectionStringName);
        }
        /// <summary>
        /// 查询全部电影演员导演
        /// </summary>
        public DataTable MoviesAllView()
        {
            return dal.MoviesAllView();
        }

        /// <summary>
        /// 查询全部电影
        /// </summary>
        public DataTable MoviesView()
        {
            return dal.MoviesView();
        }
        /// <summary>
         /// 查询全部电影热度排行
         /// </summary>
        public DataTable MoviesListView()
        {
            return dal.MoviesListView();
        }
        /// <summary>
        /// 查询全部电影
        /// </summary>
        public DataTable MoviesView_On()
        {
            return dal.MoviesView_On();
        }
        /// <summary>
        /// 查询全部电影
        /// </summary>
        public DataTable MoviesView_Off()
        {
            return dal.MoviesView_Off();
        }
        /// <summary>
        /// 按电影名字查询电影
        /// </summary>
        /// <param name="Mname"></param>
        /// <returns></returns>
        public DataTable MovieQueryByName(String Mname)
        {
            return dal.MovieQueryByName(Mname);
        }
        /// <summary>
        /// 按电影Id查询电影
        /// </summary>
        /// <param name="Mid"></param>
        /// <returns></returns>
        public DataTable MovieQueryById(int Mid)
        {
            return dal.MovieQueryById(Mid);
        }

        /// <summary>
        /// 按电影类型查询电影
        /// </summary>
        /// <param name="M_Type"></param>
        /// <returns></returns>
        public DataTable MovieQueryByType(String M_Type)
        {
            return dal.MovieQueryByType(M_Type);
        }
        /// <summary>
        /// 按电影地区查询电影
        /// </summary>
        /// <param name="M_Area"></param>
        /// <returns></returns>
        public DataTable MovieQueryByArea(String M_Area)
        {
            return dal.MovieQueryByArea(M_Area);
        }
        /// <summary>
        /// 按电影时间查询电影
        /// </summary>
        /// <param name="M_Date"></param>
        /// <returns></returns>
        public DataTable MovieQueryByDate(String M_Date)
        {
            return dal.MovieQueryByDate(M_Date);
        }
        /// <summary>
        ///自定义查询电影
        /// </summary>
        /// <param name="Query"></param>
        /// <returns></returns>
        public DataTable MovieQueryByQuery(String Query)
        {
            return dal.MovieQueryByQuery(Query);
        }
        /// <summary>
        /// 更新电影表 
        /// </summary>
        /// <param name="model">电影表模型层对象</param>
        /// <returns>是否修改成功的提示</returns>
        public string MovieUpdate(Model.Movie model)
        {
            return dal.MovieUpdate(model);
        }
        /// <summary>
        /// 添加新电影
        /// </summary>
        /// <param name="model">电影表模型层对象</param>
        /// <returns>是否修改成功的提示</returns>
        public string MovieInsert(Model.Movie model)
        {
            return dal.MovieInsert(model);
        }
        /// <summary>
        /// 更新电影图片
        /// </summary>
        /// <param name="model">电影表模型层对象</param>
        /// <returns>是否修改成功的提示</returns>
        public string MoviePictureUpdate(Model.Movie model)
        {
            return dal.MoviePictureUpdate(model);
        }
        /// <summary>
        /// 更新电影禁用/启用
        /// </summary>
        /// <param name="model">电影表模型层对象</param>
        /// <returns>是否修改成功的提示</returns>
        public void MovieEnableUpdate(Model.Movie model)
        {
            dal.MovieEnableUpdate(model);
        }
        /// <summary>
        /// 删除电影
        /// </summary>
        /// <param name="model"></param>
        public void MovieDelete(Model.Movie model)
        {
            dal.MovieDelete(model);
        }

        /// <summary>
        /// 更新存货，租赁或规划时候使用
        /// </summary>
        /// <param name="Mmodel"></param>
        public void MovieUpdateStock(Model.Movie Mmodel)
        {
            dal.MovieUpdateStock(Mmodel);
        }

        public void MovieUpdateFrequency(Model.Movie Mmodel)
        {
            dal.MovieUpdateFrequency(Mmodel);
        }
    }
}
