using System;
using System.Collections.Generic;
using System.Text;

namespace PriceCalculatorKata
{
    class Calculation
    {
        public static double TaxAmount  { get; set; }
        public static double DiscountAmount { get; set; }
        public static double FinalPrice { get; set; }


        public static Product AddTaxWithDiscount(Product product , double TaxRate, double DiscountRate)
        {

            TaxAmount = Math.Round(product.Price * (TaxRate / 100), 2);
            DiscountAmount = Math.Round(product.Price * (DiscountRate / 100), 2);
            FinalPrice = Math.Round(product.Price + TaxAmount - DiscountAmount, 2);
            
            Report.DiscountedReport(FinalPrice, DiscountAmount);

            return new Product
            (
                product.Name,
                product.UPC,
                FinalPrice
            );

        }


    }
}
