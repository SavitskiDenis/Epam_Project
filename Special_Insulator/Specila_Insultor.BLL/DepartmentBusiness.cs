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
    }
}
