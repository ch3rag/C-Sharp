// Customizing SOAP/Binary Serialization Process Using Attributes

using System;
using System.Runtime.Serialization;
using System.IO;
using System.Runtime.Serialization.Formatters.Soap;

namespace Experiment {
    [Serializable]
    public class StringData {
        private string dataItemOne = "First Data Block";
        private string dataItemTwo = "More Data";

        public StringData() {}

        [OnSerializing]
        private void OnSerializing(StreamingContext ctx) {
            dataItemOne = dataItemOne.ToUpper();
            dataItemTwo = dataItemTwo.ToUpper();
        }

        [OnDeserialized]
        private void OnDeserialized(StreamingContext ctx) {
            dataItemOne = dataItemOne.ToLower();
            dataItemTwo = dataItemTwo.ToLower();
        }

        public override string ToString() {
            return String.Format("[dataItemOne: {0}; dataItemTwo: {1}]", dataItemOne, dataItemTwo);
        }
    }
    public class Program {
        public static void Main(string[] args) {
            StringData myData = new StringData();

            using (Stream fs = File.Open("myData.soap", FileMode.Create, FileAccess.Write, FileShare.None)) {
                SoapFormatter sf = new SoapFormatter();
                sf.Serialize(fs, myData);
            }

            Console.WriteLine("Object Serialized!");

            using (Stream fs = File.OpenRead("myData.soap")) {
                SoapFormatter sf = new SoapFormatter();
                StringData data = (StringData)sf.Deserialize(fs);
                Console.WriteLine(data);
            
            }

            Console.ReadKey();
        }
    }
}