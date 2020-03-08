using System.Collections.Generic;
using System.Linq;
using static System.Console;

namespace The_Bloodfall_Catacombs.Commands
{
	public class CommandParser
	{
		private static readonly Dictionary<string, Command> mapping = new Dictionary<string, Command>
		{
			{"look", Command.Look},
			{"move", Command.Move},
			{"go", Command.Move},
			{"take", Command.Take},
			{"drop", Command.Drop},
			{"inventory", Command.Inventory},
			{"look at", Command.LookAt}
		};
		
		public static (Command, IEnumerable<string>) GetCommand(string input)
		{
			var words = input.Split(' ').ToArray();
			var wordCount = words.Length;

			for (var x = wordCount; x >= 0; x--)
			{
				var (success, command) = TryGetCommand(words.Take(x));
				if (success)
				{
					return (command, words.Skip(x));
				}
			}

			return (Command.BadCommand, null);
		}

		private static (bool, Command) TryGetCommand(IEnumerable<string> input)
		{
			var commandInput = input.Aggregate(string.Empty, (a, b) => $"{a}{b} ").Trim();
			if (mapping.ContainsKey(commandInput))
			{
				return (true, mapping[commandInput]);
			}

			return (false, Command.BadCommand);
		}
	}
}