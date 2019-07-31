using System;
using System.ServiceProcess;
using System.ServiceModel;
using MathServiceLibrary;

namespace MathWindowsServiceHost {
    public partial class MathWinService : ServiceBase {

        private ServiceHost host;
        public MathWinService() {
            InitializeComponent();
        }

        protected override void OnStart(string[] args) {
            if (host != null) host.Close();

            host = new ServiceHost(typeof(MathService));
            Uri address = new Uri("http://localhost:8080/MathServiceLibrary");
            WSHttpBinding binding = new WSHttpBinding();
            Type contract = typeof(IBasicMath);
            host.AddServiceEndpoint(contract, binding, address);

            // OR TO USE DEFAULT ENDPOINT CONFIGURATION
            // host = new ServiceHost(typeof(MathService), new Uri("http://localhost:8080/MathServiceLibrary"));
            // host.AddDefaultEndpoints();

            host.Open();
        }

        protected override void OnStop() {
            if (host != null) host.Close();
        }
    }
}
