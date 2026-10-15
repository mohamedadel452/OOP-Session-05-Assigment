using System;

namespace OOP05_SmartDelivery
{
    #region InternationalShipment Class
    public class InternationalShipment : Shipment
    {
        #region Fields & Properties
        private string destinationCountry = string.Empty;
        private decimal customsFee;

        public string DestinationCountry
        {
            get { return destinationCountry; }
            set { if (!string.IsNullOrWhiteSpace(value)) destinationCountry = value; }
        }

        public decimal CustomsFee
        {
            get { return customsFee; }
            set { if (value >= 0) customsFee = value; }
        }

        public override decimal EstimatedCost
        {
            get { return DeliveryFee + (Weight * 5m) + CustomsFee; }
        }
        #endregion

        #region Constructors
        public InternationalShipment(string trackingCode, string description, decimal weight, decimal deliveryFee, DeliveryAddress destination, string destinationCountry, decimal customsFee)
            : base(trackingCode, description, weight, deliveryFee, destination)
        {
            DestinationCountry = destinationCountry;
            CustomsFee = customsFee;
            TrackingStatus = "Delivered";
        }
        #endregion

        #region Methods
        public virtual void GenerateCustomsReport()
        {
            Console.WriteLine($"Customs Report for {TrackingCode} to {DestinationCountry}. Fee: {CustomsFee}");
        }

        public override void PrintShipment()
        {
            Console.WriteLine("International Shipment\n");
            Console.WriteLine($"Tracking Code        : {TrackingCode}");
            Console.WriteLine($"Destination Country  : {DestinationCountry}");
            Console.WriteLine($"Estimated Cost       : {EstimatedCost} EGP");
            Console.WriteLine("\n==========================================\n");
        }

        public override decimal CalculateInsurance()
        {
            return EstimatedCost * 0.12m;
        }

        public override string GetTrackingStatus()
        {
            return $"Shipment {TrackingCode} has been {TrackingStatus}.";
        }
        #endregion
    }
    #endregion
}
