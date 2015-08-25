using System.Web.Mvc;
using Zorilla.CMS.BL.Entities;
using Zorilla.CMS.BL.Services;
using Zorilla.Util.Web;

namespace Zorilla.CMS.Controllers
{
    public class TextController : Controller
    {
        private readonly ITextService textService;

        public TextController(ITextService textService)
        {
            this.textService = textService;
        }
        
        //[Authorize]
        //[ValidateInput(false)]
        //public ActionResult Save(Text text)
        //{
        //    textService.CreateOrUpdate(text);
        //    return Redirect(Request.UrlReferrer.RemoveQueryParameter("edittext").ToString());
        //}

        [Authorize]
        [ValidateInput(false)]
        public ActionResult Save(long tid, string textId, string value, int languageId)
        {
            Text text = new Text {Id = tid, Language = new Language {Id = languageId}, TextId = textId, Value = value};
            textService.CreateOrUpdate(text);
            return Redirect(Request.UrlReferrer.RemoveQueryParameter("edittext").ToString());
        }


    }
}
