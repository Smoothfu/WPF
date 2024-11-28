using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace STEM.Tech.Wpf.Framework.Utils
{
    public class DelCommand : ICommand
    {
        private Action<object> execute;
        private Predicate<object> canExecute;

        public DelCommand(Action<object> executeValue, Predicate<object> canExecuteValue = null)
        {
            execute = executeValue;
            canExecute = canExecuteValue;
        }

        public event EventHandler CanExecuteChanged
        {
            add
            {
                CommandManager.RequerySuggested += value;
            }
            remove
            {
                CommandManager.RequerySuggested -= value;
            }
        }

        public bool CanExecute(object parameter)
        {
            if (canExecute == null)
            {
                return true;
            }
            return canExecute(parameter);
        }

        public void Execute(object parameter)
        {
            execute(parameter);
        }
    }
}
