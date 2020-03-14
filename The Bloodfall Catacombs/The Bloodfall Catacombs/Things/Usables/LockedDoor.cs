using System.Collections.Generic;
using The_Bloodfall_Catacombs.Rooms;
using The_Bloodfall_Catacombs.State;
using static The_Bloodfall_Catacombs.UI.Display.TextDisplayer;

namespace The_Bloodfall_Catacombs.Things.Usables
{
	public class LockedDoor : Thing, IUsable, IUsableWith
	{
		private readonly Thing key;
		private bool isLocked = true;
		private Room exit;

		public LockedDoor(string name, string description, bool isTakeable, Thing key, Room exit) : base(name, description, isTakeable)
		{
			this.key = key;
			this.exit = exit;
		}

		public void Use(GameState gameState, IEnumerable<string> args)
		{
			if (isLocked)
			{
				DisplayLine("This door is locked.");
				return;
			}
			
			DisplayLine($"YOU USED THE {Name}");
			gameState.MoveTo(exit);
		}

		public void UseThingOn(Thing thing)
		{
			if (thing == key)
			{
				isLocked = false;
				DisplayLine("You turn the key in the lock, and are rewarded with the sound of the bolt releasing.");
				return;
			}
			DisplayLine("This has no effect.");
		}
	}
}