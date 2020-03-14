using System.Collections.Generic;
using System.Linq;
using The_Bloodfall_Catacombs.Rooms;
using The_Bloodfall_Catacombs.State;
using The_Bloodfall_Catacombs.Utils.Extensions;
using The_Bloodfall_Catacombs.Utils.Extensions.GameStateExtensions;
using static The_Bloodfall_Catacombs.UI.Display.TextDisplayer;

namespace The_Bloodfall_Catacombs.CommandHandlers
{
	public static class Handlers
	{
		public static void HandleLookCommand(GameState gameState, IEnumerable<string> arguments)
		{
			DisplayLine(gameState.CurrentRoom.Value.Description);
			DisplayLine(gameState.CurrentRoom.Value.Things.GetDisplayString("There is nothing in this room", "In this room there is a", "In here are the following things..."));
		}

		public static void HandleMoveCommand(GameState gameState, IEnumerable<string> arguments)
		{
			var direction = arguments.FirstOrDefault();
			string response;
			switch (direction)
			{
				case "north":
					response = gameState.Move(ExitDirection.North);
					break;
				case "south":
					response = gameState.Move(ExitDirection.South);
					break;
				case "east":
					response = gameState.Move(ExitDirection.East);
					break;
				case "west":
					response = gameState.Move(ExitDirection.West);
					break;
				default:
					response = "That is NOT a direction. Silly person.";
					break;
			}

			DisplayLine(response);
		}

		public static void HandleBadCommand(GameState arg1, IEnumerable<string> arg2)
		{
			DisplayLine("I do not know how to do this.");
		}

		public static void HandleDropCommand(GameState gameState, IEnumerable<string> arguments)
		{
			var nameOfThingInput = arguments.FirstOrDefault();
			var objectToDrop = gameState.PlayerState.Inventory.Things.GetThingByName(nameOfThingInput);
			
			if (objectToDrop == null)
			{
				DisplayLine("You are not carrying that.");
				return;
			}
			
			gameState.CurrentRoom.Value.AddThings(objectToDrop);
			gameState.PlayerState.Inventory.RemoveThing(objectToDrop);
			DisplayLine($"You dropped the {objectToDrop.Name}!");
		}

		public static void HandleTakeCommand(GameState gameState, IEnumerable<string> arguments)
		{
			var nameOfThingInput = arguments.FirstOrDefault();
			var objectToTake = gameState.CurrentRoom.Value.Things.GetThingByName(nameOfThingInput);
			if (objectToTake == null)
			{
				DisplayLine($"There is no {nameOfThingInput} here.");
				return;
			}
			if (!objectToTake.IsTakeable)
			{
				DisplayLine("You cannot take that");
			}
			else
			{
				gameState.CurrentRoom.Value.RemoveThing(objectToTake);
				gameState.PlayerState.Inventory.AddThings(objectToTake);
				DisplayLine($"You took the {objectToTake.Name}!");
			}
		}

		public static void HandleInventoryCommand(GameState gameState, IEnumerable<string> arguments)
		{
			DisplayLine(gameState.PlayerState.Inventory.Things.GetDisplayString("You are not carrying anything.",
				"You are carrying a", "You are carrying..."));
		}

		public static void HandleLookAtCommand(GameState gameState, IEnumerable<string> arguments)
		{
			var subject = arguments.FirstOrDefault();
			if (string.IsNullOrWhiteSpace(subject))
			{
				DisplayLine("Look at what?");
				return;
			}

			var things = gameState.GetAllThingsUserCanInteractWith();
			var thingToLookAt = things.FirstOrDefault(t => t.Name.ToLower() == subject);
			if (thingToLookAt == null)
			{
				DisplayLine($"I can't see a {subject} anywhere.");
				return;
			}
			DisplayLine(thingToLookAt.Description);
		}
	}
}