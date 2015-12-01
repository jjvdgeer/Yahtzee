using System.Collections.Generic;
using Yahtzee.CategoryCalculators;

namespace Yahtzee
{
	public class CalculatorFactory : ICalculatorFactory
	{
		public IEnumerable<ICategoryCalculator> GetCalculators()
		{
			yield return new OnesCalculator();
		}
	}
}