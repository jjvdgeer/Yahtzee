using System.Collections.Generic;

namespace Yahtzee.CategoryCalculators
{
	public abstract class CategoryCalculator : ICategoryCalculator
	{
		public abstract Category Category { get; }
		public abstract int GetScore(IEnumerable<int> roll);
	}
}