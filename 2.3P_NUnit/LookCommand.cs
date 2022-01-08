using System;
using System.Collections.Generic;

namespace _2._3P_NUnit
{
	class LookCommand : Command
	{
		// Private
		// Variables
		// Functions
		// Look for a container (containerid) in the player's (p) inventory.
		private IHaveInventory FetchContainer(Player p, string containerid)
		{
			IHaveInventory tmp = p.Locate(containerid) as IHaveInventory;
			if (tmp != null)
			{
				return tmp;
			}
			else
			{
				// Wasn't there.
				return null;
				//Console.WriteLine("I cannot find the {0}.", containerid);
			}
		}
		// Look for an item (thingid) in a container (hasinventory).
		string LookAtIn(string thingid, IHaveInventory hasinventory)
		{
			GameObject tmp = hasinventory.Locate(thingid);
			if (tmp != null)
			{
				return tmp.ShortDescription;
			}
			else
			{
				return "Could not find anything.";
				//Console.WriteLine("I cannot find the {0} in the {1}.", thingid, container);
			}
		}

		// Public
		// Variables
		// Functions
		public override string Execute(Player p, string[] text)
		{
			// Container we will look in.
			IHaveInventory container = null;
			// Item we are looking for.
			string item_id;
			// There must be either 3 or 5 elements in the array,
			//+otherwise reutrn error.
			if ( text.Length != 1 && text.Length != 3 && text.Length != 5 )
			{
				return "I don't know how to look like that.";
			}
			// The first word must be "look", otherwise return error.
			if ( false == text[0].ToLower().Equals("look") )
			{
				return "Error in look input.";
			}
			// If there is only one element "look" then the player looks at
			//+their current location.
			if (text.Length == 1)
			{
				return p.Location.ShortDescription;
			}
			// The second word must be "at", otherwise return error.
			if ( false == text[1].ToLower().Equals("at") )
			{
				return "What do you want to look at?";
			}
			// If there are 3 elements, the container is the player.
			if ( text.Length == 3 )
			{
				container = p as IHaveInventory;
			}
			// If there are 5 elements, then the container id is the 5th word.
			if ( text.Length == 5 )
			{
				container = FetchContainer( p, text[4].ToLower() );
			}
			// If container is set to null by this point then it mustn't exist.
			if (container == null)
			{
				return "I can't find the " + text[4] + ".";
			}
			else
			{
				// The item id is the 3rd word.
				item_id = text[2].ToLower();
				// Perform LookAtIn, with the container and the item id.
				return LookAtIn(item_id, container);
			}
		}

		// Always have the identity "look".
		static List<string> modifyIdents(List<string> m)
		{
			m.Add("look");
			return m;
		}
		public LookCommand(List<string> idents) : base(modifyIdents(idents)) { }
	}
}
