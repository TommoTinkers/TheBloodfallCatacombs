using The_Bloodfall_Catacombs.Rooms;
using The_Bloodfall_Catacombs.State;
using The_Bloodfall_Catacombs.UI.Console;
using static System.Console;

namespace The_Bloodfall_Catacombs
{
	internal static class Program
	{
		public static void Main()
		{
			WriteLine("Welcome to THE BLOODFALL CATACOMBS");
			var cell = new Room("Cell", "A small cell with no windows");
			var corridor = new Room("Corridor", "A fittingly omnious corridor, seemingly endless in both directions." );
			
			cell.SetExits((ExitDirection.North, corridor));
			corridor.SetExits((ExitDirection.South, cell));
			
			var gameState = CreateGameState(cell);

			while (true)
			{
				var input = GetLine();

				if (input == "look")
				{
					WriteLine(gameState.Look());
				}

				if (input == "move")
				{
					var direction = GetLine("In which direction?");
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
			}
		}

		private static string GetLine(string prompt = null)
		{
			if (prompt != null)
			{
				WriteLine(prompt);
			}
			
			Write("->");
			var input = ReadLine().ToLowerInvariant();
			return input;
		}

		private static GameState CreateGameState(Room cell)
		{
			var gameState = new GameState(cell);
			gameState.CurrentRoom.RegisterHandlerAndCallIt(room => ConsoleUtils.SetWindowTitleToCurrentLocation(room.Name));
			return gameState;
		}
	}
}