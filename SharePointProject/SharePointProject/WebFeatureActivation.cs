using Microsoft.SharePoint;
using Microsoft.SharePoint.Utilities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace SharePointProject
{
    /// <summary>
    /// Actions performed during feature activation
    /// </summary>
    internal class WebFeatureActivation
    {
        public void CreateWebPartPage(SPWeb web, string pageFileName, string templateFileName)
        {
            int lcid = web.Locale.LCID;
            string hive = SPUtility.GetGenericSetupPath(string.Format("TEMPLATE\\{0}\\STS\\DOCTEMP\\SMARTPGS\\", lcid));
            FileStream fileStream = new FileStream(hive + templateFileName, FileMode.Open);

            web.Files.Add(pageFileName, fileStream, true); // Last parameters overwrites created page
        }

        public void CopySitePage(SPWeb web, string sourceFileName, string destinationFileName)
        {
            SPFile file = web.GetFile(sourceFileName);
            if (!file.Exists)
            {
                throw new ArgumentException("Incorrect file name " + sourceFileName);
            }

            file.CopyTo(destinationFileName, true);
        }

        
    }
}
