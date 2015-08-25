using System;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Html;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using Zorilla.CMS.BL.Entities;
using Zorilla.Util.DataStructures;

namespace Zorilla.CMS.Helpers
{
    public static class CmsHelper
    {
        public static void CmsText(this HtmlHelper helper, string textId)
        {
            helper.CmsText(textId,true);
        }

        public static void CmsText(this HtmlHelper helper, string textId, bool showEditBtn)
        {
            helper.RenderPartial("CmsControls/CmsTextCtl", new Pair<string,bool>(textId,showEditBtn));
        }

        public static void RenderPosting(this HtmlHelper helper, Posting posting)
        {
            helper.RenderPartial(posting.Template.TemplateLocation,posting);
        }

        public static void PostingProperty<T>(this HtmlHelper helper, string propertyName, Posting posting)
        {
            helper.RenderPartial("CmsControls/PostingPropertyCtl", new Triplet<Posting, string, Type>(posting, propertyName, typeof(T)));
        }
    }
}
