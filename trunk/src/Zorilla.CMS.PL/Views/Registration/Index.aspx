<%@ Page Title="" MasterPageFile="~/Views/Shared/Wedding.Master" Language="C#" Inherits="System.Web.Mvc.ViewPage" %>
<%@ Import Namespace="Zorilla.CMS.BL.Context"%>
<%@ Import Namespace="Zorilla.CMS.Helpers"%>

<%--MasterPageFile="~/Views/Shared/Wedding.Master"--%>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <h1><% Html.CmsText("Registration.Header"); %></h1>

    <p>
        <% if (CmsContext.Current.CurrentUser.CanEdit)
           { %>
                <%= Html.ActionLink("View registrations","List") %>
        <% } %>
        <%--<span class="message"><%= CmsHelper.CmsText(TempData["Message"].ToString()); %></span>--%>
    </p>
    
    <p><% Html.CmsText("Registration.Description"); %></p>

    <% Html.BeginForm("Create","Registration"); %>    
    <p>
        <% Html.CmsText("Registration.Name"); %>
        <%= Html.TextBox("registration.Name") %>
    </p>
    <p>
        <% Html.CmsText("Registration.IsComing"); %>
        <%= Html.CheckBox("registration.IsComing") %>
    </p>
    
     <p>
        <% Html.CmsText("Registration.WantToGoOnBus"); %>
        <%= Html.CheckBox("registration.WantBus") %>
    </p>
    
    <p>
        <% Html.CmsText("Registration.Comment"); %><br />
        <%= Html.TextArea("registration.Comment","",4,30,null) %>
    </p>
    
    <p>
        <input type="submit" value="Submit" />
    </p>
    <% Html.EndForm(); %>

</asp:Content>
