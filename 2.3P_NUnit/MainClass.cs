using System.Collections.Generic;


namespace _2._3P_NUnit
{
	class MainClass
	{
		public static void Main(string[] args)
		{
			// Title.
			System.Console.WriteLine("Welcome to Swin-Adventure!\n\n\n");


			// Get name.
			string usr_input = "";
			System.Console.WriteLine("Please enter your name: ");
			usr_input = System.Console.ReadLine();
			// Some validation here???
			string username = usr_input;


			// Get description.
			System.Console.WriteLine("Hello {0}, please write a description for yourself: ", usr_input);
			usr_input = System.Console.ReadLine();
			// Some validation here???
			string userdesc = usr_input;


			// Create player object.
			Player p = new Player(username, userdesc);
			// Create location for player and put the player there.
			Location cave = new Location(
				new List<string> { "cave" },
				"Cave",
				"A damp, dark cave.");
			p.Location = cave;

			// Create an item and place it in the cave.
			p.Location.Inventory.Put(new Item(
				new List<string> { "rock" },
				"Rock",
				"A small rock."));

			// Give player two starting items.
			// Sword.
			p.Inventory.Put(new Item(
				new List<string> {"sword", "steel", "weapon" },
				"Steel Shortsword",
				"A steel shortsword."));
			// Healing potion.
			p.Inventory.Put(new Item(
				new List<string> { "potion", "healing", "bottle", "alchemy" },
				"Healing Potion",
				"A small healing potion."));

			// Create a bag for the player.
			Bag tmp_bag = new Bag(
				new List<string> { "bag", "container" },
				"Small Bag",
				"A small bag for holding items.");
			p.Inventory.Put(tmp_bag);

			// Create an item for the player inside the bag.
			tmp_bag.Inventory.Put(new Item(
				new List<string> { "fork", "steel", "utensil" },
				"Fork of Horripilation",
				"The Fork smells lightly of roast beef."));

			// Create look command.
			LookCommand look = new LookCommand(new List<string> { });

			// Start the game.
			System.Console.WriteLine("You are in a ");
			System.Console.WriteLine(p.Location.Name);
			System.Console.WriteLine(", you have: ");
			System.Console.WriteLine(p.Inventory.ItemList);

			// Game loop.
			while (true)
			{
				usr_input = System.Console.ReadLine();
				System.Console.WriteLine(look.Execute(p, usr_input.Split()));
			}
		}
	}
}
