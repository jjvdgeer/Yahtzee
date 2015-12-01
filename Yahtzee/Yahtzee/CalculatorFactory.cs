using System.Collections.Generic;
using Yahtzee.CategoryCalculators;

namespace Yahtzee
{
	public class CalculatorFactory : ICalculatorFactory
	{
		public IEnumerable<ICategoryCalculator> GetCalculators()
		{
			yield return new SingleNumberCalculator(Category.Ones, 1);
			yield return new SingleNumberCalculator(Category.Twos, 2);
			yield return new SingleNumberCalculator(Category.Threes, 3);
			yield return new SingleNumberCalculator(Category.Fours, 4);
			yield return new SingleNumberCalculator(Category.Fives, 5);
			yield return new SingleNumberCalculator(Category.Sixes, 6);
			yield return new PairCalculcator(Category.Pair, 2);
			yield return new PairCalculcator(Category.ThreeOfAKind, 3);
			yield return new PairCalculcator(Category.FourOfAKind, 4);
			yield return new TwoPairsCalculator(Category.TwoPairs, 2, 2);
		}
	}
}