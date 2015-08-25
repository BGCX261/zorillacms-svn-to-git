<%@ Import Namespace="Zorilla.CMS.Helpers"%>
<%@ Import Namespace="Zorilla.CMS.BL.Context"%>
<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="PostingPropertyCtl.ascx.cs" Inherits="Zorilla.CMS.Views.Shared.CmsControls.PostingPropertyCtl" %>

<% if (CmsContext.Current.Mode == CmsMode.Edit) {%>

<%= Html.ExpanderHeader("Edit property: " + ViewData.Model.Second) %>

<%= Html.BeginExpanderBody() %>
<% Html.BeginForm("SetProperty", "Posting");%>

    <%=Html.Hidden("postingId", ViewData.Model.First.Id)%>
    <%=Html.Hidden("propertyName", ViewData.Model.Second)%>
    <%=Html.Hidden("propertyType", ViewData.Model.Third.Name)%>   
    
    <p>    
    <%=ViewData.Model.Second%>
    <%=Html.TextBox("propertyValue",ViewData.Model.First.GetProperty(ViewData.Model.Second, ViewData.Model.Third))%>
    <input type="submit" value="Set property" />
    </p>
    
    
<% Html.EndForm();%>
<%= Html.EndExpanderBody() %>


<% } %>