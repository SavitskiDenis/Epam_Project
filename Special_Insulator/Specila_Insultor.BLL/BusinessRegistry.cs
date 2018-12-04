using StructureMap;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Specila_Insultor.BLL
{
    public class BusinessRegistry : Registry
    {
        public BusinessRegistry()
        {
            Scan(
                scan => {
                    scan.TheCallingAssembly();
                });

            For<IBusinessLayer>().Use<BusinessLayer>();
        }
    }
}
