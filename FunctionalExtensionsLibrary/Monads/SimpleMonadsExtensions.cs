using System;

namespace FunctionalExtensionsLibrary.Monads
{
	public static class SimpleMonadsExtensions
	{
		/// <summary>
		/// TODO
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <typeparam name="V"></typeparam>
		/// <param name="value"></param>
		/// <param name="action"></param>
		/// <returns></returns>
		public static T IfNotNull<T, V>(this V value, Func<V, T> action)
			where V : class
			where T : class
		{
			if (value == null)
			{
				return null;
			}
			return action(value);
		}
	}
}
