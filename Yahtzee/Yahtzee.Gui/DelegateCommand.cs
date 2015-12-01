using System;
using System.Windows.Input;

namespace Yahtzee.Gui
{
	public class DelegateCommand : ICommand
	{
		private readonly Action<object> _executeDelegate;

		public DelegateCommand(Action<object> executeDelegate)
		{
			_executeDelegate = executeDelegate;
		}

		public void Execute(object parameter)
		{
			_executeDelegate(parameter);
		}

		public bool CanExecute(object parameter) { return true; }
		public event EventHandler CanExecuteChanged;
	}
}