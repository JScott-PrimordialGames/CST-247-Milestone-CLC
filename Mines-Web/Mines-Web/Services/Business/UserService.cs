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
            return userDAO.getUser(id);
        }

        public bool addUser(UserModel user)
        {
            return userDAO.addUser(user);
        }

        public bool isEmailUnique(UserModel user)
        {
            return userDAO.emailUnique(user);
        }

        public bool deleteUser(UserModel user)
        {
            return userDAO.deleteUser(user);
        }

        public bool updateProfile(UserModel user)
        {
            return userDAO.updateProfile(user);
        }

        public bool updateProfileAdmin(UserModel user)
        {
            return userDAO.updateProfileAdmin(user);
        }

        public bool isUserNameUnique(UserModel user)
        {
            return userDAO.userNameUnique(user);
        }

        public List<UserModel> getUsers()
        {
            return userDAO.getAllUsers();
        }

        public List<UserModel> searchUsers(string searchString)
        {
            return userDAO.searchUsers(searchString);
        }
    }
}