using Microsoft.VisualStudio.TestTools.UnitTesting;
using FunctionalExtensionsLibrary.Monads;

namespace Tests.Monads
{
	/// <summary>
	/// Test IfNotNull extension or 'maybe' monad
	/// </summary>
	[TestClass]
	public class MaybeMonadTest
	{
		[TestMethod]
		public void InstanceIsNull()
		{
			Cow cow = null;
			var cowAnswer = cow.IfNotNull(c => c.WhatCowSay("How are you?"));
			Assert.IsNull(cowAnswer);
		}

		[TestMethod]
		public void InstanceIsNotNull()
		{
			var cow = new Cow();
			var yourQuestion = "How are you?";
			var cowAnswer = cow.IfNotNull(c => c.WhatCowSay(yourQuestion));
			Assert.AreEqual(cowAnswer, cow.WhatCowSay(yourQuestion));
		}
	}

	internal class Cow
	{
		public string WhatCowSay(string yourQuestion)
		{
			return string.Format("Your question: {0}. But cow say: MOOOOOO!", yourQuestion);
		}
	}
}
