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
            Console.WriteLine($"Total discounted amount : {Math.Round(DiscountAmount, 2)} {currency}");
        
        }


        public static void PriceReport(double ProductPrice , double TaxAmount, double TotalDiscountAmount,
            double PackagingAmount, double TransportAmount, double AdministrativeAmount, double FinalPrice, string currency)
        {

            

            Console.WriteLine($"Cost {Math.Round(ProductPrice)} {currency} ");
            
            if (TaxAmount != 0)
                Console.WriteLine($"Tax Amount {Math.Round(TaxAmount,2) } {currency} ");
            
            if (TotalDiscountAmount != 0)
                Console.WriteLine($"Discounts {Math.Round(TotalDiscountAmount,2)} {currency} ");
            
            if (PackagingAmount != 0)
                Console.WriteLine($"Packaging Amount {Math.Round(PackagingAmount, 2)} {currency} ");
            
            if (TransportAmount != 0)
                Console.WriteLine($"Transport Amount {Math.Round(TransportAmount, 2)} {currency} ");
            
            if (AdministrativeAmount != 0)
                Console.WriteLine($"Administrative Amount {Math.Round(AdministrativeAmount, 2)} {currency} ");
            
            Console.WriteLine($"TOTAL {Math.Round(FinalPrice, 2)} {currency} ");


         
        }



    }
}
