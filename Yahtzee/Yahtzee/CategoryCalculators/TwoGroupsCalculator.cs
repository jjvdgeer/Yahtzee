using System.Collections.Generic;
using System.Linq;

namespace Yahtzee.CategoryCalculators
{
	public class TwoGroupsCalculator : GroupCalculcator
	{
		private readonly int _secondCount;

		public TwoGroupsCalculator(Category category, int firstCount, int secondCount)
			: base(category, firstCount)
		{
			_secondCount = secondCount;
		}

		public override int GetScore(IEnumerable<int> roll)
		{
			var groups = GetGroups(roll).ToList();
			var firstGroup = GetCandidates(groups, _count).FirstOrDefault();
			if (firstGroup == null)
				return 0;

			var secondGroup = GetCandidatesExceptGroup(groups, firstGroup).FirstOrDefault();

			return secondGroup == null
				? 0
				: firstGroup.Dice * _count + secondGroup.Dice * _secondCount;
		}

		private IEnumerable<Group> GetCandidatesExceptGroup(IEnumerable<Group> groups, Group substractGroup)
		{
			return
				GetCandidates(groups.Select(g => SubStractGroup(g, substractGroup)), _secondCount);
		}

		private Group SubStractGroup(Group group, Group substractGroup)
		{
			return group.Dice == substractGroup.Dice
				? new Group(group.Count - _count, group.Dice)
				: group;
		}
	}
}
