using Special_Insulator.WCF;
using SpecialInsulator.BLL.Interfaces;
using SpecialInsulator.Common.Entity;
using SpecialInsulator.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Security.Policy;
using System.ServiceModel;

namespace SpecialInsulator.BLL.Implementations
{
    public class AdvertisingService : IAdvertisingService
    {
        public List<Advertising> GetLinks()
        {
            Uri address = new Uri("http://localhost:47310/AdvertisingWCFService.svc");
            BasicHttpBinding basic = new BasicHttpBinding();
            EndpointAddress endpoint = new EndpointAddress(address);
            ChannelFactory<IAdvertisingWCFService> factory = new ChannelFactory<IAdvertisingWCFService>(basic, endpoint);
            IAdvertisingWCFService channel = factory.CreateChannel();

            return channel.GetAdversiting();
        }
    }
}
