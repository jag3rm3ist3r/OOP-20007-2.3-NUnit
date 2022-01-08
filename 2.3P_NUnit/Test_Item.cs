using System;
using NUnit.Framework;
using System.Collections.Generic;

namespace _2._3P_NUnit
{
	[TestFixture]
	public class TestItem
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

	
		// Item Unit Tests
		// Test if item can be found by identifier.
		[Test]
		public void Test_ItemAreYou()
		{
			if(test_item.AreYou("sword"))
			{
				Assert.Pass();
			}
			else
			{
				Assert.Fail();
			}
		}

		// Returns correct item short description.
		[Test]
		public void Test_ShortItemDesc()
		{
			if(		test_item.ShortDescription.Equals("A steel sword. (test)")
				&&	!test_item.ShortDescription.Equals("A banana (fruit)"))
			{
				Assert.Pass();
			}
			else
			{
				Assert.Fail();
			}
		}

		// Returns correct item description.
		[Test]
		public void Test_FullDescription()
		{
			if(		test_item.FullDescription.Equals("A basic steel shortsword.")
				&&	!test_item.FullDescription.Equals("A banana made of grapes."))
			{
				Assert.Pass();
			}
			else
			{
				Assert.Fail();
			}
		}


		// Setup
		public TestItem()
		{
			Setup();
		}
	}
}
