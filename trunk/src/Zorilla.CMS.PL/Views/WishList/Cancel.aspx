<%@ Page Language="C#" MasterPageFile="~/Views/Shared/Wedding.Master" Inherits="System.Web.Mvc.ViewPage" %>
<%@ Import Namespace="Zorilla.CMS"%>
<%@ Import Namespace="Zorilla.CMS.BL.Services"%>
<%@ Import Namespace="Zorilla.CMS.Helpers"%>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <h1><% Html.CmsText("WishList.Title"); %></h1>
    <% var wish = (Wish) Model; %>    
    <% var textService = MvcApplication.Container.GetService<ITextService>(); %>
    
     <p><% Html.CmsText("WishList.CancelReservation"); %></p>
        
    <% Html.BeginForm("CancelReservation","WishList"); %>    
            
    <%= Html.Hidden("wish.Id",wish.Id) %>
    <% if (wish.Amount == 1)
       {%>
        <%= Html.Hidden("wish.Reserved", 1)%>
    <% } %>
    <% else { %>
        <p>
            <% Html.CmsText("WishList.Amount"); %>
            <%= Html.TextBox("wish.Reserved",1) %>
        </p>
    <% } %>
    
    <input type="submit" value="<%= textService.GetText("WishList.Cancel").Value %>" />
    <% Html.EndForm(); %>
        
    <p><%= Html.ActionLink(textService.GetText("Back").Value, "Index") %></p>
</asp:Content>
