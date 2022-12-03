using System;

namespace PriceCalculatorKata
{
    class Program
    {
        static void Main(string[] args)
        {

            Product Book = new Product("The Little Prince", 12345, 20.25);

            Product BookWithTax = Calculation.AddTax(Book,20);
            Console.WriteLine($"Product price reported as {Book.Price} before tax and {BookWithTax.Price}  after 20 % tax");

            BookWithTax = Calculation.AddTax(Book, 21);
            Console.WriteLine($"Product price reported as {Book.Price} before tax and {BookWithTax.Price}  after 21 % tax");

        }
    }
}
