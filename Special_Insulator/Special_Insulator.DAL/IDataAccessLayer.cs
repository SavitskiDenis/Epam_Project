using Common.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Special_Insulator.DAL
{
    public interface IDataAccessLayer
    {
        List<DetaineeWithName> GetAllDeteinees();
    }
}
