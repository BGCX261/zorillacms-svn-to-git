<%@ Import Namespace="Zorilla.CMS.BL.Context"%>
<%@ Import Namespace="Zorilla.CMS.Helpers"%>
<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CmsMenu.ascx.cs" Inherits="Zorilla.CMS.Views.Shared.CmsControls.CmsMenu" %>

<ul id="channel_menu">
<%  
    // find current channel
    List<Zorilla.CMS.BL.Entities.Channel> channels = ViewData.Model.GetRoot().SubChannels.ToList();
    Zorilla.CMS.BL.Entities.Channel active = channels.FirstOrDefault(c => Request.Url.AbsolutePath.Contains(c.Name));
    if (active == null) active = ViewData.Model.GetDefaultChannel(); // use default
    channels.Sort();
    
    foreach (var channel in channels) {
    %>
    <li id="channel_menuitem" <%= channel.Equals(active) ? "class=\"active\"" : "" %> >
        
        <a href="<%= "/Channel/Show/" + channel.Name  %>">
            <% Html.CmsText(channel.TextId ?? "null");  %>
        </a>
    </li>
<% } %>    
</ul>
