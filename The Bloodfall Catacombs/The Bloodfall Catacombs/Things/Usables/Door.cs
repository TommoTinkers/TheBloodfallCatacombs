using System.Collections.Generic;
using static System.Console;

namespace The_Bloodfall_Catacombs.Things.Usables
{
	public class Door : Thing, IUsable
	{
		public Door(string name, string description, bool isTakeable) : base(name, description, isTakeable)
		{
		}

		public void Use(IEnumerable<string> args)
		{
			WriteLine($"YOU USED THE {nameof(Door)}");
		}
	}
}