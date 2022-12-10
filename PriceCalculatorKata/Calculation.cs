using System;
using System.Collections.Generic;
using System.Text;

namespace PriceCalculatorKata
{
    class Calculation
    {
        public static double TaxAmount  { get; set; }
        public static double TotalDiscountAmount { get; set; }
        public static double FinalPrice { get; set; }

        public static double UniversalDiscountAmount { get; set; }
        public static double UPC_DiscountAmount { get; set; }


        public static Product CalculateFinalPrice(Product product , double TaxRate, 
            double UniversalDiscountRate,bool IsUniversalDiscountBeforeTax,
            double UPC_DiscountRate, bool IsUPC_DiscountBeforeTax, int UPC_ForDiscount)
        {


            if (IsUniversalDiscountBeforeTax&& IsUPC_DiscountBeforeTax)
            {

                FinalPrice = Math.Round(product.Price, 2);

                UPC_DiscountAmount = (UPC_ForDiscount == product.UPC) ? Math.Round(FinalPrice * (UPC_DiscountRate / 100), 2) : 0;
                FinalPrice = Math.Round(FinalPrice - UPC_DiscountAmount, 2);

                UniversalDiscountAmount = Math.Round(FinalPrice * (UniversalDiscountRate / 100), 2);
                FinalPrice = Math.Round(FinalPrice - UniversalDiscountAmount, 2);


                TaxAmount = Math.Round(FinalPrice * (TaxRate / 100), 2);

                FinalPrice = Math.Round(FinalPrice + TaxAmount, 2);





            }
            else if (IsUniversalDiscountBeforeTax && IsUPC_DiscountBeforeTax==false)
            {
                FinalPrice = Math.Round(product.Price, 2);

                UniversalDiscountAmount = Math.Round(FinalPrice * (UniversalDiscountRate / 100), 2);
                FinalPrice = Math.Round(FinalPrice - UniversalDiscountAmount, 2);

                TaxAmount = Math.Round(FinalPrice * (TaxRate / 100), 2);

                UPC_DiscountAmount = (UPC_ForDiscount == product.UPC) ? Math.Round(FinalPrice * (UPC_DiscountRate / 100), 2) : 0;

                FinalPrice = Math.Round(FinalPrice - UPC_DiscountAmount, 2);

                FinalPrice = Math.Round(FinalPrice + TaxAmount, 2);
                TotalDiscountAmount = Math.Round(UniversalDiscountAmount + UPC_DiscountAmount, 2);

            }
            else if (IsUniversalDiscountBeforeTax ==false && IsUPC_DiscountBeforeTax)
            {
                FinalPrice = Math.Round(product.Price, 2);

                UPC_DiscountAmount = (UPC_ForDiscount == product.UPC) ? Math.Round(FinalPrice * (UPC_DiscountRate / 100), 2) : 0;
                FinalPrice = Math.Round(FinalPrice - UPC_DiscountAmount, 2);

                TaxAmount = Math.Round(FinalPrice * (TaxRate / 100), 2);

                UniversalDiscountAmount = Math.Round(FinalPrice * (UniversalDiscountRate / 100), 2);
                FinalPrice = Math.Round(FinalPrice - UniversalDiscountAmount, 2);



                FinalPrice = Math.Round(FinalPrice + TaxAmount, 2);
                TotalDiscountAmount = Math.Round(UniversalDiscountAmount + UPC_DiscountAmount, 2);

            }

            else if (IsUniversalDiscountBeforeTax ==false && IsUPC_DiscountBeforeTax==false)
            {

                TaxAmount = Math.Round(FinalPrice * (TaxRate / 100), 2);

                FinalPrice = Math.Round(product.Price, 2);

                UPC_DiscountAmount = (UPC_ForDiscount == product.UPC) ? Math.Round(FinalPrice * (UPC_DiscountRate / 100), 2) : 0;
                FinalPrice = Math.Round(FinalPrice - UPC_DiscountAmount, 2);

                UniversalDiscountAmount = Math.Round(FinalPrice * (UniversalDiscountRate / 100), 2);
                FinalPrice = Math.Round(FinalPrice - UniversalDiscountAmount, 2);

                FinalPrice = Math.Round(FinalPrice + TaxAmount, 2);
                TotalDiscountAmount = Math.Round(UniversalDiscountAmount + UPC_DiscountAmount, 2);


            }




            Report.DiscountedReport(FinalPrice, TotalDiscountAmount);

            return new Product
            (
                product.Name,
                product.UPC,
                FinalPrice
            );

        }


    }
}
