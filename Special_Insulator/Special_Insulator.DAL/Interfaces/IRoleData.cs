using Common.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Special_Insulator.DAL.Interfaces
{
    public interface IRoleData
    {
        void AddRoleToUser(int userId,int roleId);

        void EditUserRole(int userId,int roleId);

        List<string> GetUserRolesByUserId(int Id);

        List<int> GetRolesId();

        List<Role> GetRolesByUserId(int Id);

        void DeleteRoleFromUser(int userId, int roleId);
    }
}
