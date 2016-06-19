namespace FunctionalExtensionsLibrary.Structures
{
	public static class Pair
	{
		public static Pair<T, V> Create<T, V>(T key1, V key2)
		{
			return new Pair<T, V>(key1, key2);
		}
	}

	public class Pair<T, V>
	{
		private T _key1;
		private V _key2;
		internal Pair(T key1, V key2)
		{
			_key1 = key1;
			_key2 = key2;
		}

		public T K1
		{
			get
			{
				return _key1;
			}
		}

		public V K2
		{
			get
			{
				return _key2;
			}
		}
	}
}
