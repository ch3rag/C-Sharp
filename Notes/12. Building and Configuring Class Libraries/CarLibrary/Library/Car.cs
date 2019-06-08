using System;

namespace CarLibrary {
    public enum EngineState {
        EngineAlive,
        EngineDead
    }

    public abstract class Car {
        public string PetName { get; set; }
        public int MaxSpeed { get; set; }
        public int CurrentSpeed { get; set; }
        protected EngineState engineState = EngineState.EngineAlive;
        public EngineState EngineState { get { return engineState; } }

        public abstract void TurboBoost();

        public Car() { }
        public Car(string name, int maxSpeed, int currentSpeed) {
            this.PetName = name;
            this.MaxSpeed = maxSpeed;
            this.CurrentSpeed = currentSpeed;
        }
    }
}
