using System;
using System.Windows.Input;

namespace TaskListApp.Commands
{
    public class ActionCommand : ICommand
    {
        private Action action;
        public ActionCommand(Action action)
        {
            this.action = action;
        }

        #region ICommand

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            action();
        }

        #endregion
    }
}
