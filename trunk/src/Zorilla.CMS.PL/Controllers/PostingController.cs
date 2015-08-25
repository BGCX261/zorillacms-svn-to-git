using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Ajax;
using Zorilla.CMS.BL.Entities;
using Zorilla.CMS.BL.Repositories;

namespace Zorilla.CMS.Controllers
{
    public class PostingController : Controller
    {
        private readonly IPostingRepository postingRepository;
        private readonly IChannelRepository channelRepository;
        private readonly ITemplateRepository templateRepository;

        public PostingController(IPostingRepository postingRepository, IChannelRepository channelRepository, ITemplateRepository templateRepository)
        {
            this.postingRepository = postingRepository;
            this.channelRepository = channelRepository;
            this.templateRepository = templateRepository;
        }
        [Authorize]
        public ActionResult Delete(long id)
        {
            Posting posting = postingRepository.GetByPrimaryKey(id);
            posting.Delete();
            TempData["Message"] = "Posting deleted";
            return Redirect(Request.UrlReferrer.ToString());
        }
        [Authorize]
        [ValidateInput(false)]
        public ActionResult Create(string name, long channelId, long templateId)
        {
            var posting = new Posting();
            posting.Name = name;
            posting.Channel = channelRepository.GetByPrimaryKey(channelId);
            posting.Template = templateRepository.GetByPrimaryKey(templateId);
            posting.Create();
            TempData["Message"] = "Posting created";
            return Redirect(Request.UrlReferrer.ToString());
        }

        [Authorize]
        public ActionResult SetProperty(long postingId, string propertyName, string propertyValue, string propertyType)
        {
            Posting posting = postingRepository.GetByPrimaryKey(postingId);
            if (propertyType == "Int32") posting.SetProperty<int>(propertyName,Int32.Parse(propertyValue));
            if (propertyType == "Double") posting.SetProperty<double>(propertyName, Double.Parse(propertyValue));
            if (propertyType == "String") posting.SetProperty<string>(propertyName, propertyValue);
            posting.Update();
            return Redirect(Request.UrlReferrer.ToString());
        }


        
    }
}
