// Monitoring Files And Directories

using System;
using System.IO;

namespace Experiment {
    public class Program {
        public static void Main(string[] args) {
            
            FileSystemWatcher fsw = new FileSystemWatcher();
            
            try {
                fsw.Path = @"C:\MyFolder";
            } catch (Exception ex) {
                Console.WriteLine(ex.Message);
                return;
            }


            // setup up notifying filter

            fsw.NotifyFilter = NotifyFilters.LastAccess 
                                | NotifyFilters.LastWrite 
                                | NotifyFilters.FileName 
                                | NotifyFilters.DirectoryName;
            fsw.Filter = "*.txt";

            fsw.Changed += new FileSystemEventHandler(OnChanged);
            fsw.Created += new FileSystemEventHandler(OnChanged);
            fsw.Deleted += new FileSystemEventHandler(OnChanged);
            fsw.Renamed += new RenamedEventHandler(OnRenamed);

            // begin watching!
            fsw.EnableRaisingEvents = true;
            while (!(Console.ReadLine()).Equals("q", StringComparison.OrdinalIgnoreCase)) ;
            Console.ReadKey();
        }

        static void OnChanged(object sender, FileSystemEventArgs e) {
            Console.WriteLine("File: {0} {1}!",e.FullPath, e.ChangeType);
        }

        static void OnRenamed(object sender, RenamedEventArgs e) {
            Console.WriteLine("File: {0} renamed to {1}", e.OldName, e.Name);
        }
    }
}