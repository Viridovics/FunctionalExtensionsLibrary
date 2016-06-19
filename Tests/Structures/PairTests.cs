using FunctionalExtensionsLibrary.Structures;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests.Structures
{
	[TestClass]
	public class PairTests
	{
		[TestMethod]
		public void PositivePairTest()
		{
			var pair = Pair.Create(10, 5.0);
			Assert.AreEqual(10, pair.K1);
			Assert.AreEqual(5.0, pair.K2);
		}
	}
}
