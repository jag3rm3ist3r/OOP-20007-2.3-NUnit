using System;
using NUnit.Framework;
using System.Collections.Generic;

namespace _2._3P_NUnit
{
	[TestFixture]
	public class Test_Player
	{
		private Identifiable_Object test_id;
		private Item test_item;
		private Inventory test_inventory;
		private Player test_player;


		[SetUp]
		public void Setup()
		{
			test_id = new Identifiable_Object(new List<string> { "fred", "bob" });
			test_item = new Item(new List<string> { "test", "sword", "steel" }, "A steel sword.", "A basic steel shortsword.");
			test_inventory = new Inventory();
			test_player = new Player("test", "This is just a test.");
		}

		// Player unit tests
		// Player responds to AreYou based on it's identifiers.
		[Test]
		public void Test_PlayerIsIdentifiable()
		{
			if( test_player.AreYou("me") )
			{
				Assert.Pass();
			}
			else
			{
				Assert.Fail();
			}
		}

		// Player locates items in inventory.
		[Test]
		public void Test_PlayerLocatesItems()
		{
			test_player.Inventory.Put(test_item);
			if ( test_player.Locate("sword") != null )
			{
				Assert.Pass();
			}
			else
			{
				Assert.Fail();
			}
		}

		// Player locates itself.
		[Test]
		public void Test_PlayerLocatesItself()
		{
			if (test_player.Locate("me") != null)
			{
				Assert.Pass();
			}
			else
			{
				Assert.Fail();
			}
		}

		// Player returns null when asked to locate something that doesn't exist.
		[Test]
		public void Test_PlayerLocatesNothing()
		{
			if (test_player.Locate("nothing") == null)
			{
				Assert.Pass();
			}
			else
			{
				Assert.Fail();
			}
		}

		// Player outputs full description.
		[Test]
		public void Test_PlayerFullDescription()
		{
			if (test_player.FullDescription.Equals("This is just a test."))
			{
				Assert.Pass();
			}
			else
			{
				Assert.Fail();
			}
		}


		// Setup
		public Test_Player()
		{
			Setup();
		}
	}
}
