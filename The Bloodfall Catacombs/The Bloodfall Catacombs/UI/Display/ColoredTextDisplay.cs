using System;
using System.Collections.Generic;
using System.Linq;
using static System.Console;

namespace The_Bloodfall_Catacombs.UI.Display
{
	public static class ColoredTextDisplay
	{
		private static Dictionary<string, ConsoleColor> _foregroundColorTags;
		public static void WriteColoredLine(string line)
		{
			if (_foregroundColorTags == null)
			{
				CreateForegroundColorTags();
			}
			var currentColor = ForegroundColor;
			for (var index = 0; index < line.Length; index++)
			{
				var character = line[index];
				if (character == '[')
				{
					var indexOfCloseTag = line.IndexOf(']', index);
					var tag = line.Substring(index + 1, indexOfCloseTag - index - 1);

					if (_foregroundColorTags.ContainsKey(tag))
					{
						ForegroundColor = _foregroundColorTags[tag];
					}
					else if (tag == "/")
					{
						ForegroundColor = currentColor;
					}
					else
					{
						throw new Exception($"Console color tag not defined: {tag}");
					}

					index = indexOfCloseTag;
				}
				else
				{
					Write(character);	
				}
				
			}
			Write('\n');
			ForegroundColor = currentColor;
		}

		private static void CreateForegroundColorTags()
		{
			var colors = Enum.GetValues(typeof(ConsoleColor)).Cast<ConsoleColor>();

			_foregroundColorTags = colors.ToDictionary(color => color.ToString().ToLower(), color => color);
		}
	}
}