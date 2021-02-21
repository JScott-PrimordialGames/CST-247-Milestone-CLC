using Mines_Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Mines_Web.Services.Business;
using Mines_Web.Services.Utility;
using System.Web.Script.Serialization;

namespace Mines_Web.Controllers
{
    public class SignInController : Controller
    {
        private readonly ILogger logger;

        public SignInController(ILogger logger)
        {
            this.logger = logger;
        }


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
                    logger.Info("The user {" + model.Username + "} has been authenticated successfully.");
                    Session["user"] = user;
                    return RedirectToAction("Index", "GameCenter");
                }
                else
                {
                    logger.Warning("The user {" + model.Username + "} has not been found or does not exist.");
                    Session.Clear();
                    ModelState.AddModelError("name", "The username or password supplied is not valid. Please try again");
                    return View("SignInForm");
                }
            } else
            {
                logger.Warning("The user {" + model.Username + "} has invalid fields.");
                ModelState.AddModelError("name","The username or password supplied is not valid. Please try again");
                return View("SignInForm");
            }
        }

        [HttpPost]
        public ActionResult Register(UserModel model)
        {
            if (ModelState.IsValid)
            {
                logger.Info("Initiating the creation to user with the following parameters username {" + model.Username +
                    "}, FirstName {" + model.FirstName + "}, LastName{" + model.LastName + "}, email{" + model.Email + "}" +
                    ", Gender{" + model.Gender + "}, Age{" + model.Age + "}, State{" + model.State + "}");
                if (userService.addUser(model))
                {
                    logger.Info("The creation of user {" + model.Username + "} was successful");
                    return View("SignInForm");
                } else
                {
                    logger.Warning("The creation of user {" + model.Username + "} was unsuccessful");
                    return View("RegForm");
                }
            }
            else
            {
                logger.Info("UserModel with the following parameters is invalid: username {" + model.Username +
                    "}, FirstName {" + model.FirstName + "}, LastName{" + model.LastName + "}, email{" + model.Email + "}" +
                    ", Gender{" + model.Gender + "}, Age{" + model.Age + "}, State{" + model.State + "}");
                return View("RegForm");
            }
        }
    }
}