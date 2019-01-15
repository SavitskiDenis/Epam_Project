using Common.Entity;
using Common.Reader;
using Common.SQLExecuter;
using Special_Insulator.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Configuration;

namespace Special_Insulator.DAL
{
    class RoleData : IRoleData
    {
        private string connectionString = WebConfigurationManager.ConnectionStrings["MyDb"].ConnectionString;

        public void AddRoleToUser(int userId, int roleId)
        {
            Executer.ExecuteNonQuery(connectionString,
                                    "AddInUserAndRole",
                                    new SqlParameter("@UserId", userId),
                                    new SqlParameter("@RoleId", roleId));
        }

        public void EditUserRole(int userId, int roleId)
        {
            throw new NotImplementedException();
        }

        public List<int> GetRolesId()
        {
            return Executer.ExecuteCollectionRead(connectionString, "SelectRolesId", new ReadId());
        }

        public List<string> GetUserRolesByUserId(int Id)
        {
            List<int> rolesId =  Executer.ExecuteCollectionRead(connectionString,
                                                                "SelectRolesIdByUserId",
                                                                new ReadId(),
                                                                new SqlParameter("@Id",Id));
            List<string> roles = new List<string>();
            foreach(var item in rolesId)
            {
                roles.Add(Executer.ExecuteRead(connectionString,
                                                "SelectRoleById",
                                                new ReadRoles(),
                                                new SqlParameter("@Id",item)));
            }
            return roles;
        }

        public List<Role> GetRolesByUserId(int Id)
        {
            List<int> rolesId = Executer.ExecuteCollectionRead(connectionString,
                                                                "SelectRolesIdByUserId",
                                                                new ReadId(),
                                                                new SqlParameter("@Id", Id));
            List<Role> roles = new List<Role>();

            foreach(var item in rolesId)
            {
                roles.Add(new Role { Id = item,Type = Executer.ExecuteRead(connectionString,
                                                                            "SelectRoleById",
                                                                            new ReadRoles(),
                                                                            new SqlParameter("@Id", item)) });
            }

            return roles;
        }

        public void DeleteRoleFromUser(int userId,int roleId)
        {
            Executer.ExecuteNonQuery(connectionString,
                                    "DeleteUserRole",
                                    new SqlParameter("@Id",userId),
                                    new SqlParameter("@RoleId", roleId));
        }
    }
}
