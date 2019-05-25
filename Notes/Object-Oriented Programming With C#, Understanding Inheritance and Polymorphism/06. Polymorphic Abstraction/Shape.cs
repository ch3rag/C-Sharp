using System;

namespace Shapes {
    public abstract class Shape {
        public string PetName { get; set; }

        public Shape(string name = "NoName") {
            this.PetName = name;    
        }

        // FORCE BASE CLASSES TO IMPLEMENT IT
        public abstract void draw();

    }
}
