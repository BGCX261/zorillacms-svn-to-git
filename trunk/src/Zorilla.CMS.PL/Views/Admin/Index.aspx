<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Wedding.Master" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="Zorilla.CMS.Views.Admin.Index" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h1>Administration</h1>
    
    <ul>
        <li><%= Html.ActionLink("Channels","List","Channel") %></li>
        <li><%= Html.ActionLink("Templates","List","Template") %></li>
        <li><%= Html.ActionLink("Users","List","Account") %></li>
    </ul>
</asp:Content>
