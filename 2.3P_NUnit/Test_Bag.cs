using System;
using NUnit.Framework;
using System.Collections.Generic;

namespace _2._3P_NUnit
{
	[TestFixture]
	public class Test_Bag
	{
		private Identifiable_Object test_id;
		private Item test_item;
		private Inventory test_inventory;
		private Player test_player;
		private Bag test_bag;


		[SetUp]
		public void Setup()
		{
			test_id = new Identifiable_Object(new List<string> { "fred", "bob" });
			test_item = new Item(new List<string> { "test", "sword", "steel" }, "A steel sword.", "A basic steel shortsword.");
			test_inventory = new Inventory();
			test_player = new Player("test", "This is just a test.");
			test_bag = new Bag("bagtest", "This is a bag test.");
		}

		// Bag unit tests
		// Bag responds to AreYou based on it's identifiers.
		[Test]
		public void Test_BagIsIdentifiable()
		{
			if( test_bag.AreYou("bag") )
			{
				Assert.Pass();
			}
			else
			{
				Assert.Fail();
			}
		}

		// Bag locates items in inventory.
		[Test]
		public void Test_BagLocatesItems()
		{
			test_bag.Inventory.Put(test_item);
			if ( test_bag.Locate("sword") != null )
			{
				Assert.Pass();
			}
			else
			{
				Assert.Fail();
			}
		}

		// Bag locates itself.
		[Test]
		public void Test_BagLocatesItself()
		{
			if (test_bag.Locate("bag") != null)
			{
				Assert.Pass();
			}
			else
			{
				Assert.Fail();
			}
		}

		// Bag returns null when asked to locate something that doesn't exist.
		[Test]
		public void Test_BagLocatesNothing()
		{
			if (test_bag.Locate("nothing") == null)
			{
				Assert.Pass();
			}
			else
			{
				Assert.Fail();
			}
		}

		// Bag outputs full description.
		[Test]
		public void Test_BagFullDescription()
		{
			if (test_bag.FullDescription.Equals("This is a bag test."))
			{
				Assert.Pass();
			}
			else
			{
				Assert.Fail();
			}
		}

		// Yo dawg, I put a bag inside your bag so you could find things in
		//+your bag while it's inside your other bag.
		[Test]
		public void Test_BagInsideAnotherBag()
		{
			// Create a bag to be inside the other bag.
			Bag test_internalBag = new Bag(new List<string> { "test", "inside" }, "inside", "This is the bag inside the other bag.");
			// Put the internal bag inside the outer bag.
			test_bag.Inventory.Put(test_internalBag);
			// Create a test item to go inside the internal bag.
			Item test_internalItem = new Item(new List<string> { "test", "garbage" }, "garbage", "Description.");
			// Put the internal item into the 
			test_internalBag.Inventory.Put(test_internalItem);
			// Put the test item into the outer bag.
			test_bag.Inventory.Put(test_item);

			// Test that the outer bag can find the inner bag.
			if (test_bag.Locate("inside") == null)
			{
				Assert.Fail("Didn't locate the inner bag.");
			}
			// Test that the outer bag can find items inside it.
			if (test_bag.Locate("sword") == null)
			{
				Assert.Fail("Inner bag can't Locate inside itself.");
			}
			// Test that the outer bag can't see what's inside the nested bag.
			if (test_bag.Locate("garbage") != null)
			{
				Assert.Fail("Located something in a nested bag.");
			}

			// If we haven't failed by this point then pass.
			Assert.Pass();
		}


		// Setup
		public Test_Bag()
		{
			Setup();
		}
	}
}