using Common.Entity;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Reader
{
    public class ReadDetainee : IReader<Detainee>
    {
        public List<Detainee> GetCollection(SqlDataReader dataReader)
        {
            List<Detainee> detainees = new List<Detainee>();
            Detainee detainee;
            if (dataReader.HasRows)
            {
                while (dataReader.Read())
                {
                    detainee = new Detainee()
                    {
                        Id = (int)dataReader.GetValue(0),
                        PeopleId = (int)dataReader.GetValue(1),
                        BornDate = (DateTime)dataReader.GetValue(2),
                        Status = (string)dataReader.GetValue(3),
                        Workplace = (string)dataReader.GetValue(4),
                        Phone = " +(nnn)-nn-nnn-nn-nn",
                        Photo = "",
                        Address = (string)dataReader.GetValue(6),
                        AdditionalInformation = (string)dataReader.GetValue(7)
                    };
                    detainees.Add(detainee);
                }
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
                    Id = (int)dataReader.GetValue(0),
                    PeopleId = (int)dataReader.GetValue(1),
                    BornDate = (DateTime)dataReader.GetValue(2),
                    Status = (string)dataReader.GetValue(3),
                    Workplace = (string)dataReader.GetValue(4),
                    Phone = " +(nnn)-nn-nnn-nn-nn",
                    Photo = "",
                    Address = (string)dataReader.GetValue(6),
                    AdditionalInformation = (string)dataReader.GetValue(7)
                };
            }
            catch
            {
                return null;
            }
            return detainee;
        }
    }
}
