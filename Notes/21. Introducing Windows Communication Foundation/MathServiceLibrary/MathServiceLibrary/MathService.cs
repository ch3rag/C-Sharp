using System;
using System.ServiceModel;

namespace MathServiceLibrary {
    public class MathService : IBasicMath {
        public int Add(int x, int y) {
            System.Threading.Thread.Sleep(5000);
            return x + y;
        }
    }
}
