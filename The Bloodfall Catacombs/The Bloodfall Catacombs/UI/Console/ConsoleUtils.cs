namespace The_Bloodfall_Catacombs.UI.Console
{
	public static class ConsoleUtils
	{
		public static void SetWindowTitleToCurrentLocation(string location)
		{
			System.Console.Title = $"{GameInfo.GAME_TITLE} - Current location: '{location}'";
		}
	}
}