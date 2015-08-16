using System;
using System.Security.Permissions;
using Microsoft.SharePoint;
using Microsoft.SharePoint.Utilities;
using Microsoft.SharePoint.Workflow;
using System.Diagnostics;

namespace SharePointProject.ChildSiteInit
{
    /// <summary>
    /// Web Events. Applies branding to newly created webs. 
    /// </summary>
    public class ChildSiteInit : SPWebEventReceiver
    {
        /// <summary>
        /// A site was provisioned.
        /// </summary>
        public override void WebProvisioned(SPWebEventProperties properties)
        {
            //base.WebProvisioned(properties);

            SPWeb web = properties.Web;
            SPWeb rootWeb = web.Site.RootWeb;
            
            web.MasterUrl = rootWeb.MasterUrl;
            //web.CustomMasterUrl = rootWeb.CustomMasterUrl; 
            //web.AlternateCssUrl = rootWeb.AlternateCssUrl;
            //web.SiteLogoUrl = rootWeb.SiteLogoUrl;
            web.Update();
        }
    }
}