using System.Collections.Generic;

namespace Yahtzee.CategoryCalculators
{
	public class SingleNumberCalculator : CategoryCalculator
	{
		private readonly Category _category;
		private readonly int _dice;

		public SingleNumberCalculator(Category category, int dice)
		{
			_category = category;
			_dice = dice;
		}

		public override Category Category
		{
			get { return _category; }
		}

		public override int GetScore(IEnumerable<int> roll)
		{
			return AddSumOfDice(roll, _dice);
		}
	}
}