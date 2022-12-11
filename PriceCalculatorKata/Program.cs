using System;
using System.Collections.Generic;

namespace PriceCalculatorKata
{
    class Program
    {
        static void Main(string[] args)
        {
            

            Dictionary<string, double> AdditionalCosts = new Dictionary<string, double>();

            AdditionalCosts.Add("packaging", 0);
            AdditionalCosts.Add("transport", 3);
            AdditionalCosts.Add("administrative", 0);

            Dictionary<string, bool> IsAbsoluteValue = new Dictionary<string, bool>();

            IsAbsoluteValue.Add("packaging", false);
            IsAbsoluteValue.Add("transport", false);
            IsAbsoluteValue.Add("administrative", false);


            Console.WriteLine("_____________________________________________________________________");
            
            Console.WriteLine("\nSample product: Title = “The Little Prince”, UPC=12345, price=20.25 USD.\r\nTax = 21%, universal discount = 15%, UPC discount = 7% for UPC=12345, discounts are multiplicative and after tax\r\nTransport cost = 3% of base price");
            Console.WriteLine();
            Product Book1 = new Product("The Little Prince", 12345,20.25);
            Calculation.CalculateMultiplicativeFinalPrice(product: Book1,
                                                    TaxRate: 21,
                                                    UniversalDiscountRate: 15,
                                                    IsUniversalDiscountBeforeTax: false,
                                                    UPC_DiscountRate: 7,
                                                    IsUPC_DiscountBeforeTax: false,
                                                    UPC_ForDiscount: 12345,
                                                    AdditionalCosts: AdditionalCosts,
                                                    IsAbsoluteValue: IsAbsoluteValue,
                                                    CAP: double.MaxValue,
                                                    IsCapAbsoluteValue: true,
                                                    Currency: "USD");

            Console.ReadLine();

        }
    }
}
