using Special_Insulator.DAL.Interfaces;
using Specila_Insultor.BLL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace Specila_Insultor.BLL
{
    public class AdvertisingBusiness : IAdvertisingBusiness
    {
        IAdvertisingData advertising;

        public AdvertisingBusiness(IAdvertisingData advertising)
        {
            this.advertising = advertising;
        }

        public Dictionary<Url[], string[]> GetLinks()
        {
           
            return advertising.GetLinks();
        }
    }
}
