using System;
using NUnit.Framework;
using System.Collections.Generic;

namespace _2._3P_NUnit
{
	[TestFixture]
	public class Test_IdentifiableObject
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

		// Identifyable object tests
		// Test object is identifyable.
		[Test]
		public void Test_AreYou()
		{
			if (test_id.AreYou("fred"))
			{
				Assert.Pass();
			}
			else
			{
				Assert.Fail();
			}
		}

		// Test object does not identify as something else.
		[Test]
		public void Test_Not_AreYou()
		{
			if (test_id.AreYou("garbageinput"))
			{
				Assert.Fail();
			}
			else
			{
				Assert.Pass();
			}
		}

		// Test object does not care about capital letters.
		[Test]
		public void Test_CaseSensitive()
		{
			if (test_id.AreYou("fREd"))
			{
				Assert.Pass();
			}
			else
			{
				Assert.Fail();
			}
		}
		
		// Test object can fetch it's first ID.
		[Test]
		public void Test_FirstID()
		{
			if (test_id.FirstId == "fred")
			{
				Assert.Pass();
			}
			else
			{
				Assert.Fail();
			}
		}

		// Test object can accept new identifiers.
		[Test]
		public void Test_AddIdentifier()
		{
			test_id.AddIdentifier("wilma");
			if (test_id.AreYou("wilma"))
			{
				Assert.Pass();
			}
			else
			{
				Assert.Fail();
			}
		}


		// Setup
		public Test_IdentifiableObject()
		{
			Setup();
		}
	}
}
