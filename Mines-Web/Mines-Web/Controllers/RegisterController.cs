using Mines_Web.Models;
using Mines_Web.Services.Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Mines_Web.Controllers
{
    public class RegisterController : Controller
    {
        // GET: Register
        public ActionResult Index()
        {
            return View("Register");
        }

        [HttpPost]
        public ActionResult Register(UserModel model)
        {
            // Validate the Form POST
            if (!ModelState.IsValid)
                return View("Register");

            SecurityService service = new SecurityService();

            if (service.CheckIfUsernameExists(model))
                return View("UsernameExists");
            bool result = service.RegisterUserAccount(model);

            return View("Register");

        }

    }
}