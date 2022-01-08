using NUnit.Framework;
using System.Collections.Generic;

namespace _2._3P_NUnit
{
	[TestFixture]
	public class Test_LookCommand
	{
		private Identifiable_Object test_id;
		private Item test_item;
		private Item test_item_gem;
		private Inventory test_inventory;
		private Player test_player;
		private LookCommand test_look;
		private Bag test_bag;


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
		}

		// test look at me
		[Test]
		public void Test_LookAtMe()
		{
			string tmp = test_look.Execute(test_player, "look at inventory".Split(" "));
			if ( tmp.Equals("test (me)"))
			{
				Assert.Pass(tmp);
			}
			else
			{
				Assert.Fail(tmp);
			}
		}

		// test look at gem
		[Test]
		public void Test_LookAtGem()
		{
			test_player.Inventory.Put(test_item_gem);
			//test_look
			string tmp = test_look.Execute(test_player, "look at gem".Split(" "));
			if (tmp.Equals("A small gem. (test)"))
			{
				Assert.Pass(tmp);
			}
			else
			{
				Assert.Fail(tmp);
			}
		}

		// test look at not there
		[Test]
		public void Test_LookAtNotThere()
		{
			string tmp = test_look.Execute(test_player, "look at gem".Split(" "));
			if (tmp.Equals("Could not find anything."))
			{
				Assert.Pass(tmp);
			}
			else
			{
				Assert.Fail(tmp);
			}
		}

		// test look at gem in me
		[Test]
		public void Test_LookAtGemInMe()
		{
			test_player.Inventory.Put(test_item_gem);
			string tmp = test_look.Execute(test_player, "look at gem in inventory".Split(" "));
			if (tmp.Equals("A small gem. (test)"))
			{
				Assert.Pass(tmp);
			}
			else
			{
				Assert.Fail(tmp);
			}
		}

		// test look at gem in bag
		[Test]
		public void Test_LookAtGemInBag()
		{
			test_bag.Inventory.Put(test_item_gem);
			test_player.Inventory.Put(test_bag);
			string tmp = test_look.Execute(test_player, "look at gem in bag".Split(" "));
			if (tmp.Equals("A small gem. (test)"))
			{
				Assert.Pass(tmp);
			}
			else
			{
				Assert.Fail(tmp);
			}
		}

		// test look at gem in no bag
		[Test]
		public void Test_LookAtGemInNoBag()
		{
			string tmp = test_look.Execute(test_player, "look at gem in bag".Split(" "));
			if (tmp.Equals("I can't find the bag."))
			{
				Assert.Pass(tmp);
			}
			else
			{
				Assert.Fail(tmp);
			}
		}

		// test look at no gem in bag
		[Test]
		public void Test_LookAtNoGemInBag()
		{
			test_player.Inventory.Put(test_bag);
			string tmp = test_look.Execute(test_player, "look at gem in bag".Split(" "));
			if (tmp.Equals("Could not find anything."))
			{
				Assert.Pass(tmp);
			}
			else
			{
				Assert.Fail(tmp);
			}
		}

		// test invalid look
		[Test]
		public void Test_InvalidLook1()
		{
			string tmp = test_look.Execute(test_player, "look around".Split(" "));
			if (tmp.Equals("I don't know how to look like that."))
			{
				Assert.Pass(tmp);
			}
			else
			{
				Assert.Fail(tmp);
			}
		}

		// test invalid look
		[Test]
		public void Test_InvalidLook2()
		{
			string tmp = test_look.Execute(test_player, "hello".Split(" "));
			if (tmp.Equals("Error in look input."))
			{
				Assert.Pass(tmp);
			}
			else
			{
				Assert.Fail(tmp);
			}
		}

		// test invalid look
		[Test]
		public void Test_InvalidLook3()
		{
			string tmp = test_look.Execute(test_player, "look at a at b".Split(" "));
			if (tmp.Equals("I can't find the b."))
			{
				Assert.Pass(tmp);
			}
			else
			{
				Assert.Fail(tmp);
			}
		}


		// Setup
		public Test_LookCommand()
		{
			Setup();
		}
	}
}
