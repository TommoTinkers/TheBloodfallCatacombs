using System;
using System.Collections.Generic;
using System.Text;

namespace The_Bloodfall_Catacombs.UI.Display
{
	public class TagParsedText
	{
		public string DisplayText { get; }
		public IEnumerable<Tag> Tags { get; }
		
		public TagParsedText(string displayText, IEnumerable<Tag> tags)
		{
			DisplayText = displayText;
			Tags = tags;
		}
	}

	public class Tag
	{
		public string Label { get; }
		public int Index { get; }

		public Tag(string label, int index)
		{
			Label = label;
			Index = index;
		}
	}
	
	public class TextTagParser
	{
		public static TagParsedText Parse(string text)
		{
			var stringBuilder = new StringBuilder();
			var tags = new List<Tag>();
			var totalTagLength = 0;
			for (var index = 0; index < text.Length; index++)
			{
				var character = text[index];
				if (character == '[')
				{
					var tagStart = index;
					
					var indexOfCloseTag = text.IndexOf(']', index);
					var tagText = text.Substring(index + 1, indexOfCloseTag - index - 1);
					
					tags.Add(new Tag(tagText, tagStart - totalTagLength));
					index = indexOfCloseTag;
					totalTagLength += tagText.Length + 2;
				}
				else
				{
					stringBuilder.Append(character);
				}
				
			}
			
			return new TagParsedText(stringBuilder.ToString(), tags);

		}
	}
}