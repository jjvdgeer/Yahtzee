﻿using System.Collections.Generic;
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

		public Score Max(string roll)
		{
			return Max(ParseRoll(roll));
		}

		public Score Max(IEnumerable<int> roll, IEnumerable<Category> excludedCategories = null)
		{
			var excluded = (excludedCategories ?? new Category[0]).ToList();
			return _calculatorFactory
				.GetCalculators()
				.Select(calc => new Score(calc.GetScore(roll), calc.Category))
				.Where(calc => excluded.All(c => c != calc.Category))
				.OrderByDescending(s => s.Result)
				.First();
		}

		public Score MaxWithoutChance(string roll)
		{
			return MaxWithoutChance(ParseRoll(roll));
		}

		public Score MaxWithoutChance(IEnumerable<int> roll)
		{
			return Max(roll, new[] { Category.Chance });
		}
	}
}
