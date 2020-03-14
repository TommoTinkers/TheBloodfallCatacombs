using System.Collections.Generic;
using The_Bloodfall_Catacombs.State;

namespace The_Bloodfall_Catacombs.Things.Usables
{
	public interface IUsable
	{
		void Use(GameState gameState, IEnumerable<string> args);
	}
}