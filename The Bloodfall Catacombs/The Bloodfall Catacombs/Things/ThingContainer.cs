using System.Collections.Generic;
using System.Linq;

namespace The_Bloodfall_Catacombs.Things
{
	public class ThingContainer
	{
		private readonly List<Thing> things = new List<Thing>();

		public IEnumerable<Thing> Things => things;
		
		public void AddThings(params Thing[] thingsToAdd)
		{
			things.AddRange(thingsToAdd);
		}

		public void RemoveThing(Thing thingToRemove)
		{
			things.Remove(thingToRemove);
		}

		public string GetThingsDescription()
		{
			return Things.Select(t => t.Name).Aggregate(string.Empty, (a, b) => $"{a}\n{b}");
		}
	}
}