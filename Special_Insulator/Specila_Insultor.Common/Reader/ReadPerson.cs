using Common.Entity;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Reader
{
    public class ReadPerson : IReader<Person>
    {
        public List<Person> GetCollection(SqlDataReader dataReader)
        {
            throw new NotImplementedException();
        }

        public Person GetModel(SqlDataReader dataReader)
        {
            Person person = null;
            try
            {
                dataReader.Read();
                person = new Person()
                {
                    FirstName = (string)dataReader.GetValue(1),
                    Id = (int)dataReader.GetValue(0),
                    LastName = (string)dataReader.GetValue(2)
                };
            }
            catch { }
            return person;
        }
    }
}
