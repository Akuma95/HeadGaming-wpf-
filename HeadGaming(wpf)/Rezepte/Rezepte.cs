using System;
using System.Collections;
using System.Data;
using HeadGaming_wpf_.DB;

namespace HeadGaming_wpf_.Rezepte
{
	public class Rezepte
	{
		public string RezeptName { get; set; }
		public ArrayList InputName { get; set; }
		public ArrayList OutputName { get; set; }
		public ArrayList InputPerMin { get; set; }
		public ArrayList OutputPerMin { get; set; }
		public Building Fabrik { get; set; }
		public Rezepte Vorgaenger { get; set; }
		public int ProductionTime { get; set; }

		public bool IsAlternative { get; set; }

		public Rezepte()
		{
		}
	}
}
