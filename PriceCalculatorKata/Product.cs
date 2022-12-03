using System;
using System.Collections.Generic;
using System.Text;

namespace PriceCalculatorKata
{
    class Product
    {
        public String Name { get; set; }
        public int UPC { get; set; }
        public double Price { get; set; }

        public Product(string name, int upc, double price)
        {
            Name = name;
            UPC = upc;
            Price = Math.Round(price, 2);
        }
    }
}
