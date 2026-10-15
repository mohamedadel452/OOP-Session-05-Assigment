

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
 
   
    */
    #endregion


    #region Main Program
    class Program
    {
        static void Main(string[] args)
        {
          
        }
    }
    #endregion
}