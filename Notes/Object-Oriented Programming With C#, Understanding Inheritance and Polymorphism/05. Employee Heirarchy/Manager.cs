using System;

namespace Employees {
    class Manager : Employee {
        public int StockOptions { get; set; }


        public Manager() { }
        // CALLING  BASE CLASS CONSTRUCTOR
        public Manager(string name, int age, int Id, float currentPay, int ssn, int stocks)
            : base(name, age, Id, currentPay, ssn) {
                this.StockOptions = stocks;
        }

        public override void GiveBonus(float amount) {
            base.GiveBonus(amount);
            Random r = new Random();
            StockOptions += r.Next(500);
        }

        public override void DisplayStats() {
            base.DisplayStats();
            Console.WriteLine("Number Of Stock Options: {0}", StockOptions);
        }
    }
}
