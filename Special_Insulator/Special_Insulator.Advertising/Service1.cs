using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Security.Policy;
using System.ServiceModel;
using System.Text;

namespace Special_Insulator.Advertising
{
    
    public class Service1 : IService1
    {
        public Url[] GetImages()
        {
            Url[] Urls = new Url[] { new Url("http://i.smotra.ru/data/img/users_imgs/20035/sm_users_img-264445.jpg"),new Url( "http://magistrchess.ru/img/sl-02m.jpg") };
            return Urls;
        }
    }
}
