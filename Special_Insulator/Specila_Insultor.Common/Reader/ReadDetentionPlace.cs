using SpecialInsulator.Common.Entity;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace SpecialInsulator.Common.Reader
{
    public class ReadDetentionPlace : IReader<DetentionPlace>
    {
        public List<DetentionPlace> GetCollection(SqlDataReader dataReader)
        {
            List<DetentionPlace> places = new List<DetentionPlace>();
            DetentionPlace place;
            try
            {
                if (dataReader.HasRows)
                {
                    while (dataReader.Read())
                    {
                        place = new DetentionPlace()
                        {
                            Id = (int)dataReader["Id"],
                            Address = (string)dataReader["Address"],
                        };
                        places.Add(place);
                    }
                }
            }
            catch
            { throw; }
            
            return places;
        }

        public DetentionPlace GetModel(SqlDataReader dataReader)
        {
            dataReader.Read();
            DetentionPlace place = new DetentionPlace();
            try
            {
                if (dataReader.HasRows)
                {
                    place.Id = (int)dataReader["Id"];
                    place.Address = (string)dataReader["Address"];
                }
            }
            catch
            {
                throw;
            }

            
            return place;
        }
    }
}
