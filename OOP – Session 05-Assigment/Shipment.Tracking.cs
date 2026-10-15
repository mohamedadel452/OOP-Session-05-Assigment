using System;

namespace OOP05_SmartDelivery
{
    #region Abstract Partial Shipment Class - Tracking Members
    /// <summary>
    /// Partial class file for Shipment focusing on Tracking capabilities.
    /// Demonstrates separating concerns using partial classes across multiple files.
    /// </summary>
    public abstract partial class Shipment
    {
        #region Tracking Properties
        public string TrackingStatus { get; set; } = "In Transit";
        #endregion

        #region Partial Method Declaration
        /// <summary>
        /// Partial method declaration: If not implemented, the C# compiler removes all calls to it
        /// with zero runtime overhead. Here, it is implemented in Shipment.cs.
        /// </summary>
        partial void OnTrackingStatusChanged(string newStatus);
        #endregion

        #region Tracking Methods
        public virtual string GetTrackingStatus()
        {
            return $"Shipment {TrackingCode} is {TrackingStatus}.";
        }

        public void UpdateTrackingStatus(string newStatus)
        {
            TrackingStatus = newStatus;
            // Invokes the partial method
            OnTrackingStatusChanged(newStatus);
        }
        #endregion
    }
    #endregion
}
