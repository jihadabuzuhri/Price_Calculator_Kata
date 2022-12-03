using System;

namespace PriceCalculatorKata
{
    class Program
    {
        static void Main(string[] args)
        {

            Product Book = new Product("The Little Prince", 12345, 20.25);

            Product BookWithTaxAndDiscount = Calculation.AddTaxWithDiscount(Book,20,15);
            Console.WriteLine("Sample product: Book with name = “The Little Prince”, UPC=12345, price=$20.25.");
            Console.WriteLine($"Tax amount = ${Calculation.TaxAmount} Discount amount = ${Calculation.DiscountAmount} Price before = ${Book.Price}, price after = ${BookWithTaxAndDiscount.Price} ");


        }
    }
}
