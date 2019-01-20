using System.Collections.Generic;
using SpecialInsulator.Common.Entity;
using SpecialInsulator.BLL.Interfaces;
using SpecialInsulator.DAL.Interfaces;
using SpecialInsulator.Common.Checker;

namespace SpecialInsulator.BLL.Implementations
{
    public class DetaineeService : IDetaineeService
    {
        private IDetaineeRepository detaineeRepository;

        public DetaineeService(IDetaineeRepository data)
        {
            this.detaineeRepository = data;
        }

        public bool AddDetainee(Person addPerson, Detainee addDetainee)
        {
            if(Checker.CheckedForNull(addPerson, addDetainee) && detaineeRepository.AddDetainee(addPerson, addDetainee))
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
            return detaineeRepository.GetAllDeteinees();
        }

        public bool DeleteDetaineeById(int? id)
        {
            if(Checker.CheckedForNull(id) && id>0 && detaineeRepository.DeletDetaineeById(id))
            {
                return true;
            }
            return false;
            
        }

        public DetaineeWithName GetDeteineeById(int? Id)
        {
            if(Checker.CheckedForNull(Id))
            {
                var detainee = detaineeRepository.GetDeteineeById(Id);
                if (detainee != null)
                {
                    return detainee;
                }
            }
            return null;
            
        }

        public bool EditDetaineeInfo(DetaineeWithName detainee)
        {
            if (Checker.CheckedForNull(detainee) && detaineeRepository.EditDetaineeInfo(detainee))
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
