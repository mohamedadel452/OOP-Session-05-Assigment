using System;

namespace OOP05_SmartDelivery
{
    #region ITrackable Interface
    /// <summary>
    /// Contract for trackable items across the system.
    /// Demonstrates Interface Polymorphism.
    /// </summary>
    public interface ITrackable
    {
        #region Methods
        string GetTrackingStatus();
        #endregion
    }
    #endregion
}
