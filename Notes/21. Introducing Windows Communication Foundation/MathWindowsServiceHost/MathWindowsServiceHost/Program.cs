using System;
using System.ServiceProcess;

namespace MathWindowsServiceHost {
    static class Program {

        static void Main() {
            ServiceBase[] ServicesToRun;
            ServicesToRun = new ServiceBase[] 
            { 
                new MathWinService() 
            };
            ServiceBase.Run(ServicesToRun);
        }
    }
}
