using System;

namespace Employees {
    class SalesPerson : Employee {
        public int SalesNumber { get; set; }

        public SalesPerson() { }
        public SalesPerson(string name, int age, int Id, float currentPay, int ssn, int salesNum)
            : base(name, age, Id, currentPay, ssn) {
                this.SalesNumber = salesNum;

        }

        public sealed override void GiveBonus(float amount) {
            int salesBonus = 0;
            if (SalesNumber >= 0 && SalesNumber < 100) {
                salesBonus = 10;
            } else {
                if (SalesNumber >= 101 && SalesNumber < 200) {
                    salesBonus = 15;
                } else {
                    salesBonus = 20;
                }
            }

            base.GiveBonus(salesBonus);
        }

        public override void DisplayStats() {
            base.DisplayStats();
            Console.WriteLine("Number Of Sales: {0}", SalesNumber);
        }
    }
}
