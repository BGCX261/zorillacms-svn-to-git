using System.Web.Mvc;
using Zorilla.CMS.BL.Context;

namespace Zorilla.CMS.Controllers
{
    public class CmsController : Controller
    {
        [Authorize]
        public ActionResult SetMode(CmsMode mode)
        {
            CmsContext.Current.Mode = mode;
            return Redirect(Request.UrlReferrer.ToString());
        }
    }
}
