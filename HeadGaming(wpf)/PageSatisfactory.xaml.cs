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
    /// Interaktionslogik für PageSatisfactory.xaml
    /// </summary>
    public partial class PageSatisfactory : Page
    {
        public PageSatisfactory()
        {
            InitializeComponent();
        }

        private void HomeBtn()
        {
            PageMenu pageMenu = new PageMenu();
            this.Content = pageMenu;
        }
        private void ButtonSatisfactory(object sender, RoutedEventArgs e)
        {
            PageSatisfactory pageSatisfactory = new PageSatisfactory();
            //NavigationService navService = NavigationService.GetNavigationService(this);
            //navService.Navigate(pageSatisfactory);
        }
    }
}
