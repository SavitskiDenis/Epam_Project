using Common.Entity;
using Common.Reader;
using Common.SQLExecuter;
using Special_Insulator.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Configuration;

namespace Special_Insulator.DAL
{
    
    public class PersonData : IPersonData
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
