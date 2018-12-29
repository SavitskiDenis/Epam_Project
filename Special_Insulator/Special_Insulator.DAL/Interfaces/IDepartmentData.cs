using Common.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Special_Insulator.DAL.Interfaces
{
    public interface IDepartmentData
    {
        void AddDepartment(Department departmnet);

        List<Department> GetAllDepartments();

        Department GetDepartmnetnById(int Id);

        void DeleteDepartmentsById(int Id);

        void EditDepartment(Department department);
    }
}
