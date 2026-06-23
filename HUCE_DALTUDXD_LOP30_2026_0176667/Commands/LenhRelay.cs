using System;
using System.Windows.Input;

namespace HUCE_DALTUDXD_LOP30_2026_0176667.Commands
{
    class LenhRelay : ICommand
    {
        private readonly Action<object> _thucThi;
        private readonly Predicate<object> _coTheThucThi;

        public LenhRelay(Action<object> thucThi, Predicate<object> coTheThucThi = null)
        {
            _thucThi = thucThi ?? throw new ArgumentNullException(nameof(thucThi));
            _coTheThucThi = coTheThucThi;
        }

        public bool CanExecute(object parameter) => _coTheThucThi == null || _coTheThucThi(parameter);

        public void Execute(object parameter) => _thucThi(parameter);

        public event EventHandler CanExecuteChanged
        {
            add => CommandManager.RequerySuggested += value;
            remove => CommandManager.RequerySuggested -= value;
        }

        public void RaiseCanExecuteChanged() => CommandManager.InvalidateRequerySuggested();
    }
}

