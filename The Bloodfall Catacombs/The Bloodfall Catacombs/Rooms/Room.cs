using System.Collections.Generic;
using System.Linq;

namespace The_Bloodfall_Catacombs.Rooms
{
	public enum ExitDirection
	{
		North,
		South,
		East,
		West
	}
	public class Room
	{
		public string Name { get; }
		public string Description { get; }

		public Room this[ExitDirection direction]
		{
			get { return exits.FirstOrDefault(kvp => kvp.Key == direction).Value; }
			
		}
		private Dictionary<ExitDirection, Room> exits;

		public Room(string name, string description)
		{
			Name = name;
			Description = description;
		}

		public void SetExits(params (ExitDirection direction, Room room)[] exits)
		{
			this.exits = exits.ToDictionary(exit => exit.direction, exit => exit.room);
		}
	}
}