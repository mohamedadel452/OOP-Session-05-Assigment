using System;

namespace OOP05_SmartDelivery
{
    #region ExpressShipment Class
    public class ExpressShipment : Shipment
    {
        #region Fields & Properties
        private decimal extraFee;
        public decimal ExtraFee
        {
            get { return extraFee; }
            set { if (value >= 0) extraFee = value; }
        }

        public override decimal EstimatedCost
        {
            get { return DeliveryFee + (Weight * 5m) + ExtraFee; }
        }
        #endregion

        #region Constructors
        public ExpressShipment(string trackingCode, string description, decimal weight, decimal deliveryFee, DeliveryAddress destination, decimal extraFee)
            : base(trackingCode, description, weight, deliveryFee, destination)
        {
            ExtraFee = extraFee;
            TrackingStatus = "Out For Delivery";
        }
        #endregion

        #region Methods
        public override void PrintShipment()
        {
            Console.WriteLine("Express Shipment\n");
            Console.WriteLine($"Tracking Code : {TrackingCode}");
            Console.WriteLine($"Extra Fee     : {ExtraFee} EGP");
            Console.WriteLine($"Estimated Cost: {EstimatedCost} EGP");
            Console.WriteLine("\n------------------------------------------\n");
        }

        public override decimal CalculateInsurance()
        {
            return EstimatedCost * 0.08m;
        }

        public override string GetTrackingStatus()
        {
            return $"Shipment {TrackingCode} is {TrackingStatus}.";
        }
        #endregion
    }
    #endregion
}
