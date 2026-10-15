

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