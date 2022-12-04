using System;

namespace PriceCalculatorKata
{
    class Program
    {
        static void Main(string[] args)
        {

            Product Book = new Product("The Little Prince", 12345, 20.25);
            Console.WriteLine("Sample product: Book with name = “The Little Prince”, UPC=12345, price=$20.25.");

            Console.WriteLine("Tax = 20%, discount = 15%");
            Product Book1WithTaxAndDiscount = Calculation.AddTaxWithDiscount(Book,20,15);

            Console.WriteLine("Tax = 20%, no discount");
            Product Book2WithTaxAndDiscount = Calculation.AddTaxWithDiscount(Book, 20, 0);



        }
    }
}
