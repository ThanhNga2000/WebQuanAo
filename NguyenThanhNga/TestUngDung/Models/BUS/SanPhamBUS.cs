using ModelEF.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TestUngDung.Models.BUS
{
    public class SanPhamBUS
    {
        public List<Product> DanhSachSP()
        {
            var db = new NguyenThiThanhNgaDBContext();
            return db.Products.Where(x => x.Status == true).OrderBy(x => x.Quantity).ToList();
        }
        
    }
}