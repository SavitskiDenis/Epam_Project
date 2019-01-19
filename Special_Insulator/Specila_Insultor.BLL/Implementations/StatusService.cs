using SpecialInsulator.BLL.Interfaces;
using SpecialInsulator.Common.Entity;
using SpecialInsulator.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpecialInsulator.BLL.Implementations
{
    class StatusService : IStatusService
    {
        private readonly IStatusRepository status;

        public StatusService(IStatusRepository status)
        {
            this.status = status;
        }

        public List<Status> GetAllStatuses()
        {
            return status.GetAllStatuses();
        }

        public List<Status> GetAllStatusesAndSwap(int? Id)
        {
            List<Status> statuses = GetAllStatuses();

            if (Id != null && Id > 0 && Id <= statuses.Count)
            {
                int statusId = int.Parse(Id.ToString());
                Status status = statuses[0];
                statuses[0] = statuses[statusId-1];
                statuses[statusId-1] = status;
            }
            else
            {
                return new List<Status>();
            }

            return statuses;
        }
    }
}
