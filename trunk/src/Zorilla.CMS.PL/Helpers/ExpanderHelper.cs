using System;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;

namespace Zorilla.CMS.Helpers
{
    public static class ExpanderHelper
    {
        private const string HEADERBEGIN = @"<div class=""expandable_header"">
	<table> 
		<tr>
		    <td>";
        private const string HEADEREND = @"</td>
		    <td><img class=""expandable_img_down"" src=""/Content/Images/Style/down.gif"" /> 
			<img class=""expandable_img_up"" src=""/Content/Images/Style/up.gif"" style=""display:none;"" /></td> 
		</tr> 
	</table>	
</div>";

        public static string BeginExpanderHeader(this HtmlHelper helper)
        {
            return HEADERBEGIN; 
        }

        public static string EndExpanderHeader(this HtmlHelper helper)
        {
            return HEADEREND;
        }

        public static string ExpanderHeader(this HtmlHelper helper, string headerContent)
        {
            return HEADERBEGIN + headerContent + HEADEREND;
        }


        public static string ExpanderBody(this HtmlHelper helper, string bodyContent)
        {
            return "<div class=\"expandable_body\">" + bodyContent + "</div>";
        }


        public static string BeginExpanderBody(this HtmlHelper helper)
        {
            return "<div class=\"expandable_body\">";
        }

        public static string EndExpanderBody(this HtmlHelper helper)
        {
            return "</div>";
        }
    }
}
