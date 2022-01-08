using System.Collections.Generic;

namespace _2._3P_NUnit
{
	public class Identifiable_Object
	{
		private List<string> _identifiers;

		public bool AreYou(string id)
		{
			foreach (string ident in _identifiers)
			{
				if (ident.ToLower().Equals(id.ToLower()))
				{
					return true;
				}
			}
			return false;
		}

		public string FirstId
		{
			get { return _identifiers[0]; }
		}

		public void AddIdentifier(string id)
		{
			_identifiers.Add(id.ToLower());
		}

		public Identifiable_Object(List<string> idents) => _identifiers = idents;
	}

//	public class Main_Class
//	{
//		static void Main(string[] argv)
//		{
//			Identifiable_Object id = new Identifiable_Object(new List<string> { "id1", "id2" });
//		}
//	}
}
