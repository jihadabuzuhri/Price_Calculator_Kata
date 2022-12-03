using System;
using System.Collections.Generic;
using System.Text;

namespace PriceCalculatorKata
{
    class Calculation
    {
        public static Product AddTax(Product product , double taxRate)
        {
            return new Product
            (
                product.Name,
                product.UPC,
                product.Price + Math.Round(product.Price * (taxRate/100) , 2)
            );

        }
    }
}
