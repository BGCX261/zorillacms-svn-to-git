<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Wedding.Master" AutoEventWireup="true" CodeBehind="New.aspx.cs" Inherits="Zorilla.CMS.Views.Template.New" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <% Html.BeginForm("Create", "Template"); %>
    
    <%= Html.Hidden("template.Id") %>
    <p>
        Name:
        <%= Html.TextBox("template.Name") %>
    </p>
    <p>
        Template location:
        <%= Html.TextBox("template.TemplateLocation") %>
    </p>
    
    <input type="submit" value="Create" />
    
    <% Html.EndForm(); %>
</asp:Content>
