namespace The_Bloodfall_Catacombs.Things
{
	public class Thing
	{
		public string Name { get; }
		public string Description { get; }
		public bool IsTakeable { get; }

		public Thing(string name, string description, bool isTakeable)
		{
			Name = name;
			Description = description;
			IsTakeable = isTakeable;
		}
	}
}