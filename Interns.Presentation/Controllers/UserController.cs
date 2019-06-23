using System;
using System.Linq;
using System.Web.Mvc;
using Interns.Core.Data;
using Interns.Services.Helpers;
using Interns.Services.IService;
using Interns.Services.Models.SelectFK;
using log4net;
using static System.String;

namespace Interns.Presentation.Controllers
{
    public class UserController : Controller
    {
        private static readonly ILog Log = LogManager.GetLogger(typeof(UserController));

        private readonly IUserService userService;
        private int PageSize = 10;

        public UserController(IUserService user)
        {
            userService = user;
        }

        [HttpGet]
        [AllowAnonymous]
        public ActionResult Users(string stringSearch, string sortOrder, string currentFilter, int page = 1)
        {
            Log.Debug("Started getting all the Users");

            var getUsers = userService.GetUsers().Where(e => e.Role.Name != "Admin");

            SearchingAndPagingViewModel<User> model = new SearchingAndPagingViewModel<User>
            {
                Collection = getUsers.OrderBy(p => p.UserName).Skip((page - 1) * PageSize).Take(PageSize),
                PagingInfo = new PagingInfo
                {
                    CurrentPage = page,
                    ItemsPerPage = PageSize,
                    TotalItems =
                        stringSearch == null ? getUsers.Count() :
                            getUsers.Count(s => s.UserName.Contains(stringSearch))
                },
                SortingOrder = IsNullOrEmpty(sortOrder) ? "name_desc" : "",
                SearchString = stringSearch
            };

            switch (sortOrder)
            {
                case "name_desc":
                    model.Collection = model.Collection.OrderByDescending(s => s.UserName);
                    break;
                default:
                    model.Collection = model.Collection.OrderBy(s => s.UserName);
                    break;
            }

            if (!IsNullOrEmpty(stringSearch))
            {
                model.Collection = getUsers.Where(s => s.UserName.Contains(stringSearch));
            }

            return View(model);
        }

        [HttpGet]
        [Authorize(Roles = "Admin")]
        public ActionResult EditUser(int id)
        {
            SelectUsersRoleFk model = new SelectUsersRoleFk();
            Log.Debug($"Getting the user with the id:{id}");

            try
            {
                model.User = userService.GetUser(id);
                Log.Info($"Getting the user with the id:{id} was succesfull");
            }
            catch (Exception e)
            {
                Log.Error(e.ToString());
            }

            return View(model);
        }

        [HttpPost]
        public ActionResult EditUser(User user)
        {
            Log.Debug($"Updating {user.UserName}");

            if (ModelState.IsValid)
            {
                try
                {
                    userService.UpdateUser(user);
                    Log.Info($"Updating {user.UserName} was succesfull");
                    return RedirectToAction("Users");
                }
                catch (Exception e)
                {
                    Log.Error(e.ToString());
                }
            }

            return View(user);
        }

        [HttpGet]
        [Authorize(Roles = "Admin")]
        public ActionResult DeleteUser(User user)
        {
            Log.Debug($"Deleting {user.UserName}");

            try
            {
                userService.DeleteUser(user);
                Log.Info($"{user.UserName} was deleted succesfully");
            }
            catch (Exception e)
            {
                Log.Error(e.ToString());
            }

            return RedirectToAction("Users");
        }
    }
}