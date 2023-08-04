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
        public static double PackagingAmount { get; set; }
        public static double TransportAmount { get; set; }
        public static double AdministrativeAmount { get; set; }
        public static double CapAmount { get; set; }

        public static string Currency { get; set; }






        public static Product CalculateAdditiveFinalPrice(Product product , double TaxRate, 
            double UniversalDiscountRate,bool IsUniversalDiscountBeforeTax,
            double UPC_DiscountRate, bool IsUPC_DiscountBeforeTax, int UPC_ForDiscount,
            Dictionary<string, double> AdditionalCosts,
             Dictionary<string, bool> IsAbsoluteValue,
             double CAP, bool IsCapAbsoluteValue, string Currency)
        {


            if (IsUniversalDiscountBeforeTax&& IsUPC_DiscountBeforeTax)
            {

                FinalPrice =Round(product.Price);

                UPC_DiscountAmount = (UPC_ForDiscount == product.UPC) ?Round(product.Price * (UPC_DiscountRate / 100)) : 0;
                FinalPrice =Round(FinalPrice - UPC_DiscountAmount);

                UniversalDiscountAmount =Round(product.Price * (UniversalDiscountRate / 100));
                FinalPrice =Round(FinalPrice - UniversalDiscountAmount);


                TaxAmount =Round(FinalPrice * (TaxRate / 100));

                FinalPrice =Round(FinalPrice + TaxAmount);





            }
            else if (IsUniversalDiscountBeforeTax && IsUPC_DiscountBeforeTax==false)
            {
                FinalPrice =Round(product.Price);

                UniversalDiscountAmount =Round(product.Price * (UniversalDiscountRate / 100));
                FinalPrice =Round(FinalPrice - UniversalDiscountAmount);

                TaxAmount =Round(FinalPrice * (TaxRate / 100));

                UPC_DiscountAmount = (UPC_ForDiscount == product.UPC) ?Round(product.Price * (UPC_DiscountRate / 100)) : 0;

                FinalPrice =Round(FinalPrice - UPC_DiscountAmount);

                FinalPrice =Round(FinalPrice + TaxAmount);
                TotalDiscountAmount =Round(UniversalDiscountAmount + UPC_DiscountAmount);

            }
            else if (IsUniversalDiscountBeforeTax ==false && IsUPC_DiscountBeforeTax)
            {
                FinalPrice =Round(product.Price);

                UPC_DiscountAmount = (UPC_ForDiscount == product.UPC) ?Round(product.Price * (UPC_DiscountRate / 100)) : 0;
                FinalPrice =Round(FinalPrice - UPC_DiscountAmount);

                TaxAmount =Round(FinalPrice * (TaxRate / 100));

                UniversalDiscountAmount =Round(product.Price * (UniversalDiscountRate / 100));
                FinalPrice =Round(FinalPrice - UniversalDiscountAmount);



                FinalPrice =Round(FinalPrice + TaxAmount);
                TotalDiscountAmount =Round(UniversalDiscountAmount + UPC_DiscountAmount);

            }
            else if (IsUniversalDiscountBeforeTax ==false && IsUPC_DiscountBeforeTax==false)
            {
                FinalPrice =Round(product.Price);

                TaxAmount =Round(FinalPrice * (TaxRate / 100));

                UPC_DiscountAmount = (UPC_ForDiscount == product.UPC) ?Round(product.Price * (UPC_DiscountRate / 100)) : 0;
                FinalPrice =Round(FinalPrice - UPC_DiscountAmount);

                UniversalDiscountAmount =Round(product.Price * (UniversalDiscountRate / 100));
                FinalPrice =Round(FinalPrice - UniversalDiscountAmount);

                FinalPrice =Round(FinalPrice + TaxAmount);
                TotalDiscountAmount =Round(UniversalDiscountAmount + UPC_DiscountAmount);


            }


            FinalPrice =Round(FinalPrice + TotalDiscountAmount);



            PackagingAmount = (IsAbsoluteValue["packaging"]) ?Round(AdditionalCosts["packaging"]) :Round(product.Price * (AdditionalCosts["packaging"] / 100)) ;
            TransportAmount = (IsAbsoluteValue["transport"]) ?Round(AdditionalCosts["transport"]) :Round(product.Price * (AdditionalCosts["transport"] / 100)) ;
            AdministrativeAmount = (IsAbsoluteValue["administrative"]) ?Round(AdditionalCosts["administrative"]) :Round(product.Price * (AdditionalCosts["administrative"] / 100));

            
            CapAmount = (IsCapAbsoluteValue) ?Round(CAP) :Round(product.Price * (CAP / 100));

            TotalDiscountAmount = (TotalDiscountAmount > CapAmount) ?Round(CapAmount) :Round(TotalDiscountAmount);

            

            FinalPrice =Round(FinalPrice - TotalDiscountAmount + PackagingAmount + TransportAmount + AdministrativeAmount);

            Report.PriceReport(product.Price, TaxAmount, TotalDiscountAmount, PackagingAmount, TransportAmount, AdministrativeAmount, FinalPrice, Currency);
   
            Console.WriteLine();
            Report.TotalDiscountedReport(TotalDiscountAmount, Currency);

            return new Product
            (
                product.Name,
                product.UPC,
                FinalPrice
            );

        }



        public static Product CalculateMultiplicativeFinalPrice(Product product, double TaxRate,
            double UniversalDiscountRate, bool IsUniversalDiscountBeforeTax,
            double UPC_DiscountRate, bool IsUPC_DiscountBeforeTax, int UPC_ForDiscount,
            Dictionary<string, double> AdditionalCosts,
             Dictionary<string, bool> IsAbsoluteValue,
             double CAP, bool IsCapAbsoluteValue, string Currency)
        {


            if (IsUniversalDiscountBeforeTax && IsUPC_DiscountBeforeTax)
            {

                FinalPrice =Round(product.Price);

                UPC_DiscountAmount = (UPC_ForDiscount == product.UPC) ?Round(FinalPrice * (UPC_DiscountRate / 100)) : 0;
                FinalPrice =Round(FinalPrice - UPC_DiscountAmount);

                UniversalDiscountAmount =Round(FinalPrice * (UniversalDiscountRate / 100));
                FinalPrice =Round(FinalPrice - UniversalDiscountAmount);


                TaxAmount =Round(FinalPrice * (TaxRate / 100));

                FinalPrice = Round(FinalPrice + TaxAmount);





            }
            else if (IsUniversalDiscountBeforeTax && IsUPC_DiscountBeforeTax == false)
            {
                FinalPrice =Round(product.Price);

                UniversalDiscountAmount =Round(FinalPrice * (UniversalDiscountRate / 100));
                FinalPrice =Round(FinalPrice - UniversalDiscountAmount);

                TaxAmount =Round(FinalPrice * (TaxRate / 100));

                UPC_DiscountAmount = (UPC_ForDiscount == product.UPC) ?Round(FinalPrice * (UPC_DiscountRate / 100)) : 0;

                FinalPrice =Round(FinalPrice - UPC_DiscountAmount);

                FinalPrice =Round(FinalPrice + TaxAmount);
                TotalDiscountAmount =Round(UniversalDiscountAmount + UPC_DiscountAmount);

            }
            else if (IsUniversalDiscountBeforeTax == false && IsUPC_DiscountBeforeTax)
            {
                FinalPrice =Round(product.Price);

                UPC_DiscountAmount = (UPC_ForDiscount == product.UPC) ?Round(FinalPrice * (UPC_DiscountRate / 100)) : 0;
                FinalPrice =Round(FinalPrice - UPC_DiscountAmount);

                TaxAmount =Round(FinalPrice * (TaxRate / 100));

                UniversalDiscountAmount =Round(FinalPrice * (UniversalDiscountRate / 100));
                FinalPrice =Round(FinalPrice - UniversalDiscountAmount);



                FinalPrice =Round(FinalPrice + TaxAmount);
                TotalDiscountAmount =Round(UniversalDiscountAmount + UPC_DiscountAmount);

            }
            else if (IsUniversalDiscountBeforeTax == false && IsUPC_DiscountBeforeTax == false)
            {
                FinalPrice =Round(product.Price);

                TaxAmount =Round(FinalPrice * (TaxRate / 100));

                UPC_DiscountAmount = (UPC_ForDiscount == product.UPC) ?Round(FinalPrice * (UPC_DiscountRate / 100)) : 0;
                FinalPrice =Round(FinalPrice - UPC_DiscountAmount);

                UniversalDiscountAmount =Round(FinalPrice * (UniversalDiscountRate / 100));
                FinalPrice =Round(FinalPrice - UniversalDiscountAmount);

                FinalPrice =Round(FinalPrice + TaxAmount);
                TotalDiscountAmount =Round(UniversalDiscountAmount + UPC_DiscountAmount);


            }

            FinalPrice = Round(FinalPrice + TotalDiscountAmount);


            PackagingAmount = (IsAbsoluteValue["packaging"]) ? Round(AdditionalCosts["packaging"]) : Round(product.Price * (AdditionalCosts["packaging"] / 100));
            TransportAmount = (IsAbsoluteValue["transport"]) ? Round(AdditionalCosts["transport"]) : Round(product.Price * (AdditionalCosts["transport"] / 100));
            AdministrativeAmount = (IsAbsoluteValue["administrative"]) ? Round(AdditionalCosts["administrative"]) : Round(product.Price * (AdditionalCosts["administrative"] / 100));

            CapAmount = (IsCapAbsoluteValue) ? Round(CAP) : Round(product.Price * (CAP / 100));

            TotalDiscountAmount = (TotalDiscountAmount > CapAmount) ? Round(CapAmount) : Round(TotalDiscountAmount);



            FinalPrice = Round(FinalPrice - TotalDiscountAmount + PackagingAmount + TransportAmount + AdministrativeAmount);

            Report.PriceReport(product.Price, TaxAmount, TotalDiscountAmount, PackagingAmount, TransportAmount, AdministrativeAmount, FinalPrice,Currency);

            Console.WriteLine();
            Report.TotalDiscountedReport(TotalDiscountAmount, Currency);

            return new Product
            (
                product.Name,
                product.UPC,
                FinalPrice
            );

        }

        public static double Round(double number)
        {
            return Math.Round(number, 4);
        }


    }
}
