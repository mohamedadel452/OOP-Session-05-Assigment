using System;

namespace OOP05_SmartDelivery
{
    #region DeliveryAddress Class
    /// <summary>
    /// DeliveryAddress represents the destination of a shipment.
    /// Notice: Converted to a class (Reference Type) to demonstrate Reference Equality,
    /// Memory sharing on the Managed Heap in Shallow Copy, and independent Allocation in Deep Copy.
    /// </summary>
    public class DeliveryAddress
    {
        #region Fields & Properties
        public string City { get; set; } = string.Empty;
        public string Street { get; set; } = string.Empty;
        public int BuildingNumber { get; set; }
        #endregion

        #region Constructors
        public DeliveryAddress(string city, string street, int buildingNumber)
        {
            City = city;
            Street = street;
            BuildingNumber = buildingNumber;
        }

        // Copy Constructor for Deep Copying
        public DeliveryAddress(DeliveryAddress other)
        {
            if (other != null)
            {
                City = other.City;
                Street = other.Street;
                BuildingNumber = other.BuildingNumber;
            }
        }
        #endregion

        #region Methods
        public string GetFullAddress()
        {
            return $"{BuildingNumber} {Street}, {City}";
        }
        #endregion
    }
    #endregion
}
