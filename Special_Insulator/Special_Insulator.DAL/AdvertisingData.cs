using Special_Insulator.DAL.Interfaces;
using Special_Insulator.DAL.ServiceReference1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace Special_Insulator.DAL
{
    public class AdvertisingData : IAdvertisingData
    {
        public Dictionary<Url[],string[]> GetLinks()
        {
            Uri address = new Uri("http://localhost:8733/Design_Time_Addresses/Special_Insulator.Advertising/Service1/");
            BasicHttpBinding basic = new BasicHttpBinding();
            EndpointAddress endpoint = new EndpointAddress(address);
            ChannelFactory<IService1> factory = new ChannelFactory<IService1>(basic,endpoint);
            IService1 channel = factory.CreateChannel();

            return channel.GetImages();
        }
    }
}
