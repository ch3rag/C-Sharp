// https://www.meziantou.net/2019/03/18/string-comparisons-are-harder-than-it-seems

// STRING COMPARISON BEHAVIOR


using System;

namespace Strings {
    class Program {
        public static void Main(String[] args) {

            // STRING COMPARISION ENUM
            // CurrentCulture               Compares strings using culture-sensitive sort rules and the current culture
            // CurrentCultureIgnoreCase     Compares strings using culture-sensitive sort rules and the current culture and ignores the case of the strings being compared
            // InvariantCulture             Compares strings using culture-sensitive sort rules and the invariant culture
            // InvariantCultureIgnoreCase   Compares strings using culture-sensitive sort rules and the invariant culture and ignores the case of the strings being compared
            // Ordinal                      Compares strings using ordinal (binary) sort rules
            // OrdinalIgnoreCare            Compares strings using ordinal (binary) sort rules and ignores the case of the strings being compared

            string s1 = "Hello!";
            string s2 = "HELLO!";
            Console.WriteLine("s1 = {0}", s1);
            Console.WriteLine("s2 = {0}", s2);
            Console.WriteLine();

            Console.WriteLine("Default Rules s1.Equals(s2): {0}", s1.Equals(s2));
            Console.WriteLine();
            Console.WriteLine("Ordinal s1.Equals(s2, StringComparison.Ordinal): {0}", s1.Equals(s2, StringComparison.Ordinal));
            Console.WriteLine();
            Console.WriteLine("Ordinal Ignore Case s1.Equals(s2, StringComparison.OrdinalIgnoreCase): {0}", s1.Equals(s2, StringComparison.OrdinalIgnoreCase));
            Console.WriteLine();
            Console.WriteLine("Current Culture s1.Equals(s2, StringComparison.CurrentCulture): {0}", s1.Equals(s2, StringComparison.CurrentCulture));
            Console.WriteLine();
            Console.WriteLine("Current Culture Ignore Case s1.Equals(s2, StringComparison.CurrentCulture): {0}", s1.Equals(s2, StringComparison.CurrentCultureIgnoreCase));
            Console.WriteLine();
            Console.WriteLine("Invariant Culture s1.Equals(s2, StringComparison.InvariantCulture): {0}", s1.Equals(s2, StringComparison.InvariantCulture));
            Console.WriteLine();
            Console.WriteLine("Invariant Culture Ignore Case s1.Equals(s2, StringComparison.InvariantCultureIgnoreCase): {0}", s1.Equals(s2, StringComparison.InvariantCultureIgnoreCase));
            Console.WriteLine();
            
            
           /*
            * Ordinal:
            *
            * Performs a simple byte comparison that is independent of language. This is most appropriate when 
            * comparing strings that are generated programmatically or when comparing case-sensitive 
            * resources such as passwords.
            *   
            * OrdinalIgnoreCase:
            *      
            * Treats the characters in the strings to compare as if they were converted to uppercase 
            * using the conventions of the invariant culture, and then performs a simple byte 
            * comparison that is independent of language. This is most appropriate when comparing strings 
            * that are generated programmatically or when comparing case-insensitive resources such as paths and filenames.
            * 
            */
            
            // Basic comparisons

            Console.WriteLine(string.Equals("a", "a", StringComparison.Ordinal));           // true
            Console.WriteLine(string.Equals("a", "A", StringComparison.Ordinal));           // false
            Console.WriteLine(string.Equals("a", "a", StringComparison.OrdinalIgnoreCase)); // true
            Console.WriteLine(string.Equals("a", "A", StringComparison.OrdinalIgnoreCase)); // true

           /*
            * InvariantCulture: 
            * 
            * Compares strings in a linguistically relevant manner, but it is not suitable for display in any 
            * particular culture. Its major application is to order strings in a way that will be identical 
            * across cultures.
            * 
            * InvariantCultureIgnoreCase:
            * 
            * Compares strings in a linguistically relevant manner that ignores case, but it is not suitable 
            * for display in any particular culture. Its major application is to order strings in a way that 
            * will be identical across cultures.
            * 
            */

            Console.WriteLine(string.Equals("ss", "ß", StringComparison.OrdinalIgnoreCase));          // false
            Console.WriteLine(string.Equals("ss", "ß", StringComparison.InvariantCulture));           // true on Windows / false on Linux (WSL))
            Console.WriteLine(string.Equals("ss", "ß", StringComparison.InvariantCultureIgnoreCase)); // true on Windows / false on Linux (WSL))


            /*
             * CurrentCulture:
             * 
             * Can be used when strings are linguistically relevant. For example, if strings are displayed to 
             * the user, or if strings are the result of user interaction, culture-sensitive string comparison 
             * should be used to order the string data.
             * 
             * CurrentCultureIgnoreCase:
             * 
             * Can be used when strings are linguistically relevant but their case is not. 
             * 
             * Other tricky character is the character i in the Turkish language. In Latin languages there 
             * is only one i. In Turkish, there are 2: the dotless ı and the dotted i. There are also 2 
             * different uppercase characters: I and İ.
             * 
             */

            System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en-US");
            Console.WriteLine(string.Equals("i", "I", StringComparison.CurrentCultureIgnoreCase)); // true
            Console.WriteLine(string.Equals("i", "İ", StringComparison.CurrentCultureIgnoreCase)); // false

            System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("tr-TR");
            Console.WriteLine(string.Equals("i", "I", StringComparison.CurrentCultureIgnoreCase)); // false
            Console.WriteLine(string.Equals("i", "İ", StringComparison.CurrentCultureIgnoreCase)); // true
        }
    }
}