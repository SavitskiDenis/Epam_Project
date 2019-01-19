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
                            Status = new Status
                            {
                                Id = (int)dataReader["StatusId"],
                                StatusName = (string)dataReader["StatusName"]
                            },
                            Workplace = (string)dataReader["Workplace"],
                            Phone = (string)dataReader["PhoneNumber"],
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
                    Status = new Status
                    {
                        Id = (int)dataReader["StatusId"],
                        StatusName = (string)dataReader["StatusName"]
                    },
                    Workplace = (string)dataReader["Workplace"],
                    Phone = (string)dataReader["PhoneNumber"],
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
