namespace _2._3P_NUnit
{
	interface IHaveInventory
	{
		// Private
		// Variables
		// Functions
		// Public
		// Variables
		public string Name { get; }
		public Inventory Inventory { get; }
		// Functions
		public GameObject Locate(string id);
	}
}
