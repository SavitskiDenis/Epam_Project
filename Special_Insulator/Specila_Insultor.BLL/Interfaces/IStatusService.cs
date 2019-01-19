using SpecialInsulator.Common.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpecialInsulator.BLL.Interfaces
{
    public interface IStatusService
    {
        List<Status> GetAllStatuses();

        List<Status> GetAllStatusesAndSwap(int? Id);
    }
}
