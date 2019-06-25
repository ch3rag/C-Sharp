// DirectoryInfo

using System;
using System.IO;

namespace Experiment {
    public class Program {
        public static void Main(string[] args) {
            ShowWindowsDirectoryInfo();
            ShowInfoAboutImages();
            CreateSubDirectory();
            Console.ReadLine();
        }

        public static void ShowWindowsDirectoryInfo() {
            DirectoryInfo dir = new DirectoryInfo(@"C:\Windows");
            Console.WriteLine("Fullname: {0}", dir.FullName);
            Console.WriteLine("Name: {0}", dir.Name);
            Console.WriteLine("Parent: {0}", dir.Parent);
            Console.WriteLine("Creation Time: {0}", dir.CreationTime);
            Console.WriteLine("Attributes: {0}", dir.Attributes);
            Console.WriteLine("Root: {0}", dir.Root);
        }

        public static void ShowInfoAboutImages() {
            DirectoryInfo dir = new DirectoryInfo(@"D:\New Folder");
            FileInfo[] files = dir.GetFiles("*.jpg", SearchOption.TopDirectoryOnly);
            foreach (FileInfo file in files) {
                Console.WriteLine("******************");
                Console.WriteLine("Name: {0}", file.Name);
                Console.WriteLine("Length: {0}", file.Length);
                Console.WriteLine("Creation Time: {0}", file.CreationTime);
                Console.WriteLine("Attributes: {0}", file.Attributes);
                Console.WriteLine("******************");

            }
        }

        public static void CreateSubDirectory() {
            DirectoryInfo dir = new DirectoryInfo(@"C:\");
            DirectoryInfo dataFolder = dir.CreateSubdirectory("data");
            Console.WriteLine("Data Folder Created: {0}", dataFolder);
        }
    }
}