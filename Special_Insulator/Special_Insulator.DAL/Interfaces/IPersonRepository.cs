using SpecialInsulator.Common.Entity;

namespace SpecialInsulator.DAL.Interfaces
{
    public interface IPersonRepository
    {
        Person GetPersonById(int id);
        string GetPhoneByDetaineeId(int id);
        void DeletePersonById(int personId);
        void EditPerson(Person person);
    }
}
