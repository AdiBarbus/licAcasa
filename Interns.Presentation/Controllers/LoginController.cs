using System;
using System.Linq;
using System.Web.Mvc;
using System.Web.Security;
using Interns.Services.IService;
using Interns.Services.Models;
using log4net;
using SimpleCrypto;

namespace Interns.Presentation.Controllers
{
    public class LoginController : Controller
    {
        private static readonly ILog Log = LogManager.GetLogger(typeof(LoginController));
        private readonly IUserService userService;
        public int PageSize = 3;

        public LoginController(IUserService user)
        {
            userService = user;
        }
        [HttpGet]
        public ActionResult LogIn()
        {
            return View();
        }

        [HttpPost]
        public ActionResult LogIn(LoginInputModel loginModel)
        {
            Log.Debug("Started validating user credentials");

            if (IsValid(loginModel.UserName, loginModel.Password))
            {
                Log.Info("User credentials are valid!");
                FormsAuthentication.SetAuthCookie(loginModel.UserName, false);
                return RedirectToAction("Advertises", "Advertise");
            }
            
            Log.Info("User credentials are not valid");
            ModelState.AddModelError("", "Login details are wrong.");
            
            return View(loginModel);
        }

        [Authorize]
        public ActionResult ChangePassword()
        {
            return View();
        }

        [Authorize]
        [HttpPost]
        public ActionResult ChangePassword(ChangePasswordModel model)
        {
            Log.Debug("Started validating user credential for password change.");
            if (ModelState.IsValid)
            {
                var crypto = new PBKDF2();
                var user = userService.GetUsers().FirstOrDefault(u => u.UserName == User.Identity.Name);

                if (user.Password == crypto.Compute(model.OldPassword, user.PasswordSalt))
                {
                    user.Password = crypto.Compute(model.NewPassword);
                    user.ConfirmPassword = crypto.Compute(model.ConfirmPassword);

                    try
                    {
                        userService.UpdateUser(user);
                    }
                    catch (Exception e)
                    {
                        Log.Error(e.ToString());
                    }

                    return RedirectToAction("ChangePasswordSuccess");
                }
            }
            Log.Info("The password was not succesfully changed.");

            ModelState.AddModelError("", "The current password is incorrect or the new password is invalid.");

            return View(model);
        }

        public ActionResult ChangePasswordSuccess()
        {
            Log.Info("The password was succesfully changed.");
            return View();
        }

        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            Log.Info("You were logged out succesfully");

            return RedirectToAction("Advertises", "Advertise");
        }

        private bool IsValid(string userName, string password)
        {
            var crypto = new PBKDF2();
            bool IsValid = false;

            var user = userService.GetUsers().FirstOrDefault(u => u.UserName == userName);
            if (user != null)
            {
                if (user.Password == crypto.Compute(password, user.PasswordSalt))
                {
                    IsValid = true;
                }
            }
            return IsValid;
        }
    }
}