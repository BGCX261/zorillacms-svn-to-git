<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Wedding.Master" Inherits="System.Web.Mvc.ViewPage" %>
<%@ Import Namespace="Zorilla.CMS.BL.Entities"%>


<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Registrations</h2>

    <table>
        <tr>
            <th>Name(s)</th>
            <th>Is coming</th>
            <th>Need bus</th>
            <th>Comment</th>
        </tr>
        
        <% foreach (var reg in (IList<Registration>) Model) {%>
            <tr>
                <td><%= reg.Name %></td>
                <td><%= reg.IsComing ? "Yes" : "No" %></td>
                <td><%= reg.WantBus ? "Yes" : "No" %></td>
                <td><%= reg.Comment %></td>
            </tr>        
        <% } %>        
    </table>
</asp:Content>
