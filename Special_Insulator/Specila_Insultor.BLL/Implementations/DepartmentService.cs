using SpecialInsulator.Common.Entity;
using SpecialInsulator.BLL.Interfaces;
using SpecialInsulator.DAL.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace SpecialInsulator.BLL.Implementations
{
    public class DepartmentService : IDepartmentService
    {
        IDepartmentRepository data;

        public DepartmentService(IDepartmentRepository data)
        {
            this.data = data;
        }

        public void AddDepartment(Department department)
        {
            data.AddDepartment(department);
        }

        public void DeleteDepartmentsById(int Id)
        {
            data.DeleteDepartmentsById(Id);
        }

        public List<Department> GetAllDepartments()
        {
            return data.GetAllDepartments();
        }

        public Department GetDepartmnetnById(int Id)
        {
            return data.GetDepartmnetnById(Id);
        }

        public void EditDepartment(Department department)
        {
            data.EditDepartment(department);
        }

        public List<Department> GetAllDepartmentsAndSwap(int Id)
        {
            List<Department> departments = data.GetAllDepartments();

            int index = departments.IndexOf(departments.Where(item => item.Id == Id).FirstOrDefault());
            if(index > 0)
            {
                Department myDepartment = departments[index];
                departments[index] = departments[0];
                departments[0] = myDepartment;

            }

            return departments;
        }
    }
}
