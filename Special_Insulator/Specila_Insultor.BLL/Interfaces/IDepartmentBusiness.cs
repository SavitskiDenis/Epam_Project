using Common.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Specila_Insultor.BLL.Interfaces
{
    public interface IDepartmentBusiness
    {
        void AddDepartment(Department department);

        List<Department> GetAllDepartments();

        Department GetDepartmnetnById(int Id);

        void DeleteDepartmentsById(int Id);

        void EditDepartment(Department department);
    }
}
