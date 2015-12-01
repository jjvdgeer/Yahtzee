using System;
using System.Collections.Generic;
using System.Linq;
using FluentAssertions;
using TechTalk.SpecFlow;

namespace Yahtzee.Tests.CategoryCalculatorTests.Steps
{
	[Binding]
	public sealed class CalculatorSteps
	{
		private IEnumerable<int> _roll;
		private Category _type;
		private int _result;
		private Category _category;

		[Given(@"I have the roll '(.*)'")]
		public void GivenIHaveTheRoll(string roll)
		{
			_roll = roll.Split(',').Select(s => s.ToInt()).Where(i => i.HasValue).Cast<int>();
		}

		[Given(@"I use the calculator for '(.*)'")]
		public void GivenIUseTheCalculatorFor(string type)
		{
			_type = (Category)Enum.Parse(typeof(Category), type);
		}

		[When(@"I calculate the score")]
		public void WhenICalculateTheScore()
		{
			_result = new CalculatorFactory().GetCalculators().Single(f => f.Category == _type).GetScore(_roll);
		}

		[When(@"I calculate the maximum score")]
		public void WhenICalculateTheMaximumScore()
		{
			var score = new YahtzeeScorer(new CalculatorFactory()).Max(_roll);
			_result = score.Result;
			_category = score.Category;
		}

		[When(@"I calculate the maximum score without chance")]
		public void WhenICalculateTheMaximumScoreWithoutChance()
		{
			var score = new YahtzeeScorer(new CalculatorFactory()).MaxWithoutChance(_roll);
			_result = score.Result;
			_category = score.Category;
		}

		[Then(@"the result should be (.*)")]
		public void ThenTheResultShouldBe(int expected)
		{
			_result.Should().Be(expected);
		}

		[Then(@"the category should be one of (.*)")]
		public void ThenTheCategoryShouldBe(IEnumerable<Category> categories)
		{
			categories.Where(c => c == _category).Should().NotBeEmpty();
		}

		[StepArgumentTransformation(@"(.*)")]
		public IEnumerable<Category> CategoriesTransform(string types)
		{
			return types
				.Split(',')
				.Select(s => s.Trim())
				.Select(s => (Category)Enum.Parse(typeof(Category), s));
		}
	}
}
