using SpecialInsulator.Common.Entity;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace SpecialInsulator.Common.Reader
{
    public class ReadDetainee : IReader<Detainee>
    {
        public List<Detainee> GetCollection(SqlDataReader dataReader)
        {
            List<Detainee> detainees = new List<Detainee>();
            Detainee detainee;
            try
            {
                if (dataReader.HasRows)
                {
                    while (dataReader.Read())
                    {
                        detainee = new Detainee()
                        {
                            Id = (int)dataReader["Id"],
                            PeopleId = (int)dataReader["PeopleId"],
                            BornDate = (DateTime)dataReader["BornDate"],
                            Status = (string)dataReader["Status"],
                            Workplace = (string)dataReader["Workplace"],
                            Phone = " +(nnn)-nn-nnn-nn-nn",
                            Photo = (byte[])dataReader["Photo"],
                            Address = (string)dataReader["Address"],
                            AdditionalInformation = (string)dataReader["AdditionalInformation"]
                        };
                        detainees.Add(detainee);
                    }
                }
            }
            catch
            {
                throw;
            }
            
            return detainees;
        }

        public Detainee GetModel(SqlDataReader dataReader)
        {
            Detainee detainee;
            try
            {
                dataReader.Read();

                detainee = new Detainee()
                {
                    Id = (int)dataReader["Id"],
                    PeopleId = (int)dataReader["PeopleId"],
                    BornDate = (DateTime)dataReader["BornDate"],
                    Status = (string)dataReader["Status"],
                    Workplace = (string)dataReader["Workplace"],
                    Phone = " +(nnn)-nn-nnn-nn-nn",
                    Photo = (byte[])dataReader["Photo"],
                    Address = (string)dataReader["Address"],
                    AdditionalInformation = (string)dataReader["AdditionalInformation"]
                };
            }
            catch
            {
                throw;
            }
            return detainee;
        }
    }
}
