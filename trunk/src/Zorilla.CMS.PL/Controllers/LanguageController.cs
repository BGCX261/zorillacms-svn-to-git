using System;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using Zorilla.CMS.BL.Context;
using Zorilla.CMS.BL.Entities;
using Zorilla.CMS.BL.Repositories;

namespace Zorilla.CMS.Controllers
{
    public class LanguageController : Controller
    {
        private readonly ILanguageRepository languageRepository;

        public LanguageController()
        {
            this.languageRepository = new LanguageRepository();
        }

        public ActionResult ChangeLanguage(string id)
        {
            CmsContext.Current.Language = languageRepository.GetLanguageByLanguageCode(id);
            return Redirect(Request.UrlReferrer.ToString());
        }
    }
}
