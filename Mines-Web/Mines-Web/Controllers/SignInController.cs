using Mines_Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Mines_Web.Controllers
{
    public class SignInController : Controller
    {
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
            return Content(model.UserName);
        }

        public ActionResult Register(UserModel model)
        {
            return Content(model.Username);
        }
    }
}