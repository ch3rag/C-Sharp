using System;
using System.ServiceModel;  

namespace MathServiceLibrary {
    // concreate types of service contract are called service types
    public class MyMathService : IMyMathContract {
        public MyMathService() {
            Console.WriteLine("MyMathService Instance Created");
        }


        public int Sum(int x, int y) {
            return x + y;
        }
    }
}
