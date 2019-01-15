using Common.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Special_Insulator.DAL
{
    public interface IDetaineeData
    {
        List<DetaineeWithName> GetAllDeteinees();

        bool AddDetainee(Person person,Detainee detainee);

        bool DeletDetaineeById(int? id);

        DetaineeWithName GetDeteineeById(int? Id);

        bool EditDetaineeInfo(DetaineeWithName detaineeWithName);

    }
}
