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
	}
}