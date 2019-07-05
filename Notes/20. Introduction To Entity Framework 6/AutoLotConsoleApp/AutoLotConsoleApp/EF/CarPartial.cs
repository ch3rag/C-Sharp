namespace AutoLotConsoleApp.EF {

    using System;

    public partial class Car {
        public override string ToString() {
            return String.Format("{0} is a {1} {2} with ID {3}", this.PetName ?? "*** No Name ***", 
                this.Color, this.Make, this.CarId);
        }
    }
}