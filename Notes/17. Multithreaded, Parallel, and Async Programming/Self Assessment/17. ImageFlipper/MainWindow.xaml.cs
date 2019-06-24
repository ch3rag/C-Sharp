using System;
using System.Windows;
using System.Windows.Forms;
using System.IO;
using System.Threading.Tasks;
using System.Threading;
using System.Drawing;

namespace ImageFlipper {
    public partial class MainWindow : Window {
        private static CancellationTokenSource tokenSource = new CancellationTokenSource();
        public MainWindow() {
            InitializeComponent();
        }

        private void cmdProcess_Click(object sender, RoutedEventArgs e) {
            SelectFolder();
        }

        private void cmdCancel_Click(object sender, RoutedEventArgs e) {
            tokenSource.Cancel();
        }

        private void SelectFolder() {
            FolderBrowserDialog dlg = new FolderBrowserDialog();
            DialogResult result = dlg.ShowDialog();
            if (result == System.Windows.Forms.DialogResult.OK) {
                Task.Factory.StartNew(() => ProcessFiles(dlg.SelectedPath));
            }
        }

        private void ProcessFiles(string path) {

            ParallelOptions pOpts = new ParallelOptions() {
                CancellationToken = tokenSource.Token,
                MaxDegreeOfParallelism = Environment.ProcessorCount
            };

            string[] files = Directory.GetFiles(path, "*.jpg", SearchOption.TopDirectoryOnly);
            string newDir = Path.Combine(path, "FlippedPhotos");
            Directory.CreateDirectory(newDir);
            try {
                Parallel.ForEach(files, pOpts, filePath => {

                    pOpts.CancellationToken.ThrowIfCancellationRequested();

                    string fileName = Path.GetFileName(filePath);
                    using (Bitmap bmp = new Bitmap(filePath)) {
                        bmp.RotateFlip(RotateFlipType.Rotate180FlipNone);
                        string newFilePath = Path.Combine(newDir, fileName);

                        if (System.IO.File.Exists(newFilePath)) {
                            System.IO.File.Delete(newFilePath);
                        }

                        bmp.Save(Path.Combine(newDir, fileName));
                        this.Dispatcher.Invoke((Action)delegate { this.Title = "Processing " + fileName; });
                    }
                });
                this.Dispatcher.Invoke(() => this.Title = "Done!");
            } catch (OperationCanceledException ex) {
                this.Dispatcher.Invoke(() => this.Title = ex.Message);
            }


        }
    }
}
