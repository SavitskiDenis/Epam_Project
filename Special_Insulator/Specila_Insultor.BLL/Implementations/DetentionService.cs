using System.Collections.Generic;
using SpecialInsulator.Common.Entity;
using SpecialInsulator.BLL.Interfaces;
using SpecialInsulator.DAL.Interfaces;

namespace SpecialInsulator.BLL.Implementations
{
    class DetentionService : IDetentionService
    {
        private IDetentionRepository detentionData;

        public DetentionService(IDetentionRepository detention)
        {
            detentionData = detention;
        }

        public bool AddDetention(Detention detention)
        {
            if(detention != null)
            {
                return detentionData.AddDetention(detention);
            }
            return false;
        }

        public bool DeleteDetention(int? Id)
        {
            if(Id != null)
            {
                return detentionData.DeleteDetention(int.Parse(Id.ToString()));
            }
            return false;
        }

        public List<Detention> GetDetentionsByDetaineeId(int? id)
        {
            if(id != null)
            {
                return detentionData.GetDetentionsByDetaineeId(int.Parse(id.ToString()));
            }
            return null;
        }

        public Detention GetDetentionById(int? Id)
        {
            if(Id != null)
            {
                return detentionData.GetDetentionById(int.Parse(Id.ToString()));
            }
            return null;
        }

        public bool EditDetention(Detention detention)
        {
            if(detention != null)
            {
                return detentionData.EditDetention(detention);
            }
            return false;
        }
    }
}
