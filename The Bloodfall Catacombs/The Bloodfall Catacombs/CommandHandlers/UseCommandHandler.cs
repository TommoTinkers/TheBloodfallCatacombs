using System.Collections.Generic;
using System.Linq;
using The_Bloodfall_Catacombs.State;
using The_Bloodfall_Catacombs.Things.Usables;
using The_Bloodfall_Catacombs.Utils.Extensions;
using The_Bloodfall_Catacombs.Utils.Extensions.GameStateExtensions;
using static The_Bloodfall_Catacombs.UI.Display.TextDisplayer;
namespace The_Bloodfall_Catacombs.CommandHandlers
{
	public class UseCommandHandler
	{
		public static void HandleUseCommand(GameState gameState, IEnumerable<string> arguments)
		{
			var thingToUseInput = arguments.FirstOrDefault();

			var allTheThings = gameState.GetAllThingsUserCanInteractWith();
			
			var thingToUse = allTheThings.GetThingByName(thingToUseInput);

			if (thingToUse == null)
			{
				DisplayLine($"I can't see a {thingToUseInput} anywhere.");
				return;
			}

			if(!(thingToUse is IUsable usable))
			{
				DisplayLine("You cannot use this.");
				return;
			}
			usable.Use(gameState, arguments.Skip(1));
		}
	}
}