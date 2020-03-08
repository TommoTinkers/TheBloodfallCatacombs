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
				case "take":
					return Command.Take;
				case "inventory":
					return Command.Inventory;
				default:
					return Command.BadCommand;
			}
		}
	}
}