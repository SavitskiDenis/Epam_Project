using System.Collections.Generic;
using System.Data.SqlClient;

namespace SpecialInsulator.Common.Reader
{
    public interface IReader<T>
    {
        T GetModel(SqlDataReader dataReader);

        List<T> GetCollection(SqlDataReader dataReader);
    }
}
