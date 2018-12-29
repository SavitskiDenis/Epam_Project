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
    public class WorkerData : IWorkerData
    {
        public string connectionString = @"Data Source=.\;Initial Catalog=SIDb;Integrated Security=True";
        public PersonData personData = new PersonData();

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

        public List<WorkerAndName> GetAllWorkers()
        {
            List<WorkerAndName> fullList = new List<WorkerAndName>();
            List<Worker> workers = new List<Worker>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand getDetainees = new SqlCommand("SelectAllWorkers", connection);
                getDetainees.CommandType = System.Data.CommandType.StoredProcedure;

                SqlDataReader DReader = getDetainees.ExecuteReader();
                Worker worker;


                if (DReader.HasRows)
                {
                    while (DReader.Read())
                    {
                        worker = new Worker()
                        {
                            Id = (int)DReader.GetValue(0),
                            WorkerPost = (string)DReader.GetValue(1),
                            PeopleId = (int)DReader.GetValue(2),
                        };
                        workers.Add(worker);
                    }
                }
                DReader.Close();
            }

            foreach (var item in workers)
            {
                fullList.Add(new WorkerAndName(item, personData.GetPersonById(item.PeopleId)));
            }


            return fullList;
        }

        public WorkerAndName GetWorkerById(int Id)
        {
            WorkerAndName workerWithName;
            Worker worker;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand getWorker = new SqlCommand("SelectWorkerById", connection);
                getWorker.CommandType = System.Data.CommandType.StoredProcedure;

                getWorker.Parameters.Add(new SqlParameter("@Id", Id));
                SqlDataReader DReader = getWorker.ExecuteReader();
                DReader.Read();


                worker = new Worker()
                {
                    Id = DReader.GetInt32(0),
                    WorkerPost = DReader.GetString(1),
                    PeopleId = DReader.GetInt32(2),
                };
                DReader.Close();

            }

            
            workerWithName = new WorkerAndName(worker, personData.GetPersonById(worker.PeopleId));
            return workerWithName;

        }

        public void DeleteWorkerById(int Id)
        {
            int person_id;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand deleteWorker = new SqlCommand("Delete_Worker", connection);
                deleteWorker.CommandType = System.Data.CommandType.StoredProcedure;

                deleteWorker.Parameters.Add(new SqlParameter("@Id", Id));
                SqlDataReader DReader = deleteWorker.ExecuteReader();
                DReader.Read();

                person_id = DReader.GetInt32(0);
                DReader.Close();

                personData.DeletePersonById(person_id);


            }
        }

        public void EditWorker(WorkerAndName workerAndName)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand updateWorker = new SqlCommand("UpdateWorker", connection);
                updateWorker.CommandType = System.Data.CommandType.StoredProcedure;

                SqlParameter[] parameters = new SqlParameter[]
                {
                    new SqlParameter("@Id",workerAndName.Worker.Id),
                    new SqlParameter("@WorkerPost",workerAndName.Worker.WorkerPost),
                    new SqlParameter("@PeopleId",workerAndName.Worker.PeopleId),
                };

                updateWorker.Parameters.AddRange(parameters);
                workerAndName.Person.Id = workerAndName.Worker.PeopleId;
                personData.EditPerson(workerAndName.Person);

                int result = updateWorker.ExecuteNonQuery();

            }
        }

        public int GetWorkerIdByDetentionId(int Id, string procedure)
        {
            int WorkerId=0;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand getId = new SqlCommand(procedure, connection);
                getId.CommandType = System.Data.CommandType.StoredProcedure;
                getId.Parameters.Add(new SqlParameter("@DetentionId", Id));
                SqlDataReader DReader = getId.ExecuteReader();
                DReader.Read();

                if (DReader.HasRows)
                {
                    WorkerId = DReader.GetInt32(0);
                }
                DReader.Close();
            }

            return WorkerId;
        }

    }
}
