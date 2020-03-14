using System.Collections.Generic;

namespace The_Bloodfall_Catacombs.Commands
{
	public static class ParserHelpers
	{
		public static IEnumerable<string> Prepositions => _prepositions;

		private static readonly List<string> _prepositions = new List<string>
		{
			"in",
			"on",
			"with"
		};

		public static bool IsPreposition(string argument)
		{
			return _prepositions.Contains(argument);
		}
	}
}