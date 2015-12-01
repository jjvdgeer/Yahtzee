using System.Collections.Generic;
using System.Linq;

namespace Yahtzee.CategoryCalculators
{
	public class PairCalculcator : CategoryCalculator
	{
		private readonly int _count;
		private readonly Category _category;

		public PairCalculcator(Category category, int count)
		{
			_count = count;
			_category = category;
		}

		public override Category Category
		{
			get { return _category; }
		}

		public override int GetScore(IEnumerable<int> roll)
		{
			return 
				Candidates(roll)
				.Select(g => _count * g.Dice)
				.FirstOrDefault();
		}

		private IEnumerable<Group> Candidates(IEnumerable<int> roll)
		{
			return roll
				.GroupBy(i => i)
				.Select(g => new Group(g.Count(), g.Key))
				.Where(g => g.Count >= _count)
				.OrderByDescending(g => g.Dice);
		}

		private class Group
		{
			public Group(int count, int dice)
			{
				Count = count;
				Dice = dice;
			}

			public int Dice { get; private set; }
			public int Count { get; private set; }
		}
	}
}
