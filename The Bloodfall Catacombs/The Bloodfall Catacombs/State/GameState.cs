using System.Collections.Generic;
using The_Bloodfall_Catacombs.Rooms;
using The_Bloodfall_Catacombs.Utils;

namespace The_Bloodfall_Catacombs.State
{
	public class GameState
	{
		public IBindableProperty<Room> CurrentRoom => currentRoom;
		
		public CommandHandler CommandHandler { get; }

		private readonly BindableProperty<Room> currentRoom = new BindableProperty<Room>();
		
		public GameState(Room firstRoom, CommandHandler commandHandler)
		{
			CommandHandler = commandHandler;
			currentRoom.Value = firstRoom;
		}

		public void ExecuteCommand(Command command, IEnumerable<string> arguments)
		{
			CommandHandler.ExecuteCommand(command, this, arguments );
		}
		
		public string Look() => currentRoom.Value.LookDescription();

		public string Move(ExitDirection direction)
		{
			var destinationRoom = currentRoom.Value[direction];
			if (destinationRoom == null)
			{
				return "There is no exit in that direction";
			}

			currentRoom.Value = destinationRoom;
			return $"You have moved into the {currentRoom.Value.Name}.";
		}
		
		
		
	}
}