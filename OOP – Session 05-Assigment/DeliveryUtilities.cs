using System;

namespace OOP05_SmartDelivery
{
    #region DeliveryUtilities Static Class
    /// <summary>
    /// Static utility class: Cannot be instantiated, sealed by compiler, contains only static members.
    /// Resides in the type object in memory and provides reusable console formatting methods.
    /// </summary>
    public static class DeliveryUtilities
    {
        #region Methods
        public static void PrintSeparator()
        {
            Console.WriteLine("==========================================");
        }

        public static void PrintSubSeparator()
        {
            Console.WriteLine("------------------------------------------");
        }

        public static void PrintSystemTitle(string title = "Delivery Center")
        {
            PrintSeparator();
            Console.WriteLine(title);
            PrintSeparator();
        }
        #endregion
    }
    #endregion
}
