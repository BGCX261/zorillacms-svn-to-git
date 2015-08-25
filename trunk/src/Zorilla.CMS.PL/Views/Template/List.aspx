<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Wedding.Master" AutoEventWireup="true" CodeBehind="List.aspx.cs" Inherits="Zorilla.CMS.Views.Template.List" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    
    <h1>Templates</h1>

    <p>
        <span class="message"><%= Html.Encode(TempData["Message"]) %></span>
    </p>
    
    <table>
        <tr>
            <th>Name</th>
            <th>Template location</th>
        </tr>
        <% foreach (var template in ViewData.Model)
           { %>
        <tr>
            <td><%= template.Name %></td>
            <td><%= template.TemplateLocation %></td>
            <td><%= Html.ActionLink("edit", "Edit", new {template.Id })%></td>
            <td><%= Html.ActionLink("delete", "Delete", new {template.Id })%></td>
        </tr>
        <% } %>
    </table>
    
    <p>
        <%= Html.ActionLink("Create new template","New") %>
    </p>
    
</asp:Content>
