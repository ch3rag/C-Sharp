using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using PropertyChanged;
using System.Runtime.CompilerServices;
using WpfFinalCompilation.Models;
using System.ComponentModel.DataAnnotations;

namespace WpfFinalCompilation.Models {
    public partial class Inventory : EntityBase, INotifyPropertyChanged {

        [Required]
        public int Id { get; set; }
        [Required, StringLength(50)]
        public string Color { get; set; }
        [Required, StringLength(50)]
        public string Make { get; set; }
        [Required, StringLength(50)]
        public string PetName { get; set; }

        public bool IsChanged{ get; set; }
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = "") {
            if (propertyName != nameof(IsChanged)) IsChanged = true;
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(string.Empty));
        }
    }
}
