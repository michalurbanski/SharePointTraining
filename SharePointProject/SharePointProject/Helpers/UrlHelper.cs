using Microsoft.SharePoint;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SharePointProject.Helpers
{
    public class UrlHelper
    {
        private const string Slash = "/";

        public static string GetSiteRelativeUrl(SPSite site)
        {
            string siteUrl = site.ServerRelativeUrl;
            if (!siteUrl.EndsWith(Slash))
                siteUrl += Slash;

            return siteUrl; 
        }
    }
}
