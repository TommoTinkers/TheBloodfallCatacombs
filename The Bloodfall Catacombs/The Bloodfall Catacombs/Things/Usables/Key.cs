using System.Collections.Generic;
using System.Linq;
using The_Bloodfall_Catacombs.Commands;
using The_Bloodfall_Catacombs.State;
using The_Bloodfall_Catacombs.Utils.Extensions;
using The_Bloodfall_Catacombs.Utils.Extensions.GameStateExtensions;
using static System.Console;
namespace The_Bloodfall_Catacombs.Things.Usables
{
	public class Key : Thing, IUsable
	{
		public Key(string name, string description, bool isTakeable) : base(name, description, isTakeable)
		{
		}

		public void Use(GameState gameState, IEnumerable<string> args)
		{
			var preposition = args.FirstOrDefault();

			if (preposition == null)
			{
				WriteLine($"Use {Name} with what?");
				return;
			}

			if (!ParserHelpers.IsPreposition(preposition)) return;
			
			var subjectName = args.Skip(1).FirstOrDefault();
			var subject = gameState.GetAllThingsUserCanInteractWith().GetThingByName(subjectName);
			if (subject == null)
			{
				WriteLine($"I can't see a {subject} anywhere.");
				return;
			}
				
			if(!(subject is IUsableWith usable))
			{
				WriteLine($"You cannot use the {Name} with the {subject.Name}.");
				return;
			}
				
			usable.UseThingOn(this);
		}
	}
}