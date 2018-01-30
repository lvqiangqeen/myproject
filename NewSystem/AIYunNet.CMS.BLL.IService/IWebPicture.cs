using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AIYunNet.CMS.Domain.Model;

namespace AIYunNet.CMS.BLL.IService
{
    public interface IWebPicture
    {
        List<WebPicture> GetWebPictureList(int ImgID);
        List<WebPicture> GetWebPictureList(int ImgID, int num);
        WebPicture GetWebPictureByID(int WebPictureID);
        int AddWebPicture(WebPicture WebPicture);
        int UpdateWebPicture(WebPicture WebPicture);
        int DeleteWebPicture(int WebPictureID);
    }
}
