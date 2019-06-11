using System;
namespace ModuleDefinition {
    public interface IAppFunctionality {
        void DoIt();
    }

    [AttributeUsage(AttributeTargets.Class)]
    public class ComapanyInformationAttribute : Attribute {
        public string CompanyName { get; set; }
        public string CompanyURL { get; set; }
        public ComapanyInformationAttribute(string name, string url) {
            this.CompanyName = name;
            this.CompanyURL = url;
        }
    }
}
