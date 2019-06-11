using System;
using System.Reflection;
using System.IO;
using System.Windows.Forms;
using ModuleDefinition;

namespace MainApplication {
    class Program {
        [STAThread]
        static void Main(string[] args) {
            Console.WriteLine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location));
            SelectExternalModule();
            Console.ReadLine();
        }

        private static void SelectExternalModule() {

            OpenFileDialog dlg = new OpenFileDialog() {
                InitialDirectory = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location),
                Filter = "assemblies(*.dll)|*.dll|All Files(*.*)|*.*",
                FilterIndex = 0
            };
            DialogResult dr = dlg.ShowDialog();
            if (dr == DialogResult.Cancel) {
                Console.WriteLine("User has cancelled the open file dialog box.");
            } else {
                LoadExternalModule(dlg.FileName);
            }
        }

        private static void LoadExternalModule(string path) {
            bool found = false;
            try {
                Assembly asm = Assembly.LoadFrom(path);
                Type[] types = asm.GetTypes();
                foreach (Type t in types) {
                    Type iAppFuncType = t.GetInterface("ModuleDefinition.IAppFunctionality");
                    if (iAppFuncType != null && t.IsClass) {
                        found = true;
                        IAppFunctionality app = (IAppFunctionality)asm.CreateInstance(t.FullName, true);
                        app.DoIt();
                        PrintCompanyInformation(t);
                    }
                }
            } catch (Exception ex) {
                Console.WriteLine("Error!");
                Console.WriteLine(ex);
            }

            if (!found) Console.WriteLine("Module is incompatible!");
        }

        private static void PrintCompanyInformation(Type t) {
            var attrs = t.GetCustomAttributes<ComapanyInformationAttribute>();
            foreach (var attr in attrs) {
                Console.WriteLine("More Information About {0} can be found at {1}", attr.CompanyName, attr.CompanyURL);
            }
        }
    }
}
