using SpecialInsulator.Common.Entity;
using System.Collections.Generic;

namespace SpecialInsulator.DAL.Interfaces
{
    public interface IRoleRepository
    {
        bool AddRoleToUser(int userId,int roleId);

        bool EditUserRole(int userId,int roleId);

        List<string> GetUserRolesByUserId(int Id);

        List<int> GetRolesId();

        List<Role> GetRolesByUserId(int Id);

        bool DeleteRoleFromUser(int userId, int roleId);
    }
}
