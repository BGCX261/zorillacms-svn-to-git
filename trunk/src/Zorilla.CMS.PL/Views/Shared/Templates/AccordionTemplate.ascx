<%@ Import Namespace="Zorilla.CMS.BL.Entities"%>
<%@ Import Namespace="Zorilla.Util.DataStructures"%>
<%@ Import Namespace="Zorilla.CMS.Helpers"%>
<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="AccordionTemplate.ascx.cs" Inherits="Zorilla.CMS.Views.Shared.Templates.AccordionTemplate" %>

<script type="text/javascript" src="/Scripts/Expandable.js"></script> 

<h1><% Html.CmsText(ViewData.Model.Name + ".Title"); %></h1>

<p>
<% Html.CmsText(ViewData.Model.Name + ".PreAccordion"); %>
</p>

<% int listElements = ViewData.Model.GetProperty<int>("accordion_elements"); %>

<% for (int i = 0; i < listElements; i++ ) { %>
    <%= Html.BeginExpanderHeader() %>
        <% Html.CmsText(ViewData.Model.Name + ".Header" + i); %>
    <%= Html.EndExpanderHeader() %>
    
     <%= Html.BeginExpanderBody() %>
        <% Html.CmsText(ViewData.Model.Name + ".Body" + i); %>
    <%= Html.EndExpanderBody() %>
<% } %>

<p>
<% Html.CmsText(ViewData.Model.Name + ".PostAccordion"); %>
</p>

<% Html.PostingProperty<int>("accordion_elements",ViewData.Model); %>