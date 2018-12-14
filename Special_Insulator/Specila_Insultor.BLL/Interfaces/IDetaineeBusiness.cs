using Common.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Specila_Insultor.BLL
{
    public interface IDetaineeBusiness
    {
        List<DetaineeWithName> GetAllDetainees();

        void AddDetainee(Person addPerson,Detainee addDetainee);
    }
}
