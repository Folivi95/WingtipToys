using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WingtipToys.Models;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.ModelBinding;

namespace WingtipToys
{
    public partial class ProductDetails : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        // The id parameter should match the DataKeyNames value set on the control
        // or be decorated with a value provider attribute, e.g. [QueryString]int id
        public IQueryable<Product> GetProduct([QueryString("productID")]int? productId)
        {
            var _db = new ProductContext();
            IQueryable<Product> query = _db.Products;

            if (productId.HasValue && productId > 0)
            {
                query = query.Where(p => p.ProductID == productId);
            }
            else
            {
                query = null;
            }

            return query;
        }
    }
}