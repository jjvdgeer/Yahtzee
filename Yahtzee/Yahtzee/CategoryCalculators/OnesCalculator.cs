using System.Collections.Generic;

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
			return AddSumOfDice(roll, 1);
		}
	}
}