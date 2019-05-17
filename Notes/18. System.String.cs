// STRING MANIPULATION

using System;

namespace Strings {
    class Program {
        public static void Main(String[] args) {

            String s = "Chirag";

            // LENGTH
            Console.WriteLine(s.Length);

            // COMPARETO
            Console.WriteLine(s.CompareTo("chiabc"));

            // CONTAINS
            Console.WriteLine(s.Contains("ir"));

            // EQUALS
            Console.WriteLine(s.Equals("abc"));
            // EQUALITY OPERATOR ALSO TEST STRING EQUIVALENCE (UNLIKE JAVA)
            Console.WriteLine(s == "Chirag");

            // FORMAT
            Console.WriteLine(String.Format("{0:n}", 9999999));

            // INSERT
            // string <= insert(index, string)
            s = s.Insert(s.Length, " Singh");
            Console.WriteLine(s);

            // PAD LEFT AND PAD RIGHT
            // string <= insert(numWhiteSpaces)
            s = s.PadLeft(20);
            Console.WriteLine(s);

            s = s.PadRight(2);
            Console.WriteLine(s);

            // REMOVE
            // string <= remove(startIndex, count)
            // string <= remove(startIndex)
            string s2 = s.Remove(3, 3);
            string s3 = s.Remove(5);
            Console.WriteLine(s2);
            Console.WriteLine(s3);

            // REPLACE
            // string <= replace(oldString, newString)
            // string <= replace(oldChar, newChar)

            string s4 = s.Replace("Chirag", "Bharat");
            string s5 = s.Replace('a', 'b');
            Console.WriteLine(s4);
            Console.WriteLine(s5);

            // SPLIT 
            string html = "www.google.com/images.html";
            char[] seperators = { '.', '/' };
            foreach (string x in html.Split(seperators)) {
                Console.WriteLine(x);
            }

            // TRIM
            string lotsOfSpaces = "     Chirag      ";
            lotsOfSpaces = lotsOfSpaces.Trim();
            Console.WriteLine(lotsOfSpaces);

            // TOUPPER & TOLOWER
            string uCase = s.ToUpper();
            string lCase = s.ToLower();
            Console.WriteLine(lCase);
            Console.WriteLine(uCase);


            Console.ReadKey();

        }
    }
}