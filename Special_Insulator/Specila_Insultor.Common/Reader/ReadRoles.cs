using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Reader
{
    public class ReadRoles : IReader<string>
    {
        public List<string> GetCollection(SqlDataReader dataReader)
        {
            throw new NotImplementedException();
        }

        public string GetModel(SqlDataReader dataReader)
        {
            string role = null;
            try
            {
                if(dataReader.HasRows)
                {
                    dataReader.Read();
                    role = (string)dataReader["RoleName"];
                }
            }
            catch { throw; }
            return role;
        }
    }
}
