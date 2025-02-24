using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace FrVojta.ChordPads.Wpf.Vm
{
    public class VmCommand<T> : VmData, ICommand where T: class
    {
        public event EventHandler? CanExecuteChanged;

        protected virtual void OnCanExecuteChanged()
        {
            CanExecuteChanged?.Invoke(this, EventArgs.Empty);
        }

        private Func<T, bool> CanExecuteMethod { get; }

        private Action<T> ExecuteMethod { get; }

        public VmCommand(Func<T, bool> canExecuteMethod, Action<T> executeMethod)
        {
            CanExecuteMethod = canExecuteMethod;
            ExecuteMethod = executeMethod;
        }

        public virtual bool CanExecute(object? parameter)
        {
            var tParam = parameter as T;
            if (tParam == null) throw new ArgumentException(
                "Wrong command parameter or null.");

            return CanExecuteMethod?.Invoke(tParam) ?? true;
        }

        public virtual void Execute(object? parameter)
        {
            var tParam = parameter as T;
            if (tParam == null) throw new ArgumentException(
                "Wrong command parameter or null.");

            ExecuteMethod?.Invoke(tParam);
        }
    }
}
