using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Ajax;

namespace Zorilla.CMS.Controllers
{
    public class BryllupController : Controller
    {
        //
        // GET: /Bryllup/

        public ActionResult Index()
        {
            return RedirectToAction("Show", "Channel");
        }

    }
}
