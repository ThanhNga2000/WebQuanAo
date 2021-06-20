using ModelEF.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelEF
{
    public class CategoryModel
    {
        private NguyenThiThanhNgaDBContext context = null;
        public CategoryModel()
        {
            context = new NguyenThiThanhNgaDBContext();
        }
        public List<Category> ListAll()
        {
            return context.Categories.Where(x => x.Description == null).ToList();
        }

    }
}
