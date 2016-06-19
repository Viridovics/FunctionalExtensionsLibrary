using System;
using System.Collections.Generic;

namespace FunctionalExtensionsLibrary.Loops
{
	public static class LoopsExtensions
	{
		public static void ForEach<T>(this IEnumerable<T> sequence, Action<T> action)
		{
			foreach (var item in sequence)
			{
				action(item);
			}
		}

		public static void Times(this int count, Action<int> action)
		{
			for(int i=0;i<count;i++)
			{
				action(i);
			}
		}

		public static void Times(this int count, Action action)
		{
			for (int i = 0; i < count; i++)
			{
				action();
			}
		}
	}
}
