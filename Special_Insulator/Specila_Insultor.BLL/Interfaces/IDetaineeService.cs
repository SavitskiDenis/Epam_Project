using SpecialInsulator.Common.Entity;
using System.Collections.Generic;

namespace SpecialInsulator.BLL.Interfaces
{
    public interface IDetaineeService
    {
        List<DetaineeWithName> GetAllDetainees();

        bool AddDetainee(Person addPerson,Detainee addDetainee);

        bool DeleteDetaineeById(int? id);

        DetaineeWithName GetDeteineeById(int? Id);

        bool EditDetaineeInfo(DetaineeWithName detainee);
    }
}
