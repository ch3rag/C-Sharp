using System;

namespace CommonSnappableTypes {

    public interface IAppFunctionality {
        void DoIt();
    }

    [AttributeUsage(AttributeTargets.Class)]
    public sealed class CompanyInfoAttribute : System.Attribute {
        public string CompanyName { get; set; }
        public string CompanyURL { get; set; }
    }
}
