using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    //导演演员表
    public class DirectorAndActor
    {
        /// <summary>
        /// 导演演员编号
        /// </summary>
        public int DA_Id { get; set; }
        /// <summary>
        /// 电影Id
        /// </summary>
        public int M_Id { get; set; }
        /// <summary>
        /// 导演演员名字
        /// </summary>
        public string DA_Name { get; set; }
        /// <summary>
        /// 导演演员图片路径
        /// </summary>
        public string DA_Picture { get; set; }
        /// <summary>
        /// 导演演员标志符
        /// </summary>
        public bool DA_DorA { get; set; }
        /// <summary>
        /// 导演/演员简介
        /// </summary>
        public string DA_Intro { get; set; }
        /// <summary>
        /// 导演/演员英文名
        /// </summary>
        public string DA_EName { get; set; }
    }
}
