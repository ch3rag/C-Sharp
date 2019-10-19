using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Collections.Specialized;
using System.Runtime.CompilerServices;

namespace WpfFinalCompilation.Models {
    [Obsolete]
    class InventoryManual : INotifyPropertyChanged, IDataErrorInfo {
        private int carId;
        private string color;
        private string make;
        private string petName;
        private bool isChanged;

        public int Id {
            get => carId;
            set {
                if (value == carId) return;
                carId = value;
                OnPropertyChanged();
            }
        }

        public string Color {
            get => color;
            set {
                if (value == color) return;
                color = value;
                OnPropertyChanged();
            }
        }


        public string Make {
            get => make;
            set {
                if (value == make) return;
                make = value;
                OnPropertyChanged();
            }
        }


        public string PetName {
            get => petName;
            set {
                if (value == petName) return;
                petName = value;
                OnPropertyChanged();
            }
        }

        public bool IsChanged {
            get => isChanged;
            set {
                if (isChanged == value) return;
                isChanged = value;
                OnPropertyChanged();
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string propertyName = "") {
            if (propertyName != nameof(IsChanged)) IsChanged = true;
            // PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

            // CHECK EVERY PROPERTY
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(string.Empty));
        }

        private string error;
        public string this[string columnName] {
            get {
                switch (columnName) {
                    case nameof(Id):
                        break;
                    case nameof(Make):
                        if (Make == "ModelT") return "Too Old";
                        else goto case nameof(Color);
                    case nameof(Color):
                        if (Make == "Chevy" && Color == "Pink") return $"{Make}'s dont come in {Color}";
                        break;
                    case nameof(PetName):
                        break;
                }
                return string.Empty;
            }
        }
        public string Error => error;
    }
}
