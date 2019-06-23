using System;
using System.Collections.Generic;
using System.Web.Mvc;
using Interns.Core.Data;
using Interns.Services.IService;
using Interns.Services.Models.SelectFK;
using log4net;

namespace Interns.Presentation.Controllers
{
    public class AnswerController : Controller
    {
        private static readonly ILog Log = LogManager.GetLogger(typeof(AnswerController));
        private readonly IAnswerService answerService;
        private readonly IQuestionService questionService;

        public AnswerController(IAnswerService answerServ, IQuestionService questionServ)
        {
            answerService = answerServ;
            questionService = questionServ;
        }

        [HttpGet]
        public ActionResult Answers()
        {
            IEnumerable<Answer> answers = new List<Answer>();

            Log.Debug("Started getting the Answer");
            try
            {
                answers = answerService.GetAnswers();
            }
            catch (Exception e)
            {
                Log.Error(e.ToString());
            }

            return View(answers);
        }

        [HttpGet]
        public ActionResult SelectQuestion()
        {
            SelectQuestionFK model = new SelectQuestionFK();
            model.Questions = questionService.GetQuestions();

            return View(model);
        }

        [HttpPost]
        public ActionResult SelectQuestion(SelectQuestionFK model)
        {
            Answer answer = new Answer();

            try
            {
                answer.QuestionId = model.SelectedQuestionId;
            }
            catch (Exception e)
            {
                Log.Error(e.ToString());
            }

            return RedirectToAction("CreateAnswer", new
            {
                answer.QuestionId
            });
        }


        [HttpGet]
        [Authorize(Roles = "Admin")]
        public ActionResult CreateAnswer()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreateAnswer(Answer answer, int questionId)
        {
            answer.QuestionId = questionId;

            Log.Debug("Creating Answer");
            try
            {
                answerService.InsertAnswer(answer);
            }
            catch (Exception e)
            {
                Log.Error(e.ToString());
            }

            return RedirectToAction("Answers");
        }

        [HttpGet]
        [Authorize(Roles = "Admin")]
        public ActionResult EditAnswer(int id)
        {
            var editAnswer = answerService.GetAnswer(id);
            return View(editAnswer);
        }

        [HttpPost]
        public ActionResult EditAnswer(Answer answer)
        {
            Log.Debug($"Updating {answer.Ans}");

            if (ModelState.IsValid)
            {
                try
                {
                    answerService.UpdateAnswer(answer);
                    Log.Info($"{answer.Ans} was updated succesfully");
                }
                catch (Exception e)
                {
                    Log.Error(e.ToString());
                }
            }

            return RedirectToAction("Answers");
        }

        [HttpGet]
        public ActionResult DeleteAnswer(Answer answer)
        {
            Log.Debug($"Deleting {answer.Ans}");

            try
            {
                answerService.DeleteAnswer(answer);
                Log.Info($"{answer.Ans} was deleted succesfully");
            }
            catch (Exception e)
            {
                Log.Error(e.ToString());
            }
            return RedirectToAction("Answers");
        }

    }
}