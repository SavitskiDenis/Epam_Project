using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.Entity;
using Special_Insulator.DAL;

namespace Specila_Insultor.BLL
{
    public class DetaineeBusiness : IDetaineeBusiness
    {
        private IDetaineeData data;

        public DetaineeBusiness(IDetaineeData data)
        {
            this.data = data;
        }

        public void AddDetainee(Person addPerson, Detainee addDetainee)
        {
            data.AddDetainee(addPerson,addDetainee);
        }

        public List<DetaineeWithName> GetAllDetainees()
        {
            return data.GetAllDeteinees();
        }

        public void DeleteDetaineeById(int id)
        {
            data.DeletDetaineeById(id);
        }

        public DetaineeWithName GetDeteineeById(int Id)
        {
            return data.GetDeteineeById(Id);
        }
    }
}
