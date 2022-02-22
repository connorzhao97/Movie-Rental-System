using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class ShoppingCar
    {
        /// <summary>
        //购物Id
        /// </summary>
        public int S_Id { get; set; }

        /// <summary>
        /// 用户Id
        /// </summary>
        public int U_Id { get; set; }

        /// <summary>
        /// 电影Id
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
        /// 电影图片路径
        /// </summary>
        public string M_Picture { get; set; }
        /// <summary>
        /// 电影简介
        /// </summary>
        public string M_Intro { get; set; }
    }
}
