using System;

namespace OOP05_SmartDelivery
{
    #region PriorityInternationalShipment Class (Sealed Method)
    public class PriorityInternationalShipment : InternationalShipment
    {
        public PriorityInternationalShipment(string trackingCode, string description, decimal weight, decimal deliveryFee, DeliveryAddress destination, string destinationCountry, decimal customsFee)
            : base(trackingCode, description, weight, deliveryFee, destination, destinationCountry, customsFee) { }

        /// <summary>
        /// Sealed Method: Prevents derived classes from overriding this method further.
        /// </summary>
        public sealed override void GenerateCustomsReport()
        {
            Console.WriteLine($"[URGENT] Priority Customs Report for {TrackingCode}.");
        }
    }
    #endregion
}
