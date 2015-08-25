using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using Zorilla.CMS.BL.Entities;

namespace Zorilla.CMS.BL.Context
{
    [Serializable]
    public class CmsContext
    {
        public CmsMode Mode { get; set; }
        public Language Language { get; set; }
        public ICmsUser CurrentUser { get; set; }
        public Channel CurrentChannel { get; set; }


        public CmsContext()
        {
            // HACK default language - DA
            Language = new Language {Id = 1, Name = "Dansk", LanguageCode = "DA"};
            Mode = CmsMode.Normal;
            CurrentUser = new CmsUser();
        }

        public static CmsContext Current { get
        {
            var ctx = HttpContext.Current.Session["cmscontext"] as CmsContext;
            if (ctx == null)
            {
                ctx = new CmsContext();
                HttpContext.Current.Session["cmscontext"] = ctx;
            }
            return ctx;
        }}
    }

    public interface ICmsUser
    {
        bool CanEdit { get; }
    }

    public class CmsUser : ICmsUser
    {
        public bool CanEdit
        {
            get { return HttpContext.Current.Request.IsAuthenticated; }
        }
    }

    public enum CmsMode
    {
        Normal, Edit
    }
}
