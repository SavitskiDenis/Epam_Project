using Common.Entity;
using Special_Insulator.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Special_Insulator.DAL
{
    class WorkerData : IWorkerData
    {
        public string connectionString = @"Data Source=.\;Initial Catalog=SIDb;Integrated Security=True";
        PersonData person = new PersonData();

        public void AddWorker(Worker worker,Person person)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand("AddPeople", connection);
                command.CommandType = System.Data.CommandType.StoredProcedure;

                SqlParameter fName = new SqlParameter("@FirstName", person.FirstName);
                SqlParameter SName = new SqlParameter("@LastName", person.LastName);

                command.Parameters.Add(fName);
                command.Parameters.Add(SName);
                var id = command.ExecuteScalar();

                SqlCommand command1 = new SqlCommand("AddWorker", connection);
                command1.CommandType = System.Data.CommandType.StoredProcedure;

                SqlParameter peopleId = new SqlParameter("@PeopleId", id);
                SqlParameter post = new SqlParameter("@WorkerPost", worker.WorkerPost);

                command1.Parameters.Add(peopleId);
                command1.Parameters.Add(post);

                var result = command1.ExecuteNonQuery();
            }
        }
    }
}
