using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Zorilla.CMS.BL.Entities;
using Zorilla.CMS.BL.Repositories;
using Zorilla.CMS.BL.Services;
using Zorilla.Util.DataStructures;


namespace Zorilla.CMS.Views.Channel
{
    public partial class Edit : ViewPage<Triplet<BL.Entities.Channel, IChannelService,ITemplateRepository>>
    {
        
    }
}