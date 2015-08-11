using Microsoft.SharePoint;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SharePointProject
{
    internal class SiteFeatureActivation
    {
        public SPSite GetValidatedSiteInFeature(SPFeatureReceiverProperties properties)
        {
            SPSite site = properties.Feature.Parent as SPSite;
            if (site == null)
                throw new ArgumentException("Incorrect scope for feature found during activation");

            return site; 
        }

        public void SetCustomBranding(SPWebCollection webs, string siteUrl)
        {
            foreach(SPWeb web in webs)
            {
                // For all properties URL has to be relative to web application
                web.MasterUrl = siteUrl + "_catalogs/masterpage/custom.master";
                web.CustomMasterUrl = web.MasterUrl;
                web.AlternateCssUrl = siteUrl + "Style%20Library/custom.css";
                web.UIVersion = 4;
                web.Update(); 
            }
        }

        public void RevertToOriginalBranding(SPWebCollection webs, string siteUrl)
        {
            foreach (SPWeb web in webs)
            {
                // For all properties URL has to be relative to web application
                web.MasterUrl = siteUrl + "_catalogs/masterpage/v4.master";
                web.CustomMasterUrl = web.MasterUrl;
                web.AlternateCssUrl = string.Empty; 
                web.Update(); 
            }
        }
    }
}
