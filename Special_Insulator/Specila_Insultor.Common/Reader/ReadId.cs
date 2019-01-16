using System.Collections.Generic;
using System.Data.SqlClient;

namespace SpecialInsulator.Common.Reader
{
    public class ReadId : IReader<int>
    {
        public List<int> GetCollection(SqlDataReader dataReader)
        {
            List<int> idList = new List<int>();
            try
            {
                if(dataReader.HasRows)
                {
                    while (dataReader.Read())
                    {
                        idList.Add(dataReader.GetInt32(0));
                    }
                }
                
            }
            catch { throw; }
            return idList;
        }

        public int GetModel(SqlDataReader dataReader)
        {
            int id;
            try
            {
                dataReader.Read();
                id = dataReader.GetInt32(0);
            }
            catch
            {
                throw;
            }
            return id;
        }
    }
}
