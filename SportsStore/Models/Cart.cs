﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SportsStore.Models
{
    //构建购物篮
    //用于再购物篮重添加产品移除产品计算购物篮中产品的价格
    public class Cart
    {
        private List<CartLine> lineCollection = new List<CartLine>();
        public void  AddItem(Product product,int quantity)
        {
            CartLine line = lineCollection.Where(p => p.Product.ProductID == product.ProductID).FirstOrDefault();
            if (line == null)
            {
                lineCollection.Add(new CartLine { Product = product, Quantity = quantity });
            }
            else {
                line.Quantity += quantity;
            }
        }
        public void RemoveLine(Product product )
        {
            lineCollection.RemoveAll(l=> l.Product.ProductID==product.ProductID );
        }
        public decimal ComputeTotalValue()
        {
            return lineCollection.Sum(e=> e.Product.Price*e.Quantity);
        }
        public void clear()
        {
            lineCollection.Clear();
        }
        public IEnumerable<CartLine> Lines {
            get { return lineCollection; }
        }
        public class CartLine{
            public Product Product { get; set; }
            public int Quantity { get; set; }
        }
    }
}