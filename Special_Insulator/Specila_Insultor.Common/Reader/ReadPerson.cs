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
                    FirstName = (string)dataReader["FirstName"],
                    Id = (int)dataReader["Id"],
                    LastName = (string)dataReader["LastName"],
                    Patronymic = (string)dataReader["Patronymic"]
                };
            }
            catch { throw; }
            return person;
        }
    }
}
