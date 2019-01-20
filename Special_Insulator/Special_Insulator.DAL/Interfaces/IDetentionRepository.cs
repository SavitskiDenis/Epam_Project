using SpecialInsulator.Common.Entity;
using System;
using System.Collections.Generic;

namespace SpecialInsulator.DAL.Interfaces
{
    public interface IDetentionRepository
    {
        List<Detention> GetDetentionsByDetaineeId(int id);

        bool AddDetention(Detention detention);

        int DeleteDetention(int Id);

        Detention GetDetentionById(int Id);

        bool EditDetention(Detention detention);

        bool DeleteDetentionByDetaineeId(int Id);

        List<int> GetDetentionsIdByDetaineeId(int Id);

        DateTime GetLastDetentionDateByDetaineeId(int Id);
    }
}
