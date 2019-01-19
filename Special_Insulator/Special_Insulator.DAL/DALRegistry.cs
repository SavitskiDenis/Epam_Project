using SpecialInsulator.DAL.Implementations;
using SpecialInsulator.DAL.Interfaces;
using StructureMap;

namespace SpecialInsulator.DAL
{
    public class DALRegistry : Registry
    {
        public DALRegistry()
        {
            For<IDetaineeRepository>().Singleton().Use<DetaineeRepository>();
            For<IPersonRepository>().Singleton().Use<PersonRepository>();
            For<IDetentionRepository>().Singleton().Use<DetentionRepository>();
            For<IWorkerRepository>().Singleton().Use<WorkerRepository>();
            For<IDetentionPlaceRepository>().Singleton().Use<DetentionPlaceRepository>();
            For<IRoleRepository>().Singleton().Use<RoleRepository>();
            For<IUserRepository>().Singleton().Use<UserRepository>();
            For<IAdvertisingRepository>().Singleton().Use<AdvertisingRepository>();
            For<IPostRepository>().Singleton().Use<PostRepository>();
            For<IStatusRepository>().Singleton().Use<StatusRepository>();
        }
    }
}
