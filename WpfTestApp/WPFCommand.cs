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
        //Source: http://www.wpftutorial.net/delegatecommand.html
        private readonly Predicate<object> _canExecute;
        private readonly Action<object> _execute;
        private readonly Action _executeNoParam;

        public event EventHandler CanExecuteChanged;

        //public WPFCommand(Action execute)
        //{

        //}

        public WPFCommand(Action execute, Predicate<object> canExecute = null)
        {
            _executeNoParam = execute;
            _canExecute = canExecute;
        }

        public WPFCommand(Action<object> execute, Predicate<object> canExecute = null)
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

            return _canExecute(parameter);
        }

        public void Execute(object parameter)
        {
            if (_executeNoParam != null) _executeNoParam();
            else _execute(parameter);
        }

        public void RaiseCanExecuteChanged()
        {
            if (CanExecuteChanged != null)
            {
                CanExecuteChanged(this, EventArgs.Empty);
            }
        }
    }
}
