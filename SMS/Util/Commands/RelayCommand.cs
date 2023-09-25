using System;
using System.Windows.Input;

namespace SMS.Util.Commands
{
    class RelayCommand : ICommand
    {
        private Action<object> _execute;
        private Func<object, bool> _canEcecute;

        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        public RelayCommand(Action<object> execute, Func<object, bool> canExecute = null)
        {
            _execute = execute;
            _canEcecute = canExecute;
        }

        public bool CanExecute(object parameter)
        {
            return _canEcecute == null || _canEcecute(parameter);
        }

        public void Execute(object parameter)
        {
            _execute(parameter);
        }

    }
}
