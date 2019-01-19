using SpecialInsulator.Common.Entity;
using SpecialInsulator.Common.Reader;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpecialInsulator.Common.Reader
{
    public class ReadStatus : IReader<Status>
    {
        public List<Status> GetCollection(SqlDataReader dataReader)
        {
            List<Status> statuses = new List<Status>();
            Status status = null;
            try
            {
                if(dataReader.HasRows)
                {
                    while(dataReader.Read())
                    {
                        status = new Status
                        {
                            Id = (int)dataReader["Id"],
                            StatusName = (string)dataReader["StatusName"]
                        };
                        statuses.Add(status);
                    }
                }
            }
            catch
            {
                throw;
            }

            return statuses;
        }

        public Status GetModel(SqlDataReader dataReader)
        {
            throw new NotImplementedException();
        }
    }
}
