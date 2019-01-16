using System.Collections.Generic;
using System.Security.Policy;

namespace SpecialInsulator.DAL.Interfaces
{
    public interface IAdvertisingRepository
    {
        Dictionary<Url[], string[]> GetLinks();
    }
}
