using System;
using ModuleDefinition;

namespace CSharpModule {
    [ComapanyInformation("Ultra Softwares", "www.ultrasoft.com")]
    class Module : IAppFunctionality {
        void IAppFunctionality.DoIt() {
            Console.WriteLine("C# module is doing its work");
        }
    }
}
