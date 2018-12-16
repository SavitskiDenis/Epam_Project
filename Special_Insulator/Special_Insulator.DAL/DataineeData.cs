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
        private PersonData personData = new PersonData();
        private DetentionData detentionData = new DetentionData();
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
                SqlParameter[] parameters = new SqlParameter[]
                {
                    new SqlParameter
                    {
                        ParameterName = "@People_Id",
                        Value = result
                    },

                    new SqlParameter
                    {
                        ParameterName = "@BornDate",
                        Value = detainee.BornDate

                    },

                    new SqlParameter
                    {
                        ParameterName = "@Status",
                        Value = detainee.Status

                    },

                    new SqlParameter
                    {
                        ParameterName = "@Workplace",
                        Value = detainee.Workplace

                    },

                    new SqlParameter
                    {
                        ParameterName = "@Photo",
                        Value = ""
                    },

                    new SqlParameter
                    {
                        ParameterName = "@Address",
                        Value = detainee.Address

                    },

                    new SqlParameter
                    {
                        ParameterName = "@Additional_information",
                        Value = detainee.Additional_information

                    }
            };


                command1.Parameters.AddRange(parameters);

                var result1 = command1.ExecuteNonQuery();

                SqlCommand command2 = new SqlCommand("AddPhone", connection);
                command2.CommandType = System.Data.CommandType.StoredProcedure;

                SqlParameter DId = new SqlParameter
                {
                    ParameterName = "@Detainee_Id",
                    Value = result

                };
                SqlParameter Number = new SqlParameter
                {
                    ParameterName = "@Number",
                    Value = detainee.Phone

                };

                command2.Parameters.Add(DId);
                command2.Parameters.Add(Number);
                var result2 = command2.ExecuteNonQuery();
            }
        }

        public void DeletDetaineeById(int id)
        {
            int person_id;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand deleteDetainee = new SqlCommand("Delete_Detainee", connection);
                deleteDetainee.CommandType = System.Data.CommandType.StoredProcedure;

                deleteDetainee.Parameters.Add(new SqlParameter
                {
                    ParameterName = "@Id",
                    Value = id
                });
                SqlDataReader DReader = deleteDetainee.ExecuteReader();
                DReader.Read();

                person_id = DReader.GetInt32(0);
                DReader.Close();

                personData.DeletePersonById(person_id);


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
                            Photo = "",
                            Address = (string)DReader.GetValue(6),
                            Additional_information = (string)DReader.GetValue(7)
                        };
                        detainees.Add(detainee);
                    }
                }
                DReader.Close();
            }

            foreach(var item in detainees)
            {
                item.Phone = personData.GetPhoneByDetaineeId(item.Id);
                fullList.Add(new DetaineeWithName(item, personData.GetPersonById(item.People_Id)));
            }
            
            
            return fullList;
           
        }

        public DetaineeWithName GetDeteineeById (int Id)
        {
            Detainee detainee;
            DetaineeWithName withName;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand getDetainee = new SqlCommand("SelectDetaineeById", connection);
                getDetainee.CommandType = System.Data.CommandType.StoredProcedure;

                getDetainee.Parameters.Add(new SqlParameter
                {
                    ParameterName = "@Id",
                    Value = Id
                });
                SqlDataReader DReader = getDetainee.ExecuteReader();
                DReader.Read();

                detainee = new Detainee()
                {
                    Id = DReader.GetInt32(0),
                    People_Id = DReader.GetInt32(1),
                    BornDate = DReader.GetDateTime(2),
                    Status = DReader.GetString(3),
                    Workplace = DReader.GetString(4),
                    Photo = DReader.GetString(5),
                    Address = DReader.GetString(6),
                    Additional_information = DReader.GetString(7),
                };
                DReader.Close();

            }

            detainee.Detentions = detentionData.GetDetentionsByDetaineeId(detainee.Id);
            withName = new DetaineeWithName(detainee, personData.GetPersonById(detainee.Id));
            return withName;
        }

        public void UpdateDetaineeInfo(Detainee detainee)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand updateDetainee = new SqlCommand("UpdateDetainee", connection);
                updateDetainee.CommandType = System.Data.CommandType.StoredProcedure;

                SqlParameter[] parameters = new SqlParameter[]
                {
                    new SqlParameter
                    {
                        ParameterName = "@Id",
                        Value = detainee.Id
                    },

                    new SqlParameter
                    {
                        ParameterName = "@People_Id",
                        Value = detainee.People_Id
                    },

                    new SqlParameter
                    {
                        ParameterName = "@BornDate",
                        Value = detainee.BornDate

                    },

                    new SqlParameter
                    {
                        ParameterName = "@Status",
                        Value = detainee.Status

                    },

                    new SqlParameter
                    {
                        ParameterName = "@Workplace",
                        Value = detainee.Workplace

                    },

                    new SqlParameter
                    {
                        ParameterName = "@Photo",
                        Value = detainee.Photo

                    },

                    new SqlParameter
                    {
                        ParameterName = "@Address",
                        Value = detainee.Address

                    },

                    new SqlParameter
                    {
                        ParameterName = "@Additional_information",
                        Value = detainee.Additional_information

                    }
            };

                updateDetainee.Parameters.AddRange(parameters);

                var result = updateDetainee.ExecuteNonQuery();


            }
        }
    }
}
