using System;

namespace OOP05_SmartDelivery
{
    #region IInsurable Interface
    /// <summary>
    /// Contract for insurable shipments across the system.
    /// Demonstrates Interface Polymorphism.
    /// </summary>
    public interface IInsurable
    {
        #region Methods
        decimal CalculateInsurance();
        #endregion
    }
    #endregion
}
