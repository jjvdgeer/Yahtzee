using System.Collections.Generic;

namespace Yahtzee.CategoryCalculators
{
	public class TwosCalculator : CategoryCalculator
	{
		public override Category Category
		{
			get { return Category.Twos; }
		}

		public override int GetScore(IEnumerable<int> roll)
		{
			return AddSumOfDice(roll, 2);
		}
	}
}
