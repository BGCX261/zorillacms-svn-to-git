<%@ Import Namespace="Zorilla.CMS.BL.Context"%>
<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CmsModeCtl.ascx.cs" Inherits="Zorilla.CMS.Views.Shared.CmsControls.CmsModeCtl" %>

<% if (CmsContext.Current.CurrentUser.CanEdit)
 {
     
     if (CmsContext.Current.Mode == CmsMode.Normal)
     { %>
        <%= Html.ActionLink("Edit mode", "SetMode", "Cms", new { Mode = "Edit" }, null)%>
     <% }
     else
     { %>
        <%= Html.ActionLink("Live mode","SetMode","Cms",new {Mode = "Normal"},null) %>
     <% }
      
 } %>