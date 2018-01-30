using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dos.ORM;

namespace AIYunNet.CMS.Domain
{
    public class AIYunDbSession
    {
        public static readonly DbSession Context = new DbSession("ConnectionString");
    }
}
