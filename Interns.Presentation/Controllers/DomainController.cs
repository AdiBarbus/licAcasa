using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web.Mvc;
using AutoMapper;
using Interns.Core.Data;
using Interns.Presentation.DTOs;
using Interns.Services.Helpers;
using Interns.Services.IService;
using log4net;
using static System.String;

namespace Interns.Presentation.Controllers
{
    public class DomainController : Controller
    {
        private static readonly ILog Log = LogManager.GetLogger(typeof(DomainController));

        private readonly IDomainService domainService;
        public int PageSize = 4;

        public DomainController(IDomainService domain)
        {
            domainService = domain;
        }

        [HttpGet]
        [AllowAnonymous]
        public ActionResult Domains(string stringSearch, string sortOrder, string currentFilter, int page = 1)
        {
            Log.Debug("Started getting all the Domains");

            var getDomains = domainService.GetDomains();
            
            SearchingAndPagingViewModel<Domain> model = new SearchingAndPagingViewModel<Domain>
            {
                Collection = getDomains.OrderBy(p=>p.Name).Skip((page - 1) * PageSize).Take(PageSize),
                PagingInfo = new PagingInfo
                {
                    CurrentPage = page,
                    ItemsPerPage = PageSize,
                    TotalItems =
                            stringSearch == null ? getDomains.Count() :
                                getDomains.Count(s => s.Name.Contains(stringSearch))
                },
                SortingOrder = IsNullOrEmpty(sortOrder) ? "name_desc" : "",
                SearchString = stringSearch
            };
            
            switch (sortOrder)
            {
                case "name_desc":
                    model.Collection = model.Collection.OrderByDescending(s => s.Name);
                    break;
                default:  // Name ascending 
                    model.Collection = model.Collection.OrderBy(s => s.Name);
                    break;
            }

            if (!IsNullOrEmpty(stringSearch))
            {
                model.Collection = domainService.GetDomains().Where(s => s.Name.Contains(stringSearch));
            }

            
            return View(model);
        }
        
        [HttpGet]
        [Route("domain/GetSubDomainByDomain/{domainId}")]
        public ActionResult GetSubDomainsByDomain(int domainId)
        {
            IEnumerable<SubDomain> subDomainsByDomain = new List<SubDomain>();
            Log.Debug($"Getting the adverise with the domain id:{domainId}");

            try
            {
                subDomainsByDomain = domainService.GetSubDomainsByDomain(domainId);
            }
            catch (Exception e)
            {
                Log.Error(e.ToString());
            }

            return View(subDomainsByDomain);
        }

        [HttpGet]
        [Route("domain/GetAdvertisesByDomain/{domainId}")]
        public ActionResult GetAdvertisesByDomain(int domainId)
        {
            IEnumerable<Advertise> advertisesByDomain = new List<Advertise>();
            Log.Debug($"Getting the adverise with the domain id:{domainId}");

            try
            {
                advertisesByDomain = domainService.GetAdvertisesByDomain(domainId);
            }
            catch (Exception e)
            {
                Log.Error(e.ToString());
            }

            return View(advertisesByDomain);
        }

        [HttpGet]
        [Authorize(Roles = "Admin")]
        public ActionResult CreateDomain()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreateDomain(Domain domain)
        {
            Log.Debug("Creating new Domain");

            try
            {
                domainService.InsertDomain(domain);
            }
            catch (Exception e)
            {
                Log.Error(e.ToString());
            }

            return RedirectToAction("Domains");
        }

        [HttpGet]
        [Authorize(Roles = "Admin")]
        public ActionResult EditDomain(int id)
        {
            Domain domain = new Domain();

            Log.Debug($"Getting the user with the id:{id}");
            try
            {
                domain = domainService.GetDomain(id);
            }
            catch (Exception e)
            {
                Log.Error(e.ToString());
            }

            return View(domain);
        }

        [HttpPost]
        public ActionResult EditDomain(Domain domain)
        {
            Log.Debug($"Started to update {domain.Name}");

            try
            {
                domainService.UpdateDomain(domain);
                Log.Info($"{domain.Name} was succesfully updated");
            }
            catch (Exception e)
            {
                Log.Error(e.ToString());
            }

            return RedirectToAction("Domains");
        }

        [HttpGet]
        public ActionResult DeleteDomain(Domain domain)
        {
            Log.Debug($"Deleting {domain.Name}");

            try
            {
                domainService.DeleteDomain(domain);
                Log.Info($"{domain.Name} was deleted succesfully");
            }
            catch (Exception e)
            {
                Log.Error(e.ToString());
            }

            return RedirectToAction("Domains");
        }
    }
}