using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AIYunNet.CMS.Domain.OccaModel
{
    public class BuidingAndComment
    {
        public string guid { get; set; }
        /// <summary>
        /// BuidingTitle
        /// </summary>
        public string BuidingTitle { get; set; }
        /// <summary>
        /// score
        /// </summary>
        public int score { get; set; }
        /// <summary>
        /// Comment
        /// </summary>
        public string Comment { get; set; }
        /// <summary>
        /// EndTime
        /// </summary>
        public string EndTime { get; set; }

        /// <summary>
        /// AddOn
        /// </summary>
        public string AddOn { get; set; }
    }
}
