// Applying Attributes 

using System;

namespace Experiment {
    [Serializable]
    public class Motorcycle {

        // this field will not be persisted
        [NonSerialized]
        float weightOfCurrentPassengers;

        // these field will be persisted
        bool hasRadioSystem;
        bool hasHeadSet;
        bool hasSissyBar;
    }

    // Multiple Attributes
    [Serializable, Obsolete("Use Another Vehicle")]
    public class HorseAndBuggy {

    }

    public class Program {
        public static void Main(string[] args) {

        }
    }


}