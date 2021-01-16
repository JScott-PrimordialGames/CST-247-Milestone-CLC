using Mines_Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Mines_Web.Services.Business;

namespace Mines_Web.Controllers
{
    public class SignInController : Controller
    {
        UserService userService = new UserService();
        SecurityService securityService = new SecurityService();

        // GET: SignIn
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult LoadRegForm()
        {
            return PartialView("_RegisterForm");
        }

        public ActionResult LoadSignInForm()
        {
            return PartialView("_SignInForm");
        }

        public ActionResult Authenticate(PrincipalModel model)
        {
            UserModel user = securityService.Authenticate(model);
            Console.Out.WriteLine("Principal: name: {0}, password: {1}", model.UserName, model.Password);
            Console.Out.WriteLine("User: Id: {0}, username {1}", user.ID, user.Username);
            if(user.Username != null)
            {
                return Content("Login Passed");
            } else
            {
                return Content("Login Failed");
            }
        }

        public ActionResult Register(UserModel model)
        {
            bool isRegistrationSuccessful = userService.addUser(model);
            if (isRegistrationSuccessful)
            {
                return Content("Congratulations! You have successfulled registed your account.");
            } else
            {
                return Content("Sorry! There was an error registering your account. <br/>Please try again or reach out to an administrator.");
            }
        }
    }
}