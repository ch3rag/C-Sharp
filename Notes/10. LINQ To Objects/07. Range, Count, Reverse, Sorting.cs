// LINQ Query Operators



using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

namespace Experiment {

    public class Program {
        public static void Main(string[] args) {

            // 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 
            // EXCLUSIVE
            var numbers = Enumerable.Range(0, 10);

            // COUNT EVEN NUMBERS
            int evenNumbers = (from number in numbers where number % 2 == 0 select number).Count();

            Console.WriteLine(evenNumbers);     // 5

            // REVERSING THE RESULT SET

            foreach (var num in numbers.Reverse())
                Console.WriteLine(num);
            Console.WriteLine();

            // SORTING
            string[] cars = { "BMW", "Audi", "Buggati", "Ferrari", "Chevrolet", "Ford", "Mahindra", "Honda", "Renault", "Toyota", "Maruti", "Volkswagen", "Hyundai", "Mercedes", "Jaguar", "Bently", "Force", "Lamborghini" };

            var carInAscending = from car in cars orderby car ascending select car;
            foreach (var car in carInAscending) {
                Console.WriteLine(car);
            }

            Console.WriteLine();

            var carsInDescending = from car in cars orderby car descending select car;
            foreach (var car in carsInDescending) {
                Console.WriteLine(car);
            }

            


            Console.ReadKey();
        }
    }
}