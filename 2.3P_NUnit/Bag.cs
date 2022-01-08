using System.Collections.Generic;


namespace _2._3P_NUnit
{
	class Bag : Item, IHaveInventory
	{
		// Private
		// Variables
		private Inventory _inventory;

		// Public
		// Variables
		public Inventory Inventory
		{
			get { return _inventory; }
		}
		public override string FullDescription { get { return base.FullDescription; } }
		// Functions
		// Locate something with id within this bag.
		// !!! THIS MAY RETURN NULL !!!
		public GameObject Locate(string id)
		{
			if(AreYou(id))
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
		public Bag(List<string> idents, string name, string desc) : base( idents, name, desc )
		{
			_inventory = new Inventory();
		}
		public Bag(string name, string desc) : base( new List<string> { "bag", "inventory" }, name, desc)
		{
			_inventory = new Inventory();
		}
	}
}
