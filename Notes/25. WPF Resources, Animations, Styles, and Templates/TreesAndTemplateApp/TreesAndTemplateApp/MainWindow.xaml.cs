using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Reflection;
using System.Xml;
using System.Windows.Markup;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace TreesAndTemplateApp {
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window {
        private string dataToShow;
        private Control controlToExamine;

        public MainWindow() {
            InitializeComponent();
        }

        private void BtnLogicalTree_Click(object sender, RoutedEventArgs e) {
            dataToShow = "";
            BuildLogicalTree(0, this);
            txtDisplayArea.Text = dataToShow;
        }

        private void BtnVisualTree_Click(object sender, RoutedEventArgs e) {
            dataToShow = "";
            BuildVisualTree(0, this);
            txtDisplayArea.Text = dataToShow;
           
        }

        void BuildLogicalTree(int depth, Object obj) {
            dataToShow += new string(' ', depth) + obj.GetType().Name + "\n";
            if (!(obj is DependencyObject))
                return;
            else {
                foreach (var child in LogicalTreeHelper.GetChildren((DependencyObject)obj))
                    BuildLogicalTree(depth + 5, child);
            }
        }

        void BuildVisualTree(int depth, DependencyObject obj) {
            dataToShow += new string(' ', depth) + obj.GetType().Name + '\n';
            for (int i = 0; i < VisualTreeHelper.GetChildrenCount(obj); i++) {
                BuildVisualTree(depth + 1, VisualTreeHelper.GetChild(obj, i));
            }
        }

        private void BtnTemplate_Click(object sender, RoutedEventArgs e) {
            dataToShow = "";
            ShowTemplate();
            txtDisplayArea.Text = dataToShow;
        }

        private void ShowTemplate() {
            // remove the control in display area
            if(controlToExamine != null) {
                stkTemplate.Children.Remove(controlToExamine);
            }

            try {

                Assembly asm = Assembly.Load("PresentationFramework, version=4.0.0.0, Culture=Neutral, PublicKeyToken=31bf3856ad364e35");
                controlToExamine = (Control)asm.CreateInstance(txtFullName.Text);
                controlToExamine.Height = 200;
                controlToExamine.Width = 200;
                controlToExamine.Margin = new Thickness(5);
                stkTemplate.Children.Add(controlToExamine);

                XmlWriterSettings writerSettings = new XmlWriterSettings() { Indent = true };
                StringBuilder builder = new StringBuilder();
                XmlWriter writer = XmlWriter.Create(builder, writerSettings);
                XamlWriter.Save(controlToExamine.Template, writer);
                dataToShow = builder.ToString();
            } catch(Exception ex) {
                dataToShow = ex.Message;
            }
        }
    }
}