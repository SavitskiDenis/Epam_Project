using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.Entity;

namespace Special_Insulator.DAL
{
    public class DataineeData : IDetaineeData
    {
        public string connectionString = @"Data Source=.\;Initial Catalog=SIDb;Integrated Security=True";


        public void AddDetainee(Person person, Detainee detainee)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand("AddPeople", connection);
                command.CommandType = System.Data.CommandType.StoredProcedure;

                SqlParameter fName = new SqlParameter
                {
                    ParameterName = "@FirstName",
                    Value = person.FirstName

                };
                SqlParameter SName = new SqlParameter
                {
                    ParameterName = "@LastName",
                    Value = person.LastName

                };

                command.Parameters.Add(fName);
                command.Parameters.Add(SName);
                var result = command.ExecuteScalar();

                SqlCommand command1 = new SqlCommand("AddDetainee", connection);
                command1.CommandType = System.Data.CommandType.StoredProcedure;

                SqlParameter p1 =  new SqlParameter
                {
                    ParameterName = "@People_Id",
                    Value = result
                };

                SqlParameter p2 = new SqlParameter
                {
                    ParameterName = "@BornDate",
                    Value = detainee.BornDate

                };

                SqlParameter p3 = new SqlParameter
                {
                    ParameterName = "@Status",
                    Value = detainee.Status

                };

                SqlParameter p4 = new SqlParameter
                {
                    ParameterName = "@Workplace",
                    Value = detainee.Workplace

                };

                SqlParameter p5 = new SqlParameter
                {
                    ParameterName = "@Photo",
                    Value = detainee.Photo

                };

                SqlParameter p6 = new SqlParameter
                {
                    ParameterName = "@Address",
                    Value = detainee.Address

                };

                SqlParameter p7 = new SqlParameter
                {
                    ParameterName = "@Additional_information",
                    Value = detainee.Additional_information

                };
                
                command1.Parameters.Add(p1);
                command1.Parameters.Add(p2);
                command1.Parameters.Add(p3);
                command1.Parameters.Add(p4);
                command1.Parameters.Add(p5);
                command1.Parameters.Add(p6);
                command1.Parameters.Add(p7);

                var result1 = command1.ExecuteNonQuery();
            }
        }


        public List<DetaineeWithName> GetAllDeteinees()
        {
            List<DetaineeWithName> fullList = new List<DetaineeWithName>();
            List<Detainee> detainees = new List<Detainee>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand getDetainees = new SqlCommand("SelectAllDetainees", connection);
                getDetainees.CommandType = System.Data.CommandType.StoredProcedure;
               
                SqlDataReader DReader = getDetainees.ExecuteReader();
                Detainee detainee; 
                

                if (DReader.HasRows)
                {
                    while (DReader.Read()) 
                    {
                        detainee = new Detainee()
                        {
                            Id = (int)DReader.GetValue(0),
                            People_Id = (int)DReader.GetValue(1),
                            BornDate = (DateTime)DReader.GetValue(2),
                            Status = (string)DReader.GetValue(3),
                            Workplace = (string)DReader.GetValue(4),
                            Phone = " +(nnn)-nn-nnn-nn-nn",
                            Photo = (string)DReader.GetValue(5),
                            Address = (string)DReader.GetValue(6),
                            Additional_information = (string)DReader.GetValue(7)
                        };
                        detainees.Add(detainee);
                    }
                }
                DReader.Close();
            }

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlDataReader PReader;
                SqlCommand getPerson;
                Person person;

                foreach(var item in detainees)
                {
                    getPerson = new SqlCommand("SelectPersonById", connection);
                    getPerson.CommandType = System.Data.CommandType.StoredProcedure;
                    getPerson.Parameters.Add(new SqlParameter {
                        ParameterName = "@Id",
                        Value = item.People_Id
                    });

                    PReader = getPerson.ExecuteReader();
                    PReader.Read();
                    person = new Person() {
                        FirstName = (string)PReader.GetValue(1),
                        Id = (int)PReader.GetValue(0),
                        LastName = (string)PReader.GetValue(2)
                    };
                    PReader.Close();
                    fullList.Add(new DetaineeWithName(item,person));
                }


            }
            
            return fullList;
           
        }
    }
}
