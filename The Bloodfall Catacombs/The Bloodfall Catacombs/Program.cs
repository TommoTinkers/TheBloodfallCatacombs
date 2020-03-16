using System;
using The_Bloodfall_Catacombs.CommandHandlers;
using The_Bloodfall_Catacombs.Commands;
using The_Bloodfall_Catacombs.Rooms;
using The_Bloodfall_Catacombs.State;
using The_Bloodfall_Catacombs.Things;
using The_Bloodfall_Catacombs.Things.Usables;
using The_Bloodfall_Catacombs.UI.Display;
using static The_Bloodfall_Catacombs.UI.Console.ConsoleUtils;
using static The_Bloodfall_Catacombs.UI.Display.TextDisplayer;

namespace The_Bloodfall_Catacombs
{
	internal static class Program
	{
		private static GameState gameState;

		public static void Main()
		{
			SetupWindow();

			DisplayLine("[cyan]Welcome to", OutputType.Center);
			DisplayLine("[magenta]THE BLOODFALL CATACOMBS[/]", OutputType.Center);	
			var cell = new Room("Cell", "A small cell with no windows");
			var laboratory = new Room("Laboratory", "This room looks like a laboratory that has been smashed up.");
			var corridor = new Room("Corridor", "A fittingly omnious corridor, seemingly endless in both directions." );

			var skeleton = new Thing("Skeleton", "Its a skeleton. It looks like it has been here for a long time.",
				false);
			var key = new Key("Key", "A large iron key.", true);
			var banana = new Thing("Banana", "A banana disguised as an apple.", true);
			var door = new LockedDoor("Door", "A large wooden door with a keyhole", false, key, laboratory);
			
			laboratory.SetExits((ExitDirection.South, corridor));
			corridor.AddThings(door);
			cell.SetExits((ExitDirection.North, corridor));
			cell.AddThings(skeleton, key, banana);
			
			corridor.SetExits((ExitDirection.South, cell));
			
			gameState = CreateGameState(cell);
			
			while (true)
			{
				var input = GetLine();
				var (command, arguments) = CommandParser.GetCommand(input);
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
			commandHandler.AddCommandHandler(Command.Take, Handlers.HandleTakeCommand);
			commandHandler.AddCommandHandler(Command.Drop, Handlers.HandleDropCommand);
			commandHandler.AddCommandHandler(Command.Inventory, Handlers.HandleInventoryCommand);
			commandHandler.AddCommandHandler(Command.BadCommand, Handlers.HandleBadCommand);
			commandHandler.AddCommandHandler(Command.LookAt, Handlers.HandleLookAtCommand);
			commandHandler.AddCommandHandler(Command.Use, UseCommandHandler.HandleUseCommand);

			return commandHandler;
		}

		private static void SetupWindow()
		{
			Console.SetWindowSize(Console.LargestWindowWidth, Console.LargestWindowHeight);
		}
	}
}