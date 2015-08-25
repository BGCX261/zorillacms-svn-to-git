<%@ Page Language="C#" MasterPageFile="~/Views/Shared/Wedding.Master" AutoEventWireup="true" CodeBehind="Edit.aspx.cs" Inherits="Zorilla.CMS.Views.Channel.Edit" %>
<%@ Import Namespace="Zorilla.CMS.Helpers"%>
<%@ Import Namespace="Zorilla.CMS.BL.Entities"%>
<%@ Import Namespace="Zorilla.CMS.BL.Services" %>

<asp:Content ID="indexContent" ContentPlaceHolderID="MainContent" runat="server">
    
    <h1>Edit channel</h1>
    
    <% Html.BeginForm("Update", "Channel");%>
    
     <p>
        <span class="message"><%= Html.Encode(TempData["Message"]) %></span>
    </p>    
    
    <%=Html.Hidden("channel.Id", ViewData.Model.First.Id)%>    
    <p>
        Name: <%=Html.TextBox("channel.Name", ViewData.Model.First.Name)%>
    </p>
    <p>
        TextId: <%=Html.TextBox("channel.TextId", ViewData.Model.First.TextId)%>
    </p>
    <p>
        Parent channel:
        <%
        if (ViewData.Model.First.IsRoot) { %>
            <em>No parent channel. Current channel is root channel.</em>
        <% } else { %>
            <% IList<Channel> all = ViewData.Model.Second.GetAll();
               all.Remove(ViewData.Model.First); %>    
               
            <%= Html.DropDownList("channel.Parent",new SelectList(all,"Id","Name",ViewData.Model.First.Parent.Id)) %>
        <% } %>
    </p>
    
    
    <strong>Postings:</strong>
        
    <table>
        <tr>
            <th>Name</th>
            <th>Template</th>                
        </tr>
        <%
       foreach (var posting in ViewData.Model.First.Postings)
       { %>
        <tr>
            <td><%= posting.Name %></td>
            <td><%= posting.Template.Name %></td>
            <td><%= Html.ActionLink("delete","Delete","Posting",new {posting.Id},null) %></td>
        </tr>
       <% } %>                       
    </table>
    
    <%= Html.ExpanderHeader("Create new posting") %>
		    	
    <%= Html.BeginExpanderBody() %>
    
        Name: <%= Html.TextBox("posting.Name") %>
        Template: 
          <%= Html.DropDownList("posting.Template",new SelectList(ViewData.Model.Third.GetAll(),"Id","Name")) %>
        <input type="button" id="btn_create_button" value="Create posting" /> 
           
    <%= Html.EndExpanderBody() %>
 
    <p>
        <input type="submit" value="Update" />
        <%= Html.ActionLink("delete channel","Delete",new {ViewData.Model.First.Id}) %>
    </p>
    
    <p>
        <%= Html.ActionLink("back to list","List") %>
    </p>
    <% Html.EndForm(); %>    
    
    
    <script type="text/javascript" src="/Scripts/Expandable.js"></script> 
    <script type="text/javascript">  
    
        function createPosting()
        {            
            var name = $('#posting_Name')[0].value;
            var templateId = $('#posting_Template')[0].value;
            var channelId = $('#channel_Id')[0].value;
            window.location = "/Posting/Create?name=" + name + "&templateId=" + templateId + "&channelId=" + channelId;
            //alert(name + "," + templateId);
        }
        
        $(document).ready(function() {	
  	        $("#btn_create_button").click(createPosting);
        });
    </script>   
</asp:Content>
