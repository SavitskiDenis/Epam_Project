using SpecialInsulator.Common.Entity;
using SpecialInsulator.Common.Reader;
using SpecialInsulator.Common.SQLExecuter;
using SpecialInsulator.DAL.Interfaces;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Web.Configuration;

namespace SpecialInsulator.DAL.Implementations
{
    public class DepartmentRepository : IDepartmentRepository
    {
        public string connectionString = WebConfigurationManager.ConnectionStrings["MyDb"].ConnectionString;

        public void AddDepartment(Department departmnet)
        {
            Executer.ExecuteNonQuery(connectionString, "AddDepartment", new SqlParameter("@Address", departmnet.Address));
        }

        public List<Department> GetAllDepartments()
        {
            return Executer.ExecuteCollectionRead(connectionString, "SelectAllDepartments", new ReadDepartment(), null);
        }

        public Department GetDepartmnetnById(int Id)
        {
            Department department = Executer.ExecuteRead(
                                        connectionString, 
                                        "SelectDepartmentById",
                                        new ReadDepartment(), 
                                        new SqlParameter("@Id", Id));

            return department;
        }

        public void DeleteDepartmentsById(int Id)
        {
            Executer.ExecuteNonQuery(connectionString, "Delete_Department", new SqlParameter("@Id", Id));
        }

        public void EditDepartment(Department department)
        {
            Executer.ExecuteNonQuery(connectionString,
                                    "UpdateDepartment",
                                    new SqlParameter("@Id", department.Id),
                                    new SqlParameter("@Address", department.Address));
        }
    }
}
