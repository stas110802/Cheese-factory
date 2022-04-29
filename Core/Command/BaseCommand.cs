using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Cheese_factory.Core.Command
{
    public class BaseCommand : ICommand
    {
        private Action<object> _method;
        private Predicate<object> _canExecute;

        public BaseCommand(Action<object> method) 
            : this(method, null)
        {

        }

        public BaseCommand(Action<object> method, Predicate<object> canExecute)
        {
            _method = method;
            _canExecute = canExecute;
        }

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            if (_canExecute is null)
                return true;

            return _canExecute(parameter);
        }

        public void Execute(object parameter)
        {
            _method.Invoke(parameter);
        }
    }
}
