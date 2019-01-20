using SpecialInsulator.Common.Entity;
using System.Collections.Generic;

namespace SpecialInsulator.BLL.Interfaces
{
    public interface IDetentionService
    {
        List<Detention> GetDetentionsByDetaineeId(int? id);

        bool AddDetention(Detention detention);

        int DeleteDetention(int? Id);

        Detention GetDetentionById(int? Id);

        bool EditDetention(Detention detention);
    }
}
