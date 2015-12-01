using System.Collections.Generic;
using Yahtzee.CategoryCalculators;

namespace Yahtzee
{
	public interface ICalculatorFactory
	{
		IEnumerable<ICategoryCalculator> GetCalculators();
	}
}