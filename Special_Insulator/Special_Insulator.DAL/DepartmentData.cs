using Common.Entity;
using Special_Insulator.DAL.Interfaces;
using System;
using System.Collections.Generic;
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
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand("AddDepartment", connection);
                command.CommandType = System.Data.CommandType.StoredProcedure;

                SqlParameter address = new SqlParameter("@Address", departmnet.Address);
                command.Parameters.Add(address);

                var result = command.ExecuteNonQuery();
            }
        }

        public List<Department> GetAllDepartments()
        {
            List<Department> departments = new List<Department>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand getDepartmnents = new SqlCommand("SelectAllDepartments", connection);
                getDepartmnents.CommandType = System.Data.CommandType.StoredProcedure;

                SqlDataReader DReader = getDepartmnents.ExecuteReader();
                Department department;


                if (DReader.HasRows)
                {
                    while (DReader.Read())
                    {
                        department = new Department()
                        {
                            Id = (int)DReader.GetValue(0),
                            Address = (string)DReader.GetValue(1),
                        };
                        departments.Add(department);
                    }
                }
                DReader.Close();
            }

            return departments;
        }

        public Department GetDepartmnetnById(int Id)
        {
            Department department = new Department();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand getDepartmnent = new SqlCommand("SelectDepartmentById", connection);
                getDepartmnent.CommandType = System.Data.CommandType.StoredProcedure;
                getDepartmnent.Parameters.Add(new SqlParameter("@Id", Id));
                SqlDataReader DReader = getDepartmnent.ExecuteReader();
                DReader.Read();

                if (DReader.HasRows)
                {
                    department.Id = (int)DReader.GetValue(0);
                    department.Address = (string)DReader.GetValue(1);
                }
                DReader.Close();
            }

            return department;
        }

        public void DeleteDepartmentsById(int Id)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand deleteDepartment = new SqlCommand("Delete_Department", connection);
                deleteDepartment.CommandType = System.Data.CommandType.StoredProcedure;
                deleteDepartment.Parameters.Add(new SqlParameter("@Id",Id));
                var result = deleteDepartment.ExecuteNonQuery();
            }
        }

        public void EditDepartment(Department department)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand updateDepartment = new SqlCommand("UpdateDepartment", connection);
                updateDepartment.CommandType = System.Data.CommandType.StoredProcedure;

                SqlParameter[] parameters = new SqlParameter[]
                {
                    new SqlParameter("@Id",department.Id),
                    new SqlParameter("@Address",department.Address)
                };

                updateDepartment.Parameters.AddRange(parameters);

                int result = updateDepartment.ExecuteNonQuery();


            }
        }
    }
}
