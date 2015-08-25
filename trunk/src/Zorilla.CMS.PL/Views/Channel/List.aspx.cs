using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Html;
using Zorilla.CMS.BL.Entities;


namespace Zorilla.CMS.Views.Channel
{
    public partial class List : ViewPage<BL.Entities.Channel>
    {
        public string RenderTree(BL.Entities.Channel channel)
        {
            if (channel == null) return "";
            return "<ul>" +  RenderNode(channel) + "</ul>";
        }

        private string RenderNode(BL.Entities.Channel node)
        {
            string s = "<li>" + Html.ActionLink(node.Name,"Edit",new {node.Id});
            s += " <small>" + Html.ActionLink("Move up", "MoveUp", new {node.Id});
            s += " " + Html.ActionLink("Move down", "MoveDown", new { node.Id }) + "</small>"; 

            if (node.SubChannels != null && node.SubChannels.Count > 0)
            {
                // sort subchannels
                List<BL.Entities.Channel> list = node.SubChannels.ToList();
                list.Sort();

                s += "<ul>";
                list.ForEach(n => s += RenderNode(n));
                s += "</ul>";
            }
            return s + "</li>";
        }
    }
}