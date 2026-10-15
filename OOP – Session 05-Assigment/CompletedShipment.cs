using System;

namespace OOP05_SmartDelivery
{
    #region CompletedShipment Class (Sealed Class)
    /// <summary>
    /// Sealed Class: Cannot be inherited by any other class.
    /// Represents final state of a completed shipment.
    /// </summary>
    public sealed class CompletedShipment : Shipment
    {
        public CompletedShipment(string trackingCode) : base(trackingCode) 
        {
            TrackingStatus = "Completed";
        }

        public override decimal EstimatedCost => DeliveryFee + (Weight * 5m);

        public override void PrintShipment()
        {
            Console.WriteLine($"Completed Shipment: {TrackingCode}");
        }

        public override string GetTrackingStatus() => "Completed.";
        public override decimal CalculateInsurance() => 0;
    }
    #endregion
}
