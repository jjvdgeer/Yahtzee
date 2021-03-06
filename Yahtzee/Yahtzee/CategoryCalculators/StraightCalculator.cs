﻿using System.Collections.Generic;
using System.Linq;

namespace Yahtzee.CategoryCalculators
{
	public class StraightCalculator : CategoryCalculator
	{
		private readonly int _start;
		private readonly int _end;

		public StraightCalculator(Category category, int start, int end)
			: base(category)
		{
			_start = start;
			_end = end;
		}

		public override int GetScore(IEnumerable<int> roll)
		{
			var list = roll.OrderBy(d => d).ToList();
			return IsStraight(list) ? list.Sum() : 0;

		}

		private bool IsStraight(IReadOnlyCollection<int> list)
		{
			return list.Count == 5 && list.Distinct().Count() == 5 && list.First() == _start && list.Last() == _end;
		}
	}
}
