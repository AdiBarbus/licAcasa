using System;
using System.Collections.Generic;
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
    public class SubDomainController : Controller
    {
        private static readonly ILog Log = LogManager.GetLogger(typeof(SubDomainController));
        private readonly ISubDomainService subDomainService;
        private readonly IDomainService domainService;
        public int PageSize = 10;
        
        public SubDomainController(ISubDomainService subDomain, IDomainService domain)
        {
            subDomainService = subDomain;
            domainService = domain;
        }

        public ActionResult SubDomains(string stringSearch, string sortOrder, string currentFilter, int page = 1)
        {
            Log.Debug("Started getting all the Subdomains");

            var getSubDomains = subDomainService.GetSubDomains();

            SearchingAndPagingViewModel<SubDomain> model = new SearchingAndPagingViewModel<SubDomain>
            {
                Collection = getSubDomains.OrderBy(p => p.Name).Skip((page - 1) * PageSize).Take(PageSize),
                PagingInfo = new PagingInfo
                {
                    CurrentPage = page,
                    ItemsPerPage = PageSize,
                    TotalItems =
                        stringSearch == null ? getSubDomains.Count() :
                            getSubDomains.Count(s => s.Name.Contains(stringSearch))
                },
                SortingOrder = IsNullOrEmpty(sortOrder) ? "name_desc" : "",
                SearchString = stringSearch
            };

            switch (sortOrder)
            {
                case "name_desc":
                    model.Collection = model.Collection.OrderByDescending(s => s.DomainId);
                    break;
                default:  // Name ascending 
                    model.Collection = model.Collection.OrderBy(s => s.DomainId);
                    break;
            }

            if (!IsNullOrEmpty(stringSearch))
            {
                model.Collection = getSubDomains.Where(s => s.Name.Contains(stringSearch));
            }
            return View(model);
        }

        [HttpGet]
        [Route("domain/GetAdvertisesBySubDomain/{domainId}")]
        public ActionResult GetAdvertisesBySubDomain(int domainId)
        {
            IEnumerable<Advertise> advertisesBySubDomain = new List<Advertise>();
            try
            {
                advertisesBySubDomain = subDomainService.GetAdvertisesBySubDomain(domainId);
            }
            catch (Exception e)
            {
                Log.Error(e.ToString());
            }

            return View(advertisesBySubDomain);
        }

        [HttpGet]
        public ActionResult SelectDomain()
        {
            SelectDomainViewModel model = new SelectDomainViewModel();
            model.Domains = domainService.GetDomains();

            return View(model);
        }

        [HttpPost]
        public ActionResult SelectDomain(SelectDomainViewModel model)
        {
            SubDomain subDomain = new SubDomain();
            try
            {
                subDomain.DomainId = model.SelectedDomainId;
            }
            catch (Exception e)
            {
                Log.Error(e.ToString());
            }

            return RedirectToAction("CreateSubDomain", new
            {
                subDomain.DomainId
            });
        }


        [HttpGet]
        [Authorize(Roles = "Admin")]
        public ActionResult CreateSubDomain()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreateSubDomain(SubDomain subDomain, int domainId)
        {
            subDomain.DomainId = domainId;

            Log.Debug("Creating new SubDomain");

            try
            {
                subDomainService.InsertSubDomain(subDomain);
            }
            catch (Exception e)
            {
                Log.Error(e.ToString());
            }

            return RedirectToAction("SubDomains");
        }

        [HttpGet]
        public ActionResult EditSubDomain(int id)
        {
            var subDomain = subDomainService.GetSubDomain(id);
            return View(subDomain);
        }

        [HttpPost]
        public ActionResult EditSubDomain(SubDomain subDomain)
        {
            Log.Debug($"Updating {subDomain.Name}");

            if (ModelState.IsValid)
            {
                try
                {
                    subDomainService.UpdateSubDomain(subDomain);
                    return RedirectToAction("SubDomains");
                }
                catch (Exception e)
                {
                    Log.Error(e.ToString());
                }
            }

            return View(subDomain);
        }

        [HttpGet]
        public ActionResult DeleteSubDomain(SubDomain subDomain)
        {
            Log.Debug($"Deleting {subDomain.Name}");

            try
            {
                subDomainService.DeleteSubDomain(subDomain);
                Log.Info($"{subDomain.Name} was deleted succesfully");
            }
            catch (Exception e)
            {
                Log.Error(e.ToString());
            }

            return RedirectToAction("SubDomains");
        }
    }
}