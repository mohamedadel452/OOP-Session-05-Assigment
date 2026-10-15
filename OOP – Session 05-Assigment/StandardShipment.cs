using System;

namespace OOP05_SmartDelivery
{
    #region StandardShipment Class
    public class StandardShipment : Shipment
    {
        #region Constructors
        public StandardShipment(string trackingCode, string description, decimal weight, decimal deliveryFee, DeliveryAddress destination)
            : base(trackingCode, description, weight, deliveryFee, destination)
        {
            TrackingStatus = "In Transit";
        }
        #endregion

        #region Properties
        public override decimal EstimatedCost
        {
            get { return DeliveryFee + (Weight * 5m); }
        }
        #endregion

        #region Methods
        public override void PrintShipment()
        {
            Console.WriteLine("Standard Shipment\n");
            Console.WriteLine($"Tracking Code : {TrackingCode}");
            Console.WriteLine($"Description   : {Description}");
            Console.WriteLine($"Estimated Cost: {EstimatedCost} EGP");
            Console.WriteLine("\n------------------------------------------\n");
        }

        public override decimal CalculateInsurance()
        {
            return EstimatedCost * 0.05m;
        }

        public override string GetTrackingStatus()
        {
            return $"Shipment {TrackingCode} is {TrackingStatus}.";
        }
        #endregion
    }
    #endregion
}
