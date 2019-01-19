using SpecialInsulator.Common.Entity;
using SpecialInsulator.Common.Reader;
using SpecialInsulator.Common.SQLExecuter;
using SpecialInsulator.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Configuration;

namespace SpecialInsulator.DAL.Implementations
{
    public class StatusRepository : IStatusRepository
    {
        private readonly string connectionString = WebConfigurationManager.ConnectionStrings["MyDb"].ConnectionString;

        public List<Status> GetAllStatuses()
        {
            List<Status> statuses;
            try
            {
                statuses = Executer.ExecuteCollectionRead(connectionString, "SelectAllStatuses", new ReadStatus());
            }
            catch
            {
                return null;
            }
            return statuses;
        }
    }
}
