using System.Collections.Generic;
using System.Linq;
using The_Bloodfall_Catacombs.Rooms;
using The_Bloodfall_Catacombs.State;
using The_Bloodfall_Catacombs.Utils.Extensions;
using The_Bloodfall_Catacombs.Utils.Extensions.GameStateExtensions;
using static System.Console;

namespace The_Bloodfall_Catacombs.CommandHandlers
{
	public class Handlers
	{
		public static void HandleLookCommand(GameState gameState, IEnumerable<string> arguments)
		{
			WriteLine(gameState.Look());
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

			WriteLine(response);
		}

		public static void HandleBadCommand(GameState arg1, IEnumerable<string> arg2)
		{
			WriteLine("I do not know how to do this.");
		}

		public static void HandleDropCommand(GameState gameState, IEnumerable<string> arguments)
		{
			var nameOfThingInput = arguments.FirstOrDefault();
			var objectToDrop = gameState.PlayerState.Inventory.Things.GetThingByName(nameOfThingInput);
			
			if (objectToDrop == null)
			{
				WriteLine("You are not carrying that.");
				return;
			}
			
			gameState.CurrentRoom.Value.AddThings(objectToDrop);
			gameState.PlayerState.Inventory.RemoveThing(objectToDrop);
			WriteLine($"You dropped the {objectToDrop.Name}!");
		}

		public static void HandleTakeCommand(GameState gameState, IEnumerable<string> arguments)
		{
			var nameOfThingInput = arguments.FirstOrDefault();
			var objectToTake = gameState.CurrentRoom.Value.Things.GetThingByName(nameOfThingInput);
			if (objectToTake == null)
			{
				WriteLine($"There is no {nameOfThingInput} here.");
				return;
			}
			if (!objectToTake.IsTakeable)
			{
				WriteLine("You cannot take that");
			}
			else
			{
				gameState.CurrentRoom.Value.RemoveThing(objectToTake);
				gameState.PlayerState.Inventory.AddThings(objectToTake);
				WriteLine($"You took the {objectToTake.Name}!");
			}
		}

		public static void HandleInventoryCommand(GameState gameState, IEnumerable<string> arguments)
		{
			WriteLine($"You are carrying...{gameState.PlayerState.Inventory.GetThingsDescription()}");
		}

		public static void HandleLookAtCommand(GameState gameState, IEnumerable<string> arguments)
		{
			var subject = arguments.FirstOrDefault();
			if (string.IsNullOrWhiteSpace(subject))
			{
				WriteLine("Look at what?");
				return;
			}

			var things = gameState.GetAllThingsUserCanInteractWith();
			var thingToLookAt = things.FirstOrDefault(t => t.Name.ToLower() == subject);
			if (thingToLookAt == null)
			{
				WriteLine($"I can't see a {subject} anywhere.");
				return;
			}
			WriteLine(thingToLookAt.Description);
		}
	}
}