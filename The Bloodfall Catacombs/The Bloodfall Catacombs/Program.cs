using System.Collections.Generic;
using System.Linq;
using The_Bloodfall_Catacombs.CommandHandlers;
using The_Bloodfall_Catacombs.Rooms;
using The_Bloodfall_Catacombs.State;
using The_Bloodfall_Catacombs.UI.Console;
using static The_Bloodfall_Catacombs.UI.Console.ConsoleUtils;
using static System.Console;

namespace The_Bloodfall_Catacombs
{
	internal static class Program
	{
		private static GameState gameState;

		public static void Main()
		{
			WriteLine("Welcome to THE BLOODFALL CATACOMBS");
			var cell = new Room("Cell", "A small cell with no windows");
			var corridor = new Room("Corridor", "A fittingly omnious corridor, seemingly endless in both directions." );
			
			cell.SetExits((ExitDirection.North, corridor));
			corridor.SetExits((ExitDirection.South, cell));
			
			gameState = CreateGameState(cell);
			
			while (true)
			{
				var input = GetLine();
				var words = input.Split(' ');

				var command = words.FirstOrDefault();
				var arguments = words.Skip(1);
				
				if (command == string.Empty)
				{
					WriteLine("Please enter something!");
					continue;
				}

				ProcessCommand(command, arguments);

			}
		}

		private static void ProcessCommand(string command, IEnumerable<string> arguments)
		{
			switch (command)
			{
				case "look":
					gameState.ExecuteCommand(Command.Look, arguments);
					break;
				case "move":
					gameState.ExecuteCommand(Command.Move, arguments);
					break;
			}
		}
		
		private static GameState CreateGameState(Room cell)
		{
			var commandHandler = CreateCommandHandler();
			var state = new GameState(cell, commandHandler);
			
			state.CurrentRoom.RegisterHandlerAndCallIt(room => SetWindowTitleToCurrentLocation(room.Name));
			return state;
		}

		private static CommandHandler CreateCommandHandler()
		{
			var commandHandler = new CommandHandler();
			commandHandler.AddCommandHandler(Command.Look, Handlers.HandleLookCommand);
			commandHandler.AddCommandHandler(Command.Move, Handlers.HandleMoveCommand);

			return commandHandler;
		}
	}
}