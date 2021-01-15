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
        UserDAO userDAO = new UserDAO();

        public UserModel getUser(int id)
        {
            return userDAO.GetUser(id);
        }

        public bool addUser(UserModel user)
        {
            return userDAO.AddUser(user);
        }

        public bool isEmailUnique(UserModel user)
        {
            return userDAO.EmailUnique(user);
        }

        public bool deleteUser(UserModel user)
        {
            return userDAO.DeleteUser(user);
        }

        public bool updateProfile(UserModel user)
        {
            return userDAO.UpdateProfile(user);
        }

        public bool updateProfileAdmin(UserModel user)
        {
            return userDAO.UpdateProfileAdmin(user);
        }

        public bool isUserNameUnique(UserModel user)
        {
            return userDAO.UserNameUnique(user);
        }

        public List<UserModel> getUsers()
        {
            return userDAO.GetAllUsers();
        }

        public List<UserModel> searchUsers(string searchString)
        {
            return userDAO.SearchUsers(searchString);
        }
    }
}