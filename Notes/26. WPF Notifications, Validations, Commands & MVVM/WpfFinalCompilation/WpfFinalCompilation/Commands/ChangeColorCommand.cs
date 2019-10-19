using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfFinalCompilation.Models;
using System.Windows.Input;
namespace WpfFinalCompilation.Commands {
    class ChangeColorCommand : CommandBase {
    
        public override bool CanExecute(object parameter) {
            return (parameter as Inventory) != null;
        }

        public override void Execute(object parameter) {
            (parameter as Inventory).Color = "Pink";
        }
    }
}
