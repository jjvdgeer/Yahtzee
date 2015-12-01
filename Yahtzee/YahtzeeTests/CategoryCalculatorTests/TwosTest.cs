using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Yahtzee;
using Yahtzee.CategoryCalculators;

namespace YahtzeeTests.CategoryCalculatorTests
{
	[TestClass]
	public class TwosTest
	{
		[TestMethod]
		public void ZeroTwosShouldReturnZero()
		{
			new TwosCalculator().GetScore(new[] {1, 3, 4, 5}).Should().Be(0);
		}

		[TestMethod]
		public void AllOnesShouldBeSummed()
		{
			new TwosCalculator().GetScore(new[] { 2, 2, 2, 2, 2 }).Should().Be(10);
		}

		[TestMethod]
		public void OnesCategoryShouldReturnOnes()
		{
			new TwosCalculator().Category.Should().Be(Category.Twos);
		}
	}
}
