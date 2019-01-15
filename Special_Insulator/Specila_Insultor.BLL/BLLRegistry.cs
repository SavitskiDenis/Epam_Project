using StructureMap;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Specila_Insultor.BLL.Interfaces;

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
            For<IDetaineeBusiness>().Use<DetaineeBusiness>();
            For<IDetentionBusiness>().Use<DetentionBusiness>();
            For<IWorkerBusiness>().Use<WorkerBusiness>();
            For<IUserBusiness>().Use<UserBusiness>();
            For<IAdvertisingBusiness>().Use<AdvertisingBusiness>();
            For<IPostBusiness>().Use<PostBusiness>();
        }

    }
}
