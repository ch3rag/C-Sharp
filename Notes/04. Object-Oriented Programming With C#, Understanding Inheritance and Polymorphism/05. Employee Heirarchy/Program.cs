using System;

namespace Employees {
    class Program {
        static void Main(string[] args) {
            SalesPerson fred = new SalesPerson();
            fred.Name = "Fred";
            fred.Age = 31;
            fred.SalesNumber = 50;

            fred.DisplayStats();


            Employee.BenefitPackage.BenefitPackageLevel myBenefitLevel = Employee.BenefitPackage.BenefitPackageLevel.Platinum;

            Console.ReadKey();
        }
    }
}
