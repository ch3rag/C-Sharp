// EXCEPTION FILTERING
using System;
public static class Program {
    public static void Main() {
        int a = 10;
        int b = 3;
        
        try {
        	throwExp(a);   
        } catch(Exception ex) when (ex.Message == "EVEN") {
        	Console.WriteLine("EVEN EXCEPTION");   
        } catch(Exception ex) when (ex.Message == "ODD") {
            Console.WriteLine("ODD EXCEPTION");   
        }
        
        try {
        	throwExp(b);   
        } catch(Exception ex) when (ex.Message == "EVEN") {
        	Console.WriteLine("EVEN EXCEPTION");   
        } catch(Exception ex) when (ex.Message == "ODD") {
            Console.WriteLine("ODD EXCEPTION");   
        }
                                    
    }
                                    
    public static void throwExp(int num) {
        string message = num % 2 == 0 ? "EVEN" : "ODD";
        Exception e = new Exception(message);
        throw e;
    }
}