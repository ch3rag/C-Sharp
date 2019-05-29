// YEILD

using System;
using System.Collections;

namespace Experiment {
    
    class Program {
        static void Main(string[] args) {
  			IEnumerator ie = Fibonacii().GetEnumerator();
            for(int i = 0 ; i < 10 ; i++) {
                ie.MoveNext();
            	Console.WriteLine(ie.Current);
            }
        }
        static IEnumerable Fibonacii() {
        	int x = 1;
            int y = 1;
            return implementation();
            
            IEnumerable implementation() {
                while(true) {
                    int temp = y;
                    y += x;
                    x = temp;
                    yield return y;
                }
            }
    	}
    }
}
 