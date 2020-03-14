using System.Collections.Generic;

namespace The_Bloodfall_Catacombs.Things.Usables
{
	public interface IUsable
	{
		void Use(IEnumerable<string> args);
	}
}