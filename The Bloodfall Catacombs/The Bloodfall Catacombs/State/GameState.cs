using The_Bloodfall_Catacombs.Rooms;
using The_Bloodfall_Catacombs.Utils;

namespace The_Bloodfall_Catacombs.State
{
	public class GameState
	{
		public IBindableProperty<Room> CurrentRoom => currentRoom;
		private readonly BindableProperty<Room> currentRoom = new BindableProperty<Room>();
		
		public GameState(Room firstRoom)
		{
			currentRoom.Value = firstRoom;
		}

		public string Look() => currentRoom.Value.Description;
	}
}