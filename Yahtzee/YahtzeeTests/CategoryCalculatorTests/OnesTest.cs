using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Yahtzee.CategoryCalculators;

namespace YahtzeeTests.CategoryCalculatorTests
{
	[TestClass]
	public class OnesTest
	{
		[TestMethod]
		public void ZeroOnesShouldReturnZero()
		{
			new OnesCalculator().GetScore(new[] {2, 3, 4, 5}).Should().Be(0);
		}

		[TestMethod]
		public void AllOnesShouldBeSummed()
		{
			new OnesCalculator().GetScore(new[] { 1, 1, 1, 1, 1 }).Should().Be(5);
		}
	}
}
