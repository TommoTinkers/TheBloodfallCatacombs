using System.Collections.Generic;
using System.Linq;
using The_Bloodfall_Catacombs.State;
using The_Bloodfall_Catacombs.Things;

namespace The_Bloodfall_Catacombs.Utils.Extensions.GameStateExtensions
{
	public static class ThingHelpers
	{
		public static IEnumerable<Thing> GetAllThingsUserCanInteractWith(this GameState gameState)
		{
			return gameState.CurrentRoom.Value.Things.Concat(gameState.PlayerState.Inventory.Things);
		}

		public static string GetDisplayString(this IEnumerable<Thing> things, string displayIfNone = "",
			string displayIfOne = null, string displayIfSome = null)
		{
			
			var count = things.Count();
			
			switch (count)
			{
				case 0:
					return displayIfNone;
				case 1:
					return $"{displayIfOne} {things.Single().Name}";
			}
			
			return $"{displayIfSome}\n" +
			things.Select(t => t.Name).Aggregate((a, b) => $"{a}\n{b}");
		}
	}
}