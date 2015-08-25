$(document).ready(function()
{
    //hide the all of the element with class expandable_body
    $(".expandable_body").hide();
    //toggle the componenet with class expandable_body
    $(".expandable_header").click(function()
    {  	
        $(this).next(".expandable_body").slideToggle(500);  
        $(this).find(".expandable_img_down").toggle(500);
        $(this).find(".expandable_img_up").toggle(500);
    });
});