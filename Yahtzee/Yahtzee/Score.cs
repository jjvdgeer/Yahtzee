namespace Yahtzee
{
	public class Score
	{
		public Score(int result, Category category)
		{
			Result = result;
			Category = category;
		}

		public int Result { get; private set; }
		public Category Category { get; private set; }
	}
}