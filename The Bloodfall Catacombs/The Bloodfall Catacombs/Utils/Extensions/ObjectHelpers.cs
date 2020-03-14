using System.Collections.Generic;
using System.Linq;
using The_Bloodfall_Catacombs.Things;

namespace The_Bloodfall_Catacombs.Utils.Extensions
{
	public static class ObjectHelpers
	{
		public static Thing GetThingByName(this IEnumerable<Thing> things, string name)
		{
			if (string.IsNullOrEmpty(name))
			{

				return null;
			}
			
			var roomObjects = things;
			var thing = roomObjects.FirstOrDefault(o => o.Name.ToLower() == name);

			return thing;
		}
	}
}