using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Mines_Web.Services.Data;
using Mines_Web.Models;

namespace Mines_Web.Services.Business
{
    public class UserService
    {
        UserDAO service = new UserDAO();

        public UserModel getUser(int id)
        {
            return service.GetUser(id);
        }

        public bool addUser(UserModel user)
        {
            return service.AddUser(user);
        }

        public bool isEmailUnique(UserModel user)
        {
            return service.EmailUnique(user);
        }

        public bool deleteUser(UserModel user)
        {
            return service.DeleteUser(user);
        }

        public bool updateProfile(UserModel user)
        {
            return service.UpdateProfile(user);
        }

        public bool updateProfileAdmin(UserModel user)
        {
            return service.UpdateProfileAdmin(user);
        }

        public bool isUserNameUnique(UserModel user)
        {
            return service.UserNameUnique(user);
        }

        public List<UserModel> getUsers()
        {
            return service.GetAllUsers();
        }

        public List<UserModel> searchUsers(string searchString)
        {
            return service.SearchUsers(searchString);
        }
    }
}