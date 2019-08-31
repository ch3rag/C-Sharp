using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace CustomDependencyPropertyDemo {
    /// <summary>
    /// Interaction logic for ShowNumberControl.xaml
    /// </summary>
    public partial class ShowNumberControl : UserControl {
        public ShowNumberControl() {
            InitializeComponent();
        }

        // propdp code snippet auto-generated
        public int CurrentNumber
        {
            get { return (int)GetValue(CurrentNumberProperty); }
            set { SetValue(CurrentNumberProperty, value); }
        }

        // Using a DependencyProperty as the backing store for CurrentNumber.  
        // This enables animation, styling, binding, etc...
        public static readonly DependencyProperty CurrentNumberProperty =
            DependencyProperty.Register(
                "CurrentNumber", 
                typeof(int), 
                typeof(ShowNumberControl), 
                new UIPropertyMetadata(100, new PropertyChangedCallback(CurrentNumberChanged)), 
                new ValidateValueCallback(ValidateCurrentNumber));

        public static void CurrentNumberChanged(DependencyObject depObj, DependencyPropertyChangedEventArgs e) {
            ShowNumberControl thisControl = (ShowNumberControl)depObj;
            thisControl.numberDisplay.Content = e.NewValue;
        }

        public static bool ValidateCurrentNumber(object value) {
            int val = (int)value;
            return (val >= 0 && val <= 500);
        }

        // private int currentNumber = 0;
        // public int CurrentNumber {
        //    get => currentNumber;
        //     set {
        //         currentNumber = value;
        //         numberDisplay.Content = CurrentNumber;
        //     }
        // }
    }
}
