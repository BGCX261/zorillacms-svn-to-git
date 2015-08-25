using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Ajax;
using Zorilla.CMS.BL.Context;
using Zorilla.CMS.BL.Entities;
using Zorilla.CMS.BL.Repositories;
using Zorilla.CMS.BL.Services;
using Zorilla.Util.DataStructures;
using Zorilla.Util.Strings;

namespace Zorilla.CMS.Controllers
{
    public class ChannelController : Controller
    {
        private readonly IChannelService channelService;
        private readonly ITemplateRepository templateRepository;

        public ChannelController(IChannelService channelService, ITemplateRepository templateRepository)
        {
            this.channelService = channelService;
            this.templateRepository = templateRepository;
        }

        [Authorize]
        public ActionResult List()
        {
            return View(channelService.GetRoot());
        }

        [Authorize]
        public ActionResult New()
        {
            return View(channelService);
        }

        public ActionResult Show(string id)
        {
            Channel channel = channelService.GetChannelByName(id);
            CmsContext.Current.CurrentChannel = channel;
            if (channel == null) channel = channelService.GetDefaultChannel();
            if (!channel.Url.IsNullOrEmpty()) return Redirect(channel.Url);
            return View(channel);
        }

        [Authorize]
        public ActionResult Edit(long id)
        {
            return View(new Triplet<Channel,IChannelService,ITemplateRepository>(channelService.GetChannel(id),channelService,templateRepository));
        }

        [Authorize]
        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Update([Bind(Include = "Id,Name,TextId")] Channel channel)
        {
            Channel toBeUpdated = channelService.GetChannel(channel.Id);
            toBeUpdated.Name = channel.Name;
            toBeUpdated.TextId = channel.TextId;
            if (!toBeUpdated.IsRoot)
            {
                long parent = long.Parse(Request.Form["channel.Parent"].Split(',')[0]);
                toBeUpdated.Parent = new Channel {Id = parent};
            }
            toBeUpdated.Update();
            
            TempData["Message"] = "Channel updated";
            return RedirectToAction("List");
        }

        [Authorize]
        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Create([Bind(Include = "Name,TextId")] Channel channel)
        {
            long parent = long.Parse(Request.Form["channel.Parent"]);
            channel.Parent = new Channel {Id = parent};
            channelService.Create(channel);
            
            TempData["Message"] = "Channel created";
            return RedirectToAction("List");
        }

        [Authorize]
        public ActionResult Delete(long id)
        {
            Channel channel = channelService.GetChannel(id);
            channel.Delete();

            TempData["Message"] = "Channel deleted";
            return RedirectToAction("List");
        }

        [Authorize]
        public ActionResult MoveUp(long id)
        {
            Channel channel = channelService.GetChannel(id);
            channelService.OrderingMoveUp(channel);

            TempData["Message"] = "Channel moved upwards";
            return RedirectToAction("List");
        }

        [Authorize]
        public ActionResult MoveDown(long id)
        {
            Channel channel = channelService.GetChannel(id);
            channelService.OrderingMoveDown(channel);

            TempData["Message"] = "Channel moved downwards";
            return RedirectToAction("List");
        }
    }
}
