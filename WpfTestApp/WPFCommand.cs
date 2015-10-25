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
        //Adapted from Source: http://www.wpftutorial.net/delegatecommand.html
        private readonly Predicate<object> _canExecute;
        private readonly Action<object> _execute;
        private readonly Action _executeNoArgs;

        public event EventHandler CanExecuteChanged;

        public WPFCommand(Action execute)
        {
            _executeNoArgs = execute;
            _canExecute = null;
        }

        public WPFCommand(Action execute, Predicate<object> canExecute)
        {
            _executeNoArgs = execute;
            _canExecute = canExecute;
        }

        public WPFCommand(Action<object> execute) : this(execute, null)
        {
        }

        public WPFCommand(Action<object> execute,
                       Predicate<object> canExecute)
        {
            _execute = execute;
            _canExecute = canExecute;
        }

        public bool CanExecute(object parameter)
        {
            if (_canExecute == null)
            {
                return true;
            }

            Console.WriteLine(_canExecute(parameter));

            return _canExecute(parameter);
        }

        public void Execute(object parameter)
        {
            if (_executeNoArgs != null) _executeNoArgs();
            else _execute(parameter);
        }

        public void RaiseCanExecuteChanged()
        {
            Console.WriteLine("Raisins");
            if (CanExecuteChanged != null)
            {
                CanExecuteChanged(this, EventArgs.Empty);
            }
        }
    }
}
