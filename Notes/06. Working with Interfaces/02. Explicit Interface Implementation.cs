// EXPLICIT INTERFACE

using System;


namespace Experiment {
    // NOTICE CLASHING SIGNATURE
    public interface IDrawToForm {
        void Draw();
    }

    public interface IDrawToBuffer {
        void Draw();
    }

    public interface IDrawToPrinter {
        void Draw();
    }

    public class Octagon : IDrawToForm, IDrawToBuffer, IDrawToPrinter {
        public void Draw() {
            Console.WriteLine("Drawing Octagon");
        }
    }

    public class Pentagon : IDrawToForm, IDrawToBuffer, IDrawToPrinter {

        // EXPLICIT INTERFACE INPLEMENTATION
        // returnType InterfaceName.MethodName(params) { }
        // NOTE: Do not supply an access modifier; explicitly implemented members are automatically private.

        void IDrawToForm.Draw() {
            Console.WriteLine("Drawing Pentagon on Form");
        }

        void IDrawToBuffer.Draw() {
            Console.WriteLine("Drawing Pentagon on Buffer");
        }

        void IDrawToPrinter.Draw() {
            Console.WriteLine("Drawing Pentagon on Printer");
        }
    }


    class Program {
        static void Main(string[] args) {
            Octagon o = new Octagon();

            IDrawToForm x = (IDrawToForm)o;
            IDrawToBuffer y = (IDrawToBuffer)o;
            IDrawToPrinter z = (IDrawToPrinter)o;

            x.Draw();   //--|
            y.Draw();   //--|==> CALL TO SAME METHOD
            z.Draw();   //--|

            Pentagon p = new Pentagon();

            IDrawToForm a = (IDrawToForm)p;
            IDrawToBuffer b = (IDrawToBuffer)p;
            IDrawToPrinter c = (IDrawToPrinter)p;

            a.Draw();   //--==> CALL TO IDrawToForm.Draw()
            b.Draw();   //--==> CALL TO IDrawToBuffer.Draw()
            c.Draw();   //--==> CALL TO IDrawToPrinter.Draw()
            

            Console.ReadKey();
        }
    }
}
 