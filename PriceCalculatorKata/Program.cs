using System;

namespace PriceCalculatorKata
{
    class Program
    {
        static void Main(string[] args)
        {

            Product Book = new Product("The Little Prince", 12345, 20.25);
            Console.WriteLine("Sample product: Book with name = “The Little Prince”," +
                " UPC=12345, price=$20.25.\n");

            Console.WriteLine("\nTax = 20%, universal discount (after tax) = 15%, UPC-discount (before tax) = 7% for UPC=12345");
            Product Book1WithTaxAndDiscount = Calculation.CalculateFinalPrice(Book,20,15,false,7,true,12345);

            Console.ReadLine();
            
        }
    }
}
