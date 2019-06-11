// ASSEMBLY LEVEL ATTRIBUTES
// It is also possible to apply attributes on all types within a given assembly using the [assembly:] tag
// Be aware that all assembly- or module-level attributes must be listed outside the scope of any namespace scope

// The AssemblyInfo.cs file is a handy place to put attributes that are to be applied at the assembly level.


using System;

[assembly: CLSCompliant(true)]
namespace Experiment {

    public class Test {
        // WARNING: UNSIGNED DATA IS NOT CLS COMPLIANT
        public ushort test = 0;
    }

    public class Program {
        public static void Main(string[] args) {

        }
    }
}