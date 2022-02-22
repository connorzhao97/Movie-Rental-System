using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Movie
    {
        /// <summary>
        /// 电影编号
        /// </summary>
        public int M_Id { get; set; }
        /// <summary>
        /// 电影名
        /// </summary>
        public string M_Name { get; set; }
        /// <summary>
        /// 电影英文名
        /// </summary>
        public string M_eName { get; set; }
        /// <summary>
        /// 电影时长
        /// </summary>
        public string M_Length { get; set; }
        /// <summary>
        /// 电影评分
        /// </summary>
        public string M_Grade { get; set; }
        /// <summary>
        /// 电影类型
        /// </summary>
        public string M_Type { get; set; }
        /// <summary>
        /// 电影地区
        /// </summary>
        public string M_Area{ get; set; }
        /// <summary>
        /// 电影时间
        /// </summary>
        public string M_Date { get; set; }
        /// <summary>
        /// 电影库存
        /// </summary>
        public int M_Stock { get; set; }
        /// <summary>
        /// 电影租赁次数
        /// </summary>
        public int M_Frequency { get; set; }
        /// <summary>
        /// 电影图片路径
        /// </summary>
        public string M_Picture { get; set; }
        /// <summary>
        /// 电影简介
        /// </summary>
        public string M_Intro { get; set; }

        ///// <summary>
        ///// 电影简介
        ///// </summary>
        public bool M_Enable { get; set; }

    }
}

