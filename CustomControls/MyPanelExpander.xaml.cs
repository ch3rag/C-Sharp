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

    public partial class MyPanelExpander : UserControl
    {

        public static readonly DependencyProperty ExpanderContentProperty 
            = DependencyProperty.Register("ExpanderContent", typeof(object), typeof(MyPanelExpander));

        public static readonly DependencyProperty TextProperty
            = DependencyProperty.Register("Text", typeof(string), typeof(MyPanelExpander));

        public static readonly DependencyProperty IsShownProperty 
            = DependencyProperty.Register("IsShown", typeof(bool), typeof(MyPanelExpander));


        public bool IsShown {
            get { return BdrContainer.Visibility == Visibility.Visible; }
            set {
                if (value == true) BdrContainer.Visibility = Visibility.Visible;
                else BdrContainer.Visibility = Visibility.Collapsed;
            }
        }

        public bool IsExpanded {
            get {
                return TglExpand.IsChecked == true;
            }
            set {
                TglExpand.IsChecked = value;
            }
        }

        public object ExpanderContent {
            get { return GetValue(ExpanderContentProperty); }
            set { SetValue(ExpanderContentProperty, value); }
        }

        public string Text {
            get {
                return lblText.Content.ToString();
            }
            set {
                lblText.Content = value;
            }
        }

        public MyPanelExpander()
        {
            InitializeComponent();
        }
    }
}
