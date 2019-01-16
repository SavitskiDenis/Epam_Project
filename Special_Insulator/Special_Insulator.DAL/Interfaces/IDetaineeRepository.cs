using SpecialInsulator.Common.Entity;
using System.Collections.Generic;

namespace SpecialInsulator.DAL.Interfaces
{
    public interface IDetaineeRepository
    {
        List<DetaineeWithName> GetAllDeteinees();

        bool AddDetainee(Person person,Detainee detainee);

        bool DeletDetaineeById(int? id);

        DetaineeWithName GetDeteineeById(int? Id);

        bool EditDetaineeInfo(DetaineeWithName detaineeWithName);

    }
}
