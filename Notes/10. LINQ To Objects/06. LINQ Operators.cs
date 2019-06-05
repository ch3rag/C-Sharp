// LINQ Query Operators
// the System.Linq.Enumerable class provides a set of methods that do not have a direct C# query operator shorthand notation but are instead
// exposed as extension methods. 

// These generic methods can be called to transform a result set in various manners (Reverse<>(), ToArray<>(), ToList<>(), etc.).
// Others perform various set operations (Distinct<>(), Union<>(), Intersect<>(), etc.).
// Aggregate results (Count<>(), Sum<>(), Min<>(), Max<>(), etc.).

// from, in 
// Used to define the backbone for any LINQ expression, which allows you to extract a subset of data from a fitting container.

// Where 
// Used to define a restriction for which items to extract from a container.

// Select 
// Used to select a sequence from the container. 

// join, on, equals, into 
// Performs joins based on specified key. Remember, these “joins” do not need to have anything to do with data in a relational database.

// orderby, ascending, descending 
// Allows the resulting subset to be ordered in ascending or descending order.

// group, by 
// Yields a subset with data grouped by a specified value.
 



using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

namespace Experiment {
    public class ProductInfo {
        public string Name { get; set; }
        public string Description { get; set; }
        public int NumberInStock { get; set; }

        public override string ToString() {
            return string.Format("[Name: {0}; Description: {1}; NumberInStock: {2}]", this.Name, this.Description, this.NumberInStock);
        }
    }
    public class Program {
        public static void Main(string[] args) {
            ProductInfo[] itemsInStock = {
                                             new ProductInfo() { Name = "Mac's Coffee", Description = " Coffee With Teeth", NumberInStock = 24 },
                                             new ProductInfo() { Name = "Milk Maid Milk", Description = " Milk Cow's Love", NumberInStock = 100 },
                                             new ProductInfo() { Name = "Pure Silk Tofu", Description = "Bland As Possible", NumberInStock = 120 },
                                             new ProductInfo() { Name = "Crunchy Pops", Description = "Cheezy, Peppery Goodness", NumberInStock = 2 },
                                             new ProductInfo() { Name = "Rip Off Water", Description = "From The Tap To Your Wallet", NumberInStock = 100 },
                                             new ProductInfo() { Name = "Classic Valpo Pizza", Description = "Everyone Loves Pizza!", NumberInStock = 73 }
                                         };


            // SELECT EVERYTHING

            var allItems = from product in itemsInStock select product;
            foreach (var product in allItems) {
                Console.WriteLine(product);
            }
            Console.WriteLine();

            // Name Of All The Products
            var allItemNames = from product in itemsInStock select product.Name;
            foreach (var itemName in allItemNames) {
                Console.WriteLine(itemName);
            }
            Console.WriteLine();

            // All The Item whose stock > 25

            var subset = from product in itemsInStock where product.NumberInStock > 25 select product;

            foreach (var item in subset) {
                Console.WriteLine(item);
            }

            // Projections

            var namesAndDescription = from product in itemsInStock select new { product.Name, product.Description };
            foreach (var item in namesAndDescription) {
                Console.WriteLine(item);
            }
            Console.WriteLine();

            // Returning Projections From Function
            // Return Type Must Be System.Array
            Array namesAndStock = GetNameAndStock(itemsInStock);
            foreach (object item in namesAndStock) {
                Console.WriteLine(item);
            }


            Console.ReadKey();
        }

        public static Array GetNameAndStock(ProductInfo[] items) {
            var subset = from item in items select new { item.Name, item.NumberInStock };
            return subset.ToArray();
        }
    }
}