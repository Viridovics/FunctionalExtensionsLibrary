using FunctionalExtensionsLibrary.Lambda;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Tests.Lambda
{
	[TestClass]
	public class ComposeTests
	{
		[TestMethod]
		public void ComposeTwoFunc()
		{
			Func<int, int> f1 = x => x * 2;
			var actual = f1.Compose(x => x.ToString())(5);
			Assert.AreEqual("10", actual);
		}
	}
}
