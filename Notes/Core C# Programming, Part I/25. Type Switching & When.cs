using System;

public class Program {
    public static void Main()
	{
		Console.WriteLine("1. Integer, 2. String, 3. Decimal");
		string userInput = Console.ReadLine();
		Object choice;
		
		switch(userInput) {
			case "1":
				Console.WriteLine("You Opt For Integer");
				choice = 5;
				break;
			case "2":
				Console.WriteLine("You Opt For String");
				choice = "Hi";
				break;
			case "3":
				Console.WriteLine("You Opt For Decimal");
				choice = 2.5;
				break;
			default:
				choice = 5;
				break;
		}
		switch(choice) {
			case int i:
				Console.WriteLine("You Given An Integer: {0}", i);
				break;
			case decimal d:
				Console.WriteLine("You Given A Decimal: {0}", d);
				break;
			case string s:
				Console.WriteLine("You Given A String: {0}", s);
				break;
		}
		
		Console.WriteLine("Choose A Language - 1. C#, 2. JAVA");
		string userInput2 = Console.ReadLine();
		var choice2 = int.TryParse(userInput2, out int c) ? c : (Object)userInput2;
		switch(choice2) {
			case int x when x == 1:
			case string s when s == "C#":
				Console.WriteLine("C# Is A Great Language");
				break;
			case int x when x == 2:
			case string s when s == "JAVA":
				Console.WriteLine("JAVA A Great Language");
				break;
			default:
				Console.WriteLine("Well... Good Luck With That");
				break;
		}
	}
}