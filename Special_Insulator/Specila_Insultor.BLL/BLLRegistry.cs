using StructureMap;
using SpecialInsulator.BLL.Interfaces;
using SpecialInsulator.BLL.Implementations;

namespace Specila_Insultor.BLL
{
    public class BLLRegistry : Registry
    {
        public BLLRegistry()
        {
            Scan(
                scan => {
                    scan.TheCallingAssembly();
                    scan.WithDefaultConventions();
                });
            For<IDetaineeService>().Use<DetaineeService>();
            For<IDetentionService>().Use<DetentionService>();
            For<IWorkerService>().Use<WorkerService>();
            For<IUserService>().Use<UserService>();
            For<IAdvertisingService>().Use<AdvertisingService>();
            For<IPostService>().Use<PostService>();
        }

    }
}
