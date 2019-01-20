using System.Collections.Generic;
using SpecialInsulator.Common.Entity;
using SpecialInsulator.BLL.Interfaces;
using SpecialInsulator.DAL.Interfaces;

namespace SpecialInsulator.BLL.Implementations
{
    class DetentionService : IDetentionService
    {
        private IDetentionRepository detentionRepository;

        public DetentionService(IDetentionRepository detention)
        {
            detentionRepository = detention;
        }

        public bool AddDetention(Detention detention)
        {
            if(detention != null)
            {
                return detentionRepository.AddDetention(detention);
            }
            return false;
        }

        public int DeleteDetention(int? Id)
        {
            if(Id != null)
            {
                return detentionRepository.DeleteDetention(int.Parse(Id.ToString()));
            }
            return 0;
        }

        public List<Detention> GetDetentionsByDetaineeId(int? id)
        {
            if(id != null)
            {
                return detentionRepository.GetDetentionsByDetaineeId(int.Parse(id.ToString()));
            }
            return null;
        }

        public Detention GetDetentionById(int? Id)
        {
            if(Id != null)
            {
                return detentionRepository.GetDetentionById(int.Parse(Id.ToString()));
            }
            return null;
        }

        public bool EditDetention(Detention detention)
        {
            if(detention != null)
            {
                return detentionRepository.EditDetention(detention);
            }
            return false;
        }
    }
}
