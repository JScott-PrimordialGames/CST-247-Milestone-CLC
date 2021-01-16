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

        public UserModel Authenticate(PrincipalModel principal)
        {
            return service.Authenticate(principal);
        }

        public bool ChangePassword(PrincipalModel principal)
        {
            return service.ChangePassword(principal);
        }
    }
}