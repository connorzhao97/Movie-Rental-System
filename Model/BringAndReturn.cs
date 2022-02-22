using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    //租赁表
    public class BringAndReturn
    {
        /// <summary>
        /// 租赁编号
        /// </summary>
        public int BR_Id { get; set; }
        /// <summary>
        /// 用户编号
        /// </summary>
        public int U_Id { get; set; }
        /// <summary>
        /// 电影编号
        /// </summary>
        public int M_Id { get; set; }
        /// <summary>
        /// 租赁时间
        /// </summary>
        public DateTime B_Date { get; set; }
        /// <summary>
        /// 归还时间
        /// </summary>
        public DateTime R_Date { get; set; }
        /// <summary>
        /// 租金
        /// </summary>
        public float B_Rent { get; set; }
        /// <summary>
        /// 是否归还
        /// </summary>
        public bool BR_Return { get; set; }
    }
}
