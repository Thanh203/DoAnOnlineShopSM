using DoAn.Models.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DoAn.Models.Dao
{
    public class ContentDao
    {
        OnlineShopSM db = null;
        public ContentDao()
        {
            db = new OnlineShopSM();
        }
        public Content GetByID(long id)
        {
            return db.Contents.Find(id);
        }
    }
}