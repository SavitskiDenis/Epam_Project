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

        void AddDetainee(Person person,Detainee detainee);

        void DeletDetaineeById(int id);

        DetaineeWithName GetDeteineeById(int Id);

        void UpdateDetaineeInfo(Detainee detainee);

    }
}
