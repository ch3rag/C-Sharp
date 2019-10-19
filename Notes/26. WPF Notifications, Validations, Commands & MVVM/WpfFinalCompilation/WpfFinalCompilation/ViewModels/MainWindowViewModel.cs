using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using System.Windows.Input;
using WpfFinalCompilation.Models;
using WpfFinalCompilation.Commands;

namespace WpfFinalCompilation.ViewModels {
    public class MainWindowViewModel {
        public IList<Inventory> Cars { get; } = new ObservableCollection<Inventory>();

        private ICommand changeColorCommand = null;
        private ICommand addCarCommand = null;
        public ICommand ChangeColorCommand => changeColorCommand ?? (changeColorCommand = new ChangeColorCommand());
        public ICommand AddCarCommand => addCarCommand ?? (addCarCommand = new AddCarCommand());
        private RelayCommand<Inventory> deleteCarCommand = null;
        public RelayCommand<Inventory> DeleteCarCommand => deleteCarCommand ?? (deleteCarCommand = new RelayCommand<Inventory>(x => Cars.Remove(x), x => x != null));

        public MainWindowViewModel() {
            Cars.Add(new Inventory() { Id = 1, Color = "Blue", Make = "Chevy", PetName = "Kit", IsChanged = false });
            Cars.Add(new Inventory() { Id = 2, Color = "Red", Make = "Ford", PetName = "Red Rider", IsChanged = false });
        }
    }
}
