using Mines_Web.Models;
using Mines_Web.Services.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Mines_Web.Services.Business
{
    public class SecurityService
    {
        SecurityDAO service = new SecurityDAO();

        public bool CheckIfUsernameExists(UserModel user)
        {
            return service.CheckIfUsernameExists(user);
        }

        public bool RegisterUserAccount(UserModel user)
        {
            return service.RegisterUser(user);
        }
    }
}