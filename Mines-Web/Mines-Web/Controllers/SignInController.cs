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
                    Session["user"] = user;
                    return RedirectToAction("Index", "GameCenter");
                }
                else
                {
                    Session.Clear();
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
                    return View("SignInForm");
                } else
                {
                    return View("RegForm");
                }
            }
            else
            {
                return View("RegForm");
            }
        }
    }
}