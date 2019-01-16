using SpecialInsulator.Common.Entity;
using System.Collections.Generic;

namespace SpecialInsulator.BLL.Interfaces
{
    public interface IDepartmentService
    {
        void AddDepartment(Department department);

        List<Department> GetAllDepartments();

        List<Department> GetAllDepartmentsAndSwap(int Id);

        Department GetDepartmnetnById(int Id);

        void DeleteDepartmentsById(int Id);

        void EditDepartment(Department department);
    }
}
