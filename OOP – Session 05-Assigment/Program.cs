

namespace OOP05_SmartDelivery
{

    #region PART 01: THEORETICAL QUESTIONS
    /*
    ========================================================================================================================
    Q1: Object Copying
    ------------------------------------------------------------------------------------------------------------------------
    a) What happens when you assign one object variable to another object variable?
       - Answer:
         In C#, reference-type variables (like classes) do not hold the actual object data; they store a pointer/reference 
         (memory address) that points to the object allocated on the Managed Heap.
         When you execute `Shipment shipment2 = shipment1;`, the value copied from `shipment1` to `shipment2` is merely 
         the 4-byte or 8-byte memory address on the Call Stack. No new object is allocated on the Heap.

    b) Does assigning one object to another create a new object? Explain.
       - Answer:
         No, it does NOT create a new object. Both variables (`shipment1` and `shipment2`) now reference the exact same 
         memory address on the Managed Heap. Any modification made through `shipment2` directly modifies the state of the 
         shared object and is immediately visible through `shipment1`. 
         `object.ReferenceEquals(shipment1, shipment2)` returns `true`.

    c) What is the difference between copying an object and copying its reference?
       - Answer:
         - Copying a Reference (Aliasing): Only duplicates the pointer address on the Stack. Both references point to one 
           shared instance on the Heap.
         - Copying an Object (Cloning): Allocates a brand new chunk of memory on the Managed Heap, creating an independent 
           instance with duplicated field values.

         Q2: Shallow Copy vs Deep Copy
     ------------------------------------------------------------------------------------------------------------------------
     a) What is a Shallow Copy?
        - Answer:
          A Shallow Copy duplicates the top-level object by allocating a new instance on the Heap and copying its fields 
          bit-by-bit (usually via `object.MemberwiseClone()`). Value-type fields are duplicated independently, but reference-type 
          fields only have their memory addresses copied. Thus, inner reference objects remain shared between the original and clone.

     b) What is a Deep Copy?
        - Answer:
          A Deep Copy duplicates the top-level object AND recursively duplicates all nested reference-type objects it points to. 
          The resulting copy has an entirely independent object graph on the Managed Heap with zero shared references.

     c) What happens to reference-type members when a Shallow Copy is created?
        - Answer:
          Their reference pointers are copied, meaning both the original object and the shallow-copied object point to 
          the exact same nested object in the Heap. Modifying a nested object via either copy affects both.

     d) What happens to reference-type members when a Deep Copy is created?
        - Answer:
          New instances are instantiated on the Heap for each reference-type member, and their data is copied over. 
          Modifying the nested object in the copy has zero impact on the original object.

     e) Give one situation where Deep Copy would be safer than Shallow Copy.
        - Answer:
          In financial, order-processing, or delivery systems where a shipment or customer record has an address or cart items. 
          If you duplicate an existing shipment to create a new delivery order, modifying the destination address on the new order 
          must NEVER mutate the historical delivery address of the original shipment.

     ========================================================================================================================
     Q3: Static Members
    ------------------------------------------------------------------------------------------------------------------------
    a) What is a static field, and how is it different from an instance field?
       - Answer:
         - Instance Field: Allocated inside every object instance on the Heap. Each object has its own separate copy.
         - Static Field: Belongs to the Type (Class) itself and is allocated once inside the High-Frequency Heap / Type Object. 
           It is shared across all instances in the AppDomain.

    b) What is a static method? Can a static method directly access instance members?
       - Answer:
         A static method is invoked on the class level without requiring an object instance (`ClassName.Method()`). 
         It CANNOT directly access instance fields or instance methods because it has no implicit `this` pointer pointing 
         to a specific object in memory.

    c) What is a static constructor, and when is it executed?
       - Answer:
         A parameterless constructor marked with `static`. It is executed automatically by the CLR exactly once: 
         before the first instance of the class is created or any static member is referenced. It cannot be called 
         manually, cannot take parameters, and cannot have access modifiers (`public`/`private`).

    d) What is a static class? Can you create an object from a static class?
       - Answer:
         A class declared with the `static` keyword. The compiler makes it `abstract` and `sealed` under the hood. 
         It can contain ONLY static members and static constructors. You CANNOT instantiate it (`new ClassName()` is a compile error).

    ========================================================================================================================
        Q4: Extension Methods
    ------------------------------------------------------------------------------------------------------------------------
    a) What is an Extension Method?
       - Answer:
         A static method that allows developers to "add" new methods to existing types without modifying the original source code, 
         recompiling, or creating a derived type. It is invoked syntactically as if it were an instance method on the target object.

    b) What keyword must be used in the first parameter of an extension method?
       - Answer:
         The `this` keyword (e.g., `public static string GetSummary(this Shipment shipment)`).

    c) Where must an extension method be declared?
       - Answer:
         Inside a top-level, non-nested, non-generic `static class`.

    d) Can an extension method access private members of the class it extends?
       - Answer:
         No. An extension method is syntactic sugar for a static method call. It obeys standard encapsulation rules and 
         can only access public and internal members (if in the same assembly) of the extended class.

    ========================================================================================================================

        Q5: Partial Classes and Partial Methods
    ------------------------------------------------------------------------------------------------------------------------
    a) What is a Partial Class?
       - Answer:
         A class whose definition can be split across multiple `.cs` source files using the `partial` keyword. 
         The C# compiler merges all parts into a single unified class in the final metadata/CIL assembly.

    b) Why would a developer split one class into multiple files?
       - Answer:
         1. Separation of Concerns: Dividing large classes into functional areas (e.g., `Shipment.cs` for data and `Shipment.Tracking.cs` for tracking).
         2. Source Code Generators / Tools: Code-generation tools (like EF Core, WPF, or WinForms) can generate one part while developers edit another without conflicts.
         3. Team Collaboration: Allowing multiple developers to work on different aspects of a class without merge conflicts.

    c) What is a Partial Method?
       - Answer:
         A method declared in one part of a partial class and optionally implemented in another part. It must return `void`, 
         cannot be `virtual`, `abstract`, or `sealed`, and cannot have `out` parameters.

    d) What happens if a declared partial method has no implementation?
       - Answer:
         The C# compiler completely strips out the method declaration and all calls to it from the compiled assembly. 
         It leaves ZERO runtime overhead and zero IL instructions.
    ========================================================================================================================

  
    */
    #endregion


    #region Main Program
    class Program
    {
        static void Main(string[] args)
        {

            #region Title & Static Initialization
            // 7. Static Utilities: Print system title
            DeliveryUtilities.PrintSystemTitle("Smart Delivery Management System");

            // 5. Static Constructor Trigger:
            // Accessing any static member of Shipment ensures the CLR runs the static constructor
            // which prints "Shipment System Initialized" exactly once.
            _ = Shipment.TotalShipmentsCreated;
            #endregion

            #region Creating Shipments & Static Counter
            DeliveryUtilities.PrintSeparator();
            Console.WriteLine("Creating Shipments...");
            DeliveryUtilities.PrintSeparator();

            // a. Create one StandardShipment
            DeliveryAddress addr1 = new DeliveryAddress("Cairo", "Tahrir", 1);
            StandardShipment std = new StandardShipment("SH001", "Laptop", 3m, 80m, addr1);
            Console.WriteLine("Standard Shipment Created");

            // b. Create one ExpressShipment
            DeliveryAddress addr2 = new DeliveryAddress("Giza", "Dokki", 10);
            ExpressShipment exp = new ExpressShipment("SH002", "Mobile Phone", 2m, 60m, addr2, 30m);
            Console.WriteLine("Express Shipment Created");

            // c. Create one InternationalShipment
            DeliveryAddress addr3 = new DeliveryAddress("Alex", "Corniche", 50);
            InternationalShipment intl = new InternationalShipment("SH003", "Television", 8m, 120m, addr3, "Germany", 100m);
            Console.WriteLine("International Shipment Created");

            // 6. Static Method: GetTotalShipmentsCreated
            Console.WriteLine($"Total Shipments Created : {Shipment.GetTotalShipmentsCreated()}");
            #endregion

            #region Object Copying: Reference Assignment vs Clones
            DeliveryUtilities.PrintSeparator();
            Console.WriteLine("Object Copying");
            DeliveryUtilities.PrintSeparator();

            // 1. Reference Assignment: Aliasing the pointer
            Shipment assignedShipment = std;
            Console.WriteLine($"Original Shipment  : {std.TrackingCode}");
            Console.WriteLine($"Assigned Shipment  : {assignedShipment.TrackingCode}");
            Console.WriteLine($"Same Object : {object.ReferenceEquals(std, assignedShipment)}");

            // 2. Shallow Copy Demonstration
            DeliveryUtilities.PrintSubSeparator();
            Console.WriteLine("Shallow Copy");
            DeliveryUtilities.PrintSubSeparator();

            Shipment shallowCopied = std.ShallowCopy();
            Console.WriteLine($"Original Shipment Address : {std.Destination.City}");
            Console.WriteLine($"Copied Shipment Address   : {shallowCopied.Destination.City}");

            Console.WriteLine("Changing copied shipment address...");
            shallowCopied.Destination.City = "Giza";

            Console.WriteLine($"Original Shipment Address : {std.Destination.City}");
            Console.WriteLine($"Copied Shipment Address   : {shallowCopied.Destination.City}");
            Console.WriteLine($"Same DeliveryAddress Object : {object.ReferenceEquals(std.Destination, shallowCopied.Destination)}");

            // 3. Deep Copy Demonstration
            DeliveryUtilities.PrintSubSeparator();
            Console.WriteLine("Deep Copy");
            DeliveryUtilities.PrintSubSeparator();

            // Reset address back to Cairo
            std.Destination.City = "Cairo";
            Shipment deepCopied = std.DeepCopy();
            Console.WriteLine($"Original Shipment Address : {std.Destination.City}");
            Console.WriteLine($"Copied Shipment Address   : {deepCopied.Destination.City}");

            Console.WriteLine("Changing copied shipment address...");
            deepCopied.Destination.City = "Giza";

            Console.WriteLine($"Original Shipment Address : {std.Destination.City}");
            Console.WriteLine($"Copied Shipment Address   : {deepCopied.Destination.City}");
            Console.WriteLine($"Same DeliveryAddress Object : {object.ReferenceEquals(std.Destination, deepCopied.Destination)}");
            #endregion

            #region Extension Methods Demonstration
            DeliveryUtilities.PrintSeparator();
            Console.WriteLine("Extension Methods");
            DeliveryUtilities.PrintSeparator();

            // 8. Extension Methods: GetSummary() and IsDelivered()
            Console.WriteLine(std.GetSummary());
            Console.WriteLine(exp.GetSummary());
            Console.WriteLine(intl.GetSummary());

            Console.WriteLine($"SH001 Is Delivered : {std.IsDelivered()}");
            Console.WriteLine($"SH003 Is Delivered : {intl.IsDelivered()}");
            #endregion

            #region Tracking Status & Partial Method Demonstration
            DeliveryUtilities.PrintSeparator();
            Console.WriteLine("Tracking Status");
            DeliveryUtilities.PrintSeparator();

            // 9 & 10. Partial Method Triggered via UpdateTrackingStatus
            std.UpdateTrackingStatus("Out For Delivery");
            #endregion

            #region Static Utilities Demonstration
            DeliveryUtilities.PrintSeparator();
            Console.WriteLine("Static Utilities");
            DeliveryUtilities.PrintSeparator();
            DeliveryUtilities.PrintSubSeparator();
            Console.WriteLine("Delivery Center");
            DeliveryUtilities.PrintSubSeparator();
            Console.WriteLine($"Total Shipments Created : {Shipment.GetTotalShipmentsCreated()}");
            #endregion

            #region Partial Method Further Demonstration
            DeliveryUtilities.PrintSeparator();
            Console.WriteLine("Partial Method");
            DeliveryUtilities.PrintSeparator();
            intl.UpdateTrackingStatus("Delivered");
            #endregion

            #region Assignment Completion
            DeliveryUtilities.PrintSeparator();
            Console.WriteLine("Assignment Completed");
            DeliveryUtilities.PrintSeparator();
            #endregion

        }
    }
    #endregion
}