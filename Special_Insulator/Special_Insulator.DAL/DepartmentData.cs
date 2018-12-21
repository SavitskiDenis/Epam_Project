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
    }
}
