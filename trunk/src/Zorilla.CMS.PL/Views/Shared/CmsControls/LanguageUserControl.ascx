<%@ Import Namespace="Zorilla.CMS.BL.Repositories"%>
<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="LanguageUserControl.ascx.cs" Inherits="Zorilla.CMS.Views.Shared.LoginUserControl" %>

<% var languageRepository = new LanguageRepository();
   foreach (var language in languageRepository.GetAll())
   {%>
        <a href="<%= Url.Action("ChangeLanguage","language", new {id = language.LanguageCode }) %>">
            <img src="../../../Content/Images/Languages/<%= language.LanguageCode %>.gif" alt="<%= language.Name %>" Width="26px" />
        </a> 
        
 <%}%>
 
