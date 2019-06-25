// Object Serialization - XMLSeralizer

// The XmlSerializer demands that all serialized types in the object graph support a default constructor. If this is not the 
// case, you will receive an InvalidOperationException at runtime.

using System;
using System.IO;
using System.Xml.Serialization;

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
        public bool canFly;
        [XmlAttribute]
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

            SaveAsXmlFormat(jbc, "CarData.xml");
            Console.ReadLine();
        }

        public static void SaveAsXmlFormat(object obj, string path) {
            XmlSerializer xs = new XmlSerializer(obj.GetType());
            using (Stream fs = File.Open(path, FileMode.Create, FileAccess.Write, FileShare.None)) {
                xs.Serialize(fs, obj);
            }
            Console.WriteLine("Object Serialized!");
        }
    }
}