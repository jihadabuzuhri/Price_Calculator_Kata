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







        public static Product CalculateAdditiveFinalPrice(Product product , double TaxRate, 
            double UniversalDiscountRate,bool IsUniversalDiscountBeforeTax,
            double UPC_DiscountRate, bool IsUPC_DiscountBeforeTax, int UPC_ForDiscount,
            Dictionary<string, double> AdditionalCosts,
             Dictionary<string, bool> IsAbsoluteValue,
             double CAP, bool IsCapAbsoluteValue)
        {


            if (IsUniversalDiscountBeforeTax&& IsUPC_DiscountBeforeTax)
            {

                FinalPrice = Math.Round(product.Price, 2);

                UPC_DiscountAmount = (UPC_ForDiscount == product.UPC) ? Math.Round(product.Price * (UPC_DiscountRate / 100), 2) : 0;
                FinalPrice = Math.Round(FinalPrice - UPC_DiscountAmount, 2);

                UniversalDiscountAmount = Math.Round(product.Price * (UniversalDiscountRate / 100), 2);
                FinalPrice = Math.Round(FinalPrice - UniversalDiscountAmount, 2);


                TaxAmount = Math.Round(FinalPrice * (TaxRate / 100), 2);

                FinalPrice = Math.Round(FinalPrice + TaxAmount, 2);





            }
            else if (IsUniversalDiscountBeforeTax && IsUPC_DiscountBeforeTax==false)
            {
                FinalPrice = Math.Round(product.Price, 2);

                UniversalDiscountAmount = Math.Round(product.Price * (UniversalDiscountRate / 100), 2);
                FinalPrice = Math.Round(FinalPrice - UniversalDiscountAmount, 2);

                TaxAmount = Math.Round(FinalPrice * (TaxRate / 100), 2);

                UPC_DiscountAmount = (UPC_ForDiscount == product.UPC) ? Math.Round(product.Price * (UPC_DiscountRate / 100), 2) : 0;

                FinalPrice = Math.Round(FinalPrice - UPC_DiscountAmount, 2);

                FinalPrice = Math.Round(FinalPrice + TaxAmount, 2);
                TotalDiscountAmount = Math.Round(UniversalDiscountAmount + UPC_DiscountAmount, 2);

            }
            else if (IsUniversalDiscountBeforeTax ==false && IsUPC_DiscountBeforeTax)
            {
                FinalPrice = Math.Round(product.Price, 2);

                UPC_DiscountAmount = (UPC_ForDiscount == product.UPC) ? Math.Round(product.Price * (UPC_DiscountRate / 100), 2) : 0;
                FinalPrice = Math.Round(FinalPrice - UPC_DiscountAmount, 2);

                TaxAmount = Math.Round(FinalPrice * (TaxRate / 100), 2);

                UniversalDiscountAmount = Math.Round(product.Price * (UniversalDiscountRate / 100), 2);
                FinalPrice = Math.Round(FinalPrice - UniversalDiscountAmount, 2);



                FinalPrice = Math.Round(FinalPrice + TaxAmount, 2);
                TotalDiscountAmount = Math.Round(UniversalDiscountAmount + UPC_DiscountAmount, 2);

            }
            else if (IsUniversalDiscountBeforeTax ==false && IsUPC_DiscountBeforeTax==false)
            {
                FinalPrice = Math.Round(product.Price, 2);

                TaxAmount = Math.Round(FinalPrice * (TaxRate / 100), 2);

                UPC_DiscountAmount = (UPC_ForDiscount == product.UPC) ? Math.Round(product.Price * (UPC_DiscountRate / 100), 2) : 0;
                FinalPrice = Math.Round(FinalPrice - UPC_DiscountAmount, 2);

                UniversalDiscountAmount = Math.Round(product.Price * (UniversalDiscountRate / 100), 2);
                FinalPrice = Math.Round(FinalPrice - UniversalDiscountAmount, 2);

                FinalPrice = Math.Round(FinalPrice + TaxAmount, 2);
                TotalDiscountAmount = Math.Round(UniversalDiscountAmount + UPC_DiscountAmount, 2);


            }


            FinalPrice = Math.Round(FinalPrice + TotalDiscountAmount, 2);



            PackagingAmount = (IsAbsoluteValue["packaging"]) ? Math.Round(AdditionalCosts["packaging"], 2) : Math.Round(product.Price * (AdditionalCosts["packaging"] / 100), 2) ;
            TransportAmount = (IsAbsoluteValue["transport"]) ? Math.Round(AdditionalCosts["transport"], 2) : Math.Round(product.Price * (AdditionalCosts["transport"] / 100), 2) ;
            AdministrativeAmount = (IsAbsoluteValue["administrative"]) ? Math.Round(AdditionalCosts["administrative"], 2) : Math.Round(product.Price * (AdditionalCosts["administrative"] / 100), 2);

            
            CapAmount = (IsCapAbsoluteValue) ? Math.Round(CAP, 2) : Math.Round(product.Price * (CAP / 100), 2);

            TotalDiscountAmount = (TotalDiscountAmount > CapAmount) ? Math.Round(CapAmount, 2) : Math.Round(TotalDiscountAmount, 2);

            

            FinalPrice = Math.Round(FinalPrice - TotalDiscountAmount + PackagingAmount + TransportAmount + AdministrativeAmount, 2);

            Report.PriceReport(product.Price, TaxAmount, TotalDiscountAmount, PackagingAmount, TransportAmount, AdministrativeAmount, FinalPrice);
   
            Console.WriteLine();
            Report.TotalDiscountedReport(TotalDiscountAmount);

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
             double CAP, bool IsCapAbsoluteValue)
        {


            if (IsUniversalDiscountBeforeTax && IsUPC_DiscountBeforeTax)
            {

                FinalPrice = Math.Round(product.Price, 2);

                UPC_DiscountAmount = (UPC_ForDiscount == product.UPC) ? Math.Round(FinalPrice * (UPC_DiscountRate / 100), 2) : 0;
                FinalPrice = Math.Round(FinalPrice - UPC_DiscountAmount, 2);

                UniversalDiscountAmount = Math.Round(FinalPrice * (UniversalDiscountRate / 100), 2);
                FinalPrice = Math.Round(FinalPrice - UniversalDiscountAmount, 2);


                TaxAmount = Math.Round(FinalPrice * (TaxRate / 100), 2);

                FinalPrice = Math.Round(FinalPrice + TaxAmount, 2);





            }
            else if (IsUniversalDiscountBeforeTax && IsUPC_DiscountBeforeTax == false)
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
            else if (IsUniversalDiscountBeforeTax == false && IsUPC_DiscountBeforeTax)
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
            else if (IsUniversalDiscountBeforeTax == false && IsUPC_DiscountBeforeTax == false)
            {
                FinalPrice = Math.Round(product.Price, 2);

                TaxAmount = Math.Round(FinalPrice * (TaxRate / 100), 2);

                UPC_DiscountAmount = (UPC_ForDiscount == product.UPC) ? Math.Round(FinalPrice * (UPC_DiscountRate / 100), 2) : 0;
                FinalPrice = Math.Round(FinalPrice - UPC_DiscountAmount, 2);

                UniversalDiscountAmount = Math.Round(FinalPrice * (UniversalDiscountRate / 100), 2);
                FinalPrice = Math.Round(FinalPrice - UniversalDiscountAmount, 2);

                FinalPrice = Math.Round(FinalPrice + TaxAmount, 2);
                TotalDiscountAmount = Math.Round(UniversalDiscountAmount + UPC_DiscountAmount, 2);


            }

            FinalPrice = Math.Round(FinalPrice + TotalDiscountAmount, 2);


            PackagingAmount = (IsAbsoluteValue["packaging"]) ? Math.Round(AdditionalCosts["packaging"], 2) : Math.Round(product.Price * (AdditionalCosts["packaging"] / 100), 2);
            TransportAmount = (IsAbsoluteValue["transport"]) ? Math.Round(AdditionalCosts["transport"], 2) : Math.Round(product.Price * (AdditionalCosts["transport"] / 100), 2);
            AdministrativeAmount = (IsAbsoluteValue["administrative"]) ? Math.Round(AdditionalCosts["administrative"], 2) : Math.Round(product.Price * (AdditionalCosts["administrative"] / 100), 2);

            CapAmount = (IsCapAbsoluteValue) ? Math.Round(CAP, 2) : Math.Round(product.Price * (CAP / 100), 2);

            TotalDiscountAmount = (TotalDiscountAmount > CapAmount) ? Math.Round(CapAmount, 2) : Math.Round(TotalDiscountAmount, 2);



            FinalPrice = Math.Round(FinalPrice - TotalDiscountAmount + PackagingAmount + TransportAmount + AdministrativeAmount, 2);

            Report.PriceReport(product.Price, TaxAmount, TotalDiscountAmount, PackagingAmount, TransportAmount, AdministrativeAmount, FinalPrice);

            Console.WriteLine();
            Report.TotalDiscountedReport(TotalDiscountAmount);

            return new Product
            (
                product.Name,
                product.UPC,
                FinalPrice
            );

        }


    }
}
