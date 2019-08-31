using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.IO;
using Microsoft.Win32;

namespace MyWordPad {
    public partial class MainWindow : Window {
        public MainWindow() {
            InitializeComponent();
            SetF1CommandBinding();
        }

        private void SetF1CommandBinding() {
            CommandBinding binding = new CommandBinding(ApplicationCommands.Help);
            binding.CanExecute += CanHelpExecute;
            binding.Executed += HelpExecuted;
            CommandBindings.Add(binding);
        }

        private void CanHelpExecute(object sender, CanExecuteRoutedEventArgs e) {
            e.CanExecute = true;
        }

        private void HelpExecuted(object sender, ExecutedRoutedEventArgs e) {
            MessageBox.Show("Look, it is not that difficult. Just type something!", "Help!");
        }

        protected void FileExit_Click(object sender, RoutedEventArgs e) {
            this.Close();
        }

        protected void ToolsSpellingHints_Click(object sender, RoutedEventArgs e) {
            StringBuilder hints = new StringBuilder();
            SpellingError error = txtData.GetSpellingError(txtData.CaretIndex);
            if(error != null) {
                foreach(string s in error.Suggestions) {
                    hints.AppendLine(s);
                }
            }
            lblSpellingHints.Content = hints.ToString();
            expanderSpelling.IsExpanded = true;

        }

        protected void MouseEnterExitArea(object sender, RoutedEventArgs e) {
            statBarText.Text = "Exit The Application";
        } 

        protected void MouseEnterToolsHintsArea(object sender, RoutedEventArgs e) {
            statBarText.Text = "Show Spelling Suggestions";
        }

        protected void MouseLeaveArea(object sender, RoutedEventArgs e) {
            statBarText.Text = "Ready";
        }

        private void Button_MouseEnter(object sender, MouseEventArgs e) {

        }

        private void OpenCommandCanExecute(object sender, CanExecuteRoutedEventArgs e) {
            e.CanExecute = true;
        }

        private void OpenCommandExecuted(object sender, ExecutedRoutedEventArgs e) {
            OpenFileDialog openDlg = new OpenFileDialog() {
                Filter = "Text Files|*.txt"
            };

            if(true == openDlg.ShowDialog()) {
                string dataFromFile = File.ReadAllText(openDlg.FileName);
                txtData.Text = dataFromFile;
            }
        }

        private void SaveCommandCanExecute(object sender, CanExecuteRoutedEventArgs e) {
            e.CanExecute = true;
        }

        private void SaveCommandExecuted(object sender, ExecutedRoutedEventArgs e) {
            SaveFileDialog saveDlg = new SaveFileDialog() {
                Filter = "Text Files|*.txt"
            };
            
            if(true == saveDlg.ShowDialog()) {
                File.WriteAllText(saveDlg.FileName, txtData.Text);
            }

        }
    }

    
}
