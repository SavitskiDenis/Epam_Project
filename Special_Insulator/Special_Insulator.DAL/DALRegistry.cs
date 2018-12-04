using StructureMap;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Special_Insulator.DAL
{
    public class DALRegistry
    {
        public class DARegistry : Registry
        {
            public DARegistry()
            {
                For<IDataAccessLayer>().Use<DataAccessLayer>();
            }
        }
    }
}
