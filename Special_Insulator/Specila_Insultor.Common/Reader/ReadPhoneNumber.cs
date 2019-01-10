using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Reader
{
    public class ReadPhoneNumber : IReader<string>
    {
        public List<string> GetCollection(SqlDataReader dataReader)
        {
            throw new NotImplementedException();
        }

        public string GetModel(SqlDataReader dataReader)
        {
            string number = "Нет номера";
            try
            {
                dataReader.Read();
                number = dataReader.GetString(2);
            }
            catch { }
            
            return number;
        }
    }
}
