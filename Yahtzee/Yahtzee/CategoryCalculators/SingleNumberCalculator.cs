using System.Collections.Generic;
using System.Linq;

namespace Yahtzee.CategoryCalculators
{
	public class SingleNumberCalculator : CategoryCalculator
	{
		private readonly int _dice;

		public SingleNumberCalculator(Category category, int dice)
			: base(category)
		{
			_dice = dice;
		}

		public override int GetScore(IEnumerable<int> roll)
		{
			return AddSumOfDice(roll, _dice);
		}

		private static int AddSumOfDice(IEnumerable<int> roll, int dice)
		{
			return roll.Where(i => i == dice).Sum();
		}
	}
}