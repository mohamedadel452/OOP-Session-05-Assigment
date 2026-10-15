using System;

namespace OOP05_SmartDelivery
{
    #region DeliveryCenter Class
    public class DeliveryCenter
    {
        #region Fields & Properties
        public string CenterName { get; set; } = string.Empty;
        public Driver? CenterDriver { get; set; } 

        private Shipment?[] shipments = new Shipment?[20];
        #endregion

        #region Constructors
        public DeliveryCenter(string centerName) 
        { 
            CenterName = centerName; 
        }
        #endregion

        #region Indexers
        public Shipment? this[int index]
        {
            get
            {
                if (index >= 0 && index < shipments.Length) return shipments[index];
                return null;
            }
            set
            {
                if (index >= 0 && index < shipments.Length) shipments[index] = value;
            }
        }

        public Shipment? this[string trackingCode]
        {
            get
            {
                for (int i = 0; i < shipments.Length; i++)
                {
                    if (shipments[i] != null && shipments[i]!.TrackingCode == trackingCode) return shipments[i];
                }
                return null;
            }
        }
        #endregion

        #region Methods
        public bool AddShipment(Shipment shipment)
        {
            if (shipment == null) return false;
            for (int i = 0; i < shipments.Length; i++)
            {
                if (shipments[i] == null)
                {
                    shipments[i] = shipment;
                    return true;
                }
            }
            return false;
        }

        public bool RemoveShipment(string trackingCode)
        {
            for (int i = 0; i < shipments.Length; i++)
            {
                if (shipments[i] != null && shipments[i]!.TrackingCode == trackingCode)
                {
                    shipments[i] = null;
                    return true;
                }
            }
            return false;
        }

        public void PrintAllShipments()
        {
            DeliveryUtilities.PrintSeparator();
            Console.WriteLine(CenterName);
            DeliveryUtilities.PrintSeparator();
            Console.WriteLine();
            
            if (CenterDriver != null)
                Console.WriteLine($"Driver : {CenterDriver.Name}\n");

            foreach (var ship in shipments)
            {
                if (ship != null) ship.PrintShipment();
            }
        }

        public void PrintTrackingStatuses()
        {
            foreach (var ship in shipments)
            {
                if (ship != null)
                {
                    Console.WriteLine(ship.GetTrackingStatus() + "\n");
                }
            }
        }
        #endregion
    }
    #endregion
}
