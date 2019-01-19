using SpecialInsulator.Common.Entity;
using SpecialInsulator.Common.Reader;
using SpecialInsulator.Common.SQLExecuter;
using SpecialInsulator.DAL.Interfaces;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Web.Configuration;

namespace SpecialInsulator.DAL.Implementations
{

    public class PersonRepository : IPersonRepository
    {
        private readonly string connectionString = WebConfigurationManager.ConnectionStrings["MyDb"].ConnectionString;

        public  Person GetPersonById(int id)
        {
            Person person;
            try
            {
                person = Executer.ExecuteRead(connectionString,
                                        "SelectPersonById",
                                        new ReadPerson(),
                                        new SqlParameter("@Id", id));
            }
            catch
            {
                return null;
            }
            return person;
            
        }

        //public string GetPhoneByDetaineeId(int id)
        //{
        //    return Executer.ExecuteRead(connectionString,
        //                                "SelectPhoneByDetaineeId",
        //                                new ReadPhoneNumber(),
        //                                new SqlParameter("@DetaineeId", id));
        //}

        public bool DeletePersonById(int personId)
        {
            try
            {
                Executer.ExecuteNonQuery(connectionString, "Delete_People", new SqlParameter("@Id", personId));
            }
            catch
            {
                return false;
            }
            return true;
            
        }

        public bool EditPerson(Person person)
        {
            try
            {
                SqlParameter[] parameters = new SqlParameter[]
                {
                    new SqlParameter("@Id",person.Id),
                    new SqlParameter("@FirstName",person.FirstName),
                    new SqlParameter("@LastName",person.LastName),
                    new SqlParameter("@Patronymic",person.Patronymic)
                };

                Executer.ExecuteNonQuery(connectionString, "UpdatePeople", parameters);
            }
            catch
            {
                return false;
            }
            return true;
            
        }

        
    }
}
