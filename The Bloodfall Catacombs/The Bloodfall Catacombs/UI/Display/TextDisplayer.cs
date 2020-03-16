using System;
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
			switch (outputType)
			{
				case OutputType.Normal:
					ColoredTextDisplay.WriteColoredLine(line);
					break;
				case OutputType.Center:
					WriteCentered(line);
					break;
			}
		}

		private static void WriteCentered(string line)
		{
			var lengthOfContent = line.Length;
			var widthOfScreen = WindowWidth;
			var middle = widthOfScreen / 2;

			var startPoint = middle - (lengthOfContent / 2);
			
			SetCursorPosition(startPoint, CursorTop);
			ColoredTextDisplay.WriteColoredLine(line);
		}


	}
}