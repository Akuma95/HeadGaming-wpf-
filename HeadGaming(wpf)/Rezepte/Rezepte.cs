using System;
using System.Data;
using HeadGaming_wpf_.DB;

namespace HeadGaming_wpf_.Rezepte
{
	public class Rezepte
	{
		private string rezeptName;
		private string ressourcenName;
		private string building;

		private int ressourcePerMin;
		private int productionTime;

		private bool isOutput;
		private bool isAlternative;

		public Rezepte()
		{
		}

		public string getRezeptname()
		{
			return rezeptName;
		}
	}
}
