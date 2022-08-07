using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace AttWithView.MVVMs.ViewModels
{
    public class DefaultCommand : ICommand
    {
        public event EventHandler? CanExecuteChanged;
        private readonly Action _action;
        public DefaultCommand(Action action)
        {
            _action = action;
        }
        public bool CanExecute(object? parameter)
        {
            return true;
        }
        protected void OnCanExecuteChanged()
        {
            CanExecuteChanged?.Invoke(this, EventArgs.Empty);
        }
        public void Execute(object? parameter)
        {
            _action();
        }
    }
}
