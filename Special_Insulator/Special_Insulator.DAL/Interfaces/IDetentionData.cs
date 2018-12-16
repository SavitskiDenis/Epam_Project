using Common.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Special_Insulator.DAL.Interfaces
{
    public interface IDetentionData
    {
        List<Detention> GetDetentionsByDetaineeId(int id);

    }
}
