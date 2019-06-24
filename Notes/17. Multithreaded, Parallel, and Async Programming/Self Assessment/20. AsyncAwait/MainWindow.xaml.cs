using System;
using System.Windows;
using System.Threading;
using System.Threading.Tasks;

namespace AsyncAwait {
    public partial class MainWindow : Window {
        public MainWindow() {
            InitializeComponent();
        }

        private void cmdOK_Click(object sender, RoutedEventArgs e) {
            DoTask();
        }

        private async void DoTask() {
            lblResult.Content = await DoLongProcessingWork("Chirag");
        }

        private Task<string> DoLongProcessingWork(string name) {
            return Task.Factory.StartNew<string>(() => {
                Thread.Sleep(5000);
                return "Hey, " + name;
            });
        }
    }
}
