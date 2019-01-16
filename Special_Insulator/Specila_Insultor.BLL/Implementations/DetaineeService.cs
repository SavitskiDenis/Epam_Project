using System.Collections.Generic;
using SpecialInsulator.Common.Entity;
using SpecialInsulator.BLL.Interfaces;
using SpecialInsulator.DAL.Interfaces;

namespace SpecialInsulator.BLL.Implementations
{
    public class DetaineeService : IDetaineeService
    {
        private IDetaineeRepository data;

        public DetaineeService(IDetaineeRepository data)
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
