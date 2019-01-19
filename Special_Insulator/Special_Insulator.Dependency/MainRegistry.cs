using Common;
using SpecialInsulator.DAL;
using Specila_Insultor.BLL;
using StructureMap;

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
                scan.AssemblyContainingType<CommonRegistry>();

                scan.LookForRegistries();
            });
        }
    }
}
