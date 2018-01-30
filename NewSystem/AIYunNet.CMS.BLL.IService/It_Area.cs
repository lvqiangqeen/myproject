using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AIYunNet.CMS.Domain.Model;

namespace AIYunNet.CMS.BLL.IService
{
    public interface It_Area
    {
        List<t_Area> GetAreaListByfather(string father);
    }
}
