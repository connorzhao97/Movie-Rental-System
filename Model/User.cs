using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class User
    {
        /// <summary>
        /// 用户编号
        /// </summary>
        public int U_Id { get; set; }
        /// <summary>
        /// 用户名
        /// </summary>
        public string U_Name { get; set; }
        /// <summary>
        /// 用户密码
        /// </summary>
        public string U_Pass { get; set; }
        /// <summary>
        /// 用户邮箱
        /// </summary>
        public string U_Email{ get; set; }
        /// <summary>
        /// 角色ID
        /// </summary>
        public int Ch_Id { get; set; }
        /// <summary>
        /// 禁用/启用
        /// </summary>
        public bool U_Enable { get; set; }
        /// <summary>
        /// 是否在线
        /// </summary>
        public int U_IsOnline { get; set; }
        /// <summary>
        /// 用户昵称
        /// </summary>
        public string U_Nickname { get; set; }
        /// <summary>
        /// 用户性别
        /// </summary>
        public string U_Gender { get; set; }
        /// <summary>
        /// 用户地址
        /// </summary>
        public string U_Address { get; set; }
        /// <summary>
        /// 用户图片路径
        /// </summary>
        public string U_Picture { get; set; }
        /// <summary>
        /// 用户等级
        /// </summary>
        public int U_Level { get; set; }
        /// <summary>
        /// 用户验证是否通过
        /// </summary>
        public bool U_Confirm { get; set; }
        /// <summary>
        /// 用户验证码
        /// </summary>
        public String U_Code { get; set; }
    }
}

