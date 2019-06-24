using System;
using System.Windows;
using System.Net;
using System.Threading.Tasks;
using System.Linq;

namespace TextStats {

    public partial class MainWindow : Window {
        public MainWindow() {
            InitializeComponent();
        }

        private void cmdOK_Click(object sender, RoutedEventArgs e) {
            txtOutput.Text = "";
            if (txtURL.Text == "") {
                txtOutput.Text = "Invalid URL.";
            } else {
                BeginDownload(txtURL.Text);
            }
        }

        private void BeginDownload(string url) {
            WebClient wc = new WebClient();
            wc.DownloadStringCompleted += (obj, e) => {
                txtOutput.AppendText("\nDownload Completed");
                StartTasks(e.Result);
            };
            try {
                txtOutput.AppendText("Downloading....");
                wc.DownloadStringAsync(new Uri(url));
            } catch (Exception ex) {
                txtOutput.AppendText("\n" + ex.Message);
            }
        }

        private void StartTasks(string data) {
            string[] words = data.Split(new char[] { ' ', ',', '-', ':', ';', '?', '/', '\u000a', '.', '\'', '"', '(', ')', '[', ']', '_', '#' }, StringSplitOptions.RemoveEmptyEntries);

            string longest = string.Empty;
            string[] top = null;

            Parallel.Invoke(
                () => longest = FindLongestWord(words),
                () => top = FindTopTenWords(words));

            this.Dispatcher.Invoke(() => txtOutput.AppendText("\nLongest Word: " + longest));
            this.Dispatcher.Invoke(() => {
                txtOutput.AppendText("\nTop 10 Words:");
                foreach (string word in top) {
                    txtOutput.AppendText("\n" + word);
                }
            });
        }

        private string FindLongestWord(string[] words) {
            return (from word in words orderby word.Length descending select word).FirstOrDefault();
        }

        private string[] FindTopTenWords(string[] words) {
            var topTen = from word in words where word.Length > 5 group word by word into grp orderby grp.Count() select grp.Key;
            return topTen.Take(10).ToArray();
        }
    }
}
