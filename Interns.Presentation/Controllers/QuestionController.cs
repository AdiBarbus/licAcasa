using System;
using System.Collections.Generic;
using System.Web.Mvc;
using Interns.Core.Data;
using Interns.Services.IService;
using Interns.Services.Models.SelectFK;
using log4net;

namespace Interns.Presentation.Controllers
{
    public class QuestionController : Controller
    {
        private static readonly ILog Log = LogManager.GetLogger(typeof(QuestionController));
        private readonly IQuestionService questionService;
        private readonly ITestService testService;
        private readonly IDomainService domainService;
        private readonly ISubDomainService subDomainService;

        public QuestionController(IQuestionService questionServ, ITestService testServ, IDomainService domainServ, ISubDomainService subDomainServ)
        {
            questionService = questionServ;
            testService = testServ;
            domainService = domainServ;
            subDomainService = subDomainServ;
        }

        [HttpGet]
        public ActionResult Questions()
        {
            IEnumerable<Question> questions = new List<Question>();

            Log.Debug("Started getting all the Questions");
            try
            {
                questions = questionService.GetQuestions();
            }
            catch (Exception e)
            {
                Log.Error(e.ToString());
            }

            return View(questions);
        }

        [HttpGet]
        public ActionResult SelectQuestionsFK()
        {
            SelectQuestionsFK model = new SelectQuestionsFK();
            model.Tests = testService.GetTests();
            model.Domains = domainService.GetDomains();
            model.SubDomains = subDomainService.GetSubDomains();

            return View(model);
        }

        [HttpPost]
        public ActionResult SelectQuestionsFK(SelectQuestionsFK model)
        {
            Question question = new Question();
            try
            {
                question.TestId = model.SelectedTestId;
                question.DomainId = model.SelectedDomainId;
                question.SubDomainId = model.SelectedSubDomainId;
            }
            catch (Exception e)
            {
                Log.Error(e.ToString());
            }

            return RedirectToAction("CreateQuestion", new
            {
                question.TestId,
                question.DomainId,
                question.SubDomainId
            });
        }


        [HttpGet]
        [Authorize(Roles = "Admin")]
        public ActionResult CreateQuestion()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreateQuestion(Question question, int testId)
        {
            question.TestId = testId;

            Log.Debug("Creating new Question");
            try
            {
                questionService.InsertQuestion(question);
            }
            catch (Exception e)
            {
                Log.Error(e.ToString());
            }

            return RedirectToAction("Questions");
        }

        [HttpGet]
        [Authorize(Roles = "Admin")]
        public ActionResult EditQuestion(int id)
        {
            var editQuestion = questionService.GetQuestion(id);
            return View(editQuestion);
        }

        [HttpPost]
        public ActionResult EditQuestion(Question question)
        {
            Log.Debug($"Updating {question.Quest}");
            if (ModelState.IsValid)
            {
                try
                {
                    questionService.UpdateQuestion(question);
                    Log.Info($"{question.Quest} was updated succesfully");
                }
                catch (Exception e)
                {
                    Log.Error(e.ToString());
                }
            }

            return RedirectToAction("Questions");
        }

        [HttpGet]
        public ActionResult DeleteQuestion(Question question)
        {
            Log.Debug($"Deleting {question.Quest}");

            try
            {
                questionService.DeleteQuestion(question);
                Log.Info($"{question.Quest} was deleted succesfully");
            }
            catch (Exception e)
            {
                Log.Error(e.ToString());
            }
            return RedirectToAction("Questions");
        }

    }
}