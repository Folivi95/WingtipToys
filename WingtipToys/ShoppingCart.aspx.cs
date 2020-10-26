using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WingtipToys.Logic;
using WingtipToys.Models;

namespace WingtipToys
{
    public partial class ShoppingCart : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            decimal cartTotal = 0;
            using (ShoppingCartAction shoppingCartAction = new ShoppingCartAction())
            {
                cartTotal = shoppingCartAction.GetTotal();

                if (cartTotal > 0)
                {
                    lblTotal.Text = String.Format("{0:c}", cartTotal);
                }
                else
                {
                    lblTotal.Text = "";
                    LabelTotalText.Text = "";
                    ShoppingCartTitle.InnerText = "Shopping Cart is Empty";
                }
            }
        }

        public List<CartItem> GetShoppingCartItems()
        {
            ShoppingCartAction action = new ShoppingCartAction();
            return action.GetCartItems();
        }

        protected void updateBtn_Click(object sender, EventArgs e)
        {

        }
    }
}