using System.Collections.Generic;
using System.Linq;

namespace Yahtzee
{
	public class YahtzeeScorer
	{
		private readonly ICalculatorFactory _calculatorFactory;

		public YahtzeeScorer(ICalculatorFactory calculatorFactory)
		{
			_calculatorFactory = calculatorFactory;
		}

		public int Score(string roll, Category category)
		{
			return Score(ParseRoll(roll), category);
		}

		private IEnumerable<int> ParseRoll(string roll)
		{
			return roll
				.Split(',')
				.Select(s => s.ToInt())
				.Where(i => i.HasValue)
				.Cast<int>();
		}

		private int Score(IEnumerable<int> roll, Category category)
		{
			return _calculatorFactory.GetCalculators().Single(c => c.Category == category).GetScore(roll);
		}
	}
}
