using System;
using System.Collections.Generic;
using System.Text;

namespace PriceCalculatorKata
{
    class Report
    {
        public static void TotalDiscountedReport(double DiscountAmount, string currency)
        {

            if (DiscountAmount == 0)
            Console.WriteLine("No discounts");
            else
            Console.WriteLine($"Total discounted amount : {DiscountAmount} {currency}");
        
        }


        public static void PriceReport(double ProductPrice , double TaxAmount, double TotalDiscountAmount,
            double PackagingAmount, double TransportAmount, double AdministrativeAmount, double FinalPrice, string currency)
        {

            Console.WriteLine($"Cost {ProductPrice} {currency} ");
            
            if (TaxAmount != 0)
                Console.WriteLine($"Tax Amount {TaxAmount} {currency} ");
            
            if (TotalDiscountAmount != 0)
                Console.WriteLine($"Discounts {TotalDiscountAmount} {currency} ");
            
            if (PackagingAmount != 0)
                Console.WriteLine($"Packaging Amount {PackagingAmount} {currency} ");
            
            if (TransportAmount != 0)
                Console.WriteLine($"Transport Amount {TransportAmount} {currency} ");
            
            if (AdministrativeAmount != 0)
                Console.WriteLine($"Administrative Amount {AdministrativeAmount} {currency} ");
            
            Console.WriteLine($"TOTAL {FinalPrice} {currency} ");


         
        }



    }
}
