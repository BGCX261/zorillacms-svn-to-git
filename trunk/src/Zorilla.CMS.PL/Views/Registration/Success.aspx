<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Wedding.Master" Inherits="System.Web.Mvc.ViewPage" %>
<%@ Import Namespace="Zorilla.CMS.Helpers"%>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <h1><% Html.CmsText("Registration.Header"); %></h1>

    <p><% Html.CmsText("Registration.Received"); %></p>
</asp:Content>
