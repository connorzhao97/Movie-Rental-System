using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class Character
    {
        DAL.Character dal;
        public Character(string strConnectionStringName)
        {
            dal = new DAL.Character(strConnectionStringName);
        }

        /// <summary>
        /// 查询全部角色 返回DataTable(Cdt)
        /// </summary>
        /// <returns></returns>
        public DataTable CharactersView()
        {
            
            return dal.CharactersView();
        }

        /// <summary>
        /// 添加角色 返回DataTable(Cdt)
        /// </summary>
        /// <returns></returns>
        public string CharactersInsert(Model.Character model)
        {

            return dal.CharactersInsert(model);
        }

        /// <summary>
        /// 修改角色
        /// </summary>
        /// <returns></returns>
        public string CharactersUpdate(Model.Character model)
        {

            return dal.CharactersUpdate(model);
        }

        /// <summary>
        /// 删除角色
        /// </summary>
        /// <returns></returns>
        public void CharactersDelete(Model.Character model)
        {

            dal.CharactersDelete(model);
        }

        /// <summary>
        /// 修改角色是否可用
        /// </summary>
        /// <returns></returns>
        public void CharactersUpdateEnable(Model.Character model)
        {

            dal.CharactersUpdateEnable(model);
        }
    }
}
