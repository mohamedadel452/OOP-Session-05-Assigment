using System;

namespace OOP05_SmartDelivery
{
    #region DeliveryReport Class
    public static class DeliveryReport
    {
        public static void PrintShipment(ITrackable shipment)
        {
            if (shipment != null)
            {
                Console.WriteLine(shipment.GetTrackingStatus());
            }
        }

        public static void PrintInsurance(IInsurable shipment)
        {
            if (shipment != null)
            {
                string name = shipment.GetType().Name.Replace("Shipment", " Shipment");
                Console.WriteLine($"{name} Insurance : {shipment.CalculateInsurance():0.00} EGP\n");
            }
        }
    }
    #endregion
}
