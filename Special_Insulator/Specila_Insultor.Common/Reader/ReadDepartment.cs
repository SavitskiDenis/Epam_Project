using SpecialInsulator.Common.Entity;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace SpecialInsulator.Common.Reader
{
    public class ReadDepartment : IReader<Department>
    {
        public List<Department> GetCollection(SqlDataReader dataReader)
        {
            List<Department> departments = new List<Department>();
            Department department;
            try
            {
                if (dataReader.HasRows)
                {
                    while (dataReader.Read())
                    {
                        department = new Department()
                        {
                            Id = (int)dataReader["Id"],
                            Address = (string)dataReader["Address"],
                        };
                        departments.Add(department);
                    }
                }
            }
            catch
            { throw; }
            
            return departments;
        }

        public Department GetModel(SqlDataReader dataReader)
        {
            dataReader.Read();
            Department department = new Department();
            try
            {
                if (dataReader.HasRows)
                {
                    department.Id = (int)dataReader["Id"];
                    department.Address = (string)dataReader["Address"];
                }
            }
            catch
            {
                throw;
            }

            
            return department;
        }
    }
}
