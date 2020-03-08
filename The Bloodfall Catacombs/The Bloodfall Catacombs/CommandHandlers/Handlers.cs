using System.Collections.Generic;
using System.Linq;
using The_Bloodfall_Catacombs.Rooms;
using The_Bloodfall_Catacombs.State;
using static System.Console;

namespace The_Bloodfall_Catacombs.CommandHandlers
{
	public class Handlers
	{
		public static void HandleLookCommand(GameState gameState, IEnumerable<string> arguments)
		{
			WriteLine(gameState.Look());
		}

		public static void HandleMoveCommand(GameState gameState, IEnumerable<string> arguments)
		{
			var direction = arguments.FirstOrDefault();
			string response;
			switch (direction)
			{
				case "north":
					response = gameState.Move(ExitDirection.North);
					break;
				case "south":
					response = gameState.Move(ExitDirection.South);
					break;
				case "east":
					response = gameState.Move(ExitDirection.East);
					break;
				case "west":
					response = gameState.Move(ExitDirection.West);
					break;
				default:
					response = "That is NOT a direction. Silly person.";
					break;
			}

			WriteLine(response);
		}

		public static void HandleBadCommand(GameState arg1, IEnumerable<string> arg2)
		{
			WriteLine("I do not know how to do this.");
		}
	}
}