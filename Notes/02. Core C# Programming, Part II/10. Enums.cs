// ENUMS
// NAME VALUE PAIRS

using System;
namespace Notes {
    class Program {
        // MUST BE DECLARE AT CLASS LEVEL
        enum CharaterType {
            USER = 0,
            ZOMBIE = 1,
            MONSTER = 2
        }

        // BY DEFAULT THEY ARE STORED AS INT
        // BUT WE CAN CHANGE IT  

        // ANY SEQUENCE IS ALLOWED
        // NEED NOT TO BE STARTED FROM 0
        enum OS : byte {
            Windows = 100,
            Ubuntu = 21,
            OSX = 45
        }


        public static void Main(string[] args) {
            WhatIsMyOS(OS.OSX);
            WhatIsMyOS(OS.Windows);
            WhatIsMyOS(OS.Ubuntu);

            // THIS WON'T WORK
            // WhatIsMyOS(100);

            // ENUMS INHERIT System.Enum IMLICITELY WHICH PROVIDE THEM EXTRA FUNCTIONALITY
            // System.Enum.GetUnderlyingType()
            // IT REQUIRES System.Type AS AN ARGUMENT
            // System.Type represents the metadata description of a given .NET entity.
            // TypeOf OPERATOR CAN BE USED TO GET THIS META DATA OR Variable.GetType()

            Console.WriteLine(System.Enum.GetUnderlyingType(typeof(OS)));
            Console.WriteLine(System.Enum.GetUnderlyingType(OS.Ubuntu.GetType()));

            // GETTING ENUMNAME AS STRING OF ENUM MEMBER
            // myEnumValue.toString();
            Console.WriteLine(OS.Ubuntu.ToString());    // Ubuntu

            // GETTING ENUMVALUE STORED IN ENUM MEMBER
            // CAST IT AGAINST ITS TYPE
            Console.WriteLine((byte)OS.Ubuntu);         // 21

            // System.Enum.GetValues();
            //  RETURNS AN ARRAY CONTAINING INFORAMTION ABOUT EACH MEMBER IN THE ARRAY
            OS e = OS.Ubuntu;
            PrintEnumInfo(e);
            PrintEnumInfo(CharaterType.MONSTER);

            // VALUES ONCE DEFINED CAN'T BE CHANGED
            // OS.Ubuntu = 12;

            Console.ReadKey();
        }

        // GETTING INFORMATION ABOUT AN ENUM
        //                        (SUPERCLASS)
        static void PrintEnumInfo(System.Enum e) {
            // NAME OF TYPE
            Console.WriteLine("Information About {0}", e.GetType().Name);

            // UNDERLYING DATATYPE
            Console.WriteLine("Underlying Datatype is {0}", System.Enum.GetUnderlyingType(e.GetType()));

            System.Array enumData = System.Enum.GetValues(e.GetType());
			
			// THIS ARRAY IS EQUIVALENT TO
			
			// System.Array enumData = System.Array.CreateInstance(typeof(OS), 3);
            // enumData.SetValue(OS.Windows, 0);
            // enumData.SetValue(OS.Ubuntu, 1);
            // enumData.SetValue(OS.OSX, 2);

            Console.WriteLine("Number Of Members: {0}", enumData.Length);

            for (int i = 0, max = enumData.Length; i < max; i++) {
                Console.WriteLine("Member Name: {0}, Value: {0:D}", enumData.GetValue(i));
                // OR
                // Console.WriteLine("Member Name: {0}, Value: {1}", enumData.GetValue(i), (byte)enumData.GetValue(i));

            }
            
        }

        // PASSING ENUMS TO METHODS

        static void WhatIsMyOS(OS type) {
            switch (type) {
                case OS.Windows:
                    Console.WriteLine("Windows OS");
                    break;
                case OS.Ubuntu:
                    Console.WriteLine("Ubuntu OS");
                    break;
                case OS.OSX:
                    Console.WriteLine("Apple's Mac OSX");
                    break;         
            }
        }
    }
}