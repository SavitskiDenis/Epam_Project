using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Security.Policy;
using System.ServiceModel;
using System.Text;

namespace Special_Insulator.Advertising
{
    
    [ServiceContract]
    public interface IService1
    {
        [OperationContract]
        Url[] GetImages();

    }

   
}
