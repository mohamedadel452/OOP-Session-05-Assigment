using System;

namespace OOP05_SmartDelivery
{
    #region Abstract Partial Shipment Class - Core Members
    /// <summary>
    /// Abstract partial class representing the base Shipment.
    /// Contains core fields, properties, constructors, static members, and copy mechanisms.
    /// </summary>
    public abstract partial class Shipment 
    {
        
        #region Static Members
        // Static Field: Shared across all instances in the AppDomain / Type Object in Heap
        public static int TotalShipmentsCreated = 0;

        // Static Constructor: Executed exactly once by CLR before first instance or static access
        static Shipment()
        {
            TotalShipmentsCreated = 0;
            Console.WriteLine("Shipment System Initialized");
        }

        // Static Method: Called on the type itself without allocating an instance
        public static int GetTotalShipmentsCreated()
        {
            return TotalShipmentsCreated;
        }
        #endregion

        #region Fields & Properties
        private string trackingCode;
        private string description;
        private decimal weight; 
        private decimal deliveryFee;

        // Destination is a reference type (DeliveryAddress class)
        public DeliveryAddress Destination { get; set; }

        public string TrackingCode
        {
            get { return trackingCode; }
            private set { if (!string.IsNullOrWhiteSpace(value)) trackingCode = value; }
        }

        public string Description
        {
            get { return description; }
            set { if (!string.IsNullOrWhiteSpace(value)) description = value; }
        }

        public decimal Weight
        {
            get { return weight; }
            set { if (value > 0) weight = value; }
        }

        public decimal DeliveryFee
        {
            get { return deliveryFee; }
            private set { if (value > 0) deliveryFee = value; }
        }

        // Abstract Property: Must be implemented by all derived classes
        public abstract decimal EstimatedCost { get; }
        #endregion

        #region Constructors
        public Shipment(string trackingCode)
        {
            this.trackingCode = string.Empty;
            this.description = "Unknown";
            this.weight = 1m;
            this.deliveryFee = 50m;
            this.Destination = new DeliveryAddress("Unknown", "Unknown", 0);
            this.TrackingCode = trackingCode;

            // Increment the shared static counter upon instantiation
            TotalShipmentsCreated++;
        }

        public Shipment(string trackingCode, string description, decimal weight, decimal deliveryFee, DeliveryAddress destination)
        {
            this.trackingCode = string.Empty;
            this.description = "Unknown";
            this.weight = 1m;
            this.deliveryFee = 50m;
            this.Destination = destination;
            this.TrackingCode = trackingCode;
            this.Description = description;
            this.Weight = weight;
            this.DeliveryFee = deliveryFee;

            // Increment the shared static counter upon instantiation
            TotalShipmentsCreated++;
        }
        #endregion

        #region Object Copying (Shallow vs Deep Copy)
        /// <summary>
        /// General copy method returning a deep clone.
        /// </summary>
        public Shipment CopyShipment()
        {
            return DeepCopy();
        }

        /// <summary>
        /// Shallow Copy: Uses MemberwiseClone() to copy value types bit-by-bit,
        /// and copies memory references for reference types without duplicating the heap object.
        /// </summary>
        public Shipment ShallowCopy()
        {
            return (Shipment)this.MemberwiseClone();
        }

        /// <summary>
        /// Deep Copy: Uses MemberwiseClone() for value types and primitive fields,
        /// but explicitly allocates a brand new DeliveryAddress object on the Heap.
        /// </summary>
        public Shipment DeepCopy()
        {
            Shipment cloned = (Shipment)this.MemberwiseClone();
            if (this.Destination != null)
            {
                // Explicit new allocation on Heap: Independent memory reference
                cloned.Destination = new DeliveryAddress(this.Destination);
            }
            return cloned;
        }
        #endregion

        #region Business Methods
        public void UpdateDeliveryFee(decimal newFee)
        {
            if (newFee > 0) this.DeliveryFee = newFee;
        }

        public void UpdateWeight(decimal newWeight)
        {
            if (newWeight > 0) Weight = newWeight;
        }

        public void UpdateWeight(decimal newWeight, decimal extraPackingWeight)
        {
            if (newWeight > 0 && extraPackingWeight >= 0)
            {
                Weight = newWeight + extraPackingWeight;
            }
        }

        // Abstract Method: Polymorphic printing
        public abstract void PrintShipment();

        // Interface method implementation for IInsurable
        public abstract decimal CalculateInsurance();
        #endregion

        
    }
    #endregion
}
