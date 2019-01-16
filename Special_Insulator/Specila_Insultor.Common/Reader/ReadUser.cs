using SpecialInsulator.Common.Entity;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace SpecialInsulator.Common.Reader
{
    public class ReadUser : IReader<User>
    {
        public List<User> GetCollection(SqlDataReader dataReader)
        {
            List<User> users = new List<User>();
            User user;

            try
            {
                if (dataReader.HasRows)
                {
                    while (dataReader.Read())
                    {
                        user = new User()
                        {
                            Id = (int)dataReader["Id"],
                            Login = (string)dataReader["Login"],
                            Password = (string)dataReader["Password"],
                            Email = (string)dataReader["Email"]
                        };
                        users.Add(user);
                    }
                }
            }
            catch
            {
                throw;
            }

            return users;
        }

        public User GetModel(SqlDataReader dataReader)
        {
            throw new NotImplementedException();
        }
    }
}
