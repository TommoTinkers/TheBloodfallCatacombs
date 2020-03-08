using System;
using System.Collections.Generic;
using The_Bloodfall_Catacombs.State;

namespace The_Bloodfall_Catacombs
{
	public enum Command
	{
		Look,
		Move,
		BadCommand
	}
	
	public class CommandHandler
	{
		private readonly Dictionary<Command, Action<GameState, IEnumerable<string>>> commandHandlers = new Dictionary<Command, Action<GameState, IEnumerable<string>>>();

		public void AddCommandHandler(Command command, Action<GameState, IEnumerable<string>> handler)
		{
			if (commandHandlers.ContainsKey(command))
			{
				commandHandlers[command] += handler;
				return;
			}

			commandHandlers[command] = handler;
		}

		public void ExecuteCommand(Command command, GameState gameState, IEnumerable<string> arguments)
		{
			if (commandHandlers.ContainsKey(command))
			{
				commandHandlers[command]?.Invoke(gameState, arguments);
			}
		}
	}
}