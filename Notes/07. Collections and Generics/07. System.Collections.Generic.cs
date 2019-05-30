// System.Collections.Generic

// Interfaces: 

// ICollection<T> 
// Defines general characteristics (e.g., size, enumeration, and thread safety) for all generic collection types

// IComparer<T> 
// Defines a way to compare to objects

// IDictionary<TKey, TValue> 
// Allows a generic collection object to represent its contents using key-value pairs

// IEnumerable<T> 
// Returns the IEnumerator<T> interface for a given object

// IEnumerator<T> 
// Enables foreach-style iteration over a generic collection

// IList<T> 
// Provides behavior to add, remove, and index items in a sequential list of objects

// ISet<T> 
// Provides the base interface for the abstraction of sets

// --------------------------------------------------------------------------------------------------------------------------------

// Classes:

// 1. Dictionary<TKey, TValue>
// Interfaces: ICollection<T>, IDictionary<TKey, TValue>, IEnumerable<T>
// This represents a generic collection of keys and values.

// 2. LinkedList<T> 
// Interfaces: ICollection<T>, IEnumerable<T> 
// This represents a doubly linked list.

// 3. List<T> 
// Interfaces: ICollection<T>, IEnumerable<T>, IList<T>
// This is a dynamically resizable sequential list of items.

// 4. Queue<T> 
// Interfaces: ICollection (nongeneric), IEnumerable<T>
// This is a generic implementation of a first-in, first-out list.

// 5. SortedDictionary<TKey, TValue>
// Interfaces: ICollection<T>, IDictionary<TKey, TValue>, IEnumerable<T>
// This is a generic implementation of a sorted set of key-value pairs.

// 6. SortedSet<T> 
// Interfaces: ICollection<T>, IEnumerable<T>, ISet<T>
// This represents a collection of objects that is maintained in sorted order with no duplication.

// 7. Stack<T> 
// Interfaces: ICollection (nongeneric), IEnumerable<T>
// This is a generic implementation of a last-in, first-out list.

// --------------------------------------------------------------------------------------------------------------------------------
