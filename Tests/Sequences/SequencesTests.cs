using FunctionalExtensionsLibrary.Sequences;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

namespace Tests.Sequences
{
	[TestClass]
	public class SequencesTests
	{
		[TestMethod]
		public void IntegerSequence()
		{
			var etalonSequence = Enumerable.Range(1, 10).ToList();
			var intSequence = 1.To(10).ToList();
			Assert.AreEqual(etalonSequence.Count, intSequence.Count);
			for (int i = 0; i < etalonSequence.Count; i++)
			{
				Assert.AreEqual(etalonSequence[i], intSequence[i]);
			}
		}
	}
}
