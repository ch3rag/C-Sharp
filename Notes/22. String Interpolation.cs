// STRING INTERPOLATION

using System;		
public class Program
{
	public static void Main()
	{
		string name = "Chirag";
		int age = 20;
		string greet = $"Hello {name} you are {age} years old";
		Console.WriteLine(greet);
	}
}