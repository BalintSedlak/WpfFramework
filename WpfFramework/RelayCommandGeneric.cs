using System;
using System.Windows.Input;

namespace WpfFramework
{
    public class RelayCommandGeneric<T, T1> : ICommand
    {
        private readonly Action<T> _execute;
        private readonly Predicate<T1> _canExecute;

        public RelayCommandGeneric(Action<T> execute, Predicate<T1> canExecute)
        {
            if (execute == null)
            {
                throw new ArgumentNullException(nameof(execute));
            }
            _execute = execute;
            _canExecute = canExecute;
        }

        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        public bool CanExecute(object parameter)
        {
            return _canExecute == null ? true : _canExecute((T1)parameter);
        }

        public void Execute(object parameter)
        {
            _execute((T)parameter);
        }
    }
}
