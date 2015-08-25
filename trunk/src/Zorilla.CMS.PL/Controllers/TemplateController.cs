using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Ajax;
using Zorilla.CMS.BL.Entities;
using Zorilla.CMS.BL.Repositories;

namespace Zorilla.CMS.Controllers
{
    public class TemplateController : Controller
    {
        private readonly ITemplateRepository templateRepository;

        public TemplateController(ITemplateRepository templateRepository)
        {
            this.templateRepository = templateRepository;
        }
        [Authorize]
        public ActionResult List()
        {
            IList<Template> all = templateRepository.GetAll();
            return View(all);
        }
        [Authorize]
        public ActionResult Edit(long id)
        {
            Template template = templateRepository.GetByPrimaryKey(id);
            return View(template);
        }
        [Authorize]
        public ActionResult New()
        {
            return View();
        }
        [Authorize]
        public ActionResult Delete(long id)
        {
            Template template = templateRepository.GetByPrimaryKey(id);
            template.Delete();

            TempData["Message"] = "Template deleted";
            return RedirectToAction("List");
        }
        [Authorize]
        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Create([Bind(Include = "Id,Name,TemplateLocation")] Template template)
        {
            template.Create();

            TempData["Message"] = "Template created";
            return RedirectToAction("List");
        }
        [Authorize]
        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Update([Bind(Include = "Id,Name,TemplateLocation")] Template template)
        {
            Template toBeUpdated = templateRepository.GetByPrimaryKey(template.Id);
            toBeUpdated.Name = template.Name;
            toBeUpdated.TemplateLocation = template.TemplateLocation;
            toBeUpdated.Update();

            TempData["Message"] = "Template updated";
            return RedirectToAction("List");
        }

        
    }
}
