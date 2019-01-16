using Special_Insulator.WCF;
using SpecialInsulator.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Security.Policy;
using System.ServiceModel;

namespace SpecialInsulator.DAL
{
    public class AdvertisingRepository : IAdvertisingRepository
    {
        public Dictionary<Url[],string[]> GetLinks()
        {
            //Uri address = new Uri("http://localhost:8733/Design_Time_Addresses/Special_Insulator.Advertising/Service1/");
            //BasicHttpBinding basic = new BasicHttpBinding();
            //EndpointAddress endpoint = new EndpointAddress(address);
            //ChannelFactory<IAdvertisingWCFService> factory = new ChannelFactory<IAdvertisingWCFService>(basic, endpoint);
            //IAdvertisingWCFService channel = factory.CreateChannel();

            return new Dictionary<Url[], string[]>();
        }
    }
}
