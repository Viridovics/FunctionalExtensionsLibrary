using FunctionalExtensionsLibrary.Sequences;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;

namespace Tests.Sequences
{
	[TestClass]
	public class SequencesTests
	{
		[TestMethod]
		public void IntegerSequenceTo()
		{
			var etalonSequence = Enumerable.Range(1, 10);
			var intSequence = 1.To(10);
			AssertSequences(etalonSequence, intSequence);
		}

		[TestMethod]
		public void IntegerSequenceBy()
		{
			var etalonSequence = new List<int> { 1, 5, 9 };
			var intSequence = 1.To(10).By(4);
			AssertSequences(etalonSequence, intSequence);
		}

		[TestMethod]
		public void IntegerSequenceFor()
		{
			var etalonSequence = new List<int> { 1, 5, 9 };
			var intSequence = 1.For(3).By(4);
			AssertSequences(etalonSequence, intSequence);
		}

		private void AssertSequences<T>(IEnumerable<T> expectedSequence, IEnumerable<T> actualSequences)
		{
			var etalonList = expectedSequence.ToList();
			var actualList = actualSequences.ToList();
			Assert.AreEqual(etalonList.Count, actualList.Count);
			for (int i = 0; i < etalonList.Count; i++)
			{
				Assert.AreEqual(etalonList[i], actualList[i]);
			}
		}
	}
}
