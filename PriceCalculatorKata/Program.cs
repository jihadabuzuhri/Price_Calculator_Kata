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
            AdditionalCosts.Add("transport", 0);
            AdditionalCosts.Add("administrative", 0);

            Dictionary<string, bool> IsAbsoluteValue = new Dictionary<string, bool>();

            IsAbsoluteValue.Add("packaging", false);
            IsAbsoluteValue.Add("transport", false);
            IsAbsoluteValue.Add("administrative", false);


            Console.WriteLine("_____________________________________________________________________");
            
            Console.WriteLine("\nSample product: Title = “The Little Prince”, UPC=12345, price=20.25 USD.Tax = 20%, no discounts\n");
            Product Book1 = new Product("The Little Prince", 12345, 20.25);
            Calculation.CalculateAdditiveFinalPrice(Book1,20,0,false,0, false, 12345, AdditionalCosts, IsAbsoluteValue,0,false,"USD");

            Console.WriteLine("_____________________________________________________________________");
            
            Console.WriteLine("\nSample product: Title = “The Little Prince”, UPC=12345, price=17.76 GBP.Tax = 20%, no discounts\n");
            Product Book2 = new Product("The Little Prince", 12345, 17.76);
            Calculation.CalculateAdditiveFinalPrice(Book2, 20, 0, false, 0, false, 12345, AdditionalCosts, IsAbsoluteValue, 0, false, "GBP");

            Console.ReadLine();

        }
    }
}
