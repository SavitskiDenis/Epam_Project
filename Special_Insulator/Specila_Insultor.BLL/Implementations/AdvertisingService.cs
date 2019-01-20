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
            List<Advertising> advertisings;
            try
            {
                Uri address = new Uri("http://localhost:47310/AdvertisingWCFService.svc");
                BasicHttpBinding basic = new BasicHttpBinding();
                EndpointAddress endpoint = new EndpointAddress(address);
                ChannelFactory<IAdvertisingWCFService> factory = new ChannelFactory<IAdvertisingWCFService>(basic, endpoint);
                IAdvertisingWCFService channel = factory.CreateChannel();

                advertisings =  channel.GetAdversiting();
            }
            catch
            {
                return new List<Advertising>();
            }
            return advertisings;
        }
    }
}
