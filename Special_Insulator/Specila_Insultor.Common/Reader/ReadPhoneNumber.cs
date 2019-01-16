using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace SpecialInsulator.Common.Reader
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
                number = (string)dataReader["Number"];
            }
            catch { throw; }
            
            return number;
        }
    }
}
