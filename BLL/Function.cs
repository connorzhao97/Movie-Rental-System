using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class Function
    {
        DAL.Function dal;
        public Function(string strConnectionStringName)
        {
            dal = new DAL.Function(strConnectionStringName);
        }

        /// <summary>
        /// 查询全部功能 返回DataTable(Cdt)
        /// </summary>
        /// <returns></returns>
        public DataTable FunctionView()
        {

            return dal.FunctionView();
        }

        /// <summary>
        /// 添加功能 返回DataTable(Cdt)
        /// </summary>
        /// <returns></returns>
        public string FunctionInsert(Model.Function model)
        {

            return dal.FunctionInsert(model);
        }

        /// <summary>
        /// 修改功能
        /// </summary>
        /// <returns></returns>
        public string FunctionUpdate(Model.Function model)
        {

            return dal.FunctionUpdate(model);
        }

        /// <summary>
        /// 删除功能
        /// </summary>
        /// <returns></returns>
        public void FunctionDelete(Model.Function model)
        {

            dal.FunctionDelete(model);
        }

        /// <summary>
        /// 修改功能是否可用
        /// </summary>
        /// <returns></returns>
        public void FunctionUpdateEnable(Model.Function model)
        {

            dal.FunctionUpdateEnable(model);
        }
    }
}
