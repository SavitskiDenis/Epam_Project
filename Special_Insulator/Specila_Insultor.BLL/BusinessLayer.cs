using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.Entity;
using Special_Insulator.DAL;

namespace Specila_Insultor.BLL
{
    public class BusinessLayer : IBusinessLayer
    {
        private IDataAccessLayer data;

        public List<Detainee> GetAllDetainees()
        {
            return data.GetAllDeteinees();
        }
    }
}
