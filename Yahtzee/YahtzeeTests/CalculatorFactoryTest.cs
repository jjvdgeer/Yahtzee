using System;
using System.Linq;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Yahtzee;

namespace YahtzeeTests
{
	[TestClass]
	public class CalculatorFactoryTest
	{
		[TestMethod]
		public void AllCategoriesShouldHaveACalculator()
		{
			var expected = Enum.GetValues(typeof(Category)).Cast<Category>();

			new CalculatorFactory().GetCalculators()
				.Select(c => c.Category)
				.Should()
				.BeEquivalentTo(expected);
		}
	}
}
