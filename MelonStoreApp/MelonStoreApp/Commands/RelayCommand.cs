using System;
using System.Windows.Input;

namespace MelonStoreApp.Commands
{
    public delegate void ExecuteDelegate(object obj);

    public delegate bool CanExecuteDelegate(object obj);

    public class RelayCommand : ICommand
    {
        private CanExecuteDelegate canExecute;
        private ExecuteDelegate execute;

        public RelayCommand(ExecuteDelegate execute, CanExecuteDelegate canExecute = null)
        {
            this.execute = execute;
            this.canExecute = canExecute;
        }

        public bool CanExecute(object parameter)
        {
            if (this.canExecute == null)
            {
                return true;
            }
            return this.canExecute(parameter);
        }

        public event EventHandler CanExecuteChanged;

        public void Execute(object parameter)
        {
            this.execute(parameter);
        }
    }
}