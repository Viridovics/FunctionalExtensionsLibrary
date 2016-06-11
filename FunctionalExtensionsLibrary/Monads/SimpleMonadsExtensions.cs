using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FunctionalExtensionsLibrary.Monads
{
	public static class SimpleMonadsExtensions
	{
		public static T IfNotNull<T,V>(this V value, Func<V,T> action)
																		where V:class
																		where T:class
		{
			if(value == null)
			{
				return null;
			}
			return action(value);
		}
	}
}
