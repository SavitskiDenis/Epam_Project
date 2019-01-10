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
                            Id = (int)dataReader.GetValue(0),
                            DetaineeId = (int)dataReader.GetValue(1),
                            DetentionDate = (DateTime)dataReader.GetValue(2),
                            DeliveryDate = (DateTime)dataReader.GetValue(3),
                            LiberationDate = (DateTime)dataReader.GetValue(4),
                            DepartmentId = (int)dataReader.GetValue(5),
                            AccruedAmount = (decimal)dataReader.GetValue(6),
                            PaidAmount = (decimal)dataReader.GetValue(7),
                        };
                        detentions.Add(detention);
                    }
                }
            }
            catch
            {
                return null;
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
                        Id = (int)dataReader.GetValue(0),
                        DetaineeId = (int)dataReader.GetValue(1),
                        DetentionDate = (DateTime)dataReader.GetValue(2),
                        DeliveryDate = (DateTime)dataReader.GetValue(3),
                        LiberationDate = (DateTime)dataReader.GetValue(4),
                        DepartmentId = (int)dataReader.GetValue(5),
                        AccruedAmount = (decimal)dataReader.GetValue(6),
                        PaidAmount = (decimal)dataReader.GetValue(7),
                    };
                }
            }
            catch
            {
                return null;
            }

            return detention;
        }
    }
}
