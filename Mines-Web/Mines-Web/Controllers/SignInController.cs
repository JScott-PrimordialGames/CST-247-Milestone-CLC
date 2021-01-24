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

        public ActionResult RegForm()
        {
            return View("RegForm");
        }

        public ActionResult SignInForm()
        {
            return View("SignInForm");
        }

        [HttpPost]
        public ActionResult Authenticate(PrincipalModel model)
        {
            if (ModelState.IsValid)
            {
                UserModel user = securityService.Authenticate(model);
                if (user.Username != null)
                {
                    return RedirectToAction("Index", "GameCenter");
                }
                else
                {
                    ModelState.AddModelError("name", "The username or password supplied is not valid. Please try again");
                    return View("SignInForm");
                }
            } else
            {
                ModelState.AddModelError("name","The username or password supplied is not valid. Please try again");
                return View("SignInForm");
            }
        }

        [HttpPost]
        public ActionResult Register(UserModel model)
        {
            if (ModelState.IsValid)
            {
                if (userService.addUser(model))
                {
                    return Content("Congratulations! You have successfulled registed your account.");
                } else
                {
                    return Content("Sorry! There was an error registering your account. <br/>Please try again or reach out to an administrator.");
                }
            }
            else
            {
                return Content("The information you submitted is not valid." +
                    "\nPlease make sure all fields match and First Name, Last Name, and Login are all longer than 4 characters and shorter than 40." +
                    "\nPlease make sure the password field is between 4 and 20 characters.");
            }
        }
    }
}