using System.Collections.Generic;

namespace FunctionalExtensionsLibrary.Sequences
{
	public abstract class CommonSequence<T> : IEnumerable<T>
										  where T : struct
	{
		internal T First { get; set; }
		internal T? Last { get; set; }
		internal T Step { get; set; }
		private T _count;
		internal T Count
		{
			get
			{
				return _count;
			}
			set
			{
				Last = null;
				_count = value;
			}
		}

		protected abstract IEnumerable<T> GetEnumerable();

		public IEnumerator<T> GetEnumerator()
		{
			var sequence = GetEnumerable();

			return sequence.GetEnumerator();
		}

		System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
		{
			return this.GetEnumerator();
		}

		public CommonSequence<T> To(T to)
		{
			this.Last = to;
			return this;
		}

		public CommonSequence<T> By(T step)
		{
			this.Step = step;
			return this;
		}

		public CommonSequence<T> For(T length)
		{
			this.Count = length;
			return this;
		}
	}
}
