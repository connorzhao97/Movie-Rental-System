using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace BLL
{
   public class DirectorAndActor
    {
        DAL.DirectorAndActor dal;
        public DirectorAndActor(string strConnectionStringName)
        {
            dal = new DAL.DirectorAndActor(strConnectionStringName);
        }

        /// <summary>
        /// 查询全部演员和导演 返回DataTable
        /// </summary>
        public DataTable DirectorAndActorView()
        {
            return dal.DirectorAndActorView();
        }
        
        /// <summary>
        /// 电影ID查询导演和演员
        /// </summary>
        /// <param name="M_Id"></param>
        /// <returns></returns>
        public DataTable DandASelectByMid(int M_Id)
        {
            return dal.DandASelectByMid(M_Id);
        }

        /// <summary>
        /// 电影ID查询导演
        /// </summary>
        /// <param name="M_Id"></param>
        /// <returns></returns>
        public DataTable DirectorSelectByMid(int M_Id)
        {
            return dal.DirectorSelectByMid(M_Id);
        }

        /// <summary>
        /// 电影ID查询演员
        /// </summary>
        /// <param name="M_Id"></param>
        /// <returns></returns>
        public DataTable ActorSelectByMid(int M_Id)
        {
            return dal.ActorSelectByMid(M_Id);
        }


        /// <summary>
        ///  查询全部演员或导演 返回DataTable
        /// </summary>
        /// <param name="SelectedValue"></param>
        /// <returns></returns>
        public DataTable DandASelectByDA_DorA(bool SelectedValue)
        {
            return dal.DandASelectByDA_DorA(SelectedValue);
        }

        /// <summary>
        /// 添加演员或导演
        /// </summary>
        /// <param name="DAmodel"></param>
        public string DirectorOrActorInsert(Model.DirectorAndActor DAmodel)
        {
            return dal.DirectorOrActorInsert(DAmodel);
        }

        /// <summary>
        /// 导演/演员信息修改
        /// </summary>
        /// <param name="DAmodel"></param>
        /// <returns></returns>
        public string DirectorAndActorUpdate(Model.DirectorAndActor DAmodel)
        {
            return dal.DirectorAndActorUpdate(DAmodel);
        }

        /// <summary>
        /// 删除导演/演员
        /// </summary>
        /// <param name="DAmodel"></param>
        public void DirectorAndActorDelete(Model.DirectorAndActor DAmodel)
        {
            dal.DirectorAndActorDelete(DAmodel);
        }

        /// <summary>
        /// 导演演员身份变更
        /// </summary>
        /// <param name="DAmodel"></param>
        public void UpdateDA_DorA(Model.DirectorAndActor DAmodel)
        {
            dal.UpdateDA_DorA(DAmodel);
        }

        /// <summary>
        /// 图片更新
        /// </summary>
        /// <param name="DAmodel"></param>
        /// <returns></returns>
        public string DAPictureUpdate(Model.DirectorAndActor DAmodel)
        {
            return dal.DAPictureUpdate(DAmodel);
        }
    }
}
