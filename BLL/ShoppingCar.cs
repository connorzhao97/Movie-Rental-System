using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class ShoppingCar
    {
        DAL.ShoppingCar dal;
        public ShoppingCar(string strConnectionStringName)
        {
            dal = new DAL.ShoppingCar(strConnectionStringName);
        }
        public DataTable SelectedByU_Id(int U_Id)
        {
            return dal.SelectedByU_Id(U_Id);
        }
        public string SCarInserts(Model.ShoppingCar Smodel)
        {
           return dal.SCarInserts(Smodel);
        }

        public void SCarDelete(Model.ShoppingCar Smodel)
        {
            dal.SCarDelete(Smodel);
        }
    }
}
