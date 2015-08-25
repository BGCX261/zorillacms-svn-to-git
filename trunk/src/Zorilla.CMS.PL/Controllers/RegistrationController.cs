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
    public class RegistrationController : Controller
    {
        private readonly IRegistrationRepository registrationRepository;

        public RegistrationController(IRegistrationRepository registrationRepository)
        {
            this.registrationRepository = registrationRepository;
        }

        //
        // GET: /Registration/
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Success()
        {
            return View();
        }

        [Authorize]
        public ActionResult List()
        {
            return View(registrationRepository.GetAll());
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Create([Bind] Registration registration)
        {
            registrationRepository.Create(registration);

            TempData["Message"] = "Registration.RegistrationCreated";
            return View("Success");
        }
    }
}
