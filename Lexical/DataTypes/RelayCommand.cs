using System;
using System.Windows.Input;

namespace Lexical.DataTypes
{
    public class RelayCommand : ICommand
    {
        private Action _action;
        private bool _canExecute;

        public RelayCommand(Action action, bool canExecute)
        {
            this._action = action;
            this._canExecute = canExecute;
        }

        public RelayCommand(Action action)
        {
            this._action = action;
            this._canExecute = true;
        }

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return _canExecute;
        }

        public void Execute(object parameter)
        {
            this._action.Invoke();
        }
    }
}