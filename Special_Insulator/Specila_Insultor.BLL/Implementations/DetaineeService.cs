using System.Collections.Generic;
using SpecialInsulator.Common.Entity;
using SpecialInsulator.BLL.Interfaces;
using SpecialInsulator.DAL.Interfaces;
using SpecialInsulator.Common.Checker;

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
            if(Checker.CheckedForNull(addPerson, addDetainee) && data.AddDetainee(addPerson, addDetainee))
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
            return data.GetAllDeteinees();
        }

        public bool DeleteDetaineeById(int? id)
        {
            if(Checker.CheckedForNull(id) && id>0 && data.DeletDetaineeById(id))
            {
                return true;
            }
            return false;
            
        }

        public DetaineeWithName GetDeteineeById(int? Id)
        {
            if(Checker.CheckedForNull(Id))
            {
                var detainee = data.GetDeteineeById(Id);
                if (detainee != null)
                {
                    return detainee;
                }
            }
            return null;
            
        }

        public bool EditDetaineeInfo(DetaineeWithName detainee)
        {
            if (Checker.CheckedForNull(detainee) && data.EditDetaineeInfo(detainee))
            {
                return true;
            }
            return false;
           
        }

        public List<DetaineeWithName> SortCollectionByType(string text, string type)
        {
            List<DetaineeWithName> collection = null;
            if (Checker.CheckedForNull(type))
            {
                if (type == "Все")
                {
                    collection = GetAllDetainees();
                }
                else if (type == "По ФИО" && Checker.CheckedForNull(type))
                {
                    collection = GetAllDetainees().FindAll(item => (item.person.LastName + " " + item.person.FirstName + " " + item.person.Patronymic).Contains(text));
                }
                else if (type == "По адресу" && Checker.CheckedForNull(type))
                {
                    collection = GetAllDetainees().FindAll(item => item.detainee.Address == text);
                }
                else if(type == "По дате задержания" && Checker.CheckedForNull(type))
                {
                    collection = GetAllDetainees().FindAll(item => item.lastDetention.ToShortDateString() == text);
                }
            }
            
            
            return collection;
        }

        public bool ExistId(int? Id)
        {
            if(Id != null)
            {
                var detainees = GetAllDetainees();
                if (detainees != null && detainees.Count > 0)
                {
                    foreach(var item in detainees)
                    {
                        if(item.detainee.Id == Id)
                        {
                            return true;
                        }
                    }
                }
            }
            return false;
        }
    }
}
