using Common.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Specila_Insultor.BLL.Interfaces
{
    public interface IDetentionBusiness
    {
        List<Detention> GetDetentionsByDetaineeId(int id);

        void AddDetention(Detention detention);

        void DeleteDetention(int Id);

        Detention GetDetentionById(int Id);

        void EditDetention(Detention detention);
    }
}
