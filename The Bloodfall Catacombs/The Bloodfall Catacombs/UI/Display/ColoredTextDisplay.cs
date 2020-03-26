using System;
using System.Collections.Generic;
using System.Linq;
using static System.Console;

namespace The_Bloodfall_Catacombs.UI.Display
{
	public static class ColoredTextDisplay
	{
		private static Dictionary<string, ConsoleColor> _foregroundColorTags;
		public static void WriteColoredLine(TagParsedText tags)
		{
			if (_foregroundColorTags == null)
			{
				CreateForegroundColorTags();
			}

			var currentForegroundColor = ForegroundColor;
			
			for (var index = 0; index < tags.DisplayText.Length; index++)
			{
				var tag = tags.Tags.FirstOrDefault(t => t.Index == index);
				if (tag != null)
				{
					if (_foregroundColorTags.ContainsKey(tag.Label))
					{
						ForegroundColor = _foregroundColorTags[tag.Label];
					}
				}
				
				var character = tags.DisplayText[index];
				Write(character);
			}

			Write('\n');
			ForegroundColor = currentForegroundColor;
		}

		private static void CreateForegroundColorTags()
		{
			var colors = Enum.GetValues(typeof(ConsoleColor)).Cast<ConsoleColor>();
			
			_foregroundColorTags = colors.ToDictionary(color => color.ToString().ToLower(), color => color);
		}
	}
}