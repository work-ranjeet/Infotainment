using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;


namespace Infotainment.Extension
{
    public static partial class ExtensionMethod
    {
        public static HtmlString Literal(this HtmlHelper htmHelper, string Text)
        {
            return new HtmlString(Text);
        }
    }
}