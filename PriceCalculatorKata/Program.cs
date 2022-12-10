using System;
using System.Collections.Generic;

namespace PriceCalculatorKata
{
    class Program
    {
        static void Main(string[] args)
        {
            Product Book = new Product("The Little Prince", 12345, 20.25);
            Console.WriteLine("Sample product: Book with name = “The Little Prince”, UPC=12345, price=$20.25.\n");


            Dictionary<string, double> AdditionalCosts = new Dictionary<string, double>();

            AdditionalCosts.Add("packaging", 1);
            AdditionalCosts.Add("transport", 2.2);
            AdditionalCosts.Add("administrative", 0);

            Dictionary<string, bool> IsAbsoluteValue = new Dictionary<string, bool>();

            IsAbsoluteValue.Add("packaging", false);
            IsAbsoluteValue.Add("transport", true);
            IsAbsoluteValue.Add("administrative", false);


            Console.WriteLine("_____________________________________________________________________");

            Console.WriteLine("\nTax = 21%, discount = 15%, UPC discount = 7% for UPC=12345, additive discounts Packaging cost = 1% of price Transport cost = $2.2\n");
            Product Book1WithTaxAndAdditiveDiscount = Calculation.CalculateAdditiveFinalPrice(Book,21,15,false,7, false, 12345, AdditionalCosts, IsAbsoluteValue);

            Console.WriteLine("_____________________________________________________________________");

            Console.WriteLine("\nTax = 21%, discount = 15%, UPC discount = 7% for UPC=12345, multiplicative discounts Packaging cost = 1% of price Transport cost = $2.2\n");
            Product Book1WithTaxAndMultiplicativeDiscount = Calculation.CalculateMultiplicativeFinalPrice(Book, 21, 15, false, 7, false, 12345, AdditionalCosts, IsAbsoluteValue);







            Console.ReadLine();

        }
    }
}
