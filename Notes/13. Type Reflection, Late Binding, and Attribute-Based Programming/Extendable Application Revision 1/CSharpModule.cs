using System;

using CommonSnappableTypes;

namespace CSharpSnapIn {
    [CompanyInfo(CompanyName = "FooBar", CompanyURL = "www.FooBar.com")]
    class CSharpModule : IAppFunctionality {
        void IAppFunctionality.DoIt() {
            Console.WriteLine("Added A C# Snap In");
        }
    }
}
