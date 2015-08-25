<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Wedding.Master" Inherits="System.Web.Mvc.ViewPage" %>
<%@ Import Namespace="Zorilla.CMS"%>
<%@ Import Namespace="Zorilla.CMS.BL.Services"%>
<%@ Import Namespace="Zorilla.CMS.Helpers"%>



<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <script type="text/javascript" src="/Scripts/Expandable.js"></script> 

    <h1><% Html.CmsText("WishList.Title"); %></h1>
        
    <p> <% Html.CmsText("WishList.PreText"); %></p>



<% var textService = MvcApplication.Container.GetService<ITextService>(); %>

<% foreach (Zorilla.CMS.BL.Entities.Wish wish in (IEnumerable<Zorilla.CMS.BL.Entities.Wish>) Model) { %>
    <%= Html.BeginExpanderHeader() %>
        <% Html.CmsText("WishList." + wish.Name + ".Header"); %>
    <%= Html.EndExpanderHeader() %>
    
     <%= Html.BeginExpanderBody() %>
        <% Html.CmsText("WishList." + wish.Name + ".Body"); %>
        <p>
        <% Html.CmsText("WishList.Amount"); %> <%= wish.Amount %>
        </p>
        <p>
        <%= Html.ActionLink(textService.GetText("WishList.Reserve").Value, "Reserve", new {wish.Id })%>
        </p>
    <%= Html.EndExpanderBody() %>  
    
<% } %>

<p>
<% Html.CmsText("WishList.PostText"); %>
</p>


</asp:Content>
