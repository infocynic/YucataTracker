using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace YucataTracker.Domain
{
	public static class Extensions
	{
		public static IEnumerable<U> Rank<T, TKey, U>
		(
		  this IEnumerable<T> source,
		  Func<T, TKey> keySelector,
		  Func<T, TKey> secondarySelector,
		  Func<T, TKey> tertiarySelector,
		  Func<T, int, U> selector
		)
		{
			if (!source.Any())
			{
				yield break;
			}

			int itemCount = 0;
			T[] ordered = source.OrderBy(keySelector).ThenBy(secondarySelector).ThenBy(tertiarySelector).ToArray();
			TKey previous = keySelector(ordered[0]);
			int rank = 1;
			foreach (T t in ordered)
			{
				itemCount += 1;
				TKey current = keySelector(t);
				if (!current.Equals(previous))
				{
					rank = itemCount;
				}
				yield return selector(t, rank);
				previous = current;
			}
		}
	}
}
