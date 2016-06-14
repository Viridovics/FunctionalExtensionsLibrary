using System;

namespace FunctionalExtensionsLibrary.Lambda
{
	public static class ComposeExtensions
	{
		public static Func<I, O> Compose<I, V, O>(this Func<I, V> f1, Func<V, O> f2)
		{
			return x => f2(f1(x));
		}
	}
}
