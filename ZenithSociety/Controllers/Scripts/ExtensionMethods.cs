using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace ZenithSociety.Controllers.Scripts
{
    public static class ExtensionMethods
    {
        public static MvcHtmlString DatePickerScript(this HtmlHelper helper)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("<script>$(function() {$('#datetimepicker1').datetimepicker();});$(function() {$('#datetimepicker2').datetimepicker();});</script>");

            return MvcHtmlString.Create(sb.ToString());
        }
    }
}