using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AIYunNet.CMS.Domain.Model;

namespace AIYunNet.CMS.BLL.IService
{
    public interface IWebImg
    {
        List<WebImg> GetWebImgList(int DecType);
        List<WebImg> GetWebImgListByParameter(string sql);
        WebImg GetWebImgByID(int webImgID);
        int AddWebImg(WebImg webImg);
        int UpdateWebImg(WebImg webImg);
        int DeleteWebImg(int webImgID);
    }
}
