using HeadGaming_wpf_.DB;
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

namespace HeadGaming_wpf_.UserControll
{
    /// <summary>
    /// Interaktionslogik für UCSatisfactory.xaml
    /// </summary>
    public partial class UCSatisfactory : UserControl
    {
        public UCSatisfactory()
        {
            InitializeComponent();
        }

        private void CheckBox_Checked(object sender, RoutedEventArgs e)
        {

        }

        private void saveRessourcen_Click(object sender, RoutedEventArgs e)
        {
            string name = TbNameRessource.Text;
            bool isOre = (bool)CbIsOre.IsChecked;

            SqlConection conn = new SqlConection(Properties.Resources.Connection);
            conn.Open();
            int i = conn.SetData("INSERT INTO Ressourcen (name, isOre) VALUES ('" + name + "', '" + isOre + "')");
            conn.Close();

            if (i >= 1)
            {
                LbFeedbackRessourcen.Content = "Daten wurden erfolgreich gespeichert.";
                LbFeedbackRessourcen.Foreground = new SolidColorBrush(Color.FromRgb(50, 130, 0));
            }
            else
            {
                LbFeedbackRessourcen.Content = "Ein Fehler ist aufgetretten.";
                LbFeedbackRessourcen.Foreground = new SolidColorBrush(Color.FromRgb(0, 130, 0));
            }
        }
    }
}
