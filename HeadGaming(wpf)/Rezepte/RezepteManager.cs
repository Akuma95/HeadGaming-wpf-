using System;
using System.Collections.Generic;
using System.Text;

namespace HeadGaming_wpf_.Rezepte
{
    class RezepteManager
    {
        private Dictionary<string, Rezepte> rezepteListe;

        public RezepteManager()
        {
            rezepteListe = new Dictionary<string, Rezepte>();
        }

        public void addRezept(Rezepte rezept)
        {
            rezepteListe.Add(rezept.getRezeptname(), rezept);
        }

        public void removeRezept(Rezepte rezept)
        {
            rezepteListe.Remove(rezept.getRezeptname());
        }

        public bool isRezeptExist(Rezepte rezept)
        {
            return rezepteListe.ContainsValue(rezept);
        }
    }
}
