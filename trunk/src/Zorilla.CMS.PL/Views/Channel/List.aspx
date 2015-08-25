<%@ Page Language="C#" MasterPageFile="~/Views/Shared/Wedding.Master" AutoEventWireup="true" CodeBehind="List.aspx.cs" Inherits="Zorilla.CMS.Views.Channel.List" %>

<asp:Content ID="indexContent" ContentPlaceHolderID="MainContent" runat="server">
    <h1>Channels</h1>
    <p>
        <span class="message"><%= Html.Encode(TempData["Message"]) %></span>
    </p>
    <p>
        <%= RenderTree(ViewData.Model) %>
    </p>
    <p>
        <%= Html.ActionLink("New channel","New") %>
    </p>
</asp:Content>