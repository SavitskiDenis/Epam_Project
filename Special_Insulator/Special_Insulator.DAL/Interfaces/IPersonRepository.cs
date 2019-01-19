using SpecialInsulator.Common.Entity;
using System.Collections.Generic;

namespace SpecialInsulator.DAL.Interfaces
{
    public interface IPersonRepository
    {
        Person GetPersonById(int id);
        //string GetPhoneByDetaineeId(int id);
        bool DeletePersonById(int personId);
        bool EditPerson(Person person);
    }
}
