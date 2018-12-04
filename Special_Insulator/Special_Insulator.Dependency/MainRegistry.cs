using Special_Insulator.DAL;
using Specila_Insultor.BLL;
using StructureMap;

namespace Special_Insulator.Dependency
{
    public class MainRegistry : Registry
    {
        public  MainRegistry()
        {
            Scan(
                scan => {
                    scan.AssemblyContainingType<BusinessRegistry>();
                    scan.AssemblyContainingType<DALRegistry>();
                }
                );
        }
    }
}
