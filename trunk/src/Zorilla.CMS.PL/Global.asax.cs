using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using Castle.ActiveRecord;
using Castle.ActiveRecord.Framework;
using Castle.ActiveRecord.Framework.Config;
using Castle.Windsor;
using MvcContrib.Castle;
using Zorilla.CMS.BL.Entities;
using Zorilla.CMS.BL.Repositories;
using Zorilla.CMS.BL.Services;
using Zorilla.CMS.Controllers;

namespace Zorilla.CMS
{
    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801

    public class MvcApplication : System.Web.HttpApplication
    {
        public static WindsorContainer Container { get; set; }

        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            routes.IgnoreRoute("favicon.ico");
            
            routes.MapRoute(
                "Default",                                              // Route name
                "{controller}/{action}/{id}",                           // URL with parameters
                new { controller = "Channel", action = "Show", id = "" }  // Parameter defaults
            );

            routes.MapRoute(
                "Root",
                "",
                new { controller = "Channel", action = "Show", id = "" }
            );
        }

        protected void Application_Start()
        {
            InitializeActiveRecord();
            InitializeIocContainer();
            ControllerBuilder.Current.SetControllerFactory(new WindsorControllerFactory(Container));
            RegisterRoutes(RouteTable.Routes);
        }

        private static void InitializeActiveRecord()
        {
            IConfigurationSource source = ActiveRecordSectionHandler.Instance;
            ActiveRecordStarter.Initialize(Assembly.Load("Zorilla.CMS.BL"),source);
            //ActiveRecordStarter.CreateSchema();
        }

        private static void InitializeIocContainer()
        {
            Container = new WindsorContainer();
            
            // repositories
            Container.AddComponent<ILanguageRepository,LanguageRepository>();
            Container.AddComponent<ITextRepository, TextRepository>();
            Container.AddComponent<IChannelRepository, ChannelRepository>();
            Container.AddComponent<ITemplateRepository, TemplateRepository>();
            Container.AddComponent<IPostingRepository, PostingRepository>();
            Container.AddComponent<IRegistrationRepository, RegistrationRepository>();
            Container.AddComponent<IWishRepository, WishRepository>();
            
            // services
            Container.AddComponent<ISessionProvider, SessionProvider>();
            Container.AddComponent<ITextService,TextService>();
            Container.AddComponent<IChannelService, ChannelService>();

            // controllers
            Container.RegisterControllers(Assembly.GetCallingAssembly());
        }
    }
}