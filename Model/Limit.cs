using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    //权限表
    public class Limit
    {
        // <summary>
        /// 权限编号
        /// </summary>
        public int L_Id { get; set; }
        // <summary>
        /// 角色编号
        /// </summary>
        public int Ch_Id { get; set; }
        /// <summary>
        /// 功能编号
        /// </summary>
        public int F_Id { get; set; }
        /// <summary>
        /// 功能名
        /// </summary>
        public string F_Name { get; set; }
        /// <summary>
        /// 角色名
        /// </summary>
        public string Ch_Name { get; set; }
        /// <summary>
        /// 是否启用
        /// </summary>
        public bool L_Enable { get; set; }
    }
}
