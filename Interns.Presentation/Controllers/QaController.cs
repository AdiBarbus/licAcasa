using System;
using System.Collections.Generic;
using System.Web.Mvc;
using Interns.Core.Data;
using Interns.Services.IService;
using Interns.Services.Models;
using Interns.Services.Models.SelectFK;
using log4net;

namespace Interns.Presentation.Controllers
{
    public class QaController : Controller
    {
        private static readonly ILog Log = LogManager.GetLogger(typeof(QaController));

        private readonly IQaService qaService;
        private readonly ISubDomainService subDomainService;
        private readonly IDomainService domainService;
        private readonly IQuestionService questionService;
        private readonly IAnswerService answerService;
               
        public QaController(IQaService qa, ISubDomainService subDomain, IDomainService domain, IQuestionService question, IAnswerService answer)
        {
            qaService = qa;
            subDomainService = subDomain;
            domainService = domain;
            questionService = question;
            answerService = answer;
        }

        [HttpGet]
        public ActionResult Qas()
        {
            QAModelView model = new QAModelView();

            Log.Debug("Started getting all the QAs");
            try
            {
                model.Questions = questionService.GetQuestions();
                model.Answers = answerService.GetRightAnswers();                                
            }
            catch (Exception e)
            {
                Log.Error(e.ToString());
            }

            return View(model);
        }

        [HttpGet]
        public ActionResult SelectQasForeignKeys()
        {
            SelectQasFKs setForeignKeys = new SelectQasFKs();

            try
            {
                setForeignKeys.Domains = domainService.GetDomains();
                setForeignKeys.SubDomains = subDomainService.GetSubDomains();
            }
            catch (Exception e)
            {
                Log.Error(e.ToString());
            }

            return View(setForeignKeys);
        }

        [HttpPost]
        public ActionResult SelectQasForeignKeys(SelectQasFKs model)
        {
            Qa qa = new Qa();

            try
            {
                qa.DomainId = model.SelectedDomainId;
                qa.SubDomainId = model.SelectedSubDomainId;
            }
            catch (Exception e)
            {
                Log.Error(e.ToString());
            }

            return RedirectToAction("CreateQa", new
            {
                qa.DomainId,
                qa.SubDomainId
            });
        }

        [HttpGet]
        [Authorize(Roles = "Admin")]
        public ActionResult CreateQa()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreateQa(Qa qa, int domainId, int subDomainId)
        {
            qa.DomainId = domainId;
            qa.SubDomainId = subDomainId;

            Log.Debug("Creating new Q&A");
            try
            {
                qaService.InsertQa(qa);
            }
            catch (Exception e)
            {
                Log.Error(e.ToString());
            }

            return RedirectToAction("Qas");
        }

        [HttpGet]
        [Authorize(Roles = "Admin")]
        public ActionResult EditQa(int id)
        {
            var editQa = qaService.GetQa(id);
            return View(editQa);
        }

        [HttpPost]
        public ActionResult EditQa(Qa qa)
        {
            Log.Debug($"Updating {qa.Question}");
            if (ModelState.IsValid)
            {
                try
                {
                    qaService.UpdateQa(qa);
                    Log.Info($"{qa.Question} was updated succesfully");
                }
                catch (Exception e)
                {
                    Log.Error(e.ToString());
                }
            }

            return RedirectToAction("Qas");
        }

        [HttpGet]
        public ActionResult DeleteQa(Qa qa)
        {
            Log.Debug($"Deleting {qa.Question}");

            try
            {
                qaService.DeleteQa(qa);
                Log.Info($"{qa.Question} was deleted succesfully");
            }
            catch (Exception e)
            {
                Log.Error(e.ToString());
            }
            return RedirectToAction("Qas");
        }
    }
}