using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AIYunNet.CMS.Common.Utility
{
    public class SiteHelper
    {
        public static bool IsSuperVisor()
        {
            if (SessionHelper.GetSession("companyID") != null && SessionHelper.GetSession("companyID").ToString() == "0")
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
