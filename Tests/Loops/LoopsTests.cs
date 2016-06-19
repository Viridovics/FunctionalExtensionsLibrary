using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using FunctionalExtensionsLibrary.Loops;
using System.Linq;

namespace Tests.Loops
{
	[TestClass]
	public class LoopsTests
	{
		[TestMethod]
		public void ForEachTest()
		{
			var sequence = Enumerable.Range(1, 3);
			var result = 0;
			sequence.ForEach(i => result += i);
			Assert.AreEqual(sequence.Sum(), result);
		}

		[TestMethod]
		public void TimesTest1()
		{
			var result = 0;
			55.Times(() => result++);
			Assert.AreEqual(55, result);
		}

		[TestMethod]
		public void TimesTest2()
		{
			var result = 0;
			4.Times(i => result+=i);
			Assert.AreEqual(6, result);
		}
	}
}
