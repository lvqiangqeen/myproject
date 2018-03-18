using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AIYunNet.CMS.Domain.OccaModel
{
    public class BuidTogether
    {
        public int id { get; set; }
        public int buidingID { get; set; }
        public int stageid { get; set; }
        public string buidingName { get; set; }
        public string stagename { get; set; }
        public string cityName { get; set; }
        public int PublishWorkerid { get; set; }
        public string PublishWorkerName { get; set; }
        public string PublishWorkerTel { get; set; }
        public int demandid { get; set; }
        public string ownername { get; set; }
        public string ownertel { get; set; }
        public string startTime { get; set; }
        public int IsAccept { get; set; }
    }
}
