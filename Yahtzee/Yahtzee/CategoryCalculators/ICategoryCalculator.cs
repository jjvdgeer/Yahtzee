using System.Collections.Generic;

namespace Yahtzee.CategoryCalculators
{
	public interface ICategoryCalculator
	{
		Category Category { get; }
		int GetScore(IEnumerable<int> roll);
	}
}