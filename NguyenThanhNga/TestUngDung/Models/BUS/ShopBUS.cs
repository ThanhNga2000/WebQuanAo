using ModelEF.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TestUngDung.Models.BUS
{
    public class ShopBUS
    {
        public List<Product> DanhSach()
        {
            var db = new NguyenThiThanhNgaDBContext();
            return db.Products.Where(x => x.Status == true).OrderBy(x => x.Quantity).ToList();
        }
        public Product ChiTiet(long id)
        {
            var db = new NguyenThiThanhNgaDBContext();
            return db.Products.Find(id);
        }
    }
}