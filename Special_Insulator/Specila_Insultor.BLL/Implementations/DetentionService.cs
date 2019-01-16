using System.Collections.Generic;
using SpecialInsulator.Common.Entity;
using SpecialInsulator.BLL.Interfaces;
using SpecialInsulator.DAL.Interfaces;

namespace SpecialInsulator.BLL.Implementations
{
    class DetentionService : IDetentionService
    {
        IDetentionRepository detentionData;

        public DetentionService(IDetentionRepository detention)
        {
            detentionData = detention;
        }

        public void AddDetention(Detention detention)
        {
            detentionData.AddDetention(detention);
        }

        public void DeleteDetention(int Id)
        {
            detentionData.DeleteDetention(Id);
        }

        public List<Detention> GetDetentionsByDetaineeId(int id)
        {
            return detentionData.GetDetentionsByDetaineeId(id);
        }

        public Detention GetDetentionById(int Id)
        {
            return detentionData.GetDetentionById(Id);
        }

        public void EditDetention(Detention detention)
        {
            detentionData.EditDetention(detention);
        }
    }
}
