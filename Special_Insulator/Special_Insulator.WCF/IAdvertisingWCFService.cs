using SpecialInsulator.Common.Entity;
using System.Collections.Generic;
using System.ServiceModel;

namespace Special_Insulator.WCF
{

    [ServiceContract]
    public interface IAdvertisingWCFService
    {

        [OperationContract]
        List<Advertising>  GetAdversiting();
        
    }


}
