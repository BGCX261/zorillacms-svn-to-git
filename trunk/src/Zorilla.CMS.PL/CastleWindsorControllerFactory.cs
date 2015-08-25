using System;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using Castle.Core.Resource;
using Castle.Windsor;
using Castle.Windsor.Configuration.Interpreters;

namespace Zorilla.CMS
{

    public class CastleWindsorControllerFactory : DefaultControllerFactory
    {
        public override IController CreateController(RequestContext requestContext, string controllerName)
        {
            try
            {
                if (controllerName == "favicon.ico") return null;
                return MvcApplication.Container[controllerName.ToLowerInvariant()] as IController;
            }
            catch (Exception)
            {
                return base.CreateController(requestContext, controllerName);
            }
        }
    }

}
