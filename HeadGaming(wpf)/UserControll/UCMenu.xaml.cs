using HeadGaming_wpf_.UserControll;
using System;
using System.Collections.Generic;
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

namespace HeadGaming_wpf_
{
    /// <summary>
    /// Interaktionslogik für UCMenu.xaml
    /// </summary>
    public partial class UCMenu : UserControl
    {
        public UCMenu()
        {
            InitializeComponent();
        }

        private void ButtonSatisfactory(object sender, RoutedEventArgs e)
        {
            Switcher.Switch(new UCSatisfactory());
        }
    }
}
