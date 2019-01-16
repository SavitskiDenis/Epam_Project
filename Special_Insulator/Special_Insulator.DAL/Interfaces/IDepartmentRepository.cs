using SpecialInsulator.Common.Entity;
using System.Collections.Generic;


namespace SpecialInsulator.DAL.Interfaces
{
    public interface IDepartmentRepository
    {
        void AddDepartment(Department departmnet);

        List<Department> GetAllDepartments();

        Department GetDepartmnetnById(int Id);

        void DeleteDepartmentsById(int Id);

        void EditDepartment(Department department);
    }
}
