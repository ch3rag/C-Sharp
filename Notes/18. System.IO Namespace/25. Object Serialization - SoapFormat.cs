// Object Serialization - SOAP

using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Soap;

namespace Experiment {

    [Serializable]
    public class Radio {
        public bool hasTweeters;
        public bool hasSubWoofers;
        public double[] stationPresets;
        
        [NonSerialized]
        public string radioID = "XF-5346RR6";
    }

    [Serializable]
    public class Car {
        public Radio radio = new Radio();
        public bool isHatchBack;
    }

    [Serializable]
    public class JamesBondCar : Car {
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

            SaveAsSoapFormat(jbc, "CarData.soap");

            JamesBondCar jbc2 = LoadCarFromFile("CarData.soap");

            Console.WriteLine(jbc2.canFly);
            Console.WriteLine(jbc2.canSubmerge);

            foreach (double station in jbc2.radio.stationPresets) {
                Console.WriteLine(station);
            }
            Console.ReadLine();
        }

        public static void SaveAsSoapFormat(object obj, string path) {
            SoapFormatter sf = new SoapFormatter();
            using (Stream fs = File.Open(path, FileMode.OpenOrCreate, FileAccess.Write, FileShare.None)) {
                sf.Serialize(fs, obj);
            }
            Console.WriteLine("Object Serialized!");
        }

        public static JamesBondCar LoadCarFromFile(string path) {
            SoapFormatter sf = new SoapFormatter();
            JamesBondCar car = null;
            using (Stream fs = File.OpenRead(path)) {
                car = (JamesBondCar)sf.Deserialize(fs);
            }

            return car;
        }
    }
}