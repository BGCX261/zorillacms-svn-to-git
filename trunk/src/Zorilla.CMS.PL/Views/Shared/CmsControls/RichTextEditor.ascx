<%@ Import Namespace="Zorilla.CMS.BL.Services"%>
<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="RichTextEditor.ascx.cs" Inherits="Zorilla.CMS.Views.Shared.CmsControls.RichTextEditor" %>

<link rel="stylesheet" href="../../../Scripts/jwysiwyg/jquery.wysiwyg.css" type="text/css" media="screen" /> 

<%= Html.Hidden("Text.Id",ViewData.Model.Id) %>
<%= Html.Hidden("Text.TextId", ViewData.Model.TextId)%>
<%= Html.Hidden("Text.Language.Id",ViewData.Model.Language.Id) %>


    
    <%= Html.TextArea("Text.Value",ViewData.Model.IsCreated ? ViewData.Model.Value : "",11,69,
        new Dictionary<string,object> {{"class", "wysiwyg"}}) %>    
    
  


<input type="button" id="save_text_btn" value="Save" />



<script type="text/javascript" src="../../../Scripts/jwysiwyg/jquery.wysiwyg.js"></script>  
<script type="text/javascript">  
$(function()
{
    $('.wysiwyg').wysiwyg();
});
</script>  

<script type="text/javascript">  
    
        function navigateWithReferrer(url)
        {
            var fakeLink = document.createElement ("a");
            if (typeof(fakeLink.click) == 'undefined')
                location.href = url;  // sends referrer in FF, not in IE
            else
            {
                fakeLink.href = url;
                document.body.appendChild(fakeLink);
                fakeLink.click();   // click() method defined in IE only
            }
        }
    
        function saveText()
        {            
            var id = $('#Text_Id')[0].value;
            var textId = $('#Text_TextId')[0].value;
            var languageId = $('#Text_Language_Id')[0].value;
            //var tval = $('.wysiwyg')[0].val();
            var tval = $('#Text_Value')[0].value;
            var textValue = encodeURIComponent(tval);
            var url = "/Text/Save?tid=" + id + "&textId=" + textId + "&value=" + textValue + "&languageId=" + languageId;
            navigateWithReferrer(url);
            //alert(name + "," + templateId);
        }
        
        $(document).ready(function() {	
  	        $("#save_text_btn").click(saveText);
        });
</script>   