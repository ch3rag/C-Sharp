// Object Serialization - Collection Of Objects
using System;
using System.IO;
using System.Xml.Serialization;
using System.Collections.Generic;
namespace Experiment {

    [Serializable]
    public class Radio {
        public bool hasTweeters;
        public bool hasSubWoofers;
        public double[] stationPresets;
        
        [NonSerialized, XmlIgnore]
        public string radioID = "XF-5346RR6";
    }

    [Serializable]
    public class Car {
        public Radio radio = new Radio();
        public bool isHatchBack;
    }

    [Serializable, XmlRoot(Namespace = "http://www.MyCompany.com")]
    public class JamesBondCar : Car {
        
        [XmlAttribute]
        public bool canFly, canSubmerge;

        public JamesBondCar(bool canFly, bool canSubmerge) {
            this.canFly = canFly;
            this.canSubmerge = canSubmerge;
        }

        public JamesBondCar() { }
    }

    public class Program {
        public static void Main(string[] args) {
            
            List<JamesBondCar> myCars = new List<JamesBondCar>() {
                new JamesBondCar(true, true),
                new JamesBondCar(false, true),
                new JamesBondCar(true, false),
                new JamesBondCar(false, false),
            };

            using (Stream fs = File.Open("CarCollection.xml", FileMode.Create, FileAccess.Write, FileShare.None)) {
                XmlSerializer xs = new XmlSerializer(typeof(List<JamesBondCar>));
                xs.Serialize(fs, myCars);
            }

            Console.WriteLine("Car Collection Serialized!");
            Console.ReadLine();
        }
    }
}