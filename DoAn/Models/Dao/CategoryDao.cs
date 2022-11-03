using DoAn.Models.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DoAn.Models.Dao
{
    public class CategoryDao
    {
        OnlineShopSM db = null;
        public CategoryDao()
        {
            db = new OnlineShopSM();
        }
        public List<Category> ListAll()
        {
            return db.Categories.Where(x => x.Status == true).ToList();
        }
    }
}