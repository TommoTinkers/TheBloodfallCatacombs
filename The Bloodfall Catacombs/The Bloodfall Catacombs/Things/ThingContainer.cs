using System.Collections.Generic;

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
	}
}