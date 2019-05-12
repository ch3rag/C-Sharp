public class Literals {
    public static void Main() {
        // UNSIGNED INT 
        uint i = 5u;
        System.Console.WriteLine("UNSIGNED INT = " + i + " MAX VALUE: " + uint.MaxValue + " Min Value: " + uint.MinValue + " SIZE: " + sizeof(uint));
        
        // SHORTS
        short k = 5;
        System.Console.WriteLine("SHORT = " + k + " MAX VALUE: " + short.MaxValue + " Min Value: " + short.MinValue + " SIZE: " + sizeof(short));
        
        // UNSIGNED SHORTS
        ushort us = 50;
        System.Console.WriteLine("UNSIGNED SHORT = " + us + " MAX VALUE: " + ushort.MaxValue + " Min Value: " + ushort.MinValue + " SIZE: " + sizeof(ushort));
        
        // INTS
        int j = 5;
        System.Console.WriteLine("INT = " + j + " MAX VALUE: " + int.MaxValue + " Min Value: " + int.MinValue + " SIZE: " + sizeof(int));
        
        // BYTE
        byte b = 90;
        System.Console.WriteLine("BYTE = " + b + " MAX VALUE: " + byte.MaxValue + " Min Value: " + byte.MinValue + " SIZE: " + sizeof(byte));

        // SIGNED BYTE
        sbyte x = -90;
        System.Console.WriteLine("SIGNED BYTE = " + x + " MAX VALUE: " + sbyte.MaxValue + " Min Value: " + sbyte.MinValue + " SIZE: " + sizeof(sbyte));

        // DECIMALS
        decimal d = 30.5m;
        System.Console.WriteLine("DECIMAL = " + d + " MAX VALUE: " + decimal.MaxValue + " Min Value: " + decimal.MinValue + " SIZE: " + sizeof(decimal));

        // DOUBLES
        double s = 45.23d;
        System.Console.WriteLine("DOUBLE = " + s + " MAX VALUE: " + double.MaxValue + " Min Value: " + double.MinValue + " SIZE: " + sizeof(double));

        // FLOATS
        float f = 12.5f;
        System.Console.WriteLine("FLOAT = " + f + " MAX VALUE: " + float.MaxValue + " Min Value: " + float.MinValue + " SIZE: " + sizeof(float));

        // LONG 
        long l = 123567;
        System.Console.WriteLine("LONG = " + l + " MAX VALUE: " + long.MaxValue + " Min Value: " + long.MinValue + " SIZE: " + sizeof(long));

        // UNSIGNED LONG
        ulong ul = 909077ul;
        System.Console.WriteLine("UNSIGNED LONG = " + ul + " MAX VALUE: " + ulong.MaxValue + " Min Value: " + ulong.MinValue + " SIZE: " + sizeof(ulong));
        // STRINGS
        string name = "Chirag";

        // VERBATIM STRINGS
        //  Escape sequences are ignored in verbatim string literals, and all whitespace characters are included/

        string path = @"File Path is: 
            c:\Windows\system32";
        System.Console.WriteLine(name +  path);
        
        // CHARACTERS

        char c = 'C';

        bool isSleepy = false;

        System.Console.ReadKey();


    }
}