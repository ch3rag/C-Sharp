// System.Collections

// 1. ArrayList 
// Represents a dynamically sized collection of objects listed in sequential order.
// Interfaces: IList, ICollection, IEnumerable, and ICloneable

// 2. BitArray 
// Manages a compact array of bit values, which are represented as Booleans, where true indicates that the bit is on (1) and false indicates the bit is off (0)
// Interfaces: ICollection, IEnumerable, and ICloneable

// 3. Hashtable 
// Represents a collection of key-value pairs that are organized based on the hash code of the key
// Interfaces: IDictionary, ICollection, IEnumerable, and ICloneable

// 4. Queue 
// Represents a standard first-in, first-out (FIFO) collection of objects
// Interfaces: ICollection, IEnumerable, and ICloneable

// 5. SortedList 
// Represents a collection of key-value pairs that are sorted by the keys and are accessible by key and by index
// Interfaces: IDictionary, ICollection, IEnumerable, and ICloneable

// 6. Stack 
// A last-in, first-out (LIFO) stack providing push and pop (and peek) functionality
// Interfaces: ICollection, IEnumerable, and ICloneable

// -----------------------------------------------------------------------------------------------------

// Interface Information: 

// 1. ICollection 
// Defines general characteristics (e.g., size, enumeration, and thread safety) for all nongeneric collection types

// 2. ICloneable 
// Allows the implementing object to return a copy of itself to the caller

// 3. IDictionary 
// Allows a nongeneric collection object to represent its contents using key-value pairs

// 4. IEnumerable 
// Returns an object implementing the IEnumerator interface

// 5. IEnumerator 
// Enables foreach-style iteration of collection items 

// 6. IList 
// Provides behavior to add, remove, and index items in a sequential list of objects

// --------------------------------------------------------------------------------------------------------

// Sytem.Collections.Specialized

// HybridDictionary 
// This class implements IDictionary by using a ListDictionary while the collection is small and then switching to a Hashtable when the 
// collection gets large.

// ListDictionary 
// This class is useful when you need to manage a small number of items (ten or so) that can change over time. This class makes use of a 
// singly linked list to maintain its data.

// StringCollection 
// This class provides an optimal way to manage large collections of string data.

// BitVector32 
// This class provides a simple structure that stores Boolean values and small integers in 32 bits of memory.