using System.Collections.Generic;
using System.Linq;
using The_Bloodfall_Catacombs.Objects;

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

		private readonly List<Thing> things = new List<Thing>();

		public IEnumerable<Thing> Things => things;

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

		public void AddThings(params Thing[] thingsToAdd)
		{
			things.AddRange(thingsToAdd);
		}

		public void RemoveThing(Thing thingToRemove)
		{
			things.Remove(thingToRemove);
		}

		public string LookDescription()
		{
			return $"{Description}\nIn this room there are: {GetThingsDescription()}";
		}

		private string GetThingsDescription()
		{
			return things.Select(t => t.Name).Aggregate(string.Empty, (a, b) => $"{a}\n{b}");
		}
	}
}