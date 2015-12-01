using System.Collections.Generic;
using System.Linq;

namespace Yahtzee.CategoryCalculators
{
	public class ChanceCalculator : CategoryCalculator
	{
		public ChanceCalculator()
			: base(Category.Chance)
		{
		}

		public override int GetScore(IEnumerable<int> roll)
		{
			return roll.Sum();
		}
	}
}
