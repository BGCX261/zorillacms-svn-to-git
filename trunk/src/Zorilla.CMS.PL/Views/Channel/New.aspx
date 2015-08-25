<%@ Page Language="C#" MasterPageFile="~/Views/Shared/Wedding.Master" AutoEventWireup="true" CodeBehind="New.aspx.cs" Inherits="Zorilla.CMS.Views.Channel.New" %>
<%@ Import Namespace="Zorilla.CMS.Views.Channel"%>
<%@ Import Namespace="Zorilla.CMS.BL.Services"%>

<asp:Content ID="indexContent" ContentPlaceHolderID="MainContent" runat="server">
    <% Html.BeginForm("Create","Channel"); %>
        
    <p>
        Name: <%= Html.TextBox("channel.Name") %>
    </p>
    <p>
        TextId: <%= Html.TextBox("channel.TextId") %>
    </p>
    <p>
        Parent channel: <%= Html.DropDownList("channel.Parent",new SelectList(ViewData.Model.GetAll(),"Id","Name")) %>
    </p>
    <input type="submit" value="Create" />
    
    <% Html.EndForm(); %>
</asp:Content>