using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Character
    {
        // <summary>
        /// 角色编号
        /// </summary>
        public int Ch_Id { get; set; }
        /// <summary>
        /// 角色名字 //游客 会员 管理员
        /// </summary>
        public string Ch_Name { get; set; }
        /// <summary>
        /// 是否启用
        /// </summary>
        public bool Ch_Enable { get; set; }
        /// <summary>
        /// 角色描述
        /// </summary>
        public string Ch_Intro { get; set; }
    }
}
