using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AIYunNet.CMS.BLL.IService;
using AIYunNet.CMS.Domain.Model;
using AIYunNet.CMS.Domain;

namespace AIYunNet.CMS.BLL.Service
{
    public class WebGoodsService:IWebGoods
    {
        /// <summary>
        /// 推送列表全部
        /// </summary>
        public List<WebGoods> GetWebGoodsList()
        {
            using (AIYunNetContext context = new AIYunNetContext())
            {

                return context.WebGoods.Where(p => p.FlagDelete == 0 ).OrderByDescending(p => p.EditOn).ToList();

            }
        }
        /// <summary>
        /// 根据类别和数量推送
        /// </summary>
        public List<WebGoods> GetWebGoodsList(int Belongs, int num)
        {
            using (AIYunNetContext context = new AIYunNetContext())
            {
                if (Belongs == 0)
                {
                    return context.WebGoods.Where(p => p.FlagDelete == 0 ).OrderByDescending(p => p.EditOn).Take(num).ToList();
                }
                else
                {
                    return context.WebGoods.Where(p => p.FlagDelete == 0 && p.Belongs == Belongs).OrderByDescending(p => p.EditOn).Take(num).ToList();
                }

            }
        }
        public WebGoods GetWebGoodsByID(int WebGoodsID)
        {
            using (AIYunNetContext context = new AIYunNetContext())
            {
                return context.WebGoods.Find(WebGoodsID);
            }
        }
        public int AddWebGoods(WebGoods WebGoods)
        {
            using (AIYunNetContext context = new AIYunNetContext())
            {
                context.WebGoods.Add(WebGoods);
                context.SaveChanges();
                return 1;
            }
        }

        public int UpdateWebGoods(WebGoods WebGoods)
        {
            using (AIYunNetContext context = new AIYunNetContext())
            {
                if (WebGoods != null)
                {
                    WebGoods origWebGoods = context.WebGoods.Find(WebGoods.GoodsID);
                    if (origWebGoods != null)
                    {
                        origWebGoods.goods_name = WebGoods.goods_name;
                        origWebGoods.goods_desc = WebGoods.goods_desc;
                        origWebGoods.logo = WebGoods.logo;
                        origWebGoods.price = WebGoods.price;
                        origWebGoods.is_on_sale = WebGoods.is_on_sale;
                        origWebGoods.IsTop = WebGoods.IsTop;
                        origWebGoods.thumbnailImage = WebGoods.thumbnailImage;
                        origWebGoods.Goodstock = WebGoods.Goodstock;
                        origWebGoods.Belongs = WebGoods.Belongs;
                        origWebGoods.Newprice = WebGoods.Newprice;
                        origWebGoods.Salesnum = WebGoods.Salesnum;
                        origWebGoods.goods_Info = WebGoods.goods_Info;
                        origWebGoods.EditOn = DateTime.Now;
                        context.SaveChanges();
                    }
                }


                return 1;
            }
        }

        public int DeleteWebGoods(int WebGoodsID)
        {
            using (AIYunNetContext context = new AIYunNetContext())
            {
                WebGoods WebGoods = context.WebGoods.Find(WebGoodsID);
                if (WebGoods != null)
                {
                    WebGoods.FlagDelete = 1;
                    WebGoods.DeleteOn = DateTime.Now;
                    context.SaveChanges();
                    return 1;
                }
                else
                {
                    return 0;
                }
            }
        }
    }
}
