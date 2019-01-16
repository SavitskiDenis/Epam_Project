using SpecialInsulator.Common.Entity;
using System.Collections.Generic;

namespace SpecialInsulator.BLL.Interfaces
{
    public interface IDetentionService
    {
        List<Detention> GetDetentionsByDetaineeId(int id);

        void AddDetention(Detention detention);

        void DeleteDetention(int Id);

        Detention GetDetentionById(int Id);

        void EditDetention(Detention detention);
    }
}
