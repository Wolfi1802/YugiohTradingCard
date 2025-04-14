using System.Windows.Input;

namespace YugiohTradingCars.MVVM
{
    public class RelayCommand : ICommand
    {
        private Action<object> localAction;
        public event EventHandler CanExecuteChanged;

        public RelayCommand(Action<object> action)
        {
            this.localAction = action;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            this.localAction(parameter);
        }

    }
}
