using NUnit.Framework;
using System.Collections.Generic;

namespace _2._3P_NUnit
{
	[TestFixture]
	public class Test_Location
	{
		private Identifiable_Object test_id;
		private Item test_item;
		private Item test_item_gem;
		private Inventory test_inventory;
		private Player test_player;
		private LookCommand test_look;
		private Bag test_bag;
		private Location test_location;
		private Item test_rock;


		[SetUp]
		public void Setup()
		{
			test_id = new Identifiable_Object(new List<string> { "fred", "bob" });
			test_item = new Item(new List<string> { "test", "sword", "steel" }, "A steel sword.", "A basic steel shortsword.");
			test_item_gem = new Item(new List<string> { "test", "gem", "shiny" }, "A small gem.", "This gem is part of a testing script.");
			test_inventory = new Inventory();
			test_player = new Player("test", "This is just a test player.");
			test_look = new LookCommand(new List<string> { });
			test_bag = new Bag("bagtest", "This is a bag test.");
			test_location = new Location(new List<string> { "testcave", "place" }, "Location", "This is the short description of the location.");
			test_player.Location = test_location;
			test_rock = new Item(new List<string> { "rock" }, "rock", "This is a test rock.");
			test_location.Inventory.Put(test_rock);
		}

		// Test "look"
		[Test]
		public void Test_LookAtLocation()
		{
			string tmp = test_look.Execute(test_player, "look".Split(" "));
			if (tmp.Equals("Location (testcave)"))
			{
				Assert.Pass(tmp);
			}
			else
			{
				Assert.Fail(tmp);
			}
		}

		// Test look in location.
		[Test]
		public void Test_LookInLocation()
		{
			string tmp = test_look.Execute(test_player, "look at rock in testcave".Split(" "));
			if (tmp.Equals("rock (rock)"))
			{
				Assert.Pass(tmp);
			}
			else
			{
				Assert.Fail(tmp);
			}
		}

		// Test players locating items in their location.
		[Test]
		public void Test_PlayerLocateInLocation()
		{
			string tmp = test_player.Locate("rock").ShortDescription;
			if (tmp.Equals("rock (rock)"))
			{
				Assert.Pass(tmp);
			}
			else
			{
				Assert.Fail(tmp);
			}
		}

		// Setup
		public Test_Location()
		{
			Setup();
		}
	}
}
