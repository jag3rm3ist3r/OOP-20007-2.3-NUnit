using System.Collections.Generic;

namespace _2._3P_NUnit
{
	abstract class Command : Identifiable_Object, IHaveDefaultIdents
	{
		public Command(List<string> idents) : base(IHaveDefaultIdents.ModifyIdents(idents, "command")) { }

		public abstract string Execute( Player p, string[] text );
	}
}
