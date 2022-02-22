using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    //评论表
    public class Comment
    {
        /// <summary>
        /// 评编号
        /// </summary>
        public int Com_Id { get; set; }
        /// <summary>
        /// 用户编号
        /// </summary>
        public int U_Id { get; set; }
        /// <summary>
        /// 用户名
        /// </summary>
        public string U_Name { get; set; }
        /// <summary>
        /// 电影编号
        /// </summary>
        public int M_Id { get; set; }
        /// <summary>
        /// 用户评分
        /// </summary>
        public float Com_Grade { get; set; }
        /// <summary>
        /// 评论时间
        /// </summary>
        public DateTime Com_Date { get; set; }
        /// <summary>
        /// 评论内容
        /// </summary>
        public string Com_Content { get; set; }
        /// <summary>
        /// 评论是否通过
        /// </summary>
        public bool Com_Enable { get; set; }
    }
}
