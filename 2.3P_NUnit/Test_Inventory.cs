using System;
using NUnit.Framework;
using System.Collections.Generic;

namespace _2._3P_NUnit
{
	[TestFixture]
	public class TestInventory
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

		// Inventory unit tests
		// Inventory receives item which can then be fetched.
		[Test]
		public void Test_FindItem()
		{
			test_inventory.Put(test_item);
			if( test_inventory.Fetch("test") != null )
			{
				Assert.Pass();
			}
			else
			{
				Assert.Fail();
			}
		}

		// Item that isn't there isn't found.
		[Test]
		public void Test_NoItemFind()
		{
			test_inventory.Put(test_item);
			if( test_inventory.Fetch("bananas") == null )
			{
				Assert.Pass();
			}
			else
			{
				Assert.Fail();
			}
		}

		// Item remains after Fetch.
		[Test]
		public void Test_FetchItem()
		{
			test_inventory.Put(test_item);
			test_inventory.Fetch("test");
			if( test_inventory.Fetch("test") != null )
			{
				Assert.Pass();
			}
			else
			{
				Assert.Fail();
			}
		}

		// Item doesn't remain after Take.
		[Test]
		public void Test_TakeItem()
		{
			test_inventory.Put(test_item);
			test_inventory.Take("test");
			if( test_inventory.Fetch("test") == null )
			{
				Assert.Pass();
			}
			else
			{
				Assert.Fail();
			}
		}

		// Item lists correctly.
		[Test]
		public void Test_ItemList()
		{
			test_inventory.Put(test_item);
			test_inventory.Put(test_item);
			test_inventory.Put(test_item);
			test_inventory.ItemList.Equals("\tA steel sword. (test)\n\tA steel sword. (test)\n\tA steel sword. (test)\n");
		}


		// Setup
		public TestInventory()
		{
			Setup();
		}
	}
}
