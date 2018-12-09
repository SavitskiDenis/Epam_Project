using Special_Insulator.DAL;
using Specila_Insultor.BLL;
using StructureMap;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Special_Insulator.Dependency
{
    public class MainRegistry : Registry
    {
        public MainRegistry()
        {
            Scan(scan =>
            {
                scan.AssemblyContainingType<DALRegistry>();
                scan.AssemblyContainingType<BLLRegistry>();

                scan.LookForRegistries();
            });
        }
    }
}
