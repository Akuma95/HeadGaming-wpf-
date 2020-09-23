using HeadGaming_wpf_.DB;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace HeadGaming_wpf_.Rezepte
{
    class RezeptSql
    {
        private SqlConection _conn;
        public RezeptSql()
        {
            _conn = new SqlConection(Properties.Resources.Connection);
            _conn.Open();
        }

        public void OpenSql()
        {
            if (!_conn.IsOpen())
            {
                _conn.Open();
            }
        }
        public void CloseSql()
        {
            if (_conn.IsOpen())
            {
                _conn.Close();
            }
        }

        /**
         * Holt dich aus der Datenbank das jeweilige Rezept und alle dazugehörigen Komponenten.
         * 
         * string name - Der Name des Rezeptes
         */
        public ArrayList GetRezepte(string name)
        {
            ArrayList rezeptListe = new ArrayList();
            DataTable rezeptTable;

            
                
                rezeptListe.Add("");

            do
            {
                rezeptTable = _conn.GetDataTable("SELECT * FROM Rezepte WHERE name = " + name);


            } while ();

            return rezeptListe;
        }

        public Ressource GetRessource(string name)
        {
            Ressource ressource = new Ressource();

            DataTable dt = _conn.GetDataTable("SELECT * FROM Ressource WHERE name = " + name);

            ressource.Name = dt.Rows[0].ToString();
            ressource.IsOre = dt.Rows[1].Equals(1);

            return ressource;
        }

        public Building GetBuilding(string buildingName)
        {
            Building building = new Building();

            DataTable dt = _conn.GetDataTable("SELECT * FROM Fabrik WHERE name = " + buildingName);

            building.Name = dt.Rows[0].ToString();
            building.Energie = int.Parse(dt.Rows[1].ToString());

            return building;
        }
    }
}
