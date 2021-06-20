using ModelEF.Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelEF
{
    public class ProductModel
    {
        private NguyenThiThanhNgaDBContext context = null;
        public ProductModel()
        {
            context = new NguyenThiThanhNgaDBContext();
        }

       public List<Product> ListAll()
        {
            var list = context.Database.SqlQuery<Product>("pr_Product_ListAll").ToList();
            return list;
        }
        public int Create(string ten,int gia,int? soluong,string hinh,string mota,bool? trangthai,string LSP)
        {
            object[] para=
                {
                new SqlParameter("@Name",ten),
                new SqlParameter("@UnitCost",gia),
                new SqlParameter("@Quantity",soluong),
                new SqlParameter("@Image",hinh),
                new SqlParameter("@Description",mota),
                new SqlParameter("@Status",trangthai),
                new SqlParameter("@CategoryID",LSP),
            };
            int res = context.Database.ExecuteSqlCommand("pr_Product_Insert @Name,@UnitCost,@Quantity,@Image,@Description,@Status,@CategoryID", para);
            return res;
        }
       
    }
}
