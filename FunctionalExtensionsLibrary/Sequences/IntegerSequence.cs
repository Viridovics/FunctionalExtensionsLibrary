using System;
using System.Collections.Generic;

namespace FunctionalExtensionsLibrary.Sequences
{
	public class IntegerSequence : CommonSequence<int>
	{
		internal IntegerSequence()
		{
			Count = int.MaxValue;
			Step = 1;
			First = 1;
		}

		protected override IEnumerable<int> GetEnumerable()
		{
			var sequence = this;
			int first = sequence.First;
			int step = sequence.Step;
			int last = sequence.Last ?? 1;
			if (sequence.Last == null)
			{
				for (int i = 0; i < sequence.Count; i++)
				{
					yield return first;
					first += step;
				}
			}
			else if (step > 0)
			{
				while (first <= last)
				{
					yield return first;
					first += step;
				}
			}
			else if (step < 0)
			{
				while (last <= first)
				{
					yield return first;
					first += step;
				}
			}
			else
			{
				throw new ApplicationException("Step in sequence must be not equal zero");
			}
		}
	}
}
