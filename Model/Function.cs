using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Function
    {
        // <summary>
        /// 功能编号
        /// </summary>
        public int F_Id { get; set; }
        /// <summary>
        /// 功能名字
        /// </summary>
        public string F_Name { get; set; }
        /// <summary>
        /// 功能路径
        /// </summary>
        public string F_Path { get; set; }
        /// <summary>
        /// 父功能Id
        /// </summary>
        public int F_ParentId { get; set; }
        /// <summary>
        /// 是否启用
        /// </summary>
        public bool F_Enable { get; set; }
    }
}
