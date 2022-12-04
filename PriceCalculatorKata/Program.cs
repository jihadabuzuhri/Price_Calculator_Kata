using System;

namespace PriceCalculatorKata
{
    class Program
    {
        static void Main(string[] args)
        {

            Product Book = new Product("The Little Prince", 12345, 20.25);
            Console.WriteLine("Sample product: Book with name = “The Little Prince”, UPC=12345, price=$20.25.\n");

            Console.WriteLine("\nTax = 20%, universal discount = 15%, UPC-discount = 7% for UPC=12345");
            Product Book1WithTaxAndDiscount = Calculation.CalculateFinalPrice(Book,20,15,7,12345);

            Console.WriteLine("\nTax = 21%, universal discount = 15%, UPC-discount = 7 for UPC = 789");
            Product Book2WithTaxAndDiscount = Calculation.CalculateFinalPrice(Book, 21, 15,7,789);


        }
    }
}
