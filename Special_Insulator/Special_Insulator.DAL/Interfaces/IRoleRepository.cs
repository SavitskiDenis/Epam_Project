using SpecialInsulator.Common.Entity;
using System.Collections.Generic;

namespace SpecialInsulator.DAL.Interfaces
{
    public interface IRoleRepository
    {
        void AddRoleToUser(int userId,int roleId);

        void EditUserRole(int userId,int roleId);

        List<string> GetUserRolesByUserId(int Id);

        List<int> GetRolesId();

        List<Role> GetRolesByUserId(int Id);

        void DeleteRoleFromUser(int userId, int roleId);
    }
}
