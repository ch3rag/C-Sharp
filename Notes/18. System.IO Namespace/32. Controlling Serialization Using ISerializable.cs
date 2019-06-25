// Customizing SOAP/Binary Serialization Process

using System;
using System.Runtime.Serialization;
using System.IO;
using System.Runtime.Serialization.Formatters.Soap;

namespace Experiment {
    [Serializable]
    public class StringData : ISerializable {
        private string dataItemOne = "First Data Block";
        private string dataItemTwo = "More Data";

        public StringData() {}

        protected StringData(SerializationInfo si, StreamingContext ctx) {
            Console.WriteLine("Constructor Called!");
            dataItemOne = si.GetString("First_Item").ToLower();
            dataItemTwo = si.GetString("dataItemTwo").ToLower();
        }


        void ISerializable.GetObjectData(SerializationInfo si, StreamingContext ctx) {
            Console.WriteLine("Get Object Data Called!");
            si.AddValue("First_Item", dataItemOne.ToUpper());
            si.AddValue("dataItemTwo", dataItemTwo.ToUpper());
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