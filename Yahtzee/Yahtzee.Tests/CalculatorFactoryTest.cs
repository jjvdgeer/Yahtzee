﻿using System;
using System.Linq;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Yahtzee.Tests
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
