<%@ Import Namespace="Zorilla.CMS.Helpers"%>
<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="BaseTemplate.ascx.cs" Inherits="Zorilla.CMS.Views.Shared.Templates.BaseTemplate" %>

<h1><% Html.CmsText(ViewData.Model.Name + ".Title"); %></h1>
<br />

<p>
<% Html.CmsText(ViewData.Model.Name + ".Body"); %>
</p>