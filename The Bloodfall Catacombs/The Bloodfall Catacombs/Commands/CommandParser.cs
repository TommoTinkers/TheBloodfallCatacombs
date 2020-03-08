namespace The_Bloodfall_Catacombs.Commands
{
	public class CommandParser
	{
		public static Command GetCommand(string enteredCommand)
		{
			switch (enteredCommand)
			{
				case "look":
					return Command.Look;
				case "move":
					return Command.Move;
				default:
					return Command.BadCommand;
			}
		}
	}
}