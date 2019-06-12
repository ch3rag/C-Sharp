// Simplyfying Late Bound Class Using DLR

using System;
using System.Reflection;

namespace Experiment {
    public class Program {
        public static void Main(string[] args) {
            try {
                Assembly asm = Assembly.Load("CarLibrary");

                Type sportType = asm.GetType("CarLibrary.SportsCar");
                Type enumType = asm.GetType("CarLibrary.MusicMedia");

                dynamic obj = Activator.CreateInstance(sportType);

                obj.TurboBoost();

                dynamic enumVal = enumType.GetEnumValues().GetValue(0);
                obj.TurnOnRadio(true, enumVal);

            } catch (Exception ex) {
                Console.WriteLine("Error: {0}", ex);
            }

            Console.ReadKey();
        }
    }
}