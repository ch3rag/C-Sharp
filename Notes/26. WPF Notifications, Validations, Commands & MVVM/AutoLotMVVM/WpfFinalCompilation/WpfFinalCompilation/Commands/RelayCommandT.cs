using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfFinalCompilation.Commands {
    public class RelayCommand<T> : CommandBase {
        private readonly Action<T> execute;
        private readonly Func<T, bool> canExecute;
        public RelayCommand(Action<T> execute) : this(execute, null) { }
        public RelayCommand(Action<T> execute, Func<T, bool> canExecute) {
            this.execute = execute ?? throw new ArgumentException(nameof(execute));
            this.canExecute = canExecute;
        }

        public override bool CanExecute(object parameter) => canExecute == null || canExecute((T)parameter);
        public override void Execute(object parameter) { execute((T)parameter); }
    }
}

