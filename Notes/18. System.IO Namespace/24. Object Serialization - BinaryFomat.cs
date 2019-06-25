// Object Serialization - Binary

using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace Experiment {

    [Serializable]
    class Radio {
        public bool hasTweeters;
        public bool hasSubWoofers;
        public double[] stationPresets;
        
        [NonSerialized]
        public string radioID = "XF-5346RR6";
    }

    [Serializable]
    class Car {
        public Radio radio = new Radio();
        public bool isHatchBack;
    }

    [Serializable]
    class JamesBondCar : Car {
        public bool canFly;
        public bool canSubmerge;
    }
    public class Program {
        public static void Main(string[] args) {
            JamesBondCar jbc = new JamesBondCar() {
                canFly = true,
                canSubmerge = true,
                radio = {
                    stationPresets = new double[] { 91.1, 102.6, 98.3 },
                    hasTweeters = true
                }
            };

            SaveAsBinaryFormat(jbc, "CarData.dat");
            
            JamesBondCar loadJbc = LoadCarFromFile("CarData.dat");
            Console.WriteLine(loadJbc.canFly);
            Console.WriteLine(loadJbc.canSubmerge);
            foreach (double station in loadJbc.radio.stationPresets) {
                Console.WriteLine(station);
            }

            Console.ReadLine();
        }

        static void SaveAsBinaryFormat(object obj, string fileName) {
            BinaryFormatter bf = new BinaryFormatter();
            using (Stream fStream = new FileStream(fileName, FileMode.Create, FileAccess.Write, FileShare.None)) {
                bf.Serialize(fStream, obj);
            }

            Console.WriteLine("Object Serialized!");
        }

        static JamesBondCar LoadCarFromFile(string path) {
            BinaryFormatter bf = new BinaryFormatter();
            JamesBondCar car = null;
            using (Stream fs = File.OpenRead(path)) {
                car = (JamesBondCar)bf.Deserialize(fs);
            }
            return car;
        }
    }
}