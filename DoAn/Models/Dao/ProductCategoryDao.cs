using DoAn.Models.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DoAn.Models.Dao
{
    public class ProductCategoryDao
    {
        OnlineShopSM db = null;
        public ProductCategoryDao()
        {
            db = new OnlineShopSM();
        }
        public List<ProductCategory> ListAll()
        {
            return db.ProductCategories.Where(x => x.Status == true).OrderBy(x => x.DisplayOrder).ToList();
        }
        /*public ProductCategoryDao ViewDetail(long id)
        {
            return db.ProductCategories.Find(id);
        }*/
            
    }
}