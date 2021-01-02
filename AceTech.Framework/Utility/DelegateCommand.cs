using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
namespace AceTech.Framework.Utility
{
    public class DelegateCommand : ICommand
    {
        private readonly Predicate<object> canExecute;
        private readonly Action<object> execute;
        public event EventHandler CanExecuteChanged;

        public DelegateCommand(Action<object> executeValue) :this(executeValue,null)
        { 
        }

        public DelegateCommand(Action<object> executeValue,Predicate<object> canExecuteValue)
        {
            execute = executeValue;
            canExecute = canExecuteValue;
        }

        public bool CanExecute(object parameter)
        {
            if(canExecute==null)
            {
                return true;
            }
            return canExecute(parameter);
        }

        public void Execute(object parameter)
        {
            execute(parameter);
        }

        public void RaiseCanExecuteChanged()
        {
            CanExecuteChanged?.Invoke(this, EventArgs.Empty);
        }
    }
}
