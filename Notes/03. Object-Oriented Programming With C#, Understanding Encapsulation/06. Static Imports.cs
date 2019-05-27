// STATIC IMPORTS
// IT IS USED TO IMPORT ALL THE STATIC MEMBERS OF THE CLASS
// C# 6+ ONLY

using static System.Console;
using static System.DateTime;

public static class Program {
    public static void Main() {
        WriteLine(Now.ToShortDateString());
        WriteLine(Now.ToLongTimeString());
    }
}