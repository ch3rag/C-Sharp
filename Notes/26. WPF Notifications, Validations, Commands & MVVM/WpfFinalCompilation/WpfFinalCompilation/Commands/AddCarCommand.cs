using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using WpfFinalCompilation.Models;

namespace WpfFinalCompilation.Commands {
    public  class AddCarCommand : CommandBase {
        public override bool CanExecute(object parameter) {
            return (parameter as ObservableCollection<Inventory>) != null;
        }
        public override void Execute(object parameter) {
            if(parameter is ObservableCollection<Inventory> cars) {
               int maxCount = cars?.Count == 0? 0 : cars?.Max(x => x.Id) ?? 0;
               cars?.Add(new Inventory { Id = ++maxCount, Color = "Yellow", Make = "VW", PetName = "Birdie", IsChanged = false });
            }
        }
    }
}
