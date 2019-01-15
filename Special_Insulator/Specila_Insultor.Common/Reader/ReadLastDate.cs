using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Reader
{
    public class ReadLastDate : IReader<DateTime>
    {
        public List<DateTime> GetCollection(SqlDataReader dataReader)
        {
            throw new NotImplementedException();
        }

        public DateTime GetModel(SqlDataReader dataReader)
        {
            DateTime date = new DateTime();
            try
            {
                if (dataReader.HasRows)
                {
                    dataReader.Read();
                    date = dataReader.GetDateTime(0);
                }
            }
            catch
            {
                throw;
            }
            return date;
        }
    }
}
