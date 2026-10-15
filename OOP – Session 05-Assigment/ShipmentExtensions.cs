using System;

namespace OOP05_SmartDelivery
{
    #region ShipmentExtensions Static Class
    /// <summary>
    /// Static class providing Extension Methods for Shipment.
    /// Extension methods enable adding new behaviors to existing types without modifying the original source code or inheriting.
    /// Uses 'this' keyword on the first parameter.
    /// </summary>
    public static class ShipmentExtensions
    {
        #region Methods
        /// <summary>
        /// Returns a formatted summary string: Tracking Code | Shipment Type | Weight KG | Tracking Status
        /// Example: SH001 | Standard | 3 KG | In Transit
        /// </summary>
        public static string GetSummary(this Shipment shipment)
        {
            if (shipment == null) return string.Empty;
            
            // Extract the core type name (e.g. "Standard" from "StandardShipment")
            string typeName = shipment.GetType().Name.Replace("Shipment", "");
            
            return $"{shipment.TrackingCode} | {typeName} | {shipment.Weight} KG | {shipment.TrackingStatus}";
        }

        /// <summary>
        /// Checks if the shipment is delivered.
        /// Returns true only when the tracking status equals "Delivered" (case-insensitive).
        /// </summary>
        public static bool IsDelivered(this Shipment shipment)
        {
            if (shipment == null) return false;
            return string.Equals(shipment.TrackingStatus, "Delivered", StringComparison.OrdinalIgnoreCase);
        }
        #endregion
    }
    #endregion
}
