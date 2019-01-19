using SpecialInsulator.Common.Entity;
using SpecialInsulator.Common.Reader;
using SpecialInsulator.Common.SQLExecuter;
using SpecialInsulator.DAL.Interfaces;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Web.Configuration;

namespace SpecialInsulator.DAL.Implementations
{
    public class DetentionPlaceRepository : IDetentionPlaceRepository
    {
        public string connectionString = WebConfigurationManager.ConnectionStrings["MyDb"].ConnectionString;

        public bool AddDetentionPlace(DetentionPlace place)
        {
            try
            {
                Executer.ExecuteNonQuery(connectionString, "AddDetentionPlace", new SqlParameter("@Address", place.Address));
            }
            catch
            {
                return false;
            }
            return true;
            
        }

        public List<DetentionPlace> GetAllDetentionPlaces()
        {
            try
            {
                return Executer.ExecuteCollectionRead(connectionString, "SelectAllDetentionPlaces", new ReadDetentionPlace(), null);
            }
            catch
            {
                return null;
            }
            
        }

        public DetentionPlace GetDetentionPlaceById(int Id)
        {
            DetentionPlace place;
            try
            {
                place = Executer.ExecuteRead(connectionString,
                                            "SelectDetentionPlaceById",
                                            new ReadDetentionPlace(),
                                            new SqlParameter("@Id", Id));
            }
            catch
            {
                return null;
            }

            return place;
        }

        public bool DeleteDetentionPlaceById(int Id)
        {
            try
            {
                Executer.ExecuteNonQuery(connectionString, "DeleteDetentionPlace", new SqlParameter("@Id", Id));
            }
            catch
            {
                return false;
            }
            return true;
           
        }

        public bool EditDetentionPlace(DetentionPlace place)
        {
            try
            {
                Executer.ExecuteNonQuery(connectionString,
                                    "UpdateDetentionPlace",
                                    new SqlParameter("@Id", place.Id),
                                    new SqlParameter("@Address", place.Address));
            }
            catch
            {
                return false;
            }
            return true;
            
        }
    }
}
