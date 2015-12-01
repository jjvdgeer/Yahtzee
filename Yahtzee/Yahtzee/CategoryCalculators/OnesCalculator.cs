using System.Collections.Generic;
using System.Linq;

namespace Yahtzee.CategoryCalculators
{
	public class OnesCalculator : CategoryCalculator
	{
		public override Category Category
		{
			get { return Category.Ones; }
		}

		public override int GetScore(IEnumerable<int> roll)
		{
			return roll.Where(i => i == 1).Sum();
		}
	}
}