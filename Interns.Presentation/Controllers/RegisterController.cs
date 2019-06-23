using System;
using System.Data.Entity.Validation;
using System.Linq;
using System.Web.Mvc;
using Interns.Services.IService;
using Interns.Services.Models;
using Interns.Services.Models.SelectFK;
using log4net;
using SimpleCrypto;

namespace Interns.Presentation.Controllers
{
    public class RegisterController : Controller
    {
        private static readonly ILog Log = LogManager.GetLogger(typeof(RegisterController));

        private readonly IUserService userService;
        private readonly IRoleService roleService;

        public RegisterController(IUserService user, IRoleService role)
        {
            userService = user;
            roleService = role;
        }

        [HttpGet]
        public ActionResult SelectRole()
        {
            SelectRoleViewModel model = new SelectRoleViewModel();
            model.Roles = roleService.GetRoles().Where(e => e.Name != "Admin");

            return View(model);
        }

        [HttpPost]
        public ActionResult SelectRole(SelectRoleViewModel model)
        {
            if (model.SelectedRoleId == 2)
            {
               return RedirectToAction("RegisterStudent","Register");
            }

            return RedirectToAction("RegisterCompany", "Register");
        }

        [HttpGet]
        public ActionResult RegisterStudent()
        {
            return View();
        }

        [HttpPost]
        public ActionResult RegisterStudent(RegisterViewModel viewModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var crypto = new PBKDF2();

                    var encrypPass = crypto.Compute(viewModel.User.Password);
                    viewModel.User.Password = encrypPass;
                    viewModel.User.PasswordSalt = crypto.Salt;

                    var encrypPassConfirm = crypto.Compute(viewModel.User.ConfirmPassword);
                    viewModel.User.ConfirmPassword = encrypPassConfirm;

                    viewModel.User.CreateDate = DateTime.Now;
                    viewModel.User.RoleId = 1;

                    userService.InsertUser(viewModel.User);

                    return RedirectToAction("Login", "Login");
                }

                ModelState.AddModelError("", "Data is not correct");
            }
            catch (DbEntityValidationException e)
            {
                foreach (var eve in e.EntityValidationErrors)
                {
                    Log.Error($"Entity of type \"{eve.Entry.Entity.GetType().Name}\" in state \"{eve.Entry.State}\" has the following validation errors:");
                    foreach (var ve in eve.ValidationErrors)
                    {
                        Log.Error($"- Property: \"{ve.PropertyName}\", Error: \"{ve.ErrorMessage}\"");
                    }
                }
            }

            return View();
        }
    

        [HttpGet]
        public ActionResult RegisterCompany()
        {
            return View();
        }

        [HttpPost]
        public ActionResult RegisterCompany(RegisterViewModel viewModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var crypto = new PBKDF2();

                    var encrypPass = crypto.Compute(viewModel.User.Password);
                    viewModel.User.Password = encrypPass;
                    viewModel.User.PasswordSalt = crypto.Salt;

                    var encrypPassConfirm = crypto.Compute(viewModel.User.ConfirmPassword);
                    viewModel.User.ConfirmPassword = encrypPassConfirm;

                    viewModel.User.CreateDate = DateTime.Now;
                    viewModel.User.RoleId = 2;

                    userService.InsertUser(viewModel.User);

                    return RedirectToAction("Login", "Login");
                }

                ModelState.AddModelError("", "Data is not correct");
            }
            catch (DbEntityValidationException e)
            {
                foreach (var eve in e.EntityValidationErrors)
                {
                    Log.Error($"Entity of type \"{eve.Entry.Entity.GetType().Name}\" in state \"{eve.Entry.State}\" has the following validation errors:");
                    foreach (var ve in eve.ValidationErrors)
                    {
                        Log.Error($"- Property: \"{ve.PropertyName}\", Error: \"{ve.ErrorMessage}\"");
                    }
                }
            }

            return View();
        }
    }
}