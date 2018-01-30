using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AIYunNet.CMS.Domain.Model;


namespace AIYunNet.CMS.BLL.IService
{
    public interface IWebGoods
    {
        List<WebGoods> GetWebGoodsList();
        List<WebGoods> GetWebGoodsList(int type, int num);
        WebGoods GetWebGoodsByID(int WebGoodsID);
        int AddWebGoods(WebGoods WebGoods);
        int UpdateWebGoods(WebGoods WebGoods);
        int DeleteWebGoods(int WebGoodsID);
    }
}
