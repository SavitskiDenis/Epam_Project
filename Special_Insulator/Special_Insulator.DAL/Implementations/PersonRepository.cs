using SpecialInsulator.Common.Entity;
using SpecialInsulator.Common.Reader;
using SpecialInsulator.Common.SQLExecuter;
using SpecialInsulator.DAL.Interfaces;
using System.Data.SqlClient;
using System.Web.Configuration;

namespace SpecialInsulator.DAL.Implementations
{

    public class PersonRepository : IPersonRepository
    {
        public string connectionString = WebConfigurationManager.ConnectionStrings["MyDb"].ConnectionString;

        public  Person GetPersonById(int id)
        {
            return Executer.ExecuteRead(connectionString,
                                        "SelectPersonById",
                                        new ReadPerson(),
                                        new SqlParameter("@Id", id));
        }

        public  string GetPhoneByDetaineeId(int id)
        {
            return Executer.ExecuteRead(connectionString,
                                        "SelectPhoneByDetaineeId",
                                        new ReadPhoneNumber(),
                                        new SqlParameter("@DetaineeId", id));
        }

        public void DeletePersonById(int personId)
        {
            Executer.ExecuteNonQuery(connectionString, "Delete_People", new SqlParameter("@Id", personId));
        }

        public void EditPerson(Person person)
        {
            
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@Id",person.Id),
                new SqlParameter("@FirstName",person.FirstName),
                new SqlParameter("@LastName",person.LastName),
                new SqlParameter("@Patronymic",person.Patronymic)
            };


            Executer.ExecuteNonQuery(connectionString, "UpdatePeople",parameters);

        }
    }
}
