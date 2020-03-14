using static The_Bloodfall_Catacombs.UI.Display.TextDisplayer;
using static System.Console;

namespace The_Bloodfall_Catacombs.UI.Console
{
	public static class ConsoleUtils
	{
		public static void SetWindowTitleToCurrentLocation(string location)
		{
			Title = $"{GameInfo.GAME_TITLE} - Current location: '{location}'";
		}
		
		public static string GetLine(string prompt = null)
		{
			if (prompt != null)
			{
				DisplayLine(prompt);
			}
			
			Write("->");
			var input = ReadLine().ToLowerInvariant();
			return input;
		}
	}
}