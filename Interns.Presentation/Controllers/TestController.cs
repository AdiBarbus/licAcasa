using System;
using System.Collections.Generic;
using System.Web.Mvc;
using Interns.Core.Data;
using Interns.Services.IService;
using log4net;

namespace Interns.Presentation.Controllers
{
    public class TestController : Controller
    {
        private static readonly ILog Log = LogManager.GetLogger(typeof(TestController));
        private readonly ITestService testService;

        public TestController(ITestService service)
        {
            testService = service;
        }

        [HttpGet]
        public ActionResult Tests()
        {
            IEnumerable<Test> qas = new List<Test>();

            Log.Debug("Started getting all the Tests");
            try
            {
                qas = testService.GetTests();
            }
            catch (Exception e)
            {
                Log.Error(e.ToString());
            }

            return View(qas);
        }


        [HttpGet]
        [Authorize(Roles = "Admin")]
        public ActionResult CreateTest()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreateTest(Test test)
        {
            Log.Debug("Creating new Test");

            try
            {
                testService.InsertTest(test);
            }
            catch (Exception e)
            {
                Log.Error(e.ToString());
            }

            return RedirectToAction("Tests");
        }

        [HttpGet]
        [Authorize(Roles = "Admin")]
        public ActionResult EditTest(int id)
        {
            var editTest = testService.GetTest(id);
            return View(editTest);
        }

        [HttpPost]
        public ActionResult EditTest(Test test)
        {
            Log.Debug($"Updating {test.Name}");
            if (ModelState.IsValid)
            {
                try
                {
                    testService.UpdateTest(test);
                    Log.Info($"{test.Name} was updated succesfully");
                }
                catch (Exception e)
                {
                    Log.Error(e.ToString());
                }
            }

            return RedirectToAction("Tests");
        }

        [HttpGet]
        public ActionResult DeleteTest(Test test)
        {
            Log.Debug($"Deleting {test.Name}");

            try
            {
                testService.DeleteTest(test);
                Log.Info($"{test.Name} was deleted succesfully");
            }
            catch (Exception e)
            {
                Log.Error(e.ToString());
            }
            return RedirectToAction("Tests");
        }

    }
}