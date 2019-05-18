using System;


namespace ConsoleControl {
    class Program {
        public static void Main(string[] args) {
            PrintConsoleInfo();
            Console.BufferWidth = 180;
            Console.BufferHeight = 120;
            // INCREASING THE NUMBER OF CHARACTERS CONSOLE CAN ACCOMODATE IN A SINGLE LINE

            ConsoleKeyInfo key;
            bool moved = false;
            int posX = 0;
            int posY = 0;

            do {
                key = Console.ReadKey();
                if (key.Key == ConsoleKey.LeftArrow) {
                    posX = Console.WindowLeft - 1;
                    if (posX >= 0) {
                        Console.WindowLeft = posX;
                        moved = true;
                    }
                }

                if (key.Key == ConsoleKey.RightArrow) {
                    posX = Console.WindowLeft + 1;
                    if (posX + Console.WindowWidth <= Console.BufferWidth) {
                        Console.WindowLeft = posX;
                        moved = true;
                    }
                }

                if (key.Key == ConsoleKey.UpArrow) {
                    posY = Console.WindowLeft - 1;
                    if (posY >= 0) {
                        Console.WindowTop = posY;
                        moved = true;
                    }
                }

                if (key.Key == ConsoleKey.DownArrow) {
                    posY = Console.WindowLeft + 1;
                    if (posY + Console.WindowTop <= Console.BufferHeight) {
                        Console.WindowTop = posY;
                        moved = true;
                    }
                }
                 
                if (moved) {
                    PrintConsoleInfo();
                    moved = false;
                }

            } while (true);


        }

        static void PrintConsoleInfo() {
            Console.WriteLine("Console Buffer Dimensions: {0} X {1}", Console.BufferWidth, Console.BufferHeight);
            Console.WriteLine("Console Window Dimensions: {0} X {1}", Console.WindowWidth, Console.WindowHeight);
            Console.WriteLine("Console Window Position  : ({0}, {1})", Console.WindowLeft, Console.WindowTop);
        }
    }

}