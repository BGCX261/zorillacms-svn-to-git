<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Wedding.Master" AutoEventWireup="true" CodeBehind="Edit.aspx.cs" Inherits="Zorilla.CMS.Views.Template.Edit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <% Html.BeginForm("Update", "Template"); %>
    
    <%= Html.Hidden("template.Id", ViewData.Model.Id) %>
    <p>
        Name:
        <%= Html.TextBox("template.Name",ViewData.Model.Name) %>
    </p>
    <p>
        Template location:
        <%= Html.TextBox("template.TemplateLocation",ViewData.Model.TemplateLocation) %>
    </p>
    
    <input type="submit" value="Update" />
    
    <% Html.EndForm(); %>
</asp:Content>
