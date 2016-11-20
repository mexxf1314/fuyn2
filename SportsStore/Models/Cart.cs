using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SportsStore.Models
{
    //构建购物篮
    public class Cart
    {
        private List<CartLine> lineCollection = new List<CartLine>();
        public void  AddItem(Product product,int quantity)
        {
            CartLine line = lineCollection.Where(p => p.Product.ProductID == product.ProductID).FirstOrDefault();
            if (line == null)
            {
                lineCollection.Add(new CartLine { Product = product, quantity = quantity });
            }
            else {
                line.Quantity += quantity;
            }
        }
    }
}