using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace MyImageProcessing.CustomControls
{
    public partial class MyExpander : UserControl
    {
        public static readonly DependencyProperty ExpanderContentProperty
            = DependencyProperty.Register("ExpanderContent", typeof(object), typeof(MyExpander));

        public bool IsExpanded {
            get {
                return TglExpand.IsChecked == true;
            } 
            set {
                TglExpand.IsChecked = value;
            }
        }
        public string Text {
            get {
                return lblText.Content.ToString();
            } 
            set {
                lblText.Content = value;
            }
        }

        public object ExpanderContent {
            get { return GetValue(ExpanderContentProperty);  }
            set { SetValue(ExpanderContentProperty, value); }
        }

        public MyExpander()
        {
            InitializeComponent();
        }
    }
}
