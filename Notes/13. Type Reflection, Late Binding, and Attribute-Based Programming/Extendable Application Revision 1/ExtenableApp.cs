using System;
using System.Windows.Forms;
using System.Reflection;
using System.IO;
using CommonSnappableTypes;
using System.Linq;

namespace MyExtendableApp {
    class Program {
        [STAThread]
        public static void Main(string[] args) {
            Console.WriteLine("**** WELCOME TO MY TYPE VIEWER ***");
            do {
                Console.Write("Would you like to load snap-in?[y/n]: ");
                string answer = Console.ReadLine();
                if (!answer.Equals("y", StringComparison.OrdinalIgnoreCase)) {
                    break;
                }

                try {
                    LoadSnapIn();
                } catch (Exception ex) {
                    Console.WriteLine("Sorry can't load span-in!");
                }
            } while (true);
        }

        public static void LoadSnapIn() {
            OpenFileDialog dlg = new OpenFileDialog() {
                InitialDirectory = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location),
                Filter = "Assemblies (*.dll)|*.dll|All Files(*.*)|*.*",
                FilterIndex = 1
            };
            if (dlg.ShowDialog() != DialogResult.OK) {
                Console.WriteLine("User cancelled out of open file dialog!");
                return;
            }
            if (dlg.FileName.Contains("CommonSnappableTypes")) {
                Console.WriteLine("Common Snapable Types has no snap-ins!");
            } else if (!LoadExternalModule(dlg.FileName)) {
                Console.WriteLine("Nothing Implements IAppFunctionality!");
            }
        }

        private static bool LoadExternalModule(string filePath) {
            bool foundSnapIn = false;
            Assembly snapInAsm = null;

            try {
                snapInAsm = Assembly.LoadFrom(filePath);
            } catch (Exception ex) {
                Console.WriteLine("Error while loading the assembly!");
                return false;
            }

            (from type in snapInAsm.GetTypes() where type.IsClass && (type.GetInterface("IAppFunctionality") != null) select type).ToList().ForEach(x => {
                foundSnapIn = true;
                IAppFunctionality app = (IAppFunctionality)snapInAsm.CreateInstance(x.FullName, true);
                if (app != null) app.DoIt();
                DisplayCompanyInfo(x);
            });

            return foundSnapIn;
        }

        private static void DisplayCompanyInfo(Type t) {
            (from ci in t.GetCustomAttributes(false) where (ci is CompanyInfoAttribute) select ci).ToList().ForEach(x => {
                CompanyInfoAttribute attr = x as CompanyInfoAttribute;
                Console.WriteLine("More info about {0} can be found at {1}", attr.CompanyName, attr.CompanyURL);
            });

        }
    }
}
