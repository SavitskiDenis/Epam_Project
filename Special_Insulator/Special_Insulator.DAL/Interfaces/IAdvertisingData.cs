using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace Special_Insulator.DAL.Interfaces
{
    public interface IAdvertisingData
    {
        Dictionary<Url[], string[]> GetLinks();
    }
}
