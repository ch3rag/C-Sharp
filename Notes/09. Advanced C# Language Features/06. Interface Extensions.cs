// Interface Extension Methods

// It is also possible to define an extension method that can only extend a class or structure that implements the correct interface. 
// For example, you could say something to the effect of “If a class or structure implements IEnumerable<T>, then that type gets the 
// following new members.” 

using System;
using System.Reflection;

namespace Experiment {

    static class AnnoyingExtensions {
        public static void PrintDataAndBeep(this System.Collections.IEnumerable iterator) {
            foreach (var item in iterator) {
                Console.WriteLine(item);
                Console.Beep();
            }
        }
    }
    
    public class Program {
        public static void Main(string[] args) {

            string[] cars = { "BMW", "Bugatti", "Lamborghini", "Mercedes", "Audi", };
            cars.PrintDataAndBeep();

            System.Collections.Generic.List<int> ints = new System.Collections.Generic.List<int>() {
                1, 2, 3, 4, 5, 6
            };

            ints.PrintDataAndBeep();

            Console.ReadKey();
        }
    } 
}