using System;
using System.Windows.Forms;

namespace CarLibrary {
    public class SportsCar : Car {
        public SportsCar() { }
        public SportsCar(string name, int maxSpeed, int currentSpeed) : base(name, maxSpeed, currentSpeed) { }
        public override void TurboBoost() {
            MessageBox.Show("Ramming Speed!", "Faster is Better..");
        }
    }

    public class MiniVan : Car {
        public MiniVan() { }
        public MiniVan(string name, int maxSpeed, int currentSpeed) : base(name, maxSpeed, currentSpeed) { }
        public override void TurboBoost() {
            MessageBox.Show("Eek!", "Your engine block exploded!");
        }
    }
}
