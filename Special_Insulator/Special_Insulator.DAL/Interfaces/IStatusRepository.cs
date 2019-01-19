using SpecialInsulator.Common.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpecialInsulator.DAL.Interfaces
{
    public interface IStatusRepository
    {
        List<Status> GetAllStatuses();
    }
}
