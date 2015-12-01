using System;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Input;
using Yahtzee.Gui.Annotations;

namespace Yahtzee.Gui
{
	public class YahtzeeViewModel : INotifyPropertyChanged
	{
		private readonly ICommand _getScoreCommand;
		private readonly ICommand _getRandomRollCommand;
		private readonly YahtzeeScorer _yahtzeeScorer;
		private readonly Random _random;
		private string _roll;

		public YahtzeeViewModel()
		{
			_getScoreCommand = new DelegateCommand(o => GetScore());
			_getRandomRollCommand = new DelegateCommand(o => GetRandomRoll());
			_yahtzeeScorer = new YahtzeeScorer(new CalculatorFactory());
			_random = new Random(DateTime.Now.Millisecond);
		}

		private void GetScore()
		{
			if (NormaliseAndValidateRoll())
			{
				var score = _yahtzeeScorer.MaxWithoutChance(Roll);
				MessageBox.Show(string.Format("The score is {0} (category {1})", score.Result, ConvertToText(score.Category)));
			}
		}

		private bool NormaliseAndValidateRoll()
		{
			var roll = Roll ?? string.Empty;
			var value = string.Concat(roll.Where(c => "123456".Contains(c)));
			if (value.Length != 5)
			{
				MessageBox.Show("The roll should contain 5 dice", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
				return false;
			}
			Roll = value.Select(c => c.ToString()).Aggregate((s1, s2) => s1 + "," + s2);
			return true;
		}

		private void GetRandomRoll()
		{
			Roll = Enumerable.Range(0, 5)
				.Select(i => (_random.Next(6) + 1).ToString())
				.Aggregate((s1, s2) => string.Format("{0},{1}", s1, s2));
		}

		private string ConvertToText(Category category)
		{
			var value = category.ToString();
			var replacements = value
				.Where(char.IsUpper)
				.Select(c => new { From = c.ToString(), To = string.Format(" {0}", char.ToLower(c)) })
				.ToList();

			replacements.ForEach(r => value = value.Replace(r.From, r.To));

			return value.Trim();
		}

		public ICommand GetScoreCommand
		{
			get { return _getScoreCommand; }
		}

		public ICommand GetRandomRollCommand
		{
			get { return _getRandomRollCommand; }
		}

		public string Roll
		{
			get { return _roll; }
			set
			{
				if (value == _roll) return;
				_roll = value;
				OnPropertyChanged();
			}
		}

		public event PropertyChangedEventHandler PropertyChanged;

		[NotifyPropertyChangedInvocator]
		protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
		{
			var handler = PropertyChanged;
			if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
		}
	}
}
