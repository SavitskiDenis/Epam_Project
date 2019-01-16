using SpecialInsulator.Common.Entity;
using System.Collections.Generic;

namespace SpecialInsulator.DAL.Interfaces
{
    public interface IDetentionRepository
    {
        List<Detention> GetDetentionsByDetaineeId(int id);

        void AddDetention(Detention detention);

        void DeleteDetention(int Id);

        Detention GetDetentionById(int Id);

        void EditDetention(Detention detention);

        void DeleteDetentionByDetaineeId(int Id);

        List<int> GetDetentionsIdByDetaineeId(int Id);
    }
}
