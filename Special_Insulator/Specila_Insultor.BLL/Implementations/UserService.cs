﻿using SpecialInsulator.Common.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Script.Serialization;
using System.Web.Security;
using System.Web;
using SpecialInsulator.BLL.Interfaces;
using SpecialInsulator.DAL.Interfaces;

namespace SpecialInsulator.BLL.Implementations
{
    class UserService : IUserService
    {
        IUserRepository userData;
        IRoleRepository roleData;

        public UserService(IUserRepository userData, IRoleRepository roleData)
        {
            this.userData = userData;
            this.roleData = roleData;
        }

        public bool AddUser(User user)
        {
            if(checkUser(user))
            {
                return false;
            }
            else
            {
                userData.AddUser(user);

                return true;
            }
        }

        public bool checkUser(User user)
        {
            List<User> users = GetAllUsers()??new List<User>();
            if(users.Where(item => item.Login == user.Login).FirstOrDefault()!=null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public User checkUserAndGet(User user)
        {
            List<User> users = GetAllUsers() ?? new List<User>();
            return users.Where(item => item.Login == user.Login && item.Password == user.Password).FirstOrDefault();
        }

        public List<User> GetAllUsers()
        {
            return userData.GetAllUsers();
        }

        public void EditRoles(int Id,string type)
        {
            List<Role> roles;
            List<Role> updateRoles = new List<Role>();
            if (type == "User")
            {
                roles = roleData.GetRolesByUserId(Id);
                foreach(var item in roles)
                {
                    if(item.Type == "Editor" || item.Type == "Admin")
                    {
                        roleData.DeleteRoleFromUser(Id,item.Id);
                    }
                    else
                    {
                        updateRoles.Add(item);
                    }
                }

                if(findRole("User", updateRoles) == false)
                {
                    roleData.AddRoleToUser(Id,1);
                }
            }
            else if(type == "Editor")
            {
                roles = roleData.GetRolesByUserId(Id);
                foreach (var item in roles)
                {
                    if (item.Type == "Admin")
                    {
                        roleData.DeleteRoleFromUser(Id, item.Id);
                    }
                    else
                    {
                        updateRoles.Add(item);
                    }
                }

                if (findRole("User",updateRoles) == false)
                {
                    roleData.AddRoleToUser(Id, 1);
                }
                if(findRole("Editor", updateRoles) == false)
                {
                    roleData.AddRoleToUser(Id, 2);
                }
            }
            else if(type == "Admin")
            {
                roles = roleData.GetRolesByUserId(Id);
                if (findRole("User", roles) == false)
                {
                    roleData.AddRoleToUser(Id, 1);
                }
                if (findRole("Editor", roles) == false)
                {
                    roleData.AddRoleToUser(Id, 2);
                }
                if(findRole("Admin", roles) == false)
                {
                    roleData.AddRoleToUser(Id, 3);
                }
            }
        }

        public bool AddCookies(User user)
        {
            if(user != null)
            {
                JavaScriptSerializer serializer = new JavaScriptSerializer();

                string serializeData = serializer.Serialize(user);

                FormsAuthenticationTicket formAuthTicket = new FormsAuthenticationTicket(1, user.Login, DateTime.Now, DateTime.Now.AddMinutes(15), false, serializeData);

                string encformAuthTicket = FormsAuthentication.Encrypt(formAuthTicket);

                HttpCookie formAuthCookie = new HttpCookie(FormsAuthentication.FormsCookieName, encformAuthTicket);

                HttpContext.Current.Response.Cookies.Add(formAuthCookie);

                return true;
            }
            return false;
        }

        public void DeleteCookies()
        {
            FormsAuthentication.SignOut();
        }

        private bool findRole(string name,List<Role> roles)
        {
            foreach(var item in roles)
            {
                if(item.Type == name)
                {
                    return true;
                }
            }
            return false;
        }

        public User GetUserByLoginAndEmail(string login, string email)
        {
            if(login != null && email != null)
            {
                var users = GetAllUsers();
                if(users != null)
                {
                    return users.FirstOrDefault(item => item.Login == login && item.Email == email);
                }
            }
            return null;
        }

        public bool EditUserInfo(User user)
        {
            if(user != null)
            {
                return userData.EditUserInfo(user);
            }
            return false;
        }

        public bool DeleteUser(int? Id)
        {
            if(Id != null)
            {
                return userData.DeleteUser(int.Parse(Id.ToString()));
            }
            return false;
        }
    }
}