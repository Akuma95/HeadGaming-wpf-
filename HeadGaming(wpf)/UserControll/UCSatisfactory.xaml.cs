using HeadGaming_wpf_.DB;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Text.RegularExpressions;
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
            FillAll("Ressource", CbDeleteRessource, DgRessourcen, this.TbFeedbackRessourcen);
            FillAll("Fabrik", CbDeleteBuilding, DgBuilding, this.TbFeedbackBuilding);
            FillRecepiTab();
        }

        private void CheckBox_Checked(object sender, RoutedEventArgs e)
        {

        }

        // Ressource - Tab
        private void SaveRessourcen_Click(object sender, RoutedEventArgs e)
        {
            string name = TbNameRessource.Text;
            int isOre = (bool)CbIsOre.IsChecked ? 1 : 0;

            SqlConection conn = new SqlConection(Properties.Resources.Connection);
            conn.Open(this.TbFeedbackRessourcen);
            int i = conn.SetData("INSERT INTO Ressource (name, isOre) VALUES ('" + name + "', " + isOre + ");", this.TbFeedbackRessourcen);
            FillAll("Ressource", CbDeleteRessource, DgRessourcen, this.TbFeedbackRessourcen);
            FillRecepiTab();
            if (i >= 1)
            {
                TbNameRessource.Text = "";
                CbIsOre.IsChecked = false;
            }
            conn.Close();

        }

        private void DeleteRessource_Click(object sender, RoutedEventArgs e)
        {
            string name = CbDeleteRessource.Text;

            SqlConection conn = new SqlConection(Properties.Resources.Connection);
            conn.Open(this.TbFeedbackRessourcen);
            int i = conn.DeleteData("DELETE FROM Ressource WHERE name = '" + name + "'", this.TbFeedbackRessourcen);
            FillAll("Ressource", CbDeleteRessource, DgRessourcen, this.TbFeedbackRessourcen);
            FillRecepiTab();
            conn.Close();
        }

        // Gebäude - Tab
        private void SaveBuildings_Click(object sender, RoutedEventArgs e)
        {
            string name = TbNameBuilding.Text;
            string energie = TbEnergie.Text;

            SqlConection conn = new SqlConection(Properties.Resources.Connection);
            conn.Open(this.TbFeedbackBuilding);
            int i = conn.SetData("INSERT INTO Fabrik (name, energie) VALUES ('" + name + "', " + Int32.Parse(energie) + ");", this.TbFeedbackBuilding);
            FillAll("Fabrik", CbDeleteBuilding, DgBuilding, this.TbFeedbackBuilding);
            FillRecepiTab();
            if (i >= 1)
            {
                TbNameBuilding.Text = "";
                TbEnergie.Text = "";
            }
            conn.Close();

        }

        private void DeleteBuildings_Click(object sender, RoutedEventArgs e)
        {
            string name = CbDeleteBuilding.Text;

            SqlConection conn = new SqlConection(Properties.Resources.Connection);
            conn.Open(this.TbFeedbackBuilding);
            int i = conn.DeleteData("DELETE FROM Fabrik WHERE name = '" + name + "'", this.TbFeedbackBuilding);
            FillAll("Fabrik", CbDeleteBuilding, DgBuilding, this.TbFeedbackBuilding);
            FillRecepiTab();
            conn.Close();
        }

        // Rezept - Tab
        private void SaveRecepie_Click(object sender, RoutedEventArgs e)
        {
            string name = TbNameBuilding.Text;
            int isAlternative = (bool)CbIsAlternative.IsChecked ? 1 : 0;
            string productionTime = TbProductionTime.Text;
            string madeIn = CbMadeIn.Text;

            SqlConection conn = new SqlConection(Properties.Resources.Connection);
            conn.Open(this.TbFeedbackRecepi);
            int general = conn.SetData("INSERT INTO Rezept (name, isAlternative, productionTime, producedIn) VALUES ('" + name + "', " + isAlternative + ", " + Int32.Parse(productionTime) + ", '" + madeIn + "');", this.TbFeedbackRecepi);
            DataTable testRes = conn.GetDataTable("SELECT " + name + " FROM Ressource");
            if (isAlternative == 0 && testRes == null)
            {
                int i = conn.SetData("INSERT INTO Ressource (name, isOre) VALUES ('" + name + "', 0);");
                FillAll("Ressource", CbDeleteRessource, DgRessourcen, this.TbFeedbackRecepi);
            }
            FillRecepiTab();
            
            string input1 = CbInput_1.Text;
            string input1_PM = TbInput_1_PerMin.Text;
            string input2 = CbInput_2.Text;
            string input2_PM = TbInput_2_PerMin.Text;
            string input3 = CbInput_3.Text;
            string input3_PM = TbInput_3_PerMin.Text;
            string input4 = CbInput_4.Text;
            string input4_PM = TbInput_4_PerMin.Text;

            string output1 = TbOutput_1.Text;
            string output1_PM = TbOutput_1_PerMin.Text;
            string output2 = TbOutput_2.Text;
            string output2_PM = TbOutput_2_PerMin.Text;

            int oneIn = conn.SetData("INSERT INTO RessourceRezept (ressourceName, rezeptName, ressourcePerMin, isOutput) VALUES ('" + input1 + "', '" + name + "', " + Int32.Parse(input1_PM) + ", 0);", this.TbFeedbackBuilding);
            int oneOut = conn.SetData("INSERT INTO RessourceRezept (ressourceName, rezeptName, ressourcePerMin, isOutput) VALUES ('" + output1 + "', '" + name + "', " + Int32.Parse(output1_PM) + ", 1);", this.TbFeedbackBuilding);
            if (general >= 1)
            {
                TbNameRecepi.Text = "";
                TbProductionTime.Text = "";
                CbMadeIn.Text = "";
                CbIsAlternative.IsChecked = false;
            }
            if (oneIn >= 1)
            {
                CbInput_1.Text = "";
                TbInput_1_PerMin.Text = "";
            }
            if (oneOut >= 1)
            {
                TbOutput_1.Text = "";
                TbOutput_1_PerMin.Text = "";
            }

            if (input2 != "")
            {
                int twoIn = conn.SetData("INSERT INTO RessourceRezept (ressourceName, rezeptName, ressourcePerMin, isOutput) VALUES ('" + input2 + "', '" + name + "', " + Int32.Parse(input2_PM) + ", 0);", this.TbFeedbackBuilding);
                if (twoIn >= 1)
                {
                    CbInput_2.Text = "";
                    TbInput_2_PerMin.Text = "";
                }
            }
            if (input3 != "")
            {
                int threeIn = conn.SetData("INSERT INTO RessourceRezept (ressourceName, rezeptName, ressourcePerMin, isOutput) VALUES ('" + input3 + "', '" + name + "', " + Int32.Parse(input3_PM) + ", 0);", this.TbFeedbackBuilding);
                if (threeIn >= 1)
                {
                    CbInput_3.Text = "";
                    TbInput_3_PerMin.Text = "";
                }
            }
            if (input4 != "")
            {
                int fourIn = conn.SetData("INSERT INTO RessourceRezept (ressourceName, rezeptName, ressourcePerMin, isOutput) VALUES ('" + input4 + "', '" + name + "', " + Int32.Parse(input4_PM) + ", 0);", this.TbFeedbackBuilding);
                if (fourIn >= 1)
                {
                    CbInput_4.Text = "";
                    TbInput_4_PerMin.Text = "";
                }
            }
            if (output2 != "")
            {
                int twoOut = conn.SetData("INSERT INTO RessourceRezept (ressourceName, rezeptName, ressourcePerMin, isOutput) VALUES ('" + output2 + "', '" + name + "', " + Int32.Parse(output2_PM) + ", 1);", this.TbFeedbackBuilding);
                if (twoOut >= 1)
                {
                    TbOutput_1.Text = "";
                    TbOutput_1_PerMin.Text = "";
                }
            }

            if (oneOut >= 1)
            {
                CbInput_1.Text = "";
                TbInput_1_PerMin.Text = "";
            }
            conn.Close();

        }

        private void DeleteRecepie_Click(object sender, RoutedEventArgs e)
        {
            string name = CbDeleteBuilding.Text;

            SqlConection conn = new SqlConection(Properties.Resources.Connection);
            conn.Open(this.TbFeedbackBuilding);
            int i = conn.DeleteData("DELETE FROM Fabrik WHERE name = '" + name + "'", this.TbFeedbackBuilding);
            FillAll("Fabrik", CbDeleteBuilding, DgBuilding, this.TbFeedbackBuilding);
            conn.Close();
        }
        // Allgemein 
        private void FillAll(string Tabelle, ComboBox cb, DataGrid dg, TextBlock fl)
        {
            SqlConection conn = new SqlConection(Properties.Resources.Connection);
            conn.Open(fl);
            dg.ItemsSource = conn.GetDataTable("SELECT * FROM " + Tabelle).DefaultView;
            cb.Items.Clear();
            DataTable dt = conn.GetDataTable("SELECT name FROM " + Tabelle);
            foreach (DataRow row in dt.Rows)
            {
                cb.Items.Add(row.ItemArray[0]);
            }
            conn.Close();
        }

        private void FillRecepiTab()
        {
            SqlConection conn = new SqlConection(Properties.Resources.Connection);
            conn.Open(this.TbFeedbackRecepi);
            DgRezepte.ItemsSource = conn.GetDataTable("SELECT * FROM Rezept").DefaultView;

            CbInput_1.Items.Clear();
            CbInput_2.Items.Clear();
            CbInput_3.Items.Clear();
            CbInput_4.Items.Clear();
            CbMadeIn.Items.Clear();

            DataTable dtRes = conn.GetDataTable("SELECT name FROM Ressource");
            foreach (DataRow row in dtRes.Rows)
            {
                CbInput_1.Items.Add(row.ItemArray[0]);
                CbInput_2.Items.Add(row.ItemArray[0]);
                CbInput_3.Items.Add(row.ItemArray[0]);
                CbInput_4.Items.Add(row.ItemArray[0]);
            }
            DataTable dtBuild = conn.GetDataTable("SELECT name FROM Fabrik");
            foreach (DataRow row in dtBuild.Rows)
            {
                CbMadeIn.Items.Add(row.ItemArray[0]);
            }

            conn.Close();
        }

        public void FillOutput1(object sender, RoutedEventArgs e)
        {
            TbOutput_1.Text = TbNameRecepi.Text;
            var x = 2;
        }

        private void NumberValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }

        private void BtnMainMenu(object sender, RoutedEventArgs e)
        {
            Switcher.Switch(new UCMenu());
        }
    }
}
