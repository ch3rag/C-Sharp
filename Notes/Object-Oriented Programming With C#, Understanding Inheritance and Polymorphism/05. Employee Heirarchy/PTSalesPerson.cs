using System;


namespace Employees {
    sealed class PTSalesPerson : SalesPerson {
        public PTSalesPerson(string name, int age, int Id, float currentPay, int ssn, int sales)
            : base(name, age, Id, currentPay, ssn, sales) {
        }

        // ERROR!
        // public override void GiveBonus(float amount) { }
    }
}
