using System;
using System.Collections.Generic;
using Excel = Microsoft.Office.Interop.Excel;

namespace COMInteroperability {
    class Program {
        static void Main(string[] args) {
            List<Car> carsInStock = new List<Car>() {
                new Car() { PetName = "Mary", Color = "Green", Make = "VW" },
                new Car() { PetName = "Mel", Color = "Red", Make = "Saab" },
                new Car() { PetName = "Hank", Color = "Black", Make = "Ford" },
                new Car() { PetName = "Davie", Color = "Yellow", Make = "BMW" }
            };

            ExportToExcel(carsInStock);
            Console.ReadKey();
        }

        static void ExportToExcel(List<Car> cars) {
            // LOAD UP EXCEL AND ADD A NEW WORK BOOK
            Excel.Application excelApp = new Excel.Application();
            excelApp.Workbooks.Add();

            // ESTABLISH COLUMN HEADINGS
            Excel._Worksheet workSheet = excelApp.ActiveSheet;
            workSheet.Cells[1, "A"] = "Make";
            workSheet.Cells[1, "B"] = "Color";
            workSheet.Cells[1, "C"] = "Pet Name";

            // MAP DATA TO WORK SHEET
            int row = 1;
            foreach (Car c in cars) {
                row++;
                workSheet.Cells[row, "A"] = c.Make;
                workSheet.Cells[row, "B"] = c.Color;
                workSheet.Cells[row, "C"] = c.PetName;
            }

            // GIVE IT A NICE STYLE
            workSheet.Range["A1"].AutoFormat(Excel.XlRangeAutoFormat.xlRangeAutoFormatClassic2);

            workSheet.SaveAs(Environment.CurrentDirectory + @"\Inventory.xlsx");
            excelApp.Quit();
            Console.WriteLine("Inventory has been exported in your current directory.");
        }
    }

    public class Car {
        public string PetName { get; set; }
        public string Make { get; set; }
        public string Color { get; set; }
    }
}
