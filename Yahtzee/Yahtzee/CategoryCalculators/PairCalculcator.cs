using System.Collections.Generic;
using System.Linq;

namespace Yahtzee.CategoryCalculators
{
	public class PairCalculcator : CategoryCalculator
	{
		protected readonly int _count;
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
			return GetScore(roll, _count);
		}

		protected int GetScore(IEnumerable<int> roll, int count)
		{
			return
				GetCandidates(GetGroups(roll), count)
					.Select(g => count * g.Dice)
					.FirstOrDefault();
		}

		protected IEnumerable<Group> GetCandidates(IEnumerable<Group> groups, int count)
		{
			return groups
				.Where(g => g.Count >= count)
				.OrderByDescending(g => g.Dice);
		}

		protected static IEnumerable<Group> GetGroups(IEnumerable<int> roll)
		{
			return roll
				.GroupBy(i => i)
				.Select(g => new Group(g.Count(), g.Key));
		}

		protected class Group
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
