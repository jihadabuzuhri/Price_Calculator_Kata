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

            AdditionalCosts.Add("packaging", 0);
            AdditionalCosts.Add("transport", 0);
            AdditionalCosts.Add("administrative", 0);

            Dictionary<string, bool> IsAbsoluteValue = new Dictionary<string, bool>();

            IsAbsoluteValue.Add("packaging", false);
            IsAbsoluteValue.Add("transport", true);
            IsAbsoluteValue.Add("administrative", false);


            Console.WriteLine("_____________________________________________________________________");

            Console.WriteLine("\nTax = 21%, discount = 15%, UPC discount = 7% for UPC=12345, additive discounts, cap = 20%\n");
            Calculation.CalculateAdditiveFinalPrice(Book,21,15,false,7, false, 12345, AdditionalCosts, IsAbsoluteValue,20,false);

            Console.WriteLine("_____________________________________________________________________");


            Console.WriteLine("\nTax = 21%, discount = 15%, UPC discount = 7% for UPC=12345, additive discounts, cap = $4\n");
            Calculation.CalculateAdditiveFinalPrice(Book, 21, 15, false, 7, false, 12345, AdditionalCosts, IsAbsoluteValue, 4, true);

            Console.WriteLine("_____________________________________________________________________");
            
            Console.WriteLine("\nTax = 21%, discount = 15%, UPC discount = 7% for UPC=12345, additive discounts, cap = 30%\n");
            Calculation.CalculateAdditiveFinalPrice(Book, 21, 15, false, 7, false, 12345, AdditionalCosts, IsAbsoluteValue, 30, false);



            Console.ReadLine();

        }
    }
}
