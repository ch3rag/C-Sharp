using System;
using System.Windows;
using System.IO;
using System.Drawing;
using System.Threading;
using System.Threading.Tasks;

namespace DataParallelismWithForEach {

    public partial class MainWindow : Window {
        // cancellation token to stop processing
        CancellationTokenSource cancelToken = new CancellationTokenSource();

        public MainWindow() {
            InitializeComponent();
        }

        private void cmdCancel_Click(object sender, RoutedEventArgs e) {
            // tell worker threads to stop!!
            cancelToken.Cancel();
        }

        private void cmdProcess_Click(object sender, RoutedEventArgs e) {
            // The Task class allows you to easily invoke a method on a secondary thread and can be used as a simple alternative to 
            // working with asynchronous delegates.
            Task.Factory.StartNew(() => ProcessFiles());
        }

        private void ProcessFiles() {

            ParallelOptions parallelOptions = new ParallelOptions() {
                CancellationToken = cancelToken.Token,
                MaxDegreeOfParallelism = System.Environment.ProcessorCount
            };

            // load all *.jpg files and make a new folder for modified data 
            string[] files = Directory.GetFiles("TestPictures", "*.jpg", SearchOption.AllDirectories);
            string newDir = "ModifiedPictures";
            Directory.CreateDirectory(newDir);
            try {
                Parallel.ForEach(files, parallelOptions, filePath => {

                    // check if cancellation is requested
                    parallelOptions.CancellationToken.ThrowIfCancellationRequested();

                    string fileName = Path.GetFileName(filePath);
                    using (Bitmap bitmap = new Bitmap(filePath)) {
                        bitmap.RotateFlip(RotateFlipType.Rotate180FlipNone);
                        bitmap.Save(Path.Combine(newDir, fileName));

                        // secondary thread changing the title of the window!!
                        // GUI controls have “thread affinity” with the thread that created them. If secondary threads attempt to 
                        // access a control they did not directly create, you are bound to run into runtime errors.
                        // this.Title = String.Format("Processing {0} on thread {1}", fileName, Thread.CurrentThread.ManagedThreadId);

                        // The Control parent class in WPF defines a Dispatcher object, which manages the work items for a thread. This 
                        // object has a method named Invoke(), which takes a System.Delegate as input. You can call this method when 
                        // you are in a coding context involving secondary threads to provide a thread-safe manner to update the UI of 
                        // the given control.

                        this.Dispatcher.Invoke(() => {
                            this.Title = String.Format("Processing {0} on thread {1}", fileName, Thread.CurrentThread.ManagedThreadId);
                        });
                    }
                });
                Dispatcher.Invoke(() => this.Title = "Fun With TPL");
            } catch (OperationCanceledException ex) {
                Dispatcher.Invoke(() => this.Title = ex.Message);
            }
        }
    }
}
