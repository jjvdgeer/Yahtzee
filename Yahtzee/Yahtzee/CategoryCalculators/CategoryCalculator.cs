using System.Collections.Generic;

namespace Yahtzee.CategoryCalculators
{
	public abstract class CategoryCalculator : ICategoryCalculator
	{
		protected CategoryCalculator(Category category)
		{
			Category = category;
		}

		public Category Category { get; private set; }
		public abstract int GetScore(IEnumerable<int> roll);
	}
}