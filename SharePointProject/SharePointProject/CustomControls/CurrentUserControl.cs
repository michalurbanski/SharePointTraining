using Microsoft.SharePoint;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.UI;

namespace SharePointProject.CustomControls
{
    public class CurrentUserControl : Control
    {
        private SPUser CurrentUser { get { return SPContext.Current.Web.CurrentUser; } }

        protected override void Render(HtmlTextWriter writer)
        {
            base.Render(writer);

            writer.RenderBeginTag(HtmlTextWriterTag.Div);
            writer.Write(CurrentUser);
            writer.RenderEndTag(); 

        }
    }
}
