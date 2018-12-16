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
    
    class PersonData : IPersonData
    {
        public string connectionString = @"Data Source=.\;Initial Catalog=SIDb;Integrated Security=True";

        public  Person GetPersonById(int id)
        {
            Person person = new Person();

            string connectionString = @"Data Source=.\;Initial Catalog=SIDb;Integrated Security=True";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlDataReader PReader;
                SqlCommand getPerson;
                    getPerson = new SqlCommand("SelectPersonById", connection);
                    getPerson.CommandType = System.Data.CommandType.StoredProcedure;
                    getPerson.Parameters.Add(new SqlParameter
                    {
                        ParameterName = "@Id",
                        Value = id
                    });

                    PReader = getPerson.ExecuteReader();
                    PReader.Read();
                    person = new Person()
                    {
                        FirstName = (string)PReader.GetValue(1),
                        Id = (int)PReader.GetValue(0),
                        LastName = (string)PReader.GetValue(2)
                    };
                    PReader.Close();
            }
            return person;
        }

        public  string GetPhoneByDetaineeId(int id)
        {
            string number = "Нет номера";
            string connectionString = @"Data Source=.\;Initial Catalog=SIDb;Integrated Security=True";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlDataReader PReader;
                SqlCommand getNumber;
                getNumber = new SqlCommand("SelectPhoneByDetaineeId", connection);
                getNumber.CommandType = System.Data.CommandType.StoredProcedure;
                getNumber.Parameters.Add(new SqlParameter
                {
                    ParameterName = "@Detainee_Id",
                    Value = id
                });

                PReader = getNumber.ExecuteReader();
                if (PReader.HasRows)
                {
                    PReader.Read();
                    number = PReader.GetString(2);
                }
                PReader.Close();
            }

            return number;
        }

        public void DeletePersonById(int person_id)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand deletePerson = new SqlCommand("Delete_People", connection);
                deletePerson.CommandType = System.Data.CommandType.StoredProcedure;

                deletePerson.Parameters.Add(new SqlParameter
                {
                    ParameterName = "@Id",
                    Value = person_id
                });
                var result = deletePerson.ExecuteNonQuery();
            }
               
        }
    }
}
