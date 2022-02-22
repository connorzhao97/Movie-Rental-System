using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace BLL
{
    public class Comment
    {
        DAL.Comment dal;

        public Comment(string strConnectionStringName)
        {
            dal = new DAL.Comment(strConnectionStringName);
        }
        /// <summary>
        /// 查询全部评论 返回DataTable(Cdt)
        /// </summary>
        /// <returns></returns>
        public DataTable CommentsView()
        {
            return dal.CommentsView();
        }

        /// <summary>
        /// 查询已经审查通过评论或未通过的评论 返回DataTable
        /// </summary>
        /// <param name="SelectedValue"></param>
        /// <returns></returns>
        public DataTable CommentsSelectByEnable(bool SelectedValue)
        {
            return dal.CommentsSelectByEnable(SelectedValue);
        }


        ///<summary>
        ///添加新评论 电影评论使用
        ///</summary>
        public string CommentsInsert(Model.Comment Cmodel)
        {
            return dal.CommentsInsert(Cmodel);
        }

        /// <summary>
        /// 评论修改
        /// </summary>
        /// <param name="Cmodel"></param>
        /// <returns></returns>
        public string CommentsUpdate(Model.Comment Cmodel)
        {
            return dal.CommentsUpdate(Cmodel);

        }

        /// <summary>
        /// 删除评论
        /// </summary>
        /// <param name="Cmodel"></param>
        public void CommentsDelete(Model.Comment Cmodel)
        {
            dal.CommentsDelete(Cmodel);
        }

        /// <summary>
        /// 审查评论通过或者不通过
        /// </summary>
        /// <param name="Cmodel"></param>
        public void UpdateEnable(Model.Comment Cmodel)
        {
            dal.UpdateEnable(Cmodel);
        }

        public DataTable CommentsSelectByMid(String M_id)
        {
            return dal.CommentsSelectByMid(M_id);
        }
    }
}
