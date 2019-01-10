using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Reader
{
    public interface IReader<T>
    {
        T GetModel(SqlDataReader dataReader);

        List<T> GetCollection(SqlDataReader dataReader);
    }
}
