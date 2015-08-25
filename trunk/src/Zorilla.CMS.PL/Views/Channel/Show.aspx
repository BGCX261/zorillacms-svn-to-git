<%@ Page Language="C#" MasterPageFile="~/Views/Shared/Wedding.Master" AutoEventWireup="true" CodeBehind="Show.aspx.cs" Inherits="Zorilla.CMS.Views.Channel.Show" %>
<%@ Import Namespace="Zorilla.CMS.Helpers"%>
<%@ Import Namespace="Zorilla.CMS.BL.Entities"%>

<asp:Content ID="indexContent" ContentPlaceHolderID="MainContent" runat="server">   
    <span class="message"><%= Html.Encode(TempData["Message"]) %></span>
    
    <% foreach (Posting posting in ViewData.Model.Postings)
    {
        Html.RenderPosting(posting);
    }%>
    
    <% if (ViewData.Model.Postings.Count == 0) Html.CmsText("NoPostings"); %>
</asp:Content>