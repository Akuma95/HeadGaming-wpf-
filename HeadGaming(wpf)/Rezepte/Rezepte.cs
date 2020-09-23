using System;
using System.Data;
using HeadGaming_wpf_.DB;

namespace HeadGaming_wpf_.Rezepte
{
	public class Rezepte
	{
		public string RezeptName { get; set; }
		public Ressource[] InputName { get; set; }
		public Ressource[] OutputName { get; set; }
		public Building Fabrik { get; set; }
		public Rezepte Vorgaenger { get; set; }
		public int RessourcePerMin { get; set; }
		public int ProductionTime { get; set; }

		public bool IsAlternative { get; set; }

		public Rezepte(string[] alternativen)
		{
		}
	}
}
