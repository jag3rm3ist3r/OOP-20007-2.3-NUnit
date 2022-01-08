using System.Collections.Generic;


namespace _2._3P_NUnit
{
	public interface IHaveDefaultIdents
	{
		// This has to be static so that it can be referenced in the constructor.
		// This just modifies the idents so that addthis is always present.
		public static List<string> ModifyIdents(List<string> m, string addthis)
		{
			m.Add(addthis);
			return m;
		}
	}
}
