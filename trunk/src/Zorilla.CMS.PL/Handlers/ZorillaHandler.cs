using System;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;

namespace Zorilla.CMS.Handlers
{
    public class ZorillaHandler : IHttpHandler
    {
        public void ProcessRequest(HttpContext context)
        {
            if (context.Request.Url.Host.Contains("zorilla"))
            {
                UriBuilder uriBuilder = new UriBuilder(context.Request.Url);
                uriBuilder.Port = 82;
                context.Response.Redirect(uriBuilder.Uri.ToString(),true);
            }
        }

        public bool IsReusable
        {
            get { return false; }
        }
    }

    public class ZorillaModule : IHttpModule
    {
        public void Init(HttpApplication context)
        {
            context.BeginRequest += new EventHandler(context_BeginRequest);
        }

        void context_BeginRequest(object sender, EventArgs e)
        {
            HttpApplication app = (HttpApplication)sender;
            HttpContext context = app.Context;
            if (context.Request.Url.Host.Contains("zorilla"))
            {
                UriBuilder uriBuilder = new UriBuilder(context.Request.Url);
                uriBuilder.Port = 82;
                context.Response.Redirect(uriBuilder.Uri.ToString(), true);
            }
        }

        public void Dispose()
        {
            
        }
    }
}
