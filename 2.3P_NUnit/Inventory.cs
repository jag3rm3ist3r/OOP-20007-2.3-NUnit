using System.Collections.Generic;

namespace _2._3P_NUnit
{
	class Inventory
	{
		// Private
		// Variables
		private List<Item> _items;

		// Public
		// Varaibles
		public string ItemList
		{
			get
			{
				string tmp = "";
				foreach( Item junk in _items )
				{
					tmp = tmp + "\t" + junk.ShortDescription + "\n";
				}
				return tmp;
			}
		}
		// Functions
		// Check if item is present.
		public bool HasItem(string id)
		{
			foreach( Item junk in _items )
			{
				if( junk.AreYou( id ) )
				{
					return true;
				}
			}
			return false;
		}
		// Put item into inventory.
		public void Put(Item itm)
		{
			_items.Add(itm);
		}
		// Take item out of inventory by id, return item.
		public Item Take(string id)
		{
			foreach( Item junk in _items )
			{
				if( junk.AreYou( id ) )
				{
					_items.Remove(junk);
					return junk;
				}
			}
			return null;
		}
		// Search for item by id, return item.
		// !!! THIS MAY RETURN NULL !!!
		public Item Fetch(string id)
		{
			foreach( Item junk in _items )
			{
				if( junk.AreYou( id ) )
				{
					return junk;
				}
			}
			return null;
		}


		// Constructor
		public Inventory()
		{
			_items = new List<Item>();
		}
	}
}
