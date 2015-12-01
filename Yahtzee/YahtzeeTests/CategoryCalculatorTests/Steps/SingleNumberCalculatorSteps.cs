using System;
using System.Collections.Generic;
using System.Linq;
using FluentAssertions;
using TechTalk.SpecFlow;
using Yahtzee;

namespace YahtzeeTests.CategoryCalculatorTests.Steps
{
	[Binding]
	public sealed class SingleNumberCalculatorSteps
	{
		private IEnumerable<int> _roll;
		private Category _type;
		private int _result;

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

		[Then(@"the result should be (.*)")]
		public void ThenTheResultShouldBe(int expected)
		{
			_result.Should().Be(expected);
		}
	}
}
