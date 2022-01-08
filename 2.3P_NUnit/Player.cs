using System.Collections.Generic;

namespace _2._3P_NUnit
{
	class Player : GameObject, IHaveInventory
	{
		// Private
		// Variables
		private Inventory _inventory;
		private Location _location;

		// Public
		// Varaibles
		public Inventory Inventory
		{
			get { return _inventory; }
		}
		public Location Location
		{
			get { return _location; }
			set { _location = value; }
		}
		public override string FullDescription { get { return base.FullDescription; } }
		// Functions
		// Locate something with id within Player.
		// !!! THIS MAY RETURN NULL !!!
		public GameObject Locate(string id)
		{
			if( AreYou(id) || id.ToLower().Equals("inventory") )
			{
				// We are id.
				return this;
			}
			else
			{
				// Look through inventory for id.
				GameObject tmp = _inventory.Fetch(id);
				// If it wasn't there then check in the player's location.
				if(tmp == null && _location != null)
				{
					tmp = _location.Locate(id);
				}
				return tmp;
			}
		}

		// Constructor
		public Player(string name, string desc) : base( new List<string> { "me", "inventory" }, name, desc)
		{
			_inventory = new Inventory();
		}
	}
}
