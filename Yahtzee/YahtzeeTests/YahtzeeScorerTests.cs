using System.Collections.Generic;
using FakeItEasy;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Yahtzee;
using Yahtzee.CategoryCalculators;

namespace YahtzeeTests
{
	[TestClass]
	public class YahtzeeScorerTests
	{
		[TestMethod]
		public void ParseTest()
		{
			var calculator = GetCalculator();
			GetYahtzeeScorer(calculator).Score("1,2,3,4,5", Category.Ones);

			A.CallTo(() => calculator.GetScore(A<IEnumerable<int>>.That.IsSameSequenceAs(new[] {1, 2, 3, 4, 5}))).MustHaveHappened();
		}

		private static ICategoryCalculator GetCalculator()
		{
			return A.Fake<ICategoryCalculator>();
		}

		private static YahtzeeScorer GetYahtzeeScorer(ICategoryCalculator calculator)
		{
			var factory = A.Fake<ICalculatorFactory>();
			A.CallTo(() => factory.GetCalculators()).Returns(new[] { calculator });
			return new YahtzeeScorer(factory);
		}
	}
}
