using Common.Entity;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Reader
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
                            Id = (int)dataReader.GetValue(0),
                            Address = (string)dataReader.GetValue(1),
                        };
                        departments.Add(department);
                    }
                }
            }
            catch
            { }
            
            return departments;
        }

        public Department GetModel(SqlDataReader dataReader)
        {
            dataReader.Read();
            Department department = new Department();

            if (dataReader.HasRows)
            {
                department.Id = (int)dataReader.GetValue(0);
                department.Address = (string)dataReader.GetValue(1);
            }
            return department;
        }
    }
}
