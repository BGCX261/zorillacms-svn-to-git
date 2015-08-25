<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Wedding.Master" Inherits="System.Web.Mvc.ViewPage" %>
<%@ Import Namespace="Zorilla.CMS"%>
<%@ Import Namespace="Zorilla.CMS.BL.Services"%>
<%@ Import Namespace="Zorilla.CMS.Helpers"%>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <h1><% Html.CmsText("WishList.Title"); %></h1>

    <% var textService = MvcApplication.Container.GetService<ITextService>(); %>
    
    <% Html.CmsText("WishList.ReservationRegistered"); %>

    <p><%= Html.ActionLink(textService.GetText("Back").Value, "Index") %></p>
</asp:Content>
