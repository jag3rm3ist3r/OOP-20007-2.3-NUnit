using System.Collections.Generic;


namespace _2._3P_NUnit
{
	class Location : GameObject, IHaveInventory, IHaveDefaultIdents
	{
		// Private
		// Variables
		Inventory _inventory;

		// Functions
		// Public
		// Variables
		public Inventory Inventory { get { return _inventory; } }
		// Functions
		public GameObject Locate(string id)
		{
			if (AreYou(id))
			{
				// We are id.
				return this;
			}
			else
			{
				// Look through inventory for id.
				return _inventory.Fetch(id);
				// Non recursive, don't look inside your inventory.
				//return null;
			}
		}
		// Constructor
		public Location(List<string> idents, string name, string desc) : base(IHaveDefaultIdents.ModifyIdents(idents, "location"), name, desc)
		{
			_inventory = new Inventory();
		}
	}
}
