using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AIYunNet.CMS.Common.Utility.PageParam
{
    public enum SearchMatchType
    {
        And = 0,
        Or = 1,
    };

    public enum ConditionType
    {
        Eq = 0,
        Ne = 1,
        Like = 2,
        GreaterThan = 3,
        GreaterThanOrEqual = 4,
        LessThan = 5,
        LessThanOrEqual = 6
    };
    public class SearchQuery
    {
        public SearchMatchType Type { set; get; }

        public ConditionType ConditionType { set; get; }

        public string Text { set; get; }

        public string Key { set; get; }

    }
}
