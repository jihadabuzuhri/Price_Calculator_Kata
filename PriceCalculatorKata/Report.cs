using System;
using System.Collections.Generic;
using System.Text;

namespace PriceCalculatorKata
{
    class Report
    {
        public static void DiscountedReport(double FinalPrice, double DiscountAmount)
        {
            Console.WriteLine($"Final Price : ${FinalPrice}");

            if (DiscountAmount == 0)
                return;
            
            Console.WriteLine($"discounted amount : ${DiscountAmount}");
        
        }

    }
}
