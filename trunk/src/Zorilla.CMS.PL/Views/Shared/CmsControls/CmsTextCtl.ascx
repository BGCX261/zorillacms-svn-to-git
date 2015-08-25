<%@ Import Namespace="Zorilla.CMS.BL.Entities"%>
<%@ Import Namespace="Zorilla.CMS.BL.Context"%>
<%@ Import Namespace="Zorilla.CMS.BL.Services"%>
<%@ Import Namespace="Zorilla.CMS.BL.Repositories"%>
<%@ Import Namespace="Zorilla.CMS"%>
<%@ Import Namespace="Zorilla.Util.Web"%>

<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CmsTextCtl.ascx.cs" Inherits="Zorilla.CMS.Views.Shared.CmsTextCtl" %>


<% var textService = MvcApplication.Container.GetService<ITextService>();
   Text text = textService.GetText(ViewData.Model.First, CmsContext.Current.Language);%>
        
   <%= text.Value %>

<% if (CmsContext.Current.Mode == CmsMode.Edit && ViewData.Model.Second)
   { %>      
        <% if (Request.QueryString["edittext"] != ViewData.Model.First) { %>  
            <small><a href="<%= Request.Url.AddQueryParameter("edittext",ViewData.Model.First) %>">edit</a></small>
        <% } else { %>                    
            <small><a href="<%= Request.Url.RemoveQueryParameter("edittext") %>">cancel edit</a></small>
            <% Html.RenderPartial("CmsControls/RichTextEditor", text); %>            
        <% } %>
<% } %>


