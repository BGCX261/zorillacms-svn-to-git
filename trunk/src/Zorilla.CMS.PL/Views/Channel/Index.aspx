<%@ Page Language="C#" MasterPageFile="~/Views/Shared/Site.Master" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="Zorilla.CMS.Views.Channel.Index" %>
<%@ Import Namespace="Zorilla.CMS.Helpers"%>
<%@ Import Namespace="Zorilla.CMS.BL.Entities"%>

<asp:Content ID="indexContent" ContentPlaceHolderID="MainContent" runat="server">   
    <span class="message"><%= Html.Encode(TempData["Message"]) %></span>
    
    <% foreach (Posting posting in ViewData.Model.Postings)
    {
        Html.RenderPosting(posting);
    }%>
    
</asp:Content>