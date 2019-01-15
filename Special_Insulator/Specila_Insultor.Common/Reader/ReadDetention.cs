using Common.Entity;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Reader
{
    public class ReadDetention : IReader<Detention>
    {
        public List<Detention> GetCollection(SqlDataReader dataReader)
        {
            List<Detention> detentions = new List<Detention>();
            Detention detention;
            try
            {
                if (dataReader.HasRows)
                {
                    while (dataReader.Read())
                    {
                        detention = new Detention()
                        {
                            Id = (int)dataReader["Id"],
                            DetaineeId = (int)dataReader["DetaineeId"],
                            DetentionDate = (DateTime)dataReader["DetentionDate"],
                            DeliveryDate = (DateTime)dataReader["DeliveryDate"],
                            LiberationDate = (DateTime)dataReader["LiberationDate"],
                            DepartmentId = (int)dataReader["DepartmentId"],
                            AccruedAmount = (string)dataReader["AccruedAmount"],
                            PaidAmount = (string)dataReader["PaidAmount"],
                        };
                        detentions.Add(detention);
                    }
                }
            }
            catch
            {
                throw;
            }
            
            return detentions;
        }

        public Detention GetModel(SqlDataReader dataReader)
        {
            Detention detention = null;
            try
            {
                if (dataReader.HasRows)
                {
                    dataReader.Read();
                    detention = new Detention()
                    {
                        Id = (int)dataReader["Id"],
                        DetaineeId = (int)dataReader["DetaineeId"],
                        DetentionDate = (DateTime)dataReader["DetentionDate"],
                        DeliveryDate = (DateTime)dataReader["DeliveryDate"],
                        LiberationDate = (DateTime)dataReader["LiberationDate"],
                        DepartmentId = (int)dataReader["DepartmentId"],
                        AccruedAmount = (string)dataReader["AccruedAmount"],
                        PaidAmount = (string)dataReader["PaidAmount"],
                    };
                }
            }
            catch
            {
                throw;
            }

            return detention;
        }
    }
}
