using System;
using System.Collections.Generic;
using System.Text;

namespace PriceCalculatorKata
{
    class Report
    {
        public static void TotalDiscountedReport(double DiscountAmount)
        {

            if (DiscountAmount == 0)
                return;
            
            Console.WriteLine($"Total discounted amount : ${DiscountAmount}");
        
        }


        public static void PriceReport(double ProductPrice , double TaxAmount, double TotalDiscountAmount,
            double PackagingAmount, double TransportAmount, double AdministrativeAmount, double FinalPrice)
        {

            Console.WriteLine($"Cost ${ProductPrice} ");
            
            if (TaxAmount != 0)
                Console.WriteLine($"Tax Amount ${TaxAmount} ");
            
            if (TotalDiscountAmount != 0)
                Console.WriteLine($"Discounts ${TotalDiscountAmount} ");
            
            if (PackagingAmount != 0)
                Console.WriteLine($"Packaging Amount ${PackagingAmount} ");
            
            if (TransportAmount != 0)
                Console.WriteLine($"Transport Amount ${TransportAmount} ");
            
            if (AdministrativeAmount != 0)
                Console.WriteLine($"Administrative Amount ${AdministrativeAmount} ");
            
            Console.WriteLine($"TOTAL ${FinalPrice} ");



        }



    }
}
