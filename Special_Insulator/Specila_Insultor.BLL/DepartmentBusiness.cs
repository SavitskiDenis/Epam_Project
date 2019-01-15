using Common.Entity;
using Special_Insulator.DAL.Interfaces;
using Specila_Insultor.BLL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Specila_Insultor.BLL
{
    public class DepartmentBusiness : IDepartmentBusiness
    {
        IDepartmentData data;

        public DepartmentBusiness(IDepartmentData data)
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
