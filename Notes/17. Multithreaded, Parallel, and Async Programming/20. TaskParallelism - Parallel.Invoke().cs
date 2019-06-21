using System;
using System.Threading.Tasks;
using System.Net;
using System.Text;
using System.Linq;

namespace Experiment {
    public class Program {
        private static string ebook;
        public static void Main(string[] args) {
            GetBook();
            Console.ReadKey();
        }

        private static void GetBook() {
            WebClient wc = new WebClient();
            wc.DownloadStringCompleted += (s, eArgs) => {
                ebook = eArgs.Result;
                Console.WriteLine("Download Complete");
                GetStats();
            };

            wc.DownloadStringAsync(new Uri("http://www.GutenBerg.org/files/98/98-8.txt"));
            Console.WriteLine("Download Started...");
        }

        private static void GetStats() {
            string[] words = ebook.Split(new char[] {
             ' ', '\u000A', ',', '.', ';', ':', '-',  '?', '/'}, StringSplitOptions.RemoveEmptyEntries);

            string[] tenMostCommon = null;
            string longestWord = string.Empty;

            // Invoke tasks in parallel
            Parallel.Invoke(
                () => tenMostCommon = FindTenMostCommon(words),
                () => longestWord = FindLongestWord(words)
            );

            StringBuilder bookStats = new StringBuilder("Ten Most Common Words Are:\n");
            foreach (string word in tenMostCommon) {
                bookStats.AppendLine(word);
            }

            bookStats.AppendFormat("Longest Word Is: {0}", longestWord);
            bookStats.AppendLine();
            Console.WriteLine(bookStats.ToString(), "Book Info");
        }

        private static string[] FindTenMostCommon(string[] words) {
            return (from word in words where word.Length > 0 group word by word into g orderby g.Count() descending select g.Key).Take(10).ToArray();
        }

        private static string FindLongestWord(string[] words) {
            return (from word in words orderby word.Length descending select word).FirstOrDefault();
        }
    }
}