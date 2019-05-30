// System.Collections.ArrayList

using System;
using System.Collections;

namespace Experiment {
    public class Program {
        public static void Main(string[] args) {
            ArrayList myList = new ArrayList();

            // Add(object o)
            myList.Add("Hello");
            myList.Add("World");
            myList.Add("!");

            // AddRange(ICollection collection)
            myList.AddRange(new string[] {"Welcome", "To", "C#" });

            // since Array list is-a Enumerable type
            foreach(string s in myList) {
                Console.Write(s);
                Console.Write(" ");
            }
            Console.WriteLine();

            // shallow copy
            // sice ArrayList is-a IClonable Type
            ArrayList copy = (ArrayList)myList.Clone();

            // Clear()
            myList.Clear();

            // Contains(object o)
            Console.WriteLine(copy.Contains("Hello"));      // TRUE

            // IndexOf(object o)
            // IndexOf(object o, int start)              
            // IndexOf(object o, int start, int howMany)
            Console.WriteLine(copy.IndexOf("!"));           // 2

            // LastIndexOf(object o)
            // LastIndexOf(object o, int start)              
            // LastIndexOf(object o, int start, int howMany)
            Console.WriteLine(copy.LastIndexOf("!"));       // 2

            // Insert(int index, object o)
            copy.Insert(2, "abc");
         
            // Remove(object o)
            copy.Remove("Hello");

            // RemoveAt(int index)
            copy.RemoveAt(3);

            // Reverse()
            // Reverse(int start, int howMany)
            copy.Reverse();
            copy.Reverse(1, 3);

            // Sort
            // Sort(IComparer comparer)
            // Sort(int start, int howMany, IComparer comparer)
            copy.Sort();

            // CopyTo(Array arr)
            // CopyTo(Array arr, int startIndexOfArray)
            // CopyTo(int startIndexOfArrayList, Array arr, int startIndexOfArray, int howMany);
            string[] stringArr = new string[copy.Count + 3];
            copy.CopyTo(stringArr, 3);

            // ToArray()        NOTE: L.H.S type must be object[]
            // ToArray(Type t)
            string[] strArray = (string[]) copy.ToArray("".GetType());
            object[] objArray = copy.ToArray();
            
            foreach (string s in copy) {
                Console.Write(s);
                Console.Write(" ");
            }
            Console.WriteLine();

            // PROPERTIES

            // Count
            Console.WriteLine(copy.Count);

            // Capacity
            Console.WriteLine(copy.Capacity);

            // Indexer
            Console.WriteLine(copy[2]);

            Console.ReadKey();

        }
    }
}