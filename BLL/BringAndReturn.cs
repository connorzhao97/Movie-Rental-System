using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class BringAndReturn
    {
        DAL.BringAndReturn dal;

        public BringAndReturn(string strConnectionStringName)
        {
            dal = new DAL.BringAndReturn(strConnectionStringName);
        }

        public DataTable BringAndReturnsView()
        {
            return dal.BringAndReturnsView();
        }

        /// <summary>
        /// 查询已经归还/未归还租赁单 返回DataTable
        /// </summary>
        /// <param name="SelectedValue"></param>
        /// <returns></returns>
        public DataTable BR_SelectedByBR_Return(bool SelectedValue)
        {
            return dal.BR_SelectedByBR_Return(SelectedValue);
        }


        ///<summary>
        ///添加新租赁单 租赁时使用
        ///</summary>
        public string BringAndReturnsInsert(Model.BringAndReturn BRmodel)
        {
            return dal.BringAndReturnsInsert(BRmodel);
        }

        /// <summary>
        /// 租赁单修改
        /// </summary>
        /// <param name="BRmodel"></param>
        /// <returns></returns>
        public string BringAndReturnsUpdate(Model.BringAndReturn BRmodel)
        {
            return dal.BringAndReturnsUpdate(BRmodel);

        }

        /// <summary>
        /// 删除租赁单
        /// </summary>
        /// <param name="BRmodel"></param>
        public void BringAndReturnsDelete(Model.BringAndReturn BRmodel)
        {
            dal.BringAndReturnsDelete(BRmodel);
        }

        /// <summary>
        /// 设置归还标志为1 规划时候改变
        /// </summary>
        /// <param name="BRmodel"></param>
        public void UpdateEnable(Model.BringAndReturn BRmodel)
        {
            dal.UpdateBR_Return(BRmodel);
        }

        /// <summary>
        /// 逾期欠费
        /// </summary>
        /// <param name="BRmodel"></param>
        public void BR_RentChange(Model.BringAndReturn BRmodel)
        {
            dal.BR_RentChange(BRmodel);
        }

        /// <summary>
        /// 用户id查询订单
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public DataTable BR_SelectedByU_Id(int id)
        {
            return dal.BR_SelectedByU_Id(id);
        }
    }
}
