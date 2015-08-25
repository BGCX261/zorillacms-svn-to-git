<%@ Page Language="C#" MasterPageFile="~/Views/Shared/Site.Master" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="Zorilla.CMS.Views.Home.Index" %>
<%@ Import Namespace="Zorilla.CMS.Helpers"%>
<%@ Import Namespace="Castle.ActiveRecord"%>
<%@ Import Namespace="Zorilla.CMS.BL.Repositories"%>

<asp:Content ID="indexContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2><%= Html.Encode(ViewData["Message"]) %></h2>
    <p>
        To learn more about ASP.NET MVC visit <a href="http://asp.net/mvc" title="ASP.NET MVC Website">http://asp.net/mvc</a>.
    </p>   
    
    <p>
    <% Html.CmsText("Test.Text"); %>
    </p>
    <p><% Html.CmsText("Test2.Text"); %>
    </p>
   
</asp:Content>
