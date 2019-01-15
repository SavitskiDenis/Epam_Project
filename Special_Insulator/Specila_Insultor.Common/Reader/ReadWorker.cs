using Common.Entity;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Reader
{
    public class ReadWorker : IReader<Worker>
    {
        public List<Worker> GetCollection(SqlDataReader dataReader)
        {
            List<Worker> workers = new List<Worker>();
            Worker worker;
            try
            {
                if (dataReader.HasRows)
                {
                    while (dataReader.Read())
                    {
                        worker = new Worker()
                        {
                            Id = (int)dataReader["Id"],
                            WorkerPost =  new Post {Id =(int)dataReader["WorkerPostId"] },
                            PeopleId = (int)dataReader["PeopleId"],
                        };
                        workers.Add(worker);
                    }
                }
            }
            catch { throw; }

            return workers;
        }

        public Worker GetModel(SqlDataReader dataReader)
        {
            Worker worker = null;
            try
            {
                dataReader.Read();
                worker = new Worker()
                {
                    Id = (int)dataReader["Id"],
                    WorkerPost = new Post { Id = (int)dataReader["WorkerPostId"] },
                    PeopleId = (int)dataReader["PeopleId"],
                };
            }
            catch { throw; }

            return worker;
        }
    }
}
