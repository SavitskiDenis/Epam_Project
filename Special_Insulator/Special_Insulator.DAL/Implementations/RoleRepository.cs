using SpecialInsulator.Common.Entity;
using SpecialInsulator.Common.Reader;
using SpecialInsulator.Common.SQLExecuter;
using SpecialInsulator.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Web.Configuration;

namespace SpecialInsulator.DAL.Implementations
{
    class RoleRepository : IRoleRepository
    {
        private string connectionString = WebConfigurationManager.ConnectionStrings["MyDb"].ConnectionString;

        public bool AddRoleToUser(int userId, int roleId)
        {
            try
            {
                Executer.ExecuteNonQuery(connectionString,
                                    "AddInUserAndRole",
                                    new SqlParameter("@UserId", userId),
                                    new SqlParameter("@RoleId", roleId));
            }
            catch
            {
                return false;
            }
            return true;
        }

        public List<int> GetRolesId()
        {
            List<int> ids;
            try
            {
                ids = Executer.ExecuteCollectionRead(connectionString, "SelectRolesId", new ReadId());
            }
            catch
            {
                return null;
            }
            return ids;
        }

        public List<string> GetUserRolesByUserId(int Id)
        {
            List<int> rolesId;
            List<string> roles;
            try
            {
                rolesId = Executer.ExecuteCollectionRead(connectionString,
                                                   "SelectRolesIdByUserId",
                                                   new ReadId(),
                                                   new SqlParameter("@Id", Id));
                roles = new List<string>();
                foreach (var item in rolesId)
                {
                    roles.Add(Executer.ExecuteRead(connectionString,
                                                    "SelectRoleById",
                                                    new ReadRoles(),
                                                    new SqlParameter("@Id", item)));
                }
            }
            catch
            {
                return null;
            }
           
            return roles;
        }

        public List<Role> GetRolesByUserId(int Id)
        {
            List<int> rolesId;
            List<Role> roles;
            try
            {
                rolesId = Executer.ExecuteCollectionRead(connectionString,
                                                        "SelectRolesIdByUserId",
                                                        new ReadId(),
                                                        new SqlParameter("@Id", Id));
                roles = new List<Role>();

                foreach (var item in rolesId)
                {
                    roles.Add(new Role
                    {
                        Id = item,
                        Type = Executer.ExecuteRead(connectionString,
                                                    "SelectRoleById",
                                                    new ReadRoles(),
                                                    new SqlParameter("@Id", item))
                    });
                }
            }
            catch
            {
                return null;
            }
            

            return roles;
        }

        public bool DeleteRoleFromUser(int userId,int roleId)
        {
            try
            {
                Executer.ExecuteNonQuery(connectionString,
                                    "DeleteUserRole",
                                    new SqlParameter("@Id", userId),
                                    new SqlParameter("@RoleId", roleId));
            }
            catch
            {
                return false;
            }
            return true;
        }
    }
}
