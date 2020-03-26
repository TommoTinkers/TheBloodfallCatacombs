using static System.Console;

namespace The_Bloodfall_Catacombs.UI.Display
{
	public enum OutputType
	{
		Normal,
		Center,
	}

	public static class TextDisplayer
	{
		public static void DisplayLine(string line, OutputType outputType = OutputType.Normal)
		{
			var tags = TextTagParser.Parse(line);
			
			switch (outputType)
			{
				case OutputType.Normal:
					ColoredTextDisplay.WriteColoredLine(tags);
					break;
				case OutputType.Center:
					WriteCenteredLine(tags);
					break;
			}
		}

		private static void WriteCenteredLine(TagParsedText tags)
		{
			var lengthOfContent = tags.DisplayText.Length;
			var widthOfScreen = WindowWidth;
			var middle = widthOfScreen / 2;

			var startPoint = middle - (lengthOfContent / 2);
			
			SetCursorPosition(startPoint, CursorTop);
			ColoredTextDisplay.WriteColoredLine(tags);
		}
	}
}