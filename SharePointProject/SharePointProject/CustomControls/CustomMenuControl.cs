using Microsoft.SharePoint;
using Microsoft.SharePoint.WebControls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.UI;

namespace SharePointProject.CustomControls
{
    /// <summary>
    /// Custom control which implements Site Settings menu option with fly out options
    /// </summary>
    /// <remarks>When used in menu deployed using custom action then control has to be marked as safe in web.config!</remarks>
    public class CustomMenuControl : Control
    {
        private const string FirstMenuItemUrl = @"/_layouts/SharePointProject/FirstApplicationPage.aspx";
        private const string SecondMenuItemUrl = @"/Page1.aspx";

        protected override void CreateChildControls()
        {
            base.CreateChildControls();

            SPWeb web = SPContext.Current.Web; 

            // Menu options
            SubMenuTemplate subMenuTemplate = new SubMenuTemplate();
            subMenuTemplate.ID = "CustomSubMenu";
            subMenuTemplate.Text = "Pages demo";
            subMenuTemplate.Description = "Pages demo - Application page and site page";
            subMenuTemplate.MenuGroupId = 1; // Id of group in menu. Value of 1 means that it will be placed in first group (with Edit Page item)
            subMenuTemplate.Sequence = 1; 

            // Menu items (commands) 
            MenuItemTemplate template1 = new MenuItemTemplate();
            template1.ID = "FirstMenuItem";
            template1.Text = "First Application Page";
            template1.Sequence = 1;
            template1.ClientOnClickNavigateUrl = web.Url + FirstMenuItemUrl; 

            MenuItemTemplate template2 = new MenuItemTemplate();
            template2.ID = "SecondMenuItem";
            template2.Text = "Site page";
            template2.Sequence = 2;
            template2.ClientOnClickNavigateUrl = web.Url + SecondMenuItemUrl; 

            // Add controls 
            subMenuTemplate.Controls.Add(template1);
            subMenuTemplate.Controls.Add(template2);

            this.Controls.Add(subMenuTemplate); 
        }
    }
}
