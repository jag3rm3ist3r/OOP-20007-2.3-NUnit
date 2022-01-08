using System.Collections.Generic;

namespace _2._3P_NUnit
{
	class GameObject : Identifiable_Object
	{
		// Private
		// Variables
		private string _description;
		private string _name;

		// Public
		// Varialbes
		public string Name { get { return _name; } }
		// Name and first ID of this GameObject.
		public string ShortDescription
		{
			get { return _name + " (" + FirstId + ")"; }
		}
		public virtual string FullDescription
		{
			get { return _description; }
		}

		// Functions
		// idents == list of identities
		// n == name
		// d == description
		public GameObject(List<string> idents, string n, string d) : base(idents)
		{
			_name = n;
			_description = d;
		}
	}
}
