﻿using System;
using System.Collections.Generic;
using System.Collections.Specialized;
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
                    updateBtn.Visible = false;
                }
            }
        }

        public List<CartItem> UpdateCartItems()
        {
            using (ShoppingCartAction usersShoppingCart = new ShoppingCartAction())
            {
                String cartId = usersShoppingCart.GetCartId();

                ShoppingCartAction.ShoppingCartUpdates[] cartUpdates = new ShoppingCartAction.ShoppingCartUpdates[CartList.Rows.Count];
                for (int i = 0; i < CartList.Rows.Count; i++)
                {
                    IOrderedDictionary rowValues = new OrderedDictionary();
                    rowValues = GetValues(CartList.Rows[i]);
                    cartUpdates[i].ProductId = Convert.ToInt32(rowValues["ProductID"]);

                    CheckBox cbRemove = new CheckBox();
                    cbRemove = (CheckBox)CartList.Rows[i].FindControl("Remove");
                    cartUpdates[i].RemoveItem = cbRemove.Checked;

                    TextBox quantityTextBox = new TextBox();
                    quantityTextBox = (TextBox)CartList.Rows[i].FindControl("PurchaseQuantity");
                    cartUpdates[i].PurchaseQuantity = Convert.ToInt16(quantityTextBox.Text.ToString());
                }
                usersShoppingCart.UpdateShoppingCartDatabase(cartId, cartUpdates);
                CartList.DataBind();
                lblTotal.Text = String.Format("{0:c}", usersShoppingCart.GetTotal());
                return usersShoppingCart.GetCartItems();
            }
        }

        public static IOrderedDictionary GetValues(GridViewRow row)
        {
            IOrderedDictionary values = new OrderedDictionary();
            foreach (DataControlFieldCell cell in row.Cells)
            {
                if (cell.Visible)
                {
                    // Extract values from the cell.
                    cell.ContainingField.ExtractValuesFromCell(values, cell, row.RowState, true);
                }
            }
            return values;
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