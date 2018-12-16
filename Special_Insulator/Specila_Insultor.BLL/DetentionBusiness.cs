using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.Entity;
using Special_Insulator.DAL.Interfaces;
using Specila_Insultor.BLL.Interfaces;

namespace Specila_Insultor.BLL
{
    class DetentionBusiness : IDetentionBusiness
    {
        IDetentionData detention;

        public DetentionBusiness(IDetentionData detention)
        {
            this.detention = detention;
        }

        public List<Detention> GetDetentionsByDetaineeId(int id)
        {
            return detention.GetDetentionsByDetaineeId(id);
        }
    }
}
