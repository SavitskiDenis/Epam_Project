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

        public bool AddDetainee(Person addPerson, Detainee addDetainee)
        {
            if(data.AddDetainee(addPerson, addDetainee))
            {
                return true;
            }
            else
            {
                return false;
            }
            
           
        }

        public List<DetaineeWithName> GetAllDetainees()
        {
            var detainees = data.GetAllDeteinees();
            if(detainees != null)
            {
                return detainees;
            }
            else
            {
                return new List<DetaineeWithName>();
            }
            
        }

        public bool DeleteDetaineeById(int? id)
        {
            if(id!=null && id>0 && data.DeletDetaineeById(id) == true)
            {
                return true;
            }
            return false;
            
        }

        public DetaineeWithName GetDeteineeById(int? Id)
        {
            var detainee = data.GetDeteineeById(Id);
            if (detainee !=null)
            {
                return detainee;
            }
            return new DetaineeWithName(new Detainee() { Id=0},new Person());
        }

        public bool EditDetaineeInfo(DetaineeWithName detainee)
        {
            if (data.EditDetaineeInfo(detainee))
            {
                return true;
            }
            return false;
           
        }
    }
}
