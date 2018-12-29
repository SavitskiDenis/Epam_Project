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
        IDetentionData detentionData;

        public DetentionBusiness(IDetentionData detention)
        {
            detentionData = detention;
        }

        public void AddDetention(Detention detention)
        {
            detentionData.AddDetention(detention);
        }

        public List<Detention> GetDetentionsByDetaineeId(int id)
        {
            return detentionData.GetDetentionsByDetaineeId(id);
        }
    }
}
