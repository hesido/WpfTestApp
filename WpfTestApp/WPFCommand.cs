using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Windows.Input;

namespace WpfTestApp
{
    public class WPFCommand : ICommand
    {
        private readonly Predicate<object> _canExecute;
        private readonly Action<object> _execute;
        private readonly Action _executeNoParam;
        private bool _useCommandManager;
        private event EventHandler _canExecuteChanged;


        public event EventHandler CanExecuteChanged {
            add {
                if(_useCommandManager) CommandManager.RequerySuggested += value;
                _canExecuteChanged = value;
            }
            remove {
                if (_useCommandManager) CommandManager.RequerySuggested -= value;
                _canExecuteChanged = null;
            }
        }


        public WPFCommand(Action execute, Predicate<object> canExecute = null, bool useCommandManager = true)
        {
            _executeNoParam = execute;
            _canExecute = canExecute;
            _useCommandManager = useCommandManager;
        }

        public WPFCommand(Action<object> execute, Predicate<object> canExecute = null, bool useCommandManager = true)
        {
            _execute = execute;
            _canExecute = canExecute;
            _useCommandManager = useCommandManager;
        }


        public bool CanExecute(object parameter)
        {
            return (_canExecute == null)? true : _canExecute(parameter);
        }

        public void Execute(object parameter)
        {
            if (_executeNoParam != null) _executeNoParam();
            else _execute(parameter);
        }

        public void RaiseCanExecuteChanged()
        {
            _canExecuteChanged?.Invoke(this, EventArgs.Empty);
        }
    }
}
