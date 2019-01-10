using Common.Entity;
using Common.Reader;
using Common.SQLExecuter;
using Special_Insulator.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Special_Insulator.DAL
{
    public class DepartmentData : IDepartmentData
    {
        public string connectionString = @"Data Source=.\;Initial Catalog=SIDb;Integrated Security=True";

        public void AddDepartment(Department departmnet)
        {
            Executer.ExecuteNonQuery(connectionString, "AddDepartment", new SqlParameter("@Address", departmnet.Address));
        }

        public List<Department> GetAllDepartments()
        {
            List<Department> departments = new List<Department>();
            departments = Executer.ExecuteCollectionRead(connectionString, "SelectAllDepartments",new ReadDepartment(),null);

            return departments;
        }

        public Department GetDepartmnetnById(int Id)
        {
            Department department = Executer.ExecuteRead(connectionString, "SelectDepartmentById",new ReadDepartment(), new SqlParameter("@Id", Id));

            return department;
        }

        public void DeleteDepartmentsById(int Id)
        {
            Executer.ExecuteNonQuery(connectionString, "Delete_Department", new SqlParameter("@Id", Id));
        }

        public void EditDepartment(Department department)
        {
            Executer.ExecuteNonQuery(connectionString, "UpdateDepartment", new SqlParameter("@Id", department.Id),new SqlParameter("@Address", department.Address));
        }
    }
}
