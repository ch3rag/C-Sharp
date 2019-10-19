using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfFinalCompilation.Commands {
    public class RelayCommand : CommandBase {
        private readonly Action execute;
        private readonly Func<bool> canExecute;

        public RelayCommand() { }
        public RelayCommand(Action execute) : this(execute, null) { }
        public RelayCommand(Action execute, Func<bool> canExecute) {
            this.execute = execute ?? throw new ArgumentException(nameof(execute));
            this.canExecute = canExecute;
        }


        public override bool CanExecute(object parameter) => canExecute == null || canExecute();
        public override void Execute(object parameter) { execute(); }
    }
}
