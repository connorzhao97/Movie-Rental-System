using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class Limit
    {
        DAL.Limit dal;
        public Limit(string strConnectionStringName)
        {
            dal = new DAL.Limit(strConnectionStringName);
        }

        /// <summary>
        /// 查询全部权限 返回DataTable(Cdt)
        /// </summary>
        /// <returns></returns>
        public DataTable LimitView()
        {

            return dal.LimitView();
        }

        /// <summary>
        /// 查询全部功能 返回DataTable(Cdt)
        /// </summary>
        /// <returns></returns>
        public DataTable FunctionName()
        {

            return dal.FunctionName();
        }

        /// <summary>
        /// 查询全部角色 返回DataTable(Cdt)
        /// </summary>
        /// <returns></returns>
        public DataTable CharacterName()
        {

            return dal.CharacterName();
        }
        /// <summary>
        /// 添加权限
        /// </summary>
        /// <returns>是否成功的提示</returns>
        public string LimitInsert(Model.Limit model)
        {

            return dal.LimitInsert(model);
        }
        /// <summary>
        /// 修改权限
        /// </summary>
        /// <returns></returns>
        public string LimitUpdate(Model.Limit model)
        {

            return dal.LimitUpdate(model);
        }

        /// <summary>
        /// 删除权限
        /// </summary>
        /// <returns></returns>
        public void LimitDelete(Model.Limit model)
        {

            dal.LimitDelete(model);
        }

        /// <summary>
        /// 修改权限是否可用
        /// </summary>
        /// <returns></returns>
        public void LimitUpdateEnable(Model.Limit model)
        {

            dal.LimitUpdateEnable(model);
        }
    }
}
