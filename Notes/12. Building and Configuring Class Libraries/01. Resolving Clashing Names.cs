// RESOLVING CLASHING NAMES

// WAY 1
// USE FULLY QUALIFIED NAME

// WAY 2
// USE ALIASES


using System;
// ALIAS
using bf = System.Runtime.Serialization.Formatters.Binary;

namespace Experiment {
    public class Program {
        // WAY 1
        System.Runtime.Serialization.Formatters.Binary.BinaryFormatter b2 = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();

        // WAY 2
        bf.BinaryFormatter b = new bf.BinaryFormatter();
    }
}

