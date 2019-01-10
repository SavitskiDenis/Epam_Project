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
        public string connectionString = /*WebConfigurationManager.ConnectionStrings["MyDataBase"].ConnectionString*/@"Data Source=.\;Initial Catalog=SIDb;Integrated Security=True";

        public  Person GetPersonById(int id)
        {
            //using (SqlConnection connection = new SqlConnection(connectionString))
            //{
            //    connection.Open();
            //    SqlDataReader PReader;
            //    SqlCommand getPerson;
            //    getPerson = new SqlCommand("SelectPersonById", connection);
            //    getPerson.CommandType = System.Data.CommandType.StoredProcedure;
            //    getPerson.Parameters.Add(new SqlParameter("@Id", id));
                   

            //    PReader = getPerson.ExecuteReader();
            //    PReader.Read();

            //    person = new Person()
            //    {
            //        FirstName = (string)PReader.GetValue(1),
            //        Id = (int)PReader.GetValue(0),
            //        LastName = (string)PReader.GetValue(2)
            //    };
            //    PReader.Close();
            //}
            return Executer.ExecuteRead(connectionString, "SelectPersonById",new ReadPerson(), new SqlParameter("@Id", id));
        }

        public  string GetPhoneByDetaineeId(int id)
        {
            //string number = "Нет номера";
            //string connectionString = @"Data Source=.\;Initial Catalog=SIDb;Integrated Security=True";

            //using (SqlConnection connection = new SqlConnection(connectionString))
            //{
            //    connection.Open();
            //    SqlDataReader PReader;
            //    SqlCommand getNumber;
            //    getNumber = new SqlCommand("SelectPhoneByDetaineeId", connection);
            //    getNumber.CommandType = System.Data.CommandType.StoredProcedure;
            //    getNumber.Parameters.Add(new SqlParameter("@DetaineeId", id));


            //    PReader = getNumber.ExecuteReader();
            //    if (PReader.HasRows)
            //    {
            //        PReader.Read();
            //        number = PReader.GetString(2);
            //    }
            //    PReader.Close();
            //}
            return Executer.ExecuteRead(connectionString, "SelectPhoneByDetaineeId",new ReadPhoneNumber(), new SqlParameter("@DetaineeId", id));
        }

        public void DeletePersonById(int personId)
        {
            //using (SqlConnection connection = new SqlConnection(connectionString))
            //{
            //    connection.Open();
            //    SqlCommand deletePerson = new SqlCommand("Delete_People", connection);
            //    deletePerson.CommandType = System.Data.CommandType.StoredProcedure;

            //    deletePerson.Parameters.Add(new SqlParameter("@Id", personId));
            //    var result = deletePerson.ExecuteNonQuery();
            //}
            Executer.ExecuteNonQuery(connectionString, "Delete_People", new SqlParameter("@Id", personId));
        }

        public void EditPerson(Person person)
        {
            //using (SqlConnection connection = new SqlConnection(connectionString))
            //{
            //    connection.Open();
            //    SqlCommand updatePerson = new SqlCommand("UpdatePeople", connection);
            //    updatePerson.CommandType = System.Data.CommandType.StoredProcedure;

            //    SqlParameter[] parameters = new SqlParameter[]
            //    {
            //        new SqlParameter("@Id",person.Id),
            //        new SqlParameter("@FirstName",person.FirstName),
            //        new SqlParameter("@LastName",person.LastName),
            //    };

            //    updatePerson.Parameters.AddRange(parameters);

            //    int result = updatePerson.ExecuteNonQuery();
            //}
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@Id",person.Id),
                new SqlParameter("@FirstName",person.FirstName),
                new SqlParameter("@LastName",person.LastName),
            };
            Executer.ExecuteNonQuery(connectionString, "UpdatePeople",parameters);

        }
    }
}
