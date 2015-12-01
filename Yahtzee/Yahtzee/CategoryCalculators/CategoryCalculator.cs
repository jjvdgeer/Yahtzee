using System.Collections.Generic;
using System.Linq;

namespace Yahtzee.CategoryCalculators
{
	public abstract class CategoryCalculator : ICategoryCalculator
	{
		public abstract Category Category { get; }
		public abstract int GetScore(IEnumerable<int> roll);

		protected static int AddSumOfDice(IEnumerable<int> roll, int dice)
		{
			return roll.Where(i => i == dice).Sum();
		}
	}
}