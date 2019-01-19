using SpecialInsulator.Common.Reader;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace SpecialInsulator.Common.SQLExecuter
{
    public class Executer
    {
        public static bool ExecuteNonQuery(string connectionString, string procedureName, params SqlParameter[] parametrs)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    SqlCommand cmd = new SqlCommand(procedureName, connection);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    if(parametrs != null)
                    {
                        cmd.Parameters.AddRange(parametrs);
                    }
                    cmd.ExecuteNonQuery();
                }
            }
            catch
            {
                throw;
            }
            return true;
        }

        public static object ExecuteScalar(string connectionString, string procedureName, params SqlParameter[] parametrs)
        {
            object myVar;
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    SqlCommand cmd = new SqlCommand(procedureName, connection);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    if (parametrs != null)
                    {
                        cmd.Parameters.AddRange(parametrs);
                    }
                    myVar = cmd.ExecuteScalar();
                    
                }
            }
            catch
            {
                return null;
            }

            return myVar;


        }

        public static T ExecuteRead<T>(string connectionString, string procedureName, IReader<T> reader, params SqlParameter[] parametrs)
        {
            T model;
            SqlDataReader dataReader = null;
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    SqlCommand cmd = new SqlCommand(procedureName, connection);
                    cmd.CommandType = CommandType.StoredProcedure;
                    if (parametrs != null)
                    {
                        cmd.Parameters.AddRange(parametrs);
                    }
                    dataReader = cmd.ExecuteReader();
                    model = reader.GetModel(dataReader);
                }
            }
            catch
            {
                throw;
            }
            return model;
        }

        public static List<T> ExecuteCollectionRead<T>(string connectionString, string procedureName, IReader<T> reader,params SqlParameter[] parametrs)
        {
            List<T> collection;
            SqlDataReader dataReader = null;
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    SqlCommand cmd = new SqlCommand(procedureName, connection);
                    cmd.CommandType = CommandType.StoredProcedure;
                    if (parametrs != null)
                    {
                        cmd.Parameters.AddRange(parametrs);
                    }
                    dataReader = cmd.ExecuteReader();
                    collection = reader.GetCollection(dataReader);
                }
            }
            catch
            {
                throw;
            }
            return collection;
        }
    }
}
