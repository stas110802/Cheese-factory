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
        private readonly Action<object> _method;
        private readonly Predicate<object> _canExecute;

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
            return _canExecute is null ? true : _canExecute(parameter);
        }

        public void Execute(object parameter)
        {
            _method.Invoke(parameter);
        }
    }
}
