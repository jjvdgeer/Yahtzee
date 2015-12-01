using System.Collections.Generic;

namespace Yahtzee.CategoryCalculators
{
	public class YahtzeeCalculator : GroupCalculcator
	{
		public YahtzeeCalculator()
			: base(Category.Yahtzee, 5)
		{
		}

		public override int GetScore(IEnumerable<int> roll)
		{
			return base.GetScore(roll) == 0 ? 0 : 50;
		}
	}
}
