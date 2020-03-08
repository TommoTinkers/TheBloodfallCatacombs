using System.Linq;
using The_Bloodfall_Catacombs.CommandHandlers;
using The_Bloodfall_Catacombs.Commands;
using The_Bloodfall_Catacombs.Objects;
using The_Bloodfall_Catacombs.Rooms;
using The_Bloodfall_Catacombs.State;
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

			var skeleton = new Thing("Skeleton", "Its a skeleton. It looks like it has been here for a long time.",
				false);
			var key = new Thing("Key", "A large iron key.", true);
			
			cell.SetExits((ExitDirection.North, corridor));
			cell.AddThings(skeleton, key);
			
			corridor.SetExits((ExitDirection.South, cell));
			
			gameState = CreateGameState(cell);
			
			while (true)
			{
				var input = GetLine();
				var words = input.Split(' ');

				var commandInput = words.FirstOrDefault();
				var arguments = words.Skip(1);
				
				if (commandInput == string.Empty)
				{
					WriteLine("Please enter something!");
					continue;
				}

				var command = CommandParser.GetCommand(commandInput);
				gameState.ExecuteCommand(command, arguments);
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
			commandHandler.AddCommandHandler(Command.BadCommand, Handlers.HandleBadCommand);

			return commandHandler;
		}
	}
}