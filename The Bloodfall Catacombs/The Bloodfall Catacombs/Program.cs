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
			var gameState = CreateGameState(cell);

			while (true)
			{
				Write("->");
				var input = ReadLine();

				if (input == "look")
				{
					WriteLine(gameState.Look());
				}
			}
		}

		private static GameState CreateGameState(Room cell)
		{
			var gameState = new GameState(cell);
			gameState.CurrentRoom.RegisterHandlerAndCallIt(room => ConsoleUtils.SetWindowTitleToCurrentLocation(room.Name));
			return gameState;
		}
	}
}