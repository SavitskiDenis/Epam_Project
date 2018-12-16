using Common.Entity;
using Special_Insulator.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Special_Insulator.DAL
{
    class DetentionData : IDetentionData
    {

        public List<Detention> GetDetentionsByDetaineeId(int id)
        {
            List<Detention> detentions = new List<Detention>();



            return detentions;
        }
    }
}
