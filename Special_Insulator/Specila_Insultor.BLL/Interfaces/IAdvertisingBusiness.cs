using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace Specila_Insultor.BLL.Interfaces
{
    public interface IAdvertisingBusiness
    {
        Dictionary<Url[], string[]> GetLinks();
    }
}
