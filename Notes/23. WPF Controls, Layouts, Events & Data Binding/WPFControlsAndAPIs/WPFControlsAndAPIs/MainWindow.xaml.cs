using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.IO;
using System.Windows.Ink;
using System.Windows.Data;
using System.Linq;
using AutoLotDALEF.Repos;


namespace WPFControlsAndAPIs {
    public partial class MainWindow : Window {
        public MainWindow() {
            InitializeComponent();

            this.MyInkCanvas.EditingMode = InkCanvasEditingMode.Ink;
            this.inkRadio.IsChecked = true;
            this.comboColors.SelectedIndex = 0;
            ConfigureGrid();
            SetBindings();
        }

        private void RadioButtonClicked(object sender, RoutedEventArgs e) {
            switch((sender as RadioButton)?.Content.ToString()) {
                case "Ink Mode!":
                    this.MyInkCanvas.EditingMode = InkCanvasEditingMode.Ink;
                    break;
                case "Erase Mode!":
                    this.MyInkCanvas.EditingMode = InkCanvasEditingMode.EraseByStroke;
                    break;
                case "Select Mode!":
                    this.MyInkCanvas.EditingMode = InkCanvasEditingMode.Select;
                    break;
            }
        }

        private void ColorChanged(object sender, SelectionChangedEventArgs e) {
            string colorToUse = (this.comboColors.SelectedItem as StackPanel)?.Tag.ToString();
            this.MyInkCanvas.DefaultDrawingAttributes.Color = (Color)ColorConverter.ConvertFromString(colorToUse);
        }

        private void SaveData(object sender, RoutedEventArgs e) {
            using (FileStream fs = new FileStream("StrokeData.bin", FileMode.Create)) {
                this.MyInkCanvas.Strokes.Save(fs);
                fs.Close();
            }
        }

        private void LoadData(object sender, RoutedEventArgs e) {
            using(FileStream fs = new FileStream("StrokeData.bin", FileMode.Open, FileAccess.Read)) {
                StrokeCollection strokes = new StrokeCollection(fs);
                this.MyInkCanvas.Strokes = strokes;
            }
        }

        private void Clear(object sender, RoutedEventArgs e) {
            this.MyInkCanvas.Strokes.Clear();
        }

        private void SetBindings() {
            Binding binding = new Binding();
            binding.Converter = new MyDoubleClass();
            binding.Source = this.MyScrollBar;
            binding.Path = new PropertyPath("Value");
            this.ScrollBarThumb.SetBinding(Label.ContentProperty, binding);
        }

        private void ConfigureGrid() {
            using(InventoryRepo repo = new InventoryRepo()) {
                gridInventory.ItemsSource = repo.GetAll().Select(x => new { x.Id, x.PetName, x.Make, x.Color });
            }
        }
    }
}
