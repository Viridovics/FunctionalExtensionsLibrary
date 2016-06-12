using System;
using System.Collections.Generic;

namespace FunctionalExtensionsLibrary.Sequences
{
	public static class SequenceExtensions
	{
		private static CommonSequence<T> ConstructSequence<T>(T first) where T : struct
		{
			CommonSequence<T> result = null;
			if (first is int)
				result = new IntegerSequence() as CommonSequence<T>;
			else if (first is double)
				result = new DoubleSequence() as CommonSequence<T>;
			if (result == null)
				throw new ApplicationException("Unsupported sequence type");
			result.First = first;
			return result;
		}

		public static CommonSequence<T> To<T>(this T from, T to) where T : struct
		{
			CommonSequence<T> sequence = ConstructSequence<T>(from);
			sequence.Last = to;
			return sequence;
		}

		public static CommonSequence<T> By<T>(this T from, T step) where T : struct
		{
			CommonSequence<T> sequence = ConstructSequence<T>(from);
			sequence.Step = step;
			return sequence;
		}

		public static CommonSequence<T> For<T>(this T from, T length) where T : struct
		{
			CommonSequence<T> sequence = ConstructSequence<T>(from);
			sequence.Count = length;
			return sequence;
		}

		public static IEnumerable<T> GenerateSequence<T>(this T initValue, Func<T, T> generator)
		{
			var currentValue = initValue;
			while (true)
			{
				yield return currentValue;
				currentValue = generator(currentValue);
			}
		}

		public static IEnumerable<T> GenerateSequence<T>(this T initValue, Func<T, T> generator, T breakValue) where T : IEquatable<T>
		{
			var currentValue = initValue;
			while (!currentValue.Equals(breakValue))
			{
				yield return currentValue;
				currentValue = generator(currentValue);
			}
		}

		public static IEnumerable<T> GenerateSequence<T>(this T initValue, Func<T, T> generator, Predicate<T> conditionForContinuation)
		{
			var currentValue = initValue;
			while (conditionForContinuation(currentValue))
			{
				yield return currentValue;
				currentValue = generator(currentValue);
			}
		}
	}
}
